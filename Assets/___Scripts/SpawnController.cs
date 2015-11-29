using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{

	public int maxSpawnCount = 0;
	public GameObject[] prefab;
	public float rate = 1f;
	public float velocity = 1f;

	int spawned;

	void Start ()
	{
		InvokeRepeating ("Spawn", 0f, rate);
	}

	public bool IsEntirelyDone ()
	{
		return IsDoneSpawning () && transform.childCount == 0;
	}

	bool IsDoneSpawning ()
	{
		return maxSpawnCount > 0 && spawned >= maxSpawnCount;
	}

	void Spawn ()
	{
		if (!enabled) {
			return;
		}

		if (IsEntirelyDone ()) {
			StopAllCoroutines ();
			Destroy (gameObject);
			return;
		}

		if (!IsDoneSpawning ()) {
			++spawned;
			GameObject clone = Instantiate (prefab [0], transform.position, transform.rotation) as GameObject;
			clone.transform.parent = transform;
			clone.transform.rotation = Quaternion.identity;
			Rigidbody2D rb = clone.GetComponent<Rigidbody2D> ();
			rb.velocity = transform.up * velocity;
		}
	}
}
