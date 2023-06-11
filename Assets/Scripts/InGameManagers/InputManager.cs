using UnityEngine;

public class InputManager : MonoBehaviour
{
	private Camera mainCamera;
	private GridManager gridManager;
	private BuildingManager buildingManager;
	private GameObject building;
	private BuildingFeatures selectedFeature;

	private bool isBuildingCreated;

	private Vector3 mousePos;
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
			CreateBuilding();
			MoveBuilding();
		}
		if (Input.GetMouseButtonUp(0))
		{
			PlaceBuilding();
			OnMouseRelease();
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

	private void GetBuilding(BuildingType type) => selectedFeature = buildingManager.GetBuilding(type);

	private void CreateBuilding()
	{

		if (diff.x < 4 || isBuildingCreated)
		{
			return;
		}

		ActionManager.OnBuildingCreated?.Invoke(true);
		building = selectedFeature.GetBuilding();
		isBuildingCreated = true;
	}


	private void MoveBuilding()
	{

		if (!isBuildingCreated)
			return;

		mousePos = InputExtension.GetMouseWorldPosition(mainCamera);
		mousePos.z = 0;

		building.transform.position = mousePos;

		if (gridManager.CheckCanBuild(mousePos, selectedFeature))
		{
			//give color green
		}
		else
		{
			//give color red
		}
	}

	private void PlaceBuilding()
	{

		ActionManager.OnBuildingCreated?.Invoke(false);

		if (!isBuildingCreated)
			return;

		Vector3 mousePos = InputExtension.GetMouseWorldPosition(mainCamera);
		mousePos.z = 0;
		gridManager.GetXY(mousePos, out int x, out int y);

		if (gridManager.CheckCanBuild(mousePos, selectedFeature))
		{
			building.transform.position = gridManager.GetWorldPosition(x, y);

			gridManager.SetCanBuild(mousePos, selectedFeature);
		}
		else
		{
			Destroy(building);
		}


		isBuildingCreated = false;
	}

}
