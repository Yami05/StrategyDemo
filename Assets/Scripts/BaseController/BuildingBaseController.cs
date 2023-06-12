using Pathfinding;
using UnityEngine;

public class BuildingBaseController : MonoBehaviour
{
	private DynamicGridObstacle dynamicGridObstacle;

	//Setting this with instantiate
	private BuildingType type;

	public BuildingType Type { get => type; set => type = value; }

	private void Awake()
	{
		dynamicGridObstacle = GetComponent<DynamicGridObstacle>();
	}

	private void Start()
	{
		ActionManager.OnBuildingCreated += OnPlaced;
	}

	private void OnPlaced(bool a)
	{
		if (!a)
			dynamicGridObstacle.DoUpdateGraphs();

	}

	private void OnMouseDown()
	{
		ActionManager.OnClickFromBuildingMenu?.Invoke(Type, transform);
	}
}
