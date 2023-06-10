using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoSingleton<GridManager>
{
	[SerializeField] private GridSettings gridSettings;

	private GridCell[,] gridArray;
	private TextMesh[,] textArray;

	private void Awake()
	{
		InitiliazeGrid();
	}

	private void SetArray()
	{
		gridArray = new GridCell[gridSettings.Width, gridSettings.Height];
		textArray = new TextMesh[gridSettings.Width, gridSettings.Height];

		for (int x = 0; x < gridSettings.Width; x++)
		{
			for (int y = 0; y < gridSettings.Height; y++)
			{
				gridArray[x, y] = new GridCell();
			}
		}
	}

	private void InitiliazeGrid()
	{
		SetArray();
		DrawGrid();
	}

	private void DrawGrid()
	{
		gridSettings.DrawGrid(GetWorldPosition, null, gridArray, textArray);
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

	public GridCell GetGridObject(int x, int z)
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

	private List<Vector2Int> GetBuildingPlaceOnGrid(Vector3 mousePos, BuildingFeatures selectedFeature)
	{
		GetXY(mousePos, out int x, out int y);

		Vector2Int placedObjectMousePos = new Vector2Int(x, y);

		return selectedFeature.GetGridPositionList(placedObjectMousePos);
	}

	public bool CheckCanBuild(Vector3 mousePos, BuildingFeatures selectedFeature)
	{
		List<Vector2Int> gridPositionList = GetBuildingPlaceOnGrid(mousePos, selectedFeature);

		foreach (Vector2Int gridPosition in gridPositionList)
		{

			GridCell grid = GetGridObject(gridPosition.x, gridPosition.y);

			if (!grid.CanBuild)
			{
				return false;
			}
		}

		return true;
	}

	public void SetCanBuild(Vector3 mousePos, BuildingFeatures selectedFeature)
	{
		List<Vector2Int> gridPositionList = GetBuildingPlaceOnGrid(mousePos, selectedFeature);

		foreach (Vector2Int gridPosition in gridPositionList)
		{
			GridCell grid = GetGridObject(gridPosition.x, gridPosition.y);

			grid.CanBuild = false;
		}

	}
}
