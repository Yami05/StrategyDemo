using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingButton : ButtonBaseController, IPointerDownHandler
{
	[SerializeField] private BuildingType buildingType;

	private BuildingManager buildingManager;
	private Image image;

	protected override void Awake()
	{
		base.Awake();
		image = GetComponent<Image>();
		buildingManager = BuildingManager.instance;

	}

	public void SetPreferences(int i)
	{
		buildingType = (BuildingType)i;

		BuildingFeatures buildingFeature = buildingManager.GetBuilding(buildingType);

		image.sprite = buildingFeature.UIPhoto1;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		ActionManager.OnClickUIBuilding?.Invoke(buildingType);

	}
}
