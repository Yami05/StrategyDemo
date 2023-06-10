using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
	//[SerializeField] private bool test;

	//#region ForLevelSystem

	//[SerializeField] private LevelScriptableObject level;

	//private LevelScriptableObject currentLevel;

	//public LevelScriptableObject CurrentLevel { get => currentLevel; set => currentLevel = value; }
	//public int CurrentLevelIndex { get => currentLevelIndex; set => currentLevelIndex = value; }

	//private int currentLevelIndex = 0;

	//private string currentLevelName;
	//private int tempInt;

	//private void Awake()
	//{
	//	currentLevelIndex = (PlayerPrefs.GetInt(StringUtil.PREF_LEVEL) % Resources.LoadAll("LevelSO/").Length);
	//	tempInt = currentLevelIndex + 1;
	//	currentLevelName = StringUtil.LEVEL_SCRIPTABLE_PATH + tempInt;
	//	level = Resources.Load<LevelScriptableObject>(currentLevelName);

	//	CurrentLevel = level;
	//	if (!test)
	//		Instantiate(CurrentLevel.LevelPrefab);
	//}

	//#endregion

}
