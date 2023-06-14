using Pathfinding;
using UnityEngine;

public class BuildingBaseController : MonoBehaviour, ITarget
{
	private DynamicGridObstacle dynamicGridObstacle;
	private Transform midPoint;
	private BuildingFeatures feature;
	private DamageHandler damageHandler;

	private BuildingType type;

	public BuildingType Type { get => type; set => type = value; }
	public Transform MidPoint { get => midPoint; }
	public BuildingFeatures Feature { get => feature; set => feature = value; }

	private void Awake()
	{
		dynamicGridObstacle = GetComponent<DynamicGridObstacle>();
		damageHandler = GetComponent<DamageHandler>();
		midPoint = transform.GetChild(1);
	}

	private void Start()
	{
		ActionManager.OnBuildingCreated += OnPlaced;
		damageHandler.Health = feature.Health;

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
