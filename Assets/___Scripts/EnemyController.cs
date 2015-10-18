using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public GameObject explosionprefab;
	public int hitpoints = 1;

	TextMesh textmesh;

	void UpdateText ()
	{
		textmesh.text = string.Format ("{0}", hitpoints);
	}

	public void TakeHit ()
	{
		if (--hitpoints <= 0) {
			GameObject clone = Instantiate (explosionprefab);
			clone.transform.position = transform.position;
			Destroy (gameObject);
		} else {
			UpdateText ();
		}
		MoneyTextController.AddMoney (1);
	}

	void Update ()
	{
	}

	void Start ()
	{
		textmesh = transform.GetChild (0).GetComponent<TextMesh> ();
		UpdateText ();
	}	

}
