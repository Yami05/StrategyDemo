using UnityEngine;
using UnityEngine.UI;

public class ProductionPanel : MonoBehaviour
{
	private ProductFeatures[] products;
	private Button[] usableButtons;

	private Transform productionBuilding;

	public ProductFeatures[] Products { get => products; set => products = value; }
	public Transform ProductionBuilding { get => productionBuilding; set => productionBuilding = value; }

	private void Awake()
	{
		usableButtons = transform.GetComponentsInChildren<Button>();
	}

	private void OnEnable()
	{
		EnableButtons();
	}

	private void EnableButtons()
	{
		for (int i = 0; i < products.Length; i++)
		{
			Button currentButton = usableButtons[i];
			ProduceButton produceButton = currentButton.GetComponent<ProduceButton>();
			produceButton.Product = products[i];
			currentButton.gameObject.SetActive(true);
			currentButton.image.sprite = products[i].Photo;
		}
	}

}
