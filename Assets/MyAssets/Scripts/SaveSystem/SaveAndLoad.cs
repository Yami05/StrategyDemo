using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
	private string SavePath => $"{Application.persistentDataPath}/save.txt";

	private void Awake()
	{
		ActionManager.Save += Save;
		ActionManager.Load += Load;
	}


	[ContextMenu("Save")]
	private void Save()
	{
		var state = LoadFile();
		CaptureState(state);
		SaveFile(state);
	}

	[ContextMenu("Load")]
	private void Load()
	{
		var state = LoadFile();
		RestoreState(state);
	}

	[ContextMenu("Resets")]
	private void Resets()
	{
		PlayerPrefs.DeleteAll();
		if (File.Exists(SavePath))
		{
			File.Delete(SavePath);
		}
	}

	private Dictionary<string, object> LoadFile()
	{
		if (!File.Exists(SavePath))
		{
			return new Dictionary<string, object>();
		}

		using (FileStream stream = File.Open(SavePath, FileMode.Open))
		{
			var formatter = new BinaryFormatter();
			return (Dictionary<string, object>)formatter.Deserialize(stream);
		}
	}

	private void SaveFile(object state)
	{
		using (var stream = File.Open(SavePath, FileMode.Create))
		{
			var formatter = new BinaryFormatter();
			formatter.Serialize(stream, state);
		}
	}

	private void CaptureState(Dictionary<string, object> state)
	{
		foreach (var saveable in FindObjectsOfType<SaveableEntity>())
		{
			state[saveable.Id] = saveable.CaptureState();
		}
	}

	private void RestoreState(Dictionary<string, object> state)
	{
		foreach (var saveable in FindObjectsOfType<SaveableEntity>())
		{
			if (state.TryGetValue(saveable.Id, out object value))
			{
				saveable.RestoreState(value);
			}
		}
	}

}
