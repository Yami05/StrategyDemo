using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoSingleton<BuildingManager>
{
	[SerializeField] private List<BuildingFeatures> buildingFeatures = new List<BuildingFeatures>();

	public List<BuildingFeatures> BuildingFeatures { get => buildingFeatures; set => buildingFeatures = value; }


	public BuildingFeatures GetBuilding(BuildingType buildingType)
	{
		return BuildingFeatures.Find(x => x.BuildingType == buildingType);

	}
}
