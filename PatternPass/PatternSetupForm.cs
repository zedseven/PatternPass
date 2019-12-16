using KeePassLib;
using KeePassLib.Security;
using PatternPass.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PatternPass
{
	public sealed partial class PatternSetupForm : Form
	{
		private readonly PwEntry _entry;

		private const int DefaultRows = 3;
		private const int DefaultColumns = 3;
		private const string InputNameBase = "input";
		private const int InputWidth = 80;
		private const int InputHeight = 35;
		private const int InputGridTabIndexBuffer = 10;

		private Pattern Pattern { get; set; }

		internal PatternSetupForm(PwEntry entry)
		{
			_entry = entry;
			InitializeComponent();
			Text = string.Format(Resources.PatternSetupForm_Title, _entry.Strings.ReadSafe(PwDefs.TitleField));
			if (LoadPattern())
				return;
			NewPattern();
		}

		private void GenerateInputGrid()
		{
			ClearInputGrid();
			rowsInput.Text = Pattern.Rows.ToString();
			columnsInput.Text = Pattern.Columns.ToString();
			int gridElements = Pattern.Rows * Pattern.Columns;
			int?[] patternNodes = Pattern.NodeOrder.Cast<int?>().ToArray();
			int inputMarginHorizontal = (patternNodeContainer.Width - Pattern.Columns * InputWidth) / (Pattern.Columns * 2);
			int inputMarginVertical = (patternNodeContainer.Height - Pattern.Rows * InputHeight) / (Pattern.Rows * 2);
			for (int i = 0; i < gridElements; i++)
			{
				NumericUpDown nodeInput = new NumericUpDown
				{
					Name = InputNameBase + i,
					Minimum = -1,
					Maximum = gridElements - 1,
					Value = patternNodes[i].HasValue ? patternNodes[i].Value : -1,
					Increment = 1,
					TabIndex = InputGridTabIndexBuffer + i,
					Width = InputWidth,
					Height = InputHeight,
					Margin = new Padding(inputMarginHorizontal, inputMarginVertical, inputMarginHorizontal, inputMarginVertical),
					BackColor = SystemColors.Window
				};
				nodeInput.ValueChanged += CheckForDuplicates;
				patternNodeContainer.Controls.Add(nodeInput);
			}
			patternNodeContainer.Invalidate();
			patternNodeContainer.Update();
		}

		private void ClearInputGrid()
		{
			int componentCount = patternNodeContainer.Controls.Count;
			if (componentCount <= 0)
				return;
			rowsInput.Text = DefaultRows.ToString();
			columnsInput.Text = DefaultColumns.ToString();
			for (int i = componentCount - 1; i >= 0; i--)
				patternNodeContainer.Controls.RemoveAt(i);
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
			GenerateInputGrid();
			rowsInput.Value = Pattern.Rows;
			columnsInput.Value = Pattern.Columns;
			Interface.UpdateStatus(string.Format("Pattern for entry '{0}' loaded.", _entry.Strings.ReadSafe(PwDefs.TitleField)));
			return true;
		}
		private void LoadPattern(object sender, EventArgs e)
		{
			LoadPattern();
		}

		private void SavePattern(object sender, EventArgs e)
		{
			if (!RefreshPattern())
				return;
			_entry.Strings.Set(Constants.PatternStringName, new ProtectedString(true, Pattern.ToString()));
			Interface.UpdateStatus(string.Format("Pattern for entry '{0}' saved.", _entry.Strings.ReadSafe(PwDefs.TitleField)));
		}

		private void RemovePattern()
		{
			if(_entry.Strings.Remove(Constants.PatternStringName))
				Interface.UpdateStatus(string.Format("Pattern for entry '{0}' removed.", _entry.Strings.ReadSafe(PwDefs.TitleField)));
		}
		private void RemovePattern(object sender, EventArgs e)
		{
			RemovePattern();
		}

		private void NewPattern()
		{
			int rowsCount = (int) rowsInput.Value;
			int columnsCount = (int) columnsInput.Value;
			Pattern = new Pattern(rowsCount, columnsCount);
			GenerateInputGrid();
		}
		private void NewPattern(object sender, EventArgs e)
		{
			NewPattern();
		}

		private bool CheckForDuplicates()
		{
			foreach (Control control in patternNodeContainer.Controls)
				control.BackColor = SystemColors.Window;
			IEnumerable<Tuple<int, NumericUpDown>> inputValueTuples = patternNodeContainer.Controls.Cast<NumericUpDown>()
				.Select(x => new Tuple<int, NumericUpDown>((int) x.Value, x));
			IEnumerable<int> duplicateValues = inputValueTuples
				.Select(x => x.Item1)
				.GroupBy(x => x)
				.Where(g => g.Count() > 1 && g.Key > -1)
				.Select(y => y.Key);
			IEnumerable<NumericUpDown> duplicateControls = inputValueTuples
				.Where(x => duplicateValues.Contains(x.Item1))
				.Select(x => x.Item2);
			foreach (NumericUpDown control in duplicateControls)
				control.BackColor = Color.LightCoral;
			return duplicateControls.Any();
		}
		private void CheckForDuplicates(object sender, EventArgs e)
		{
			CheckForDuplicates();
		}

		private bool RefreshPattern()
		{
			if (CheckForDuplicates())
				return false;

			int?[,] patternNodes = new int?[Pattern.Rows,Pattern.Columns];

			for (int y = 0; y < Pattern.Rows; y++)
			{
				for (int x = 0; x < Pattern.Columns; x++)
				{
					int nodeValue = (int) ((NumericUpDown) patternNodeContainer.Controls[InputNameBase + (y * Pattern.Columns + x)]).Value;
					patternNodes[y, x] = nodeValue >= 0 ? nodeValue : (int?) null;
				}
			}

			try
			{
				Pattern = new Pattern(patternNodes);
			}
			catch (Pattern.PatternNoNodesException)
			{
				RemovePattern();
				return false;
			}

			return true;
		}
	}
}
