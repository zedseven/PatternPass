using System;
using System.Linq;

namespace PatternPass
{
	public class Pattern
	{
		public int Rows { get; }
		public int Columns { get; }

		public int?[,] NodeOrder { get; }

		//Initialization

		public Pattern(IComparable[,] nodeOrder, IComparable maxVal)
		{
			if(nodeOrder.GetType().GetElementType() != maxVal.GetType())
				throw new ArgumentException($"The type of {nameof(nodeOrder)} ({nodeOrder.GetType().GetElementType()}) does not match the type of {nameof(maxVal)} ({maxVal.GetType()}).", nameof(maxVal));
			Rows = nodeOrder.GetLength(0);
			Columns = nodeOrder.GetLength(1);
			NodeOrder = VerifyNodeOrder(nodeOrder, maxVal);
		}
		public Pattern(int?[,] nodeOrder)
		{
			Rows = nodeOrder.GetLength(0);
			Columns = nodeOrder.GetLength(1);
			NodeOrder = VerifyNodeOrder(nodeOrder, int.MaxValue);
		}
		public Pattern(long?[,] nodeOrder)
		{
			Rows = nodeOrder.GetLength(0);
			Columns = nodeOrder.GetLength(1);
			NodeOrder = VerifyNodeOrder(nodeOrder, long.MaxValue);
		}
		public Pattern(float?[,] nodeOrder)
		{
			Rows = nodeOrder.GetLength(0);
			Columns = nodeOrder.GetLength(1);
			NodeOrder = VerifyNodeOrder(nodeOrder, float.MaxValue);
		}
		public Pattern(double?[,] nodeOrder)
		{
			Rows = nodeOrder.GetLength(0);
			Columns = nodeOrder.GetLength(1);
			NodeOrder = VerifyNodeOrder(nodeOrder, double.MaxValue);
		}

		private int?[,] VerifyNodeOrder<T>(T[,] nodeOrder, T maxVal) where T : IComparable
		{
			if (Rows < 1)
				throw new ArgumentException("Input node array has no rows.", nameof(nodeOrder));
			if (Columns < 1)
				throw new ArgumentException("Input node array has no columns.", nameof(nodeOrder));
			if (nodeOrder.Cast<T>().All(node => node == null))
				throw new ArgumentException("Input node array is filled with only null values.", nameof(nodeOrder));

			int?[,] finalOrder = new int?[Rows,Columns];
			
			T minVal = nodeOrder.Cast<T>().Where(node => node != null).Min();
			int i = 0;
			while(true)
			{
				//nextLowest = nodeOrder.Min(row => (int) row.Where(col => (col ?? int.MaxValue) > lowestNum).Min());
				T nextVal = maxVal;
				int nextX = -1;
				int nextY = -1;
				for (int y = 0; y < nodeOrder.Length; y++)
				{
					for (int x = 0; x < nodeOrder.Length; x++)
					{
						if (nodeOrder[x, y] == null)
							continue;
						if (nodeOrder[x, y].Equals(nextVal) || nodeOrder[x,y].Equals(minVal))
							throw new ArgumentException("Input node array has duplicate values.", nameof(nodeOrder));
						if (nodeOrder[x, y].CompareTo(nextVal) > 0 || nodeOrder[x, y].CompareTo(minVal) < 0)
							continue;
						nextVal = nodeOrder[x, y];
						nextX = x;
						nextY = y;
					}
				}
				if (nextVal.Equals(maxVal))
					break;
				finalOrder[nextX, nextY] = i;
				minVal = nextVal;
				i++;
			}

			return finalOrder;
		}

		private int?[,] VerifyNodeOrder<T>(T?[,] nodeOrder, T maxVal) where T : struct, IComparable
		{
			if (Rows < 1)
				throw new ArgumentException("Input node array has no rows.", nameof(nodeOrder));
			if (Columns < 1)
				throw new ArgumentException("Input node array has no columns.", nameof(nodeOrder));
			if (nodeOrder.Cast<T?>().All(node => !node.HasValue))
				throw new ArgumentException("Input node array is filled with only null values.", nameof(nodeOrder));

			int?[,] finalOrder = new int?[Rows,Columns];
			
			T minVal = nodeOrder.Cast<T?>().Where(node => node.HasValue).Min().Value;
			int i = 0;
			while(true)
			{
				//nextLowest = nodeOrder.Min(row => (int) row.Where(col => (col ?? int.MaxValue) > lowestNum).Min());
				T nextVal = maxVal;
				int nextX = -1;
				int nextY = -1;
				for (int y = 0; y < nodeOrder.Length; y++)
				{
					for (int x = 0; x < nodeOrder.Length; x++)
					{
						if (!nodeOrder[x, y].HasValue)
							continue;
						if (nodeOrder[x, y].Equals(nextVal) || nodeOrder[x,y].Equals(minVal))
							throw new ArgumentException("Input node array has duplicate values.", nameof(nodeOrder));
						if (nodeOrder[x, y].Value.CompareTo(nextVal) > 0 || nodeOrder[x, y].Value.CompareTo(minVal) < 0)
							continue;
						nextVal = nodeOrder[x, y].Value;
						nextX = x;
						nextY = y;
					}
				}
				if (nextVal.Equals(maxVal))
					break;
				finalOrder[nextX, nextY] = i;
				minVal = nextVal;
				i++;
			}

			return finalOrder;
		}
	}
}
