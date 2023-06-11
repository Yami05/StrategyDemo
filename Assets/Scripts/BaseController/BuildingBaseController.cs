using UnityEngine;

public class BuildingBaseController : MonoBehaviour
{
	//Setting this with instantieate
	private BuildingType type;

	public BuildingType Type { get => type; set => type = value; }

	private void OnMouseDown()
	{
		ActionManager.OnClickUIBuilding?.Invoke(Type);
	}
}
