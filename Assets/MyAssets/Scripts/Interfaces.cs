using UnityEngine;

interface IInteract
{
	void Interact();
}


interface ISaveable
{
	object CaptureState();
	void RestoreState(object state);
}

public class Interfaces : MonoBehaviour
{

}
