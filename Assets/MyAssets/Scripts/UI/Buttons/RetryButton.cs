using UnityEngine.SceneManagement;

public class RetryButton : ButtonBaseController
{
	public override void OnClick()
	{
		base.OnClick();
		ActionManager.ResetAllStaticsVariables();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
