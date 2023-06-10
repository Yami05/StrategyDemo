using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollContent : MonoBehaviour
{
	[SerializeField] private int itemCount;
	[SerializeField] private float productsScale;
	[SerializeField] private List<RectTransform> products = new List<RectTransform>();

	private RectTransform rectTransform;
	private VerticalLayoutGroup verticalLayoutGroup;

	private float height;
	private float productHeight;
	private float productWidth;
	private float itemSpacing;

	public float Height { get => height; }
	public float ProductHeight { get => productHeight; }
	public float ProductWidth { get => productWidth; }
	public float ItemSpacing { get => itemSpacing; }
	public List<RectTransform> Products { get => products; set => products = value; }

	private void Awake()
	{
		verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
		itemSpacing = verticalLayoutGroup.spacing;
	}

	private void Start()
	{

		GetContentMenu();
		InitProduct();
	}

	private void GetContentMenu()
	{

		rectTransform = GetComponent<RectTransform>();

		height = rectTransform.rect.height;
	}

	private void InitProduct()
	{

		for (int i = 0; i < itemCount; i++)
		{
			GameObject productionItem = ActionManager.GetPoolItem?.Invoke(PoolItems.UIProductionItem, default, transform);
			productionItem.gameObject.name = i.ToString();

			products.Add(productionItem.GetComponent<RectTransform>());
			Products[i].localScale = Vector3.one * productsScale;
		}

		productWidth = Products[0].rect.width;
		productHeight = Products[0].rect.height;

	}

	public void GetNewProduct(bool isPositive)
	{
		GameObject newItem = ActionManager.GetPoolItem?.Invoke(PoolItems.UIProductionItem, default, transform);
		RectTransform rectTransform = newItem.GetComponent<RectTransform>();
		rectTransform.localScale = Vector3.one * productsScale;

		if (isPositive)
		{
			Products.Add(rectTransform);
			rectTransform.SetSiblingIndex(products.Count - 1);
		}
		else
		{
			products.Insert(0, rectTransform);
			rectTransform.SetSiblingIndex(0);
		}

	}

}
