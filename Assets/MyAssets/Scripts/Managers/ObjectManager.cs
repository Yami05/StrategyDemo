using UnityEngine;

public class ObjectManager : MonoSingleton<ObjectManager>
{
	[SerializeField] private Camera UICam;

	public Camera UICam1 { get => UICam; }
}
