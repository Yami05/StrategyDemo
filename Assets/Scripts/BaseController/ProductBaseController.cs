using UnityEngine;

public class ProductBaseController : MonoBehaviour
{

	protected BuildingBaseController productionBuilding;
	protected ProductFeatures productFeatures;

	public ProductFeatures ProductFeatures { get => productFeatures; set => productFeatures = value; }

	public virtual void OnInitiliazed(Transform productionBuilding)
	{
		this.productionBuilding = productionBuilding.GetComponentInParent<BuildingBaseController>();
	}
}
