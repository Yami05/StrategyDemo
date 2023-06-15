using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/ProductFeatures")]
public class ProductFeatures : ScriptableObject
{
	[SerializeField] private Sprite photo;
	[SerializeField] private GameObject productPrefab;
	[SerializeField] private float health;
	[SerializeField] private float damage;
	[SerializeField] private float fireRate;

	public GameObject GetProduct(Transform buildingPos)
	{
		GameObject product = Instantiate(productPrefab, buildingPos.position - Vector3.forward * 0.1f, Quaternion.identity);
		ProductBaseController features = product.GetComponent<ProductBaseController>();
		features.OnInitiliazed(buildingPos);
		features.ProductFeatures = this;
		return product;
	}

	#region Encaps
	public Sprite Photo { get => photo; }
	public float Health { get => health; }
	public float Damage { get => damage; }
	public float FireRate { get => fireRate;}
	#endregion
}
