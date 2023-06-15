using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{

	public bool ExecuteGame { get => executeGame; set => executeGame = value; }

	public Action GameStart { get; set; }
	public Action GameWin { get; set; }
	public Action GameFail { get; set; }

	private bool executeGame = false;

	private void Awake()
	{
		Application.targetFrameRate = 60;

		GameStart += InitiliazeGame;
		GameWin += GameEndWin;
		GameFail += GameEndFail;
	}

#if UNITY_EDITOR
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
			RestartLevel();

		if (Input.GetKeyDown(KeyCode.N))
			NextLevel();

		if (Input.GetKeyDown(KeyCode.B))
			PreviousLevel();
	}
#endif

	private void InitiliazeGame()
	{
		executeGame = true;
	}

	private void GameEnd()
	{
		executeGame = false;
	}

	private void GameEndWin()
	{
		GameEnd();
		NextLevel();
	}

	private void GameEndFail()
	{
		GameEnd();
	}

	private void PreviousLevel()
	{
		PlayerPrefManager.ChangeLevel(-1);
		RestartLevel();
	}

	private void NextLevel()
	{
		PlayerPrefManager.ChangeLevel(1);
		RestartLevel();
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(StringUtil.SCENE_NAME);
	}

}
