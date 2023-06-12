
using UnityEngine;

public class InputPlacementController : InputBaseController
{
	private GridManager gridManager;
	private BuildingManager buildingManager;
	private GameObject building;
	private BuildingFeatures selectedFeature;

	private bool isBuildingCreated;

	protected override void Start()
	{
		base.Start();
		gridManager = GridManager.instance;
		buildingManager = BuildingManager.instance;
		ActionManager.OnClickFromBuildingMenu += GetBuilding;

	}

	protected override void OnMouseClick()
	{
		base.OnMouseClick();
	}

	protected override void OnMouseHold()
	{
		CreateBuilding();
		MoveBuilding();
		base.OnMouseHold();
	}

	protected override void OnMouseRelease()
	{
		base.OnMouseRelease();
		PlaceBuilding();
	}

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

	private void GetBuilding(BuildingType type, Transform buildingPos) => selectedFeature = buildingManager.GetBuilding(type);

}
