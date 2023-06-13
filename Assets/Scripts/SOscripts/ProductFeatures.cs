using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/ProductFeatures")]
public class ProductFeatures : ScriptableObject
{
	[SerializeField] private Sprite photo;
	[SerializeField] private GameObject productPrefab;
	[SerializeField] private float health;
	[SerializeField] private float damage;

	public GameObject GetProduct(Transform buildingPos)
	{
		GameObject product = Instantiate(productPrefab, buildingPos.position - Vector3.forward * 0.1f, Quaternion.identity);
		product.GetComponent<ProductBaseController>().OnInitiliazed();
		return product;
	}

	public Sprite Photo { get => photo; }
	public float Health { get => health; }
	public float Damage { get => damage; }
}
