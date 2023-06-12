using UnityEngine;

public class BuildingBaseController : MonoBehaviour
{
	//Setting this with instantiate
	private BuildingType type;

	public BuildingType Type { get => type; set => type = value; }

	private void OnMouseDown()
	{
		ActionManager.OnClickFromBuildingMenu?.Invoke(Type, transform);
	}
}
