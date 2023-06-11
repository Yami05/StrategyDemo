using UnityEngine;
using UnityEngine.UI;

public class ProductionPanel : MonoBehaviour
{
	private ProductFeatures[] products;
	private Button[] usableButtons;

	public ProductFeatures[] Products { get => products; set => products = value; }

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

			currentButton.gameObject.SetActive(true);
			currentButton.image.sprite = products[i].Photo;
		}
	}

}
