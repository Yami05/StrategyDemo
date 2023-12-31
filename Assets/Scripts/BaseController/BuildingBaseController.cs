using Pathfinding;
using UnityEngine;

public class BuildingBaseController : MonoBehaviour, ITarget
{
	[SerializeField] private SpriteRenderer preview;

	private DynamicGridObstacle dynamicGridObstacle;
	private Transform midPoint;
	private BuildingFeatures feature;
	private DamageHandler damageHandler;
	private GridManager gridManager;
	protected Transform movePoint;

	private BuildingType type;

	public BuildingType Type { get => type; set => type = value; }
	public Transform MidPoint { get => midPoint; }
	public BuildingFeatures Feature { get => feature; set => feature = value; }
	public SpriteRenderer Preview { get => preview; set => preview = value; }
	public Transform MovePoint { get => movePoint; set => movePoint = value; }

	private void Awake()
	{
		dynamicGridObstacle = GetComponent<DynamicGridObstacle>();
		damageHandler = GetComponent<DamageHandler>();
		midPoint = transform.GetChild(1);
	}

	private void Start()
	{
		gridManager = GridManager.instance;
		ActionManager.OnBuildingCreated += OnPlaced;
		damageHandler.Health = feature.Health;

	}

	private void OnPlaced(bool isBuildingCreated)
	{
		if (!isBuildingCreated)
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

	private void OnDestroy()
	{
		gridManager.SetCanBuild(transform.position, feature, true);

	}

}
