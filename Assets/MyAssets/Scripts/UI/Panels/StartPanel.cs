using UnityEngine;
using UnityEngine.EventSystems;

public class StartPanel : MonoBehaviour, IPointerDownHandler
{
	private GameManager gameManager;

	private void Start()
	{
		gameManager = GameManager.instance;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		gameManager.GameStart?.Invoke();
		gameObject.SetActive(false);
	}
}
