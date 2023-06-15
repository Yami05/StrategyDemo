using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanel : MonoBehaviour
{
	[SerializeField] private GameObject productionPart;
	[SerializeField] private Image photo;
	[SerializeField] private Transform closePoint;
	[SerializeField] private Transform openPoint;
	[SerializeField] private GameObject nameOfBuilding;

	private BuildingManager buildingManager;
	private TextMeshProUGUI nameOfBuild;

	private bool canProduce;

	private void Awake()
	{
		nameOfBuild = nameOfBuilding.GetComponent<TextMeshProUGUI>();
	}

	private void Start()
	{
		buildingManager = BuildingManager.instance;
		SetPos(false);
		ActionManager.OnBuildingCreated += (bool a) => SetPos(false);
		ActionManager.OnClickFromBuildingMenu += FillInformations;
		ActionManager.OnEmptyClick += () => SetPos(false);
	}

	private void SetPos(bool isClickled)
	{
		float xPoint;

		if (isClickled)
		{
			xPoint = openPoint.position.x;

		}
		else
		{
			xPoint = closePoint.position.x;

		}


		transform.GetChild(0).DOMoveX(xPoint, 1, isClickled).SetId(GetHashCode());

	}

	private void FillInformations(BuildingType buildingType, Transform buildingPosition)
	{
		SetPos(true);
		BuildingFeatures buildingFeature = buildingManager.GetBuilding(buildingType);
		photo.sprite = buildingFeature.GetUIPhoto();
		nameOfBuild.text = buildingFeature.NameOfBuilding;

		canProduce = buildingFeature.CanProduce;

		if (canProduce)
		{
			ProductionPanel productionPanel = productionPart.GetComponent<ProductionPanel>();
			productionPanel.ProductionBuilding = buildingPosition;
			productionPanel.Products = buildingFeature.ProductFeatures;

		}

		productionPart.SetActive(canProduce);

	}
}
