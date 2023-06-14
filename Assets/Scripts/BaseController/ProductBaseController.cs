using UnityEngine;

public class ProductBaseController : MonoBehaviour
{

	protected BuildingBaseController productionBuilding;

	public virtual void OnInitiliazed(Transform productionBuilding)
	{
		print(productionBuilding.gameObject.name);
		print(productionBuilding.position);
		this.productionBuilding = productionBuilding.GetComponent<BuildingBaseController>();
	}
}
