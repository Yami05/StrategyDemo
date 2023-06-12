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
		ActionManager.isPointerOn += (bool isOn) => isPointerOnSoldier = isOn;
		ActionManager.OnSoldierSelected += OnSoldierClicked;
	}

	protected override void OnMouseClick()
	{
		base.OnMouseClick();

		if (!isPointerOnSoldier)
		{
			ActionManager.OnSoldierSelected?.Invoke(false, clickedSoldier);
		}
	}

	protected override void OnRightClick()
	{
		base.OnRightClick();
		SetSoldiersTarget();
	}

	private void OnSoldierClicked(bool isSelected, Soldier currentSoldier)
	{
		clickedSoldier = currentSoldier;
		isSoldierSelected = isSelected;
	}

	private void SetSoldiersTarget()
	{
		if (!isSoldierSelected)
			return;

		Vector3 mouseToWorld = InputExtension.GetMouseWorldPosition(mainCamera);
		mouseToWorld.z = 0;

		clickedSoldier.SetTargetPosition(mouseToWorld);
	}

}
