using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/ProductFeatures")]
public class ProductFeatures : ScriptableObject
{
	[SerializeField] private Sprite photo;
	[SerializeField] private float health;
	[SerializeField] private float damage;
}
