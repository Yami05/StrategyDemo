using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoSingleton<GridManager>
{
	[SerializeField] private GridSettings gridSettings;

	[SerializeField] List<GameObject> displayedObjects = new List<GameObject>();


	private GridCell[,] gridArray;
	private TextMesh[,] textArray;

	private void Awake()
	{
		InitiliazeGrid();
	}

	private void InitiliazeGrid()
	{
		SetArray();
		DrawGrid();
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
			Vector3 vector3 = new Vector3(gridPosition.x, gridPosition.y, 0f);

			GridCell grid = GetGridObject(gridPosition.x, gridPosition.y);

			if (grid == null || !grid.CanBuild)
			{

				SetColor(vector3, false);
				return false;
			}
			else
			{

				SetColor(vector3, true);

			}

		}

		ClosePreviewCell(gridPositionList);
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
	private void SetColor(Vector3 gridPos, bool isAvailable)
	{
		GridCell gridCell = GetGridObject((int)gridPos.x, (int)gridPos.y);

		if (gridCell.IsColored == true)
			return;


		GameObject previewObj = ActionManager.GetPoolItem?.Invoke(PoolItem.GridCellPreview, gridPos, null);
		gridCell.IsColored = true;

		Color selectedColor;

		if (isAvailable)
		{
			selectedColor = Color.green;
		}
		else
		{
			selectedColor = Color.red;
		}

		previewObj.GetComponentInChildren<SpriteRenderer>().color = selectedColor;

		if (!displayedObjects.Contains(previewObj))
		{
			displayedObjects.Add(previewObj);
		}
	}

	private void ClosePreviewCell(List<Vector2Int> gridPositionList)
	{

		foreach (GameObject obj in displayedObjects)
		{
			Vector2Int objPos = new Vector2Int((int)obj.transform.position.x, (int)obj.transform.position.y);
			GridCell grid = GetGridObject(objPos.x, objPos.y);

			if (!gridPositionList.Contains(objPos))
			{
				// Return the object to the pool
				ActionManager.ReturnToPool?.Invoke(obj, PoolItem.GridCellPreview, 0);

			}

			grid.IsColored = false;
		}

	}

	private void DrawGrid()
	{
		gridSettings.DrawGrid(GetWorldPosition, null, gridArray, textArray);
	}
	#endregion
}
