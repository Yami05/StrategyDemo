using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExt
{

	public static void SetLayer(this GameObject obj, string layerName)
	{
		int layer = LayerMask.NameToLayer(layerName);
		obj.layer = layer;
	}

	public static void RemoveComponent<T>(this GameObject obj) where T : Component
	{
		Component component = obj.GetComponent<T>();

		if (component != null)
		{
			Object.Destroy(component);
		}
		else
		{
			Debug.LogWarning("No Component");
		}
	}

}
