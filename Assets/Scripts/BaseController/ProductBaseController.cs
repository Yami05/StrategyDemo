using UnityEngine;

public class ProductBaseController : MonoBehaviour
{

	protected BuildingBaseController productionBuilding;
	protected ProductFeatures productFeatures;
	protected DamageHandler damageHandler;


	public ProductFeatures ProductFeatures { get => productFeatures; set => productFeatures = value; }


	private void Start()
	{
		damageHandler = GetComponent<DamageHandler>();
		damageHandler.Health = productFeatures.Health;
	}

	public virtual void OnInitiliazed(Transform productionBuilding)
	{
		this.productionBuilding = productionBuilding.GetComponentInParent<BuildingBaseController>();
	}
}
