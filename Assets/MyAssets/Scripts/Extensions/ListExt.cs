using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public static class ListExt
{

	//LIST
	public static T GetRandomItem<T>(this IList<T> list) => list[Random.Range(0, list.Count)];
	public static T GetLastItem<T>(this IList<T> list) => list[list.Count - 1];
	public static void RemoveLastItem<T>(this IList<T> list) => list.RemoveAt(list.Count - 1);
	public static void Sort<TSource, TResult>(this List<TSource> self, Func<TSource, TResult> selector) where TResult : IComparable
	=> self.Sort((x, y) => selector(x).CompareTo(selector(y)));

	//ARRAY
	public static T GetRandomItem<T>(this T[] array) => array[Random.Range(0, array.Length)];
	public static T GetLastItem<T>(this T[] array) => array[array.Length - 1];
	public static void Sort<TSource, TResult>(this TSource[] self, Func<TSource, TResult> selector) where TResult : IComparable
		=> Array.Sort(self, (x, y) => selector(x).CompareTo(selector(y)));

}
