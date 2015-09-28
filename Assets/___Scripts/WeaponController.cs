using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{

	public int durability = 1;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Enemy")) {
			EnemyController controller = other.gameObject.GetComponent<EnemyController> ();
			controller.TakeHit ();

			durability -= 1;
			if (durability <= 0) {
				Destroy (gameObject);
			}
		}
	}
	
	void Update ()
	{
		float angle = 300f * Time.time; 
		transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
	}
}
