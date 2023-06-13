using UnityEngine;

public class Area : MonoBehaviour
{
	private void OnMouseDown()
	{
		ActionManager.OnEmptyClick?.Invoke();
	}
}
