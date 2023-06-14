using Pathfinding;
using UnityEngine;

public class SoldierMovementController : AIPath
{
	[SerializeField] private Transform soldierTarget;

	private AIDestinationSetter destinationSetter;
	private Soldier soldier;

	private bool isArrived;

	protected override void Awake()
	{
		base.Awake();
		destinationSetter = GetComponent<AIDestinationSetter>();
		soldier = GetComponent<Soldier>();
	}

	public override void OnTargetReached()
	{
		base.OnTargetReached();

		if (!isArrived)
		{
			if (soldier.IsTargetSetted)
			{
				StartCoroutine(soldier.Fire());
			}

			ActionManager.ReturnToPool?.Invoke(destinationSetter.target.gameObject, PoolItem.SoldierTarget, 0f);
			isArrived = true;
			destinationSetter.target = null;

		}

	}

	public void InitMovement(Vector3 pos)
	{
		if (destinationSetter.target != null)
		{
			soldierTarget.position = pos;
		}
		else
		{
			soldierTarget = ActionManager.GetPoolItem?.Invoke(PoolItem.SoldierTarget, pos, null).transform;

		}

		destinationSetter.target = soldierTarget;

		isArrived = false;

	}
}
