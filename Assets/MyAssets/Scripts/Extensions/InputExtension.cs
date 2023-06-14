using System;
using UnityEngine;

public static class InputExtension
{
	public static RaycastHit GetRaycastHit3D(Camera camera)
	{
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;

		if (Physics.Raycast(ray, out hit))
		{
			return hit;
		}
		else
		{
			throw new Exception("No raycast hit detected.");
		}
	}

	public static RaycastHit2D GetRaycastHit2D(Camera camera)
	{
		Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

		RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

		if (hit.collider != null)
		{
			return hit;
		}
		else
		{
			return default(RaycastHit2D);
		}
	}



	public static Vector3 GetMouseWorldPosition(Camera camera)
	{
		return camera.ScreenToWorldPoint(Input.mousePosition);
	}


}
