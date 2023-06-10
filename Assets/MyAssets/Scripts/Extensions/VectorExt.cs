using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExt
{
	public static Vector3 WithX(this Vector3 vector, float x)
	{
		return new Vector3(x, vector.y, vector.z);
	}

	public static Vector3 WithY(this Vector3 vector, float y)
	{
		return new Vector3(vector.x, y, vector.z);
	}

	public static Vector3 WithZ(this Vector3 vector, float z)
	{
		return new Vector3(vector.x, vector.y, z);
	}

	public static Vector3 WithMagnitude(this Vector3 vector, float magnitude)
	{
		return vector.normalized * magnitude;
	}

}
