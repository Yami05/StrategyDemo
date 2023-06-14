using System.Collections;
using UnityEngine;

public class Soldier : ProductBaseController
{
	[SerializeField] private float movementSpeed;

	private SoldierMovementController movementController;
	private Transform target;

	private bool isTargetSetted;

	public bool IsTargetSetted { get => isTargetSetted; }

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
		isTargetSetted = false;
		movementController.InitMovement(pos);
	}

	public void MoveToTarget(Transform target)
	{
		this.target = target;
		Vector3 direction = target.position - transform.position;
		Vector3 targetPosition = target.position + direction.normalized * -5f;
		movementController.InitMovement(targetPosition);
		isTargetSetted = true;
	}

	public IEnumerator Fire()
	{
		while (isTargetSetted)
		{
			yield return new WaitForSeconds(productFeatures.FireRate);

			WaitForFixedUpdate wait = new WaitForFixedUpdate();

			Transform bullet = ActionManager.GetPoolItem?.Invoke(PoolItem.Bullet, transform.position, null).transform;

			Vector3 targetPos = target.position;

			while ((targetPos - bullet.position).magnitude > .1f)
			{
				bullet.position = Vector3.MoveTowards(bullet.position, targetPos, movementSpeed * Time.fixedDeltaTime);

				Vector3 direction = targetPos - bullet.position;
				float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

				bullet.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
				transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

				yield return wait;
			}

		}
	}

}
