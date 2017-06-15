using System.Collections.Generic;
using System.Linq;
using MergeSortNet4;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTestProject1
{
	[TestFixture]
	public class DivideMergeSortUnitTest
	{
		[TestCase(null, null, TestName = "null")]
		[TestCase(new int[]{}, new int[]{}, TestName = "empty array")]
		[TestCase(new[] { 1 }, new[] { 1 }, TestName = "array length 1")]
		[TestCase(new[] { 1, 2 }, new[] { 1, 2 }, TestName = "sorted array length 2")]
		[TestCase(new[] { 2, 1 }, new[] { 1, 2 }, TestName = "unsorted array length 2")]
		[TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, TestName = "sorted array length 3")]
		[TestCase(new[] { 2, 3, 1 }, new[] { 1, 2, 3 }, TestName = "unsorted array length 3")]
		[TestCase(new[] { 2, 3, 5, 2, 7, 2, 9, 54, 32, 7 }, new[] { 2, 2, 2, 3, 5, 7, 7, 9, 32, 54 }, TestName = "odd long array")]
		[TestCase(new[] { 4,5,7,39,6,0 }, new[] { 0,4,5,6,7,39 }, TestName = "even long array")]
		public void TestMethod(int[] a, int[] b)
		{
			var initialArray =a?.ToList();
			var sortedArray = b?.ToList();
			var result = DivideMergeSort.Sort(initialArray);
			Assert.AreEqual(result == null, sortedArray == null);
			if (result == null || sortedArray == null)
			{
				return;
			}
			Assert.AreEqual(result.Count, sortedArray.Count);
			for (var index = 0; index < result.Count; index++)
			{
				Assert.AreEqual(result[index], sortedArray[index]);
			}
		}
	}
}
