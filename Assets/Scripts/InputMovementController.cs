using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovementController : InputBaseController
{
	private Soldier clickedSoldier;

	private bool isPointerOnSoldier;
	private bool isSoldierSelected;

	protected override void Start()
	{
		base.Start();
		ActionManager.OnSoldierSelected += OnSoldierClicked;
	}

	protected override void OnMouseClick()
	{
		base.OnMouseClick();

	}

	protected override void OnRightClick()
	{
		base.OnRightClick();
		SetSoldiersTarget();
	}

	private void OnSoldierClicked(bool isSelected, Soldier currentSoldier)
	{
		clickedSoldier = currentSoldier;

	}

	private void SetSoldiersTarget()
	{

		Vector3 mouseToWorld = InputExtension.GetMouseWorldPosition(mainCamera);
		mouseToWorld.z = 0;

		clickedSoldier.SetTargetPosition(mouseToWorld);
	}

}
