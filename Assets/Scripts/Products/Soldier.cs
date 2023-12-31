using System.Collections;
using UnityEngine;

public class Soldier : ProductBaseController, ITarget
{
	[SerializeField] private float movementSpeed;
	[SerializeField] private Transform bulletSpawnPoint;

	private SoldierMovementController movementController;
	private Transform target;

	private bool isTargetSetted;
	private bool isFiring = false;

	public bool IsTargetSetted { get => isTargetSetted; }

	private void Awake()
	{
		movementController = GetComponent<SoldierMovementController>();
	}

	private IEnumerator Start()
	{
		yield return new WaitForSeconds(0.5f);

		if (productionBuilding != null)
		{
			SetMovePoint(productionBuilding.MidPoint.position);

		}
	}

	private void OnMouseDown()
	{
		ActionManager.OnSoldierSelected?.Invoke(true, this);
	}

	public void SetMovePoint(Vector3 pos)
	{
		isTargetSetted = false;
		isFiring = false;

		movementController.enableRotation = true;
		movementController.InitMovement(pos);

	}

	public void MoveToTarget(Transform target)
	{
		isFiring = false;
		isTargetSetted = true;

		this.target = target;
		Vector3 targetPos = target.position;
		Vector3 direction = target.position - transform.position;
		Vector3 pointToArrive = target.position + direction.normalized * -5f;

		movementController.enableRotation = true;

		if (Vector3.Distance(transform.position, targetPos) < Vector3.Distance(pointToArrive, targetPos))
		{
			movementController.InitMovement(transform.position);
		}
		else
		{
			movementController.InitMovement(pointToArrive);
		}
	}

	public IEnumerator Fire()
	{
		isFiring = true;


		while (isTargetSetted)
		{
			yield return new WaitForSeconds(productFeatures.FireRate);

			if (!isFiring)
				yield break;
			if (target == null)
				yield break;

			movementController.enableRotation = false;

			WaitForFixedUpdate wait = new WaitForFixedUpdate();

			GameObject bullet = ActionManager.GetPoolItem?.Invoke(PoolItem.Bullet, bulletSpawnPoint.position, null);
			BulletController bulletController = bullet.GetComponent<BulletController>();

			bulletController.IsShooted = true;
			bulletController.MoveToTarget(target, movementSpeed);
			bulletController.Damage = productFeatures.Damage;
			Quaternion rotation = Quaternion.LookRotation(Vector3.forward, target.position - transform.position);
			transform.rotation = rotation;

		}
	}

	public void MarkYourself(Soldier soldier)
	{
		soldier.MoveToTarget(transform);
	}
}
