using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/BuildingFeatures")]
public class BuildingFeatures : ScriptableObject
{
	[ShowIf("@canProduce != false")]
	[SerializeField] private ProductFeatures[] productFeatures;
	[SerializeField] private GameObject buildingPrefab;

	[SerializeField] private BuildingType buildingType;

	[SerializeField] private float health;
	[SerializeField] private bool canProduce;
	[SerializeField] private string nameOfBuilding;

	private float width;
	private float height;

	#region Encaps
	public BuildingType BuildingType { get => buildingType; }
	public string NameOfBuilding { get => nameOfBuilding; }
	public bool CanProduce { get => canProduce; }
	public GameObject BuildingPrefab { get => buildingPrefab; }
	public ProductFeatures[] ProductFeatures { get => productFeatures; set => productFeatures = value; }
	public float Health { get => health; }
	#endregion


	public GameObject GetBuilding()
	{
		GameObject building = Instantiate(buildingPrefab);
		BuildingBaseController buildingBase = building.GetComponent<BuildingBaseController>();
		buildingBase.Feature = this;
		buildingBase.Type = buildingType;
		Vector3 localScale = building.transform.GetChild(0).localScale;
		width = localScale.x;
		height = localScale.y;
		return building;
	}

	public Sprite GetUIPhoto()
	{
		return buildingPrefab.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
	}

	public List<Vector2Int> GetGridPositionList(Vector2Int offset)
	{
		List<Vector2Int> gridPositionList = new List<Vector2Int>();

		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				gridPositionList.Add(offset + new Vector2Int(x, y));
			}
		}

		return gridPositionList;
	}

}
