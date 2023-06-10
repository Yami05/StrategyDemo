using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBaseController : MonoBehaviour
{
	protected Button myButton;

	protected Vector3 initialScale;

	protected virtual void Awake()
	{
		myButton = GetComponent<Button>();
		myButton.onClick.AddListener(OnClick);

		initialScale = transform.localScale;
	}

	public virtual void OnClick()
	{

	}

	public virtual void ScaleDown()
	{
		transform.DOScale(0, 0.25f).SetEase(Ease.InBack);
	}

	public virtual void ScaleUp()
	{
		transform.DOScale(initialScale, 0.25f).SetEase(Ease.OutBack);
	}
}
