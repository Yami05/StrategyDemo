using UnityEngine;

public class InputManager : MonoBehaviour
{
	private Camera mainCamera;
	private GridManager gridManager;
	private BuildingManager buildingManager;
	private GameObject building;

	private bool isBuildingSelected;

	private Vector2 firstMousePos;
	private Vector2 lastMousePos;
	private Vector2 diff;

	private void Awake()
	{
		mainCamera = Camera.main;
	}

	private void Start()
	{
		gridManager = GridManager.instance;
		buildingManager = BuildingManager.instance;
		ActionManager.OnClickUIBuilding += GetBuilding;
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
			MoveBuilding();
		}
		if (Input.GetMouseButtonUp(0))
		{
			OnMouseRelease();
			PlaceBuilding();
		}
	}
	private void OnMouseClick()
	{
		firstMousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		lastMousePos = firstMousePos;
	}

	private void OnMouseHold()
	{
		lastMousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		diff = lastMousePos - firstMousePos;
	}

	private void OnMouseRelease()
	{
		diff.x = 0;
	}

	private void GetBuilding(BuildingType type)
	{
		BuildingFeatures selectedFeature = buildingManager.GetBuilding(type);

		building = selectedFeature.GetBuilding();
		isBuildingSelected = true;
	}

	private void MoveBuilding()
	{
		if (!isBuildingSelected || diff.x < 1)
			return;

		Vector3 mousePos = InputExtension.GetMouseWorldPosition(mainCamera);
		mousePos.z = 0;

		building.transform.position = mousePos;
	}

	private void PlaceBuilding()
	{

		if (!isBuildingSelected)
			return;

		Vector3 mousePos = InputExtension.GetMouseWorldPosition(mainCamera);
		mousePos.z = 0;
		gridManager.GetXY(mousePos, out int x, out int y);
		building.transform.position = gridManager.GetWorldPosition(x, y);

		isBuildingSelected = false;
	}

}
