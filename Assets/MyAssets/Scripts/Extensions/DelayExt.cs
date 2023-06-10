using System.Collections;
using UnityEngine;

public static class DelayExt
{
	public static Coroutine After(this MonoBehaviour monoBehaviour, float delay, System.Action action)
	{
		return monoBehaviour.StartCoroutine(RunAfter(delay, action));
	}

	private static IEnumerator RunAfter(float delay, System.Action action)
	{
		yield return new WaitForSeconds(delay);
		action?.Invoke();
	}
}
