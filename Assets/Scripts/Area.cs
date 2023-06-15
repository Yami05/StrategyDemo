using UnityEngine;
using UnityEngine.EventSystems;

public class Area : MonoBehaviour
{
	private void OnMouseDown()
	{
		if (!EventSystem.current.IsPointerOverGameObject())
		{
			ActionManager.OnEmptyClick?.Invoke();
		}
	}
}
