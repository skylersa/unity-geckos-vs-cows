using UnityEngine;
using System.Collections;

public class SelfDestructController : MonoBehaviour
{
	public int delaySeconds = 1;

	void Start ()
	{
		Invoke ("SelfDestruct", delaySeconds);
	}

	void SelfDestruct ()
	{
		Destroy (this);
	}
}