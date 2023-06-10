using UnityEngine.SceneManagement;

public class NextLevelButton : ButtonBaseController
{
	public override void OnClick()
	{
		base.OnClick();
		PlayerPrefManager.ChangeLevel(1);
		ActionManager.ResetAllStaticsVariables();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
