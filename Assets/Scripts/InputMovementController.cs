using UnityEngine;

public class InputMovementController : InputBaseController
{
	private Soldier clickedSoldier;

	private bool isSoldierSelected;

	protected override void Start()
	{
		base.Start();
		ActionManager.OnSoldierSelected += OnSoldierClicked;
		ActionManager.OnEmptyClick += () => isSoldierSelected = false;
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
		isSoldierSelected = isSelected;
	}

	private void SetSoldiersTarget()
	{
		if (!isSoldierSelected)
			return;

		Vector3 mouseToWorld = InputExtension.GetMouseWorldPosition(mainCamera);
		mouseToWorld.z = 0;
		RaycastHit2D hit = InputExtension.GetRaycastHit2D(mainCamera);

		if (hit.transform.TryGetComponent<ITarget>(out ITarget target))
		{
			target.MarkYourself(clickedSoldier);
		}
		else
		{
			clickedSoldier.SetMovePoint(mouseToWorld);

		}

	}

}
