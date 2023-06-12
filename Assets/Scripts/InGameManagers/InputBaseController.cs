using UnityEngine;

public class InputBaseController : MonoBehaviour
{
	protected Camera mainCamera;

	protected Vector3 mousePos;
	private Vector2 firstMousePos;
	private Vector2 lastMousePos;
	protected Vector2 diff;

	private void Awake()
	{
		mainCamera = Camera.main;
	}

	protected virtual void Start()
	{
		
	}

	private void Update()
	{

		if (Input.GetMouseButtonDown(0))
		{
			OnMouseClick();

			

		}
		if (Input.GetMouseButton(0))
		{
			OnMouseHold();
		}
		if (Input.GetMouseButtonUp(0))
		{
			OnMouseRelease();
		}

		if (Input.GetMouseButtonDown(1)) 
		{
			OnRightClick();
		}

	}

	protected virtual void OnMouseClick()
	{
		firstMousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		lastMousePos = firstMousePos;
	}

	protected virtual void OnMouseHold()
	{
		lastMousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		diff = lastMousePos - firstMousePos;
	}

	protected virtual void OnMouseRelease()
	{
		diff.x = 0;
	}

	protected virtual void OnRightClick()
	{

	}

}
