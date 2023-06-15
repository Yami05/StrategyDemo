using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfiniteScrollView : MonoBehaviour, IBeginDragHandler, IDragHandler
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

	private void Start()
	{
		ActionManager.OnBuildingCreated += (bool enable) => scrollRect.enabled = !enable;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		lastPosOfDrag = eventData.position;
	}


	public void OnDrag(PointerEventData eventData)
	{
		isPositiveDrag = eventData.position.y > lastPosOfDrag.y;

	}

	public void OnViewScroll()
	{
		CalculatePoses();
	}

	private void CalculatePoses()
	{
		Transform lastItem;

		float bound;
		float distance;

		if (isPositiveDrag)
		{
			lastItem = scrollContent.transform.GetChild(scrollContent.transform.childCount - 1);
			bound = upperBound.position.y;
			distance = bound - lastItem.position.y;
		}
		else
		{
			lastItem = scrollContent.transform.GetChild(0);
			bound = -lowerBound.position.y;
			distance = lastItem.position.y - bound;

		}

		SetNewPositions(distance);

	}

	private void SetNewPositions(float distance)
	{
		if (distance > 0.3f)
		{
			return;
		}

		int currItemIndex = isPositiveDrag ? scrollRect.content.childCount - 1 : 0;
		var currItem = scrollRect.content.GetChild(currItemIndex);

		int endItemIndex = isPositiveDrag ? 0 : scrollRect.content.childCount - 1;
		Transform endItem = scrollRect.content.GetChild(endItemIndex);
		Vector2 newPos = endItem.position;

		if (isPositiveDrag)
		{
			newPos.y = endItem.position.y - scrollContent.ProductHeight * 1.5f - scrollContent.DynamicSpacing;
		}
		else
		{
			newPos.y = endItem.position.y + scrollContent.ProductHeight * 1.5f + scrollContent.DynamicSpacing;
		}

		currItem.position = newPos;
		currItem.SetSiblingIndex(endItemIndex);

	}

}
