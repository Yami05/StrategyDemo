using System;
using System.Reflection;
using UnityEngine;

public static class ActionManager
{
	public static Action<bool> OpenZoomPanel { get; set; }
	public static Action<Vector3, PoolItems> SetUIParticle { get; set; }


	//Camera
	public static Action<Transform> SetCameraTarget { get; set; }

	//Save System
	public static Action Save { get; set; }
	public static Action Load { get; set; }

	//Pool Part
	public static Func<PoolItems, Vector3, Transform, GameObject> GetPoolItem { get; set; }
	public static Action<GameObject, PoolItems, float> ReturnToPool { get; set; }


	public static void ResetAllStaticsVariables()
	{
		Type type = typeof(ActionManager);

		var fields = type.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Public);

		foreach (var fieldInfo in fields)
		{
			fieldInfo.SetValue(null, GetDefault(type));
		}
	}

	public static object GetDefault(Type type)
	{
		if (type.IsValueType)
		{
			return Activator.CreateInstance(type);
		}

		return null;
	}
}
