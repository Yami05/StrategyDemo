using Pathfinding;
using UnityEngine;

public class Soldier : ProductBaseController
{
	[SerializeField] private Transform target;

	private AIDestinationSetter destinationSetter;

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
		target.position = pos;
		destinationSetter.target = target;
	}
}
