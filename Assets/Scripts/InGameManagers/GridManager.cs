using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoSingleton<GridManager>
{
	[SerializeField] private GridSettings gridSettings;

	private gridCell[,] gridArray;
	private TextMesh[,] textArray;

	private void Awake()
	{
		InitiliazeGrid();
	}

	private void SetArray()
	{
		gridArray = new gridCell[gridSettings.Width, gridSettings.Height];
		textArray = new TextMesh[gridSettings.Width, gridSettings.Height];
	}

	private void InitiliazeGrid()
	{
		SetArray();
		DeleteGrid();
		CreateGrid();
	}

	private void CreateGrid()
	{
		gridSettings.DrawGrid(GetWorldPosition, null, gridArray, textArray);
	}

	private void DeleteGrid()
	{
		//for (int i = textParent.childCount - 1; i >= 0; i--)
		//	DestroyImmediate(textParent.GetChild(0).gameObject);

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

	public gridCell GetGridObject(int x, int z)
	{
		if (x >= 0 && z >= 0 && x < gridSettings.Width && z < gridSettings.Height)
		{
			return gridArray[x, z];
		}
		else
		{
			return null;
		}
	}

	public List<Vector2Int> PlaceOnGrid(Vector2Int placedObjectPos, BuildingFeatures selectedFeature)
	{
		return selectedFeature.GetGridPositionList(placedObjectPos);
	}

	public bool CanBuild(Vector3 mousePos, BuildingFeatures selectedFeature)
	{

		GetXY(mousePos, out int x, out int y);

		Vector2Int placedObjectMousePos = new Vector2Int(x, y);

		List<Vector2Int> gridPositionList = PlaceOnGrid(placedObjectMousePos, selectedFeature);

		foreach (Vector2Int gridPosition in gridPositionList)
		{
			if (GetGridObject(gridPosition.x, gridPosition.y).CanBuild)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		return false;
	}
}
