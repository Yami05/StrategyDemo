using UnityEngine;

public class ScrollContent : MonoBehaviour
{
	[SerializeField] private int itemCount;
	[SerializeField] private float productsScale;
	[SerializeField] private float itemSpacing;

	private RectTransform rectTransform;
	private RectTransform[] products;

	private float dynamicSpacing;

	private float height;
	private float productHeight;
	private float productWidth;

	public float Height { get => height; }
	public float ProductHeight { get => productHeight; }
	public float ProductWidth { get => productWidth; }
	public float ItemSpacing { get => itemSpacing; }
	public float ProductsScale { get => productsScale; set => productsScale = value; }
	public float DynamicSpacing { get => dynamicSpacing; }

	private void Start()
	{

		GetContentMenu();
		PlaceProduct();
		InitiliazeProductPositions();
	}

	private void GetContentMenu()
	{
		rectTransform = GetComponent<RectTransform>();
		products = new RectTransform[itemCount];
		height = rectTransform.rect.height;

	}

	private void PlaceProduct()
	{

		for (int i = 0; i < itemCount; i++)
		{
			GameObject productionItem = ActionManager.GetPoolItem?.Invoke(PoolItem.UIProductionItem, default, transform);
			BuildingButton productionButton = productionItem.GetComponent<BuildingButton>();
			productionButton.SetPreferences(i);
			products[i] = rectTransform.GetChild(i) as RectTransform;
			products[i].localScale = Vector3.one * ProductsScale;
		}

		productWidth = products[0].rect.width;
		productHeight = products[0].rect.height;

	}

	private void InitiliazeProductPositions()
	{
		float originY = 0 - (height * 0.5f);
		float posOffset = productHeight * 0.5f;
		float screenHeight = Screen.height;
		dynamicSpacing = itemSpacing * (screenHeight / 1080f);

		for (int i = 0; i < products.Length; i++)
		{
			Vector2 childPos = products[i].localPosition;
			childPos.x = 0;
			childPos.y = originY + posOffset + i * (productHeight + dynamicSpacing);
			products[i].localPosition = childPos;
		}
	}


}
