using System;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
	private float health;

	public float Health { get => health; set => health = value; }

	public void TakeDamage(float damage)
	{
		Health -= damage;

		if (Health <= 0)
		{
			GameObject explosionVfx = ActionManager.GetPoolItem?.Invoke(PoolItem.ExplosionVFX, transform.position, null);
			ActionManager.ReturnToPool?.Invoke(explosionVfx, PoolItem.ExplosionVFX, 1f);
			Destroy(gameObject);
		}
	}

}
