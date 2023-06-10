using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfiniteScrollView : MonoBehaviour, IBeginDragHandler, IDragHandler, IScrollHandler
{
	[SerializeField] private Transform content;
	[SerializeField] private Transform lowerBound, upperBound;

	private ScrollRect scrollRect;
	private ScrollContent scrollContent;

	private Vector2 lastPosOfDrag;

	private bool isPositiveDrag;

	private void Awake()
	{
		scrollContent = GetComponentInChildren<ScrollContent>();
		scrollRect = GetComponent<ScrollRect>();

	}


	public void OnBeginDrag(PointerEventData eventData)
	{
		lastPosOfDrag = eventData.position;
	}

	public void OnDrag(PointerEventData eventData)
	{
		isPositiveDrag = eventData.position.y > lastPosOfDrag.y;

		CalculatePoses();

	}

	private void CalculatePoses()
	{

		float lowerBoundY = lowerBound.position.y;
		float upperBoundY = upperBound.position.y;

		Transform onBorderProduct;
		List<RectTransform> products = scrollContent.Products;

		int newIndex;

		if (isPositiveDrag)
		{
			onBorderProduct = scrollContent.transform.GetChild(0);
			newIndex = products.Count - 1;
		}
		else
		{
			onBorderProduct = scrollContent.transform.GetChild(scrollContent.transform.childCount - 1);
			newIndex = 0;
		}

		float distance = isPositiveDrag ? upperBoundY - onBorderProduct.position.y : onBorderProduct.position.y - lowerBoundY;

		if (distance <= 0.3f)
		{
			GameObject lastItem = onBorderProduct.gameObject;
			print(lastItem.name);

			if (isPositiveDrag)
			{
				onBorderProduct.SetSiblingIndex(products.Count - 1);
			}
			else
			{
				onBorderProduct.SetSiblingIndex(0);
			}

			//ActionManager.ReturnToPool?.Invoke(onBorderProduct.gameObject, PoolItems.UIProductionItem, 0);

			//scrollContent.GetNewProduct(isPositiveDrag);

			//if (isPositiveDrag)
			//{
			//	desiredPos.y = products[newIndex].position.y + scrollContent.ProductHeight * 1.5f;
			//}
			//else
			//{
			//	desiredPos.y = products[newIndex].position.y - scrollContent.ProductHeight * 1.5f;
			//}

		}

	}


	public void OnScroll(PointerEventData eventData)
	{
		isPositiveDrag = eventData.scrollDelta.y > 0;
	}

	//private bool ReachedThreshold(Transform item)
	//{

	//	//float posYThreshold = transform.position.y + scrollContent.Height * 0.5f + outOfBound;
	//	//float negYThreshold = transform.position.y - scrollContent.Height * 0.5f - outOfBound;

	//	//return isPositiveDrag ? item.position.y - scrollContent.ProductWidth * 0.5f > posYThreshold :
	//	//	item.position.y + scrollContent.ProductWidth * 0.5f < negYThreshold;

	//}

	private void HandleVerticalScroll()
	{
		int currItemIndex = isPositiveDrag ? scrollRect.content.childCount - 1 : 0;
		Transform currItem = scrollRect.content.GetChild(currItemIndex);

		//if (!ReachedThreshold(currItem))
		//{
		//	return;
		//}


		int endItemIndex = isPositiveDrag ? scrollRect.content.childCount - 1 : 0;
		Transform endItem = scrollRect.content.GetChild(endItemIndex);
		Vector2 newPos = endItem.position;
		//ActionManager.ReturnToPool?.Invoke(endItem.gameObject, PoolItems.UIProductionItem, 0.0f);

		//print(endItem.gameObject.name + " " + "endItem");
		//print(currItem.gameObject.name + " " + "currItem");

		if (isPositiveDrag)
		{
			newPos.y = endItem.position.y + scrollContent.ProductHeight * 1.5f + scrollContent.ItemSpacing;
		}
		else
		{
			newPos.y = endItem.position.y - scrollContent.ProductHeight * 1.5f - scrollContent.ItemSpacing;
		}

		currItem.position = newPos;
		currItem.SetSiblingIndex(endItemIndex);
	}

}
