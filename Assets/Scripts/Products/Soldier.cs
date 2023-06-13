using Pathfinding;
using UnityEngine;

public class Soldier : ProductBaseController
{

	private SoldierMovementController movementController;

	private void Awake()
	{
		movementController = GetComponent<SoldierMovementController>();
	}

	private void OnMouseDown()
	{

		ActionManager.OnSoldierSelected?.Invoke(true, this);
	}

	private void OnMouseEnter()
	{
		ActionManager.isPointerOn?.Invoke(true);
	}

	private void OnMouseExit()
	{
		ActionManager.isPointerOn?.Invoke(false);

	}

	public void SetTargetPosition(Vector3 pos)
	{
		movementController.InitMovement(pos);
	}
}
