﻿using UnityEngine;

public class BulletController : MonoBehaviour
{
	private DamageHandler damageHandler;

	private Vector3 targetPosition;

	private float movementSpeed;
	private float damage;

	public float Damage { get => damage; set => damage = value; }

	private void Start()
	{
		GetComponent<SpriteRenderer>().sprite = ActionManager.SetSprite?.Invoke(AtlasSprites.Bullet);
	}

	public void MoveToTarget(Transform target, float speed)
	{

		targetPosition = target.position;
		movementSpeed = speed;
		damageHandler = target.GetComponentInParent<DamageHandler>();

		Vector3 direction = target.position - transform.position;
		direction.z = 0f;
		Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction.normalized);
		transform.rotation = rotation;
	}

	private void FixedUpdate()
	{

		transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.fixedDeltaTime);

		if (transform.position == targetPosition)
		{
			if (damageHandler != null)
			{
				damageHandler.TakeDamage(Damage);

			}
			ActionManager.ReturnToPool?.Invoke(gameObject, PoolItem.Bullet, 0.0f);
		}

	}

}
