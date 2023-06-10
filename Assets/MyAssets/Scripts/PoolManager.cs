using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

	[Serializable]
	public struct Pool
	{
		public PoolItems items;
		public GameObject prefab;
		public int poolSize;
	}

	[SerializeField] Pool[] pools;

	private readonly Dictionary<PoolItems, Queue<GameObject>> pooledObjects =
			new Dictionary<PoolItems, Queue<GameObject>>();

	private readonly Dictionary<PoolItems, Pool> pooledObjectsContainer =
			new Dictionary<PoolItems, Pool>();


	private void Awake()
	{
		ActionManager.GetPoolItem += GetFromPool;
		ActionManager.ReturnToPool += ReturnToPool;
	}

	private void OnEnable()
	{
		foreach (Pool pool in pools)
		{
			pooledObjects.Add(pool.items, new Queue<GameObject>());
			pooledObjectsContainer.Add(pool.items, pool);
			Spawn(pool.items);
		}
	}

	public void Spawn(PoolItems items)
	{
		pooledObjects[items].Clear();

		for (int i = 0; i < pooledObjectsContainer[items].poolSize; i++)
		{
			GameObject obj = Instantiate(pooledObjectsContainer[items].prefab);
			obj.SetActive(false);
			pooledObjects[items].Enqueue(obj);
		}
	}

	public GameObject GetFromPool(PoolItems items, Vector3 position, Transform parent = null)
	{

		if (pooledObjects[items].Count > 0)
		{
			GameObject obj = pooledObjects[items].Dequeue();
			obj.SetActive(true);
			obj.transform.position = position;
			obj.transform.parent = parent;
			return obj;
		}
		else
		{
			GameObject obj = Instantiate(pooledObjectsContainer[items].prefab);
			obj.transform.position = position;
			obj.transform.SetParent(parent);
			return obj;
		}
	}

	public void ReturnToPool(GameObject poolObject, PoolItems item, float time = 0)
	{
		StartCoroutine(ReturnTime(poolObject, item, time));
	}

	IEnumerator ReturnTime(GameObject poolObject, PoolItems item, float time)
	{
		yield return new WaitForSeconds(time);
		pooledObjects[item].Enqueue(poolObject);
		poolObject.SetActive(false);
	}
}
