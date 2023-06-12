using UnityEngine;

public class ProduceButton : ButtonBaseController
{
	private ProductFeatures product;
	private ProductionPanel productionPanel;

	public ProductFeatures Product { get => product; set => product = value; }

	protected override void Awake()
	{
		base.Awake();
		productionPanel = transform.GetComponentInParent<ProductionPanel>();

	}

	public override void OnClick()
	{
		base.OnClick();

		if (productionPanel.ProductionBuilding != null)
		{
			product.GetProduct(productionPanel.ProductionBuilding);

		}
	}
}
