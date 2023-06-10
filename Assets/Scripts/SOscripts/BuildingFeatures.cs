using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/BuildingFeatures")]
public class BuildingFeatures : ScriptableObject
{
	[ShowIf("@canProduce != false")]
	[SerializeField] private ProductFeatures[] productFeatures;
	[SerializeField] private GameObject buildingPrefab;
	[SerializeField] private Sprite UIPhoto;

	[SerializeField] private BuildingType buildingType;

	[SerializeField] private float health;
	[SerializeField] private bool canProduce;
	[SerializeField] private string nameOfBuilding;

	public BuildingType BuildingType { get => buildingType; }
	public Sprite UIPhoto1 { get => UIPhoto; }
	public string NameOfBuilding { get => nameOfBuilding; }
	public bool CanProduce { get => canProduce; }
	public GameObject BuildingPrefab { get => buildingPrefab; }


	public GameObject GetBuilding()
	{
		return Instantiate(buildingPrefab);
	}
}
