using System.Collections;
using UnityEngine;

public class Soldier : ProductBaseController
{
	private SoldierMovementController movementController;

	private void Awake()
	{
		movementController = GetComponent<SoldierMovementController>();
	}

	private IEnumerator Start()
	{
		yield return new WaitForSeconds(0.5f);
		SetMovePoint(productionBuilding.MidPoint.position);
	}

	private void OnMouseDown()
	{
		ActionManager.OnSoldierSelected?.Invoke(true, this);
	}

	public void SetMovePoint(Vector3 pos)
	{
		movementController.InitMovement(pos);
	}

	public void MoveToTarget(Vector3 targetPos)
	{
		Vector3 direction = targetPos - transform.position;

		Vector3 targetPosition = targetPos + direction.normalized * -5f;
		SetMovePoint(targetPosition);
	}

}
