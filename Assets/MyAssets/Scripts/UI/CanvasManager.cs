using UnityEngine;

public class CanvasManager : MonoSingleton<CanvasManager>
{
	[SerializeField] private GameObject gameOverPanel;
	[SerializeField] private GameObject winPanel;

	private GameManager gameManager;

	private void Start()
	{
		gameManager = GameManager.instance;
		gameManager.GameWin += () => winPanel.SetActive(true);
		gameManager.GameFail += () => gameOverPanel.SetActive(true);
	}
}
