using UnityEngine;

public class AnimationController : MonoBehaviour
{
	private Animator anim;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	public void PlayAnim(AnimType type)
	{
		anim.SetInteger("animState", (int)type);
	}
}
