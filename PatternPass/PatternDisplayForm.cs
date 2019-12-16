using KeePassLib;
using KeePassLib.Security;
using PatternPass.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PatternPass
{
	public sealed partial class PatternDisplayForm : Form
	{
		private readonly PwEntry _entry;
		private readonly Stopwatch _animationStopwatch;

		private readonly Color DrawColor = Color.DarkBlue;
		private const int DrawWidth = 10;
		private const int NodeRadius = 20;
		private const int DrawFrameRate = 60;
		private const float DrawSpeed = 0.5f; //Point units per millisecond
		private const int AnimationEndDelay = 1000;

		private float _widthUnit;
		private float _heightUnit;
		private readonly Brush _drawBrush;
		private readonly Pen _drawPen;

		private Pattern Pattern { get; set; }
		private Tuple<int, int>[] _patternSteps;
		private int _currentPatternStep;

		//Helps mitigate flickering in the animation - courtesy of https://stackoverflow.com/a/3304728/6003488
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000; //WS_EX_COMPOSITED

				return cp;
			}
		}

		internal PatternDisplayForm(PwEntry entry)
		{
			_entry = entry;
			InitializeComponent();
			if (!LoadPattern())
			{
				DialogResult = DialogResult.Abort;
				Load += delegate { Close(); };
				return;
			}

			DoubleBuffered = true;
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.UserPaint, true);

			Text = string.Format(Resources.PatternDisplayForm_Title, _entry.Strings.ReadSafe(PwDefs.TitleField));

			_drawBrush = new SolidBrush(DrawColor);
			_drawPen = new Pen(_drawBrush, DrawWidth)
			{
				EndCap = LineCap.Round,
				LineJoin = LineJoin.Round,
				DashCap = DashCap.Round
			};

			Timer animationTimer = new Timer
			{
				Interval = 1000 / DrawFrameRate
			};
			animationTimer.Tick += delegate
			{
				if (_currentPatternStep < _patternSteps.Length - 1)
				{
					PointF currentNode = NodeCoordsToDrawCoords(_patternSteps[_currentPatternStep].Item1, _patternSteps[_currentPatternStep].Item2);
					PointF nextNode = NodeCoordsToDrawCoords(_patternSteps[_currentPatternStep + 1].Item1, _patternSteps[_currentPatternStep + 1].Item2);
					float deltaX = nextNode.X - currentNode.X;
					float deltaY = nextNode.Y - currentNode.Y;
					float deltaDistance = (float)Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));

					if (DrawSpeed * _animationStopwatch.ElapsedMilliseconds >= deltaDistance)
					{
						_animationStopwatch.Restart();
						_currentPatternStep++;
					}
				}
				else if (_animationStopwatch.ElapsedMilliseconds >= AnimationEndDelay)
				{
					_animationStopwatch.Restart();
					_currentPatternStep = 0;
				}
				drawPanel.Invalidate(true);
				drawPanel.Update();
			};
			_animationStopwatch = new Stopwatch();
			animationTimer.Enabled = true;
			_animationStopwatch.Start();
		}

		private bool LoadPattern()
		{
			ProtectedString loadedPatternProtectedString = _entry.Strings.Get(Constants.PatternStringName);
			if (loadedPatternProtectedString == null)
				return false;
			string loadedPatternString = loadedPatternProtectedString.ReadString();
			if (loadedPatternString.Length <= 0)
				return false;
			Pattern = new Pattern(loadedPatternString);

			_widthUnit = (float) drawPanel.Width / (Pattern.Columns * 2);
			_heightUnit = (float) drawPanel.Height / (Pattern.Rows * 2);
			LoadPatternSteps();

			return true;
		}

		private void LoadPatternSteps()
		{
			List<Tuple<Tuple<int, int>, int?>> patternNodes = new List<Tuple<Tuple<int, int>, int?>>();

			for (int y = 0; y < Pattern.Rows; y++)
			for (int x = 0; x < Pattern.Columns; x++)
				patternNodes.Add(new Tuple<Tuple<int, int>, int?>(new Tuple<int, int>(x, y), Pattern.NodeOrder[y, x]));

			_patternSteps = patternNodes.Where(x => x.Item2.HasValue)
				.OrderBy(x => x.Item2)
				.Select(x => x.Item1)
				.ToArray();
		}

		private void OnDrawPanelPaint(object sender, PaintEventArgs e)
		{
			//Draw pattern lines
			List<PointF> nodePointFs = new List<PointF>();
			for (int i = 0; i <= _currentPatternStep; i++)
				nodePointFs.Add(NodeCoordsToDrawCoords(_patternSteps[i].Item1, _patternSteps[i].Item2));
			if (_currentPatternStep < _patternSteps.Length - 1)
			{
				PointF currentNode = NodeCoordsToDrawCoords(_patternSteps[_currentPatternStep].Item1, _patternSteps[_currentPatternStep].Item2);
				PointF nextNode = NodeCoordsToDrawCoords(_patternSteps[_currentPatternStep + 1].Item1, _patternSteps[_currentPatternStep + 1].Item2);
				float deltaX = nextNode.X - currentNode.X;
				float deltaY = nextNode.Y - currentNode.Y;
				float deltaDistance = (float) Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
				nodePointFs.Add(new PointF(currentNode.X + deltaX / deltaDistance * DrawSpeed * _animationStopwatch.ElapsedMilliseconds,
					currentNode.Y + deltaY / deltaDistance * DrawSpeed * _animationStopwatch.ElapsedMilliseconds));
			}
			e.Graphics.DrawLines(_drawPen, nodePointFs.ToArray());

			//Draw nodes on top
			for (int y = 0; y < Pattern.Rows; y++)
			{
				for (int x = 0; x < Pattern.Columns; x++)
				{
					PointF drawCoords = NodeCoordsToDrawCoords(x, y);
					e.Graphics.FillEllipse(_drawBrush, drawCoords.X - NodeRadius, drawCoords.Y - NodeRadius, NodeRadius * 2, NodeRadius * 2);
				}
			}
		}

		private PointF NodeCoordsToDrawCoords(int x, int y)
		{
			return new PointF(_widthUnit + x * _widthUnit * 2, _heightUnit + y * _heightUnit * 2);
		}
	}
}
