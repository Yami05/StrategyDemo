using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/GridSettings")]
public class GridSettings : ScriptableObject
{
	[SerializeField] private int width;
	[SerializeField] private int height;
	[SerializeField] private int cellSize;

	public int Width { get => width; }
	public int Height { get => height; }
	public int CellSize { get => cellSize; }

	public void DrawGrid(Func<int, int, Vector3> GetWorldPosition, Transform textParent, GridCell[,] gridArray, TextMesh[,] textArray)
	{

		for (int x = 0; x < gridArray.GetLength(0); x++)
			for (int y = 0; y < gridArray.GetLength(1); y++)
			{
				//textArray[x, y] = Utilities.CreateWorldText(gridArray[x, y].ToString(), textParent,
				//	GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f, 20, Color.white);

				Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100);
				Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100);
			}

		Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100);
		Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100);
	}

}

public class GridCell
{
	private bool canBuild = true;

	public bool CanBuild { get => canBuild; set => canBuild = value; }
}
