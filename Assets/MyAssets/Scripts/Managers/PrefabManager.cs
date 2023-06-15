using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/PrefabManager")]
public class PrefabManager : ScriptableObject
{
	[SerializeField] private GameObject cubePrefab;

	public GameObject GetCube(Vector3 pos, Transform parent)
	{
		return Instantiate(cubePrefab, parent);
	}
}
