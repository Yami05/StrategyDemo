using UnityEngine;

public class CameraController : MonoBehaviour
{

	[SerializeField] private Vector3 offset;
	[SerializeField] private Transform target;

	private bool isFollow = true;

	private void OnEnable()
	{
		ActionManager.SetCameraTarget += SetTarget;
	}

	private void SetTarget(Transform target) => this.target = target;

	void FixedUpdate()
	{
		if (isFollow)
		{
			Vector3 desiredPos = target.position + offset;
			transform.position = Vector3.Lerp(transform.position, desiredPos, 0.2f);
		}
	}
}
