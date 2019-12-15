using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PatternPass.Tests
{
	[TestClass]
	public class PatternTests
	{
		private readonly int?[,] TestNodes0 = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
		private readonly int?[,] TestNodes1 = { { 0, null, 5 }, { 1, 3, 4 }, { 2, null, 6 } };
		private readonly int?[,] TestNodes2 = { { 1, 0, 3, 5 }, { 10, 7, 4, null }, { 2, 6, 8, 9 } };
		private readonly TestClass0[,] TestNodes3 = { { new TestClass0(1), new TestClass0(3) }, { new TestClass0(0), null }, { new TestClass0(5), new TestClass0(4),  } };
		private const string TestNodes0Encoded = "pattern:3x3:0,1,2,3,4,5,6,7,8";
		private const string TestNodes1Encoded = "pattern:3x3:0,p,5,1,3,4,2,p,6";
		private const string TestNodes2Encoded = "pattern:3x4:1,0,3,5,10,7,4,p,2,6,8,9";
		private const string TestNodes3Encoded = "pattern:3x2:1,2,0,p,4,3";

		private class TestClass0 : IComparable
		{
			private readonly float _val;

			public TestClass0(float val)
			{
				_val = val;
			}

			public int CompareTo(object obj)
			{
				if (obj is null) return 1;
				if (ReferenceEquals(this, obj)) return 0;
				return obj is TestClass0 other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(TestClass0)}");
			}

			private int CompareTo(TestClass0 other)
			{
				if (other is null) return 1;
				if (ReferenceEquals(this, other)) return 0;
				return _val.CompareTo(other._val);
			}
		}

		[TestMethod]
		public void PatternTest()
		{
			Assert.AreEqual(new Pattern(TestNodes0), new Pattern(TestNodes0Encoded));
			Assert.AreEqual(new Pattern(TestNodes1), new Pattern(TestNodes1Encoded));
			Assert.AreEqual(new Pattern(TestNodes2), new Pattern(TestNodes2Encoded));
			Assert.AreEqual(new Pattern(TestNodes3, new TestClass0(float.MinValue), new TestClass0(float.MaxValue)), new Pattern(TestNodes3Encoded));
		}

		[TestMethod]
		public void ToStringTest()
		{
			Assert.AreEqual(TestNodes0Encoded, new Pattern(TestNodes0).ToString());
			Assert.AreEqual(TestNodes1Encoded, new Pattern(TestNodes1).ToString());
			Assert.AreEqual(TestNodes2Encoded, new Pattern(TestNodes2).ToString());
			Assert.AreEqual(TestNodes3Encoded, new Pattern(TestNodes3, new TestClass0(float.MinValue), new TestClass0(float.MaxValue)).ToString());
		}

		[TestMethod]
		public void EncodeDecodeTest()
		{
			Assert.AreEqual(new Pattern(TestNodes0), new Pattern(new Pattern(TestNodes0).ToString()));
			Assert.AreEqual(new Pattern(TestNodes1), new Pattern(new Pattern(TestNodes1).ToString()));
			Assert.AreEqual(new Pattern(TestNodes2), new Pattern(new Pattern(TestNodes2).ToString()));
			Assert.AreEqual(new Pattern(TestNodes3, new TestClass0(float.MinValue), new TestClass0(float.MaxValue)),
				new Pattern(new Pattern(TestNodes3, new TestClass0(float.MinValue), new TestClass0(float.MaxValue))
					.ToString()));
		}
	}
}