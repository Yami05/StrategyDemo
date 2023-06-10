using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager : MonoSingleton<GridManager>
{
	[SerializeField] private GridSettings gridSettings;
	[SerializeField] private Transform textParent;

	private int[,] gridArray;
	private TextMesh[,] textArray;

	private void Awake()
	{
		InitiliazeGrid();
	}

	private void SetArray()
	{
		gridArray = new int[gridSettings.Width, gridSettings.Height];
		textArray = new TextMesh[gridSettings.Width, gridSettings.Height];
	}


#if UNITY_EDITOR

	[Button]
	private void InitiliazeGrid()
	{
		SetArray();
		DeleteGrid();
		CreateGrid();
	}

	private void CreateGrid()
	{
		gridSettings.DrawGrid(GetWorldPosition, textParent, gridArray, textArray);
	}

	private void DeleteGrid()
	{
		for (int i = textParent.childCount - 1; i >= 0; i--)
			DestroyImmediate(textParent.GetChild(0).gameObject);

	}

	public Vector3 GetWorldPosition(int x, int y)
	{
		return new Vector3(x, y) * gridSettings.CellSize;
	}

	public void GetXY(Vector3 worldPosition, out int x, out int y)
	{
		x = Mathf.FloorToInt(worldPosition.x) / gridSettings.CellSize;
		y = Mathf.FloorToInt(worldPosition.y) / gridSettings.CellSize;
	}


	//public void SetValue(int x, int y, int value)
	//{
	//	gridArray[x, y] = value;
	//	//textArray[x, y].text = gridArray[x, y].ToString();

	//}

	//public void SetValue(Vector3 worldPosition, int value)
	//{
	//	int x, y;
	//	GetXY(worldPosition, out x, out y);
	//	SetValue(x, y, value);

	//}

	public int GetGridObject(int x, int z)
	{
		if (x >= 0 && z >= 0 && x < gridSettings.Width && z < gridSettings.Height)
		{
			return gridArray[x, z];
		}
		else
		{
			return 0;
		}
	}

#endif

}
