using UnityEngine;

public static class InputExtension
{
	public static Vector3 GetMouseRaycastPosition(Camera camera)
	{
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;

		if (Physics.Raycast(ray, out hit))
		{
			return hit.point;
		}
		else
		{
			return Vector3.zero;
		}
	}

	public static Vector3 GetMouseWorldPosition(Camera camera)
	{
		return camera.ScreenToWorldPoint(Input.mousePosition);
	}


}
