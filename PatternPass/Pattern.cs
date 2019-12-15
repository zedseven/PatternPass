using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using PatternPass.Properties;

namespace PatternPass
{
	public class Pattern : IEquatable<Pattern>
	{
		private readonly int?[,] _nodeOrder;
		private const string EmptyNodeStr = "p";

		/// <summary>
		/// The number of rows of the pattern.
		/// </summary>
		public int Rows { get { return NodeOrder.GetLength(0); } }
		/// <summary>
		/// The number of columns of the pattern.
		/// </summary>
		public int Columns { get { return NodeOrder.GetLength(1); } }

		/// <summary>
		/// The pattern in a two-dimensional array format. A null node means the node is not a step, and the nodes are guaranteed to count up with one following another.
		/// </summary>
		public int?[,] NodeOrder { get { return _nodeOrder; } }

		//Exception Types
		[Serializable]
		public class PatternInvalidFormatException : ArgumentException
		{
			public PatternInvalidFormatException(string message) : base(message) { }
			public PatternInvalidFormatException(string message, Exception innerException) : base(message, innerException) { }
		}
		[Serializable]
		public class PatternInvalidDimensionException : ArgumentException
		{
			public PatternInvalidDimensionException(string message) : base(message) { }
			public PatternInvalidDimensionException(string message, Exception innerException) : base(message, innerException) { }
		}
		[Serializable]
		public class PatternInvalidNodeException : ArgumentException
		{
			public PatternInvalidNodeException(string message) : base(message) { }
			public PatternInvalidNodeException(string message, Exception innerException) : base(message, innerException) { }
		}
		[Serializable]
		public class PatternNoNodesException : ArgumentException
		{
			public PatternNoNodesException(string message) : base(message) { }
			public PatternNoNodesException(string message, Exception innerException) : base(message, innerException) { }
		}
		[Serializable]
		public class PatternDuplicateNodeException : ArgumentException
		{
			public PatternDuplicateNodeException(string message) : base(message) { }
			public PatternDuplicateNodeException(string message, Exception innerException) : base(message, innerException) { }
		}

		//Base Overrides

		public bool Equals(Pattern other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return NodeOrder.Cast<int?>().SequenceEqual(other.NodeOrder.Cast<int?>());
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((Pattern) obj);
		}

		public override int GetHashCode()
		{
			return NodeOrder != null ? NodeOrder.GetHashCode() : 0;
		}

		public static bool operator ==(Pattern left, Pattern right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Pattern left, Pattern right)
		{
			return !Equals(left, right);
		}

		//Initialization

		/// <summary>
		/// Initializes a new, empty pattern of the dimensions <paramref name="rows"/> x <paramref name="columns"/>.
		/// </summary>
		/// <param name="rows">The number of rows the empty <see cref="Pattern"/> will have.</param>
		/// <param name="columns">The number of columns the empty <see cref="Pattern"/> will have.</param>
		public Pattern(int rows, int columns)
		{
			_nodeOrder = new int?[rows,columns];
		}
		/// <summary>
		/// Sanitizes the provided <paramref name="nodeOrder"/> into a <see cref="Pattern"/>.
		/// </summary>
		/// <param name="nodeOrder">A 2D array of elements that define an order of nodes in a pattern.</param>
		/// <param name="minVal">A value guaranteed to be less than the value of any node in <paramref name="nodeOrder"/>. Must be of the same type as an element in <paramref name="nodeOrder"/>.</param>
		/// <param name="maxVal">A value guaranteed to be greater than the value of any node in <paramref name="nodeOrder"/>. Must be of the same type as an element in <paramref name="nodeOrder"/>.</param>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="PatternNoNodesException"></exception>
		/// <exception cref="PatternDuplicateNodeException"></exception>
		public Pattern(IComparable[,] nodeOrder, IComparable minVal, IComparable maxVal)
		{
			if (nodeOrder.GetType().GetElementType() != minVal.GetType())
				throw new ArgumentException(string.Format(Resources.Pattern_Ctor_Generic_Type_Mismatch, "nodeOrder", nodeOrder.GetType().GetElementType(), "minVal", minVal.GetType()), "minVal");
			if (nodeOrder.GetType().GetElementType() != maxVal.GetType())
				throw new ArgumentException(string.Format(Resources.Pattern_Ctor_Generic_Type_Mismatch, "nodeOrder", nodeOrder.GetType().GetElementType(), "maxVal", maxVal.GetType()), "maxVal");
			_nodeOrder = EnsureNodeOrder(nodeOrder, minVal, maxVal);
		}
		/// <summary>
		/// Sanitizes the provided <paramref name="nodeOrder"/> into a <see cref="Pattern"/>.
		/// </summary>
		/// <param name="nodeOrder">A 2D array of elements that define an order of nodes in a pattern.</param>
		/// <exception cref="PatternNoNodesException"></exception>
		/// <exception cref="PatternDuplicateNodeException"></exception>
		public Pattern(int?[,] nodeOrder)
		{
			_nodeOrder = EnsureNodeOrder(nodeOrder, int.MinValue, int.MaxValue);
		}
		/// <summary>
		/// Sanitizes the provided <paramref name="nodeOrder"/> into a <see cref="Pattern"/>.
		/// </summary>
		/// <param name="nodeOrder">A 2D array of elements that define an order of nodes in a pattern.</param>
		/// <exception cref="PatternNoNodesException"></exception>
		/// <exception cref="PatternDuplicateNodeException"></exception>
		public Pattern(long?[,] nodeOrder)
		{
			_nodeOrder = EnsureNodeOrder(nodeOrder, long.MinValue, long.MaxValue);
		}
		/// <summary>
		/// Sanitizes the provided <paramref name="nodeOrder"/> into a <see cref="Pattern"/>.
		/// </summary>
		/// <param name="nodeOrder">A 2D array of elements that define an order of nodes in a pattern.</param>
		/// <exception cref="PatternNoNodesException"></exception>
		/// <exception cref="PatternDuplicateNodeException"></exception>
		public Pattern(float?[,] nodeOrder)
		{
			_nodeOrder = EnsureNodeOrder(nodeOrder, float.MinValue, float.MaxValue);
		}
		/// <summary>
		/// Sanitizes the provided <paramref name="nodeOrder"/> into a <see cref="Pattern"/>.
		/// </summary>
		/// <param name="nodeOrder">A 2D array of elements that define an order of nodes in a pattern.</param>
		/// <exception cref="PatternNoNodesException"></exception>
		/// <exception cref="PatternDuplicateNodeException"></exception>
		public Pattern(double?[,] nodeOrder)
		{
			_nodeOrder = EnsureNodeOrder(nodeOrder, double.MinValue, double.MaxValue);
		}
		/// <summary>
		/// Decodes the provided <paramref name="patStr"/> into a <see cref="Pattern"/>.
		/// </summary>
		/// <param name="patStr">The encoded <see cref="Pattern"/> created with <see cref="ToString"/>.</param>
		/// <exception cref="PatternInvalidFormatException"></exception>
		/// <exception cref="PatternInvalidDimensionException"></exception>
		/// <exception cref="PatternInvalidNodeException"></exception>
		/// <exception cref="PatternDuplicateNodeException"></exception>
		public Pattern(string patStr)
		{
			patStr = patStr.Trim().TrimEnd(',');

			if(!Regex.IsMatch(patStr, @"pattern\:\d+x\d+\:(?:(?:(?:\d+)|" + EmptyNodeStr + @"),?)+"))
				throw new PatternInvalidFormatException(string.Format(Resources.Pattern_Ctor_Decode_Invalid_Format, patStr));

			string[] patParts = patStr.Split(':');
			string[] patDims = patParts[1].Split('x');

			int patRows;
			int patCols;
			//if(!int.TryParse(patDims[0], out int patRows) || !int.TryParse(patDims[1], out int patCols))
			try
			{
				patRows = int.Parse(patDims[0]);
				patCols = int.Parse(patDims[1]);
			}
			catch(FormatException e)
			{
				throw new PatternInvalidDimensionException(string.Format(Resources.Pattern_Ctor_Decode_Invalid_Dimensions, patStr), e);
			}

			_nodeOrder = new int?[patRows,patCols];

			string[] patNodes = patParts[2].Split(',');
			
			if(patNodes.Length != Rows * Columns)
				throw new PatternInvalidDimensionException(string.Format(Resources.Pattern_Ctor_Decode_Length_Mismatch, patStr, Rows, Columns));

			List<int> runningNodeVals = new List<int>();

			for (int i = 0; i < patNodes.Length; i++)
			{
				string nodeStr = patNodes[i];

				int indexX = i % Columns;
				int indexY = (int) Math.Floor((double) i / Columns);

				if (nodeStr == EmptyNodeStr)
				{
					NodeOrder[indexY, indexX] = null;
					continue;
				}

				int nodeVal;
				//if(!int.TryParse(nodeStr, out int nodeVal))
				try
				{
					nodeVal = int.Parse(nodeStr);
				}
				catch (FormatException e)
				{
					throw new PatternInvalidNodeException(string.Format(Resources.Pattern_Ctor_Decode_Invalid_Node_Value, nodeStr, patStr), e);
				}

				if(runningNodeVals.Contains(nodeVal))
					throw new PatternDuplicateNodeException(string.Format(Resources.Pattern_Ctor_Decode_Duplicate_Node_Values, patStr));

				NodeOrder[indexY, indexX] = nodeVal;
				runningNodeVals.Add(nodeVal);
			}
		}

		private int?[,] EnsureNodeOrder<T>(T[,] nodeOrder, T minVal, T maxVal) where T : IComparable
		{
			int rows = nodeOrder.GetLength(0);
			int cols = nodeOrder.GetLength(1);
			if (rows < 1)
				throw new PatternNoNodesException(Resources.Pattern_EnsureNodeOrder_Empty_Node_Array);
			if (cols < 1)
				throw new PatternNoNodesException(Resources.Pattern_EnsureNodeOrder_No_Columns);
			if (nodeOrder.Cast<T>().All(node => node == null))
				throw new PatternNoNodesException(Resources.Pattern_EnsureNodeOrder_All_Null_Nodes);
			if (nodeOrder.Cast<T>().GroupBy(x => x).Any(x => x.Key != null && x.Skip(1).Any()))
				throw new PatternDuplicateNodeException(Resources.Pattern_EnsureNodeOrder_Duplicate_Node_Values);

			int?[,] finalOrder = new int?[rows,cols];
			
			T baseVal = minVal;
			int i = 0;
			while(true)
			{
				//nextLowest = nodeOrder.Min(row => (int) row.Where(col => (col ?? int.MaxValue) > lowestNum).Min());
				T nextVal = maxVal;
				int nextX = -1;
				int nextY = -1;
				for (int y = 0; y < nodeOrder.GetLength(0); y++)
				{
					for (int x = 0; x < nodeOrder.GetLength(1); x++)
					{
						if (nodeOrder[y, x] == null || nodeOrder[y, x].CompareTo(nextVal) >= 0 || nodeOrder[y, x].CompareTo(baseVal) <= 0)
							continue;
						nextVal = nodeOrder[y, x];
						nextX = x;
						nextY = y;
					}
				}
				if (nextVal.Equals(maxVal))
					break;
				finalOrder[nextY, nextX] = i;
				baseVal = nextVal;
				i++;
			}

			return finalOrder;
		}

		private int?[,] EnsureNodeOrder<T>(T?[,] nodeOrder, T minVal, T maxVal) where T : struct, IComparable
		{
			int rows = nodeOrder.GetLength(0);
			int cols = nodeOrder.GetLength(1);
			if (rows < 1)
				throw new PatternNoNodesException(Resources.Pattern_EnsureNodeOrder_Empty_Node_Array);
			if (cols < 1)
				throw new PatternNoNodesException(Resources.Pattern_EnsureNodeOrder_No_Columns);
			if (nodeOrder.Cast<T?>().All(node => !node.HasValue))
				throw new PatternNoNodesException(Resources.Pattern_EnsureNodeOrder_All_Null_Nodes);
			if (nodeOrder.Cast<T?>().GroupBy(x => x).Any(x => x.Key.HasValue && x.Skip(1).Any()))
				throw new PatternDuplicateNodeException(Resources.Pattern_EnsureNodeOrder_Duplicate_Node_Values);

			int?[,] finalOrder = new int?[rows,cols];

			T baseVal = minVal;
			int i = 0;
			while(true)
			{
				//nextLowest = nodeOrder.Min(row => (int) row.Where(col => (col ?? int.MaxValue) > lowestNum).Min());
				T nextVal = maxVal;
				int nextX = -1;
				int nextY = -1;
				for (int y = 0; y < nodeOrder.GetLength(0); y++)
				{
					for (int x = 0; x < nodeOrder.GetLength(1); x++)
					{
						if (!nodeOrder[y, x].HasValue || nodeOrder[y, x].Value.CompareTo(nextVal) >= 0 || nodeOrder[y, x].Value.CompareTo(baseVal) <= 0)
							continue;
						nextVal = nodeOrder[y, x].Value;
						nextX = x;
						nextY = y;
					}
				}
				if (nextVal.Equals(maxVal))
					break;
				finalOrder[nextY, nextX] = i;
				baseVal = nextVal;
				i++;
			}

			return finalOrder;
		}

		//Public Methods

		/// <summary>
		/// Encodes the pattern as an easily-storable, transferable string.
		/// </summary>
		/// <returns>The string format of the <see cref="Pattern"/>.</returns>
		public override string ToString()
		{
			return string.Format("pattern:{0}x{1}:", Rows, Columns) +
			       string.Join(",", NodeOrder.Cast<int?>().Select(node => node != null ? node.ToString() : EmptyNodeStr));
		}
	}
}
