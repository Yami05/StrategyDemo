using Pathfinding;
using UnityEngine;

public class SoldierMovementController : AIPath
{
	[SerializeField] private Transform soldierTarget;

	private AIDestinationSetter destinationSetter;
	private Transform olderTarget;

	protected override void Awake()
	{
		base.Awake();
		destinationSetter = GetComponent<AIDestinationSetter>();
	}

	public override void OnTargetReached()
	{
		base.OnTargetReached();
		ActionManager.ReturnToPool?.Invoke(soldierTarget.gameObject, PoolItem.SoldierTarget, 0.2f);
	}

	public void InitMovement(Vector3 pos)
	{
		if (soldierTarget != null)
		{
			olderTarget = soldierTarget;
			ActionManager.ReturnToPool?.Invoke(olderTarget.gameObject, PoolItem.SoldierTarget, 0.2f);

		}

		soldierTarget = ActionManager.GetPoolItem?.Invoke(PoolItem.SoldierTarget, pos, null).transform;

		destinationSetter.target = soldierTarget;
	}
}
