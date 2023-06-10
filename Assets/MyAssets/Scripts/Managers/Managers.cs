using UnityEngine;

public class Managers : MonoSingleton<Managers>
{
	[SerializeField] private PrefabManager prefabManager;

	public PrefabManager PrefabManager { get => prefabManager; }
}
