using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoSingleton<GridManager>
{
	[SerializeField] private GridSettings gridSettings;

	private GridCell[,] gridArray;

	private void Awake()
	{
		InitiliazeGrid();
	}

	private void InitiliazeGrid()
	{
		SetArray();
	}

	private void SetArray()
	{
		gridArray = new GridCell[gridSettings.Width, gridSettings.Height];

		for (int x = 0; x < gridSettings.Width; x++)
		{
			for (int y = 0; y < gridSettings.Height; y++)
			{
				gridArray[x, y] = new GridCell();
			}
		}
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

		if (x >= 0 && y >= 0 && x < gridSettings.Width && y < gridSettings.Height)
		{
			Vector2Int placedObjectMousePos = new Vector2Int(x, y);
			return selectedFeature.GetGridPositionList(placedObjectMousePos);

		}

		return null;

	}

	public bool CheckCanBuild(Vector3 mousePos, BuildingFeatures selectedFeature)
	{

		List<Vector2Int> gridPositionList = GetBuildingPlaceOnGrid(mousePos, selectedFeature);

		if (gridPositionList == null)
			return false;



		foreach (Vector2Int gridPosition in gridPositionList)
		{

			GridCell grid = GetGridObject(gridPosition.x, gridPosition.y);

			if (grid == null || !grid.CanBuild)
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

	#region VisualPart


	public void GridPreview(Vector3 mousePos, BuildingFeatures selectedFeature)
	{

		CloseGridPreview();

		List<Vector2Int> gridPositionList = GetBuildingPlaceOnGrid(mousePos, selectedFeature);
		Color gridColor;

		if (CheckCanBuild(mousePos, selectedFeature))
		{
			gridColor = Color.green;
		}
		else
		{
			gridColor = Color.red;
		}

		if (gridPositionList == null)
			return;


		foreach (Vector2Int gridPosition in gridPositionList)
		{
			Vector3 grid3D = new Vector3(gridPosition.x, gridPosition.y, -0.1f);
			GridCell gridCell = GetGridObject(gridPosition.x, gridPosition.y);

			if (gridCell.IsColored)
				return;

			GameObject gridPreview = ActionManager.GetPoolItem?.Invoke(PoolItem.GridCellPreview, grid3D, null);
			SpriteRenderer spriteRenderer = gridPreview.GetComponentInChildren<SpriteRenderer>();
			spriteRenderer.sprite = ActionManager.SetSprite?.Invoke(AtlasSprites.Square);
			spriteRenderer.material.color = gridColor;
			activeGridPreviews.Add(gridPreview);
		}
	}


	private List<GameObject> activeGridPreviews = new List<GameObject>();

	public void CloseGridPreview()
	{
		foreach (GameObject gridPreview in activeGridPreviews)
		{
			GridCell gridCell = GetGridObject((int)gridPreview.transform.position.x, (int)gridPreview.transform.position.y);
			gridCell.IsColored = false;

			ActionManager.ReturnToPool?.Invoke(gridPreview, PoolItem.GridCellPreview, 0);
		}

		activeGridPreviews.Clear();
	}


	#endregion
}
