using UnityEngine;

interface IInteract
{
	void Interact();
}

interface ITarget
{
	void MarkYourself(Soldier soldier);
}

interface ISaveable
{
	object CaptureState();
	void RestoreState(object state);
}

public class Interfaces : MonoBehaviour
{

}
