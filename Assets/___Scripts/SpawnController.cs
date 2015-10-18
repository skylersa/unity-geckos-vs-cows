using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{

	public int spawncount = 10;
	public GameObject[] prefab;
	public float rate = 1f;
	public float velocity = 1f;

	private int spawned;
	void Start ()
	{
		InvokeRepeating ("Spawn", 0f, rate);
	}
	
	void Spawn ()
	{
		if (!enabled) {
			return;
		}
		if (++spawned > spawncount) {
			StopAllCoroutines ();
			return;
		}

		GameObject clone = Instantiate (prefab [0], transform.position, transform.rotation) as GameObject;
		clone.transform.parent = transform;
		clone.transform.rotation = Quaternion.identity;
		Rigidbody2D rb = clone.GetComponent<Rigidbody2D> ();
		rb.velocity = transform.up * velocity;
	}
}
