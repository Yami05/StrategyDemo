using Pathfinding;
using UnityEngine;

public class BuildingBaseController : MonoBehaviour, ITarget
{
	private DynamicGridObstacle dynamicGridObstacle;
	private Transform midPoint;

	private BuildingType type;

	public BuildingType Type { get => type; set => type = value; }
	public Transform MidPoint { get => midPoint; }

	private void Awake()
	{
		dynamicGridObstacle = GetComponent<DynamicGridObstacle>();
		midPoint = transform.GetChild(0);
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
		ActionManager.OnClickFromBuildingMenu?.Invoke(Type, MidPoint);
	}

	public void MarkYourself(Soldier soldier)
	{
		soldier.MoveToTarget(MidPoint);
	}
}
