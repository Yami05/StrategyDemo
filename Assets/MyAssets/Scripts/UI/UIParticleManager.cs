using UnityEngine;

public class UIParticleManager : MonoBehaviour
{
	private Camera cam;

	private void Start()
	{
		cam = Camera.main;
		ActionManager.SetUIParticle += SetParticle;
	}

	private void SetParticle(Vector3 desiredPos, PoolItem poolItems)
	{
		GameObject particle = ActionManager.GetPoolItem?.Invoke(poolItems, desiredPos, transform.parent);
		particle.GetComponent<RectTransform>().localScale = Vector3.one;
		particle.GetComponent<RectTransform>().anchoredPosition = CalculatePosOfUIGem(desiredPos);
	}

	private Vector2 CalculatePosOfUIGem(Vector3 desiredPos)
	{
		RectTransform CanvasRect = transform.parent.GetComponent<RectTransform>();
		Vector2 viewPortPosition = cam.WorldToViewportPoint(desiredPos);
		return new Vector2(
			(viewPortPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f),
			(viewPortPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f));
	}
}
