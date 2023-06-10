using UnityEngine;

public class InputManager : MonoBehaviour
{
	private Camera mainCamera;
	private GridManager gridManager;

	public GameObject bb;

	private void Awake()
	{
		mainCamera = Camera.main;
	}

	private void Start()
	{
		gridManager = GridManager.instance;
	}


	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePos = InputExtension.GetMouseWorldPosition(mainCamera);
			mousePos.z = 0;
			gridManager.GetXY(mousePos, out int x, out int y);
			Instantiate(bb, gridManager.GetWorldPosition(x, y), Quaternion.identity);
		} 
	}
}
