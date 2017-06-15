using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSortNet4
{
	public static class DivideMergeSort
	{
		private static List<int> Merge(List<int> a, List<int> b)
		{
			if (a == null || !a.Any())
			{
				return b;
			}
			if (b == null || !b.Any())
			{
				return null;
			}
			var result = new List<int>();
			var indexA = 0;
			var indexB = 0;
			var minLength = Math.Min(a.Count, b.Count);

			while (indexA < minLength || indexB<minLength) 
			{
				if (indexA < minLength && indexB < minLength)
				{
					result.Add(a[indexA] < b[indexB] ? a[indexA++] : b[indexB++]);
				}
				if (indexA == minLength)
				{
					result.Add(b[indexB++]);
				}
				if (indexB == minLength)
				{
					result.Add(a[indexA++]);
				}
			}
			return result;
			//return  indexA == minLength ? result.Concat(b.Skip(indexB)).ToList() : result.Concat(a.Skip(indexA)).ToList();
		}

		private static List<int> SortInner(List<int> a)
		{
			if (a.Count == 1)
			{
				return a;
			}
			var middle = a.Count / 2;
			return Merge(SortInner(a.Take(middle).ToList()), SortInner(a.Skip(middle).ToList()));
		}

		public static List<int> Sort(List<int> a)
		{
			if (a == null || !a.Any())
			{
				return a;
			}
			return SortInner(a);
		}
	}
}
