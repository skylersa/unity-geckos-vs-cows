using UnityEngine;
using System.Collections;

public class MacheteController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position += new Vector3 (0f, 5f, 0f) * Time.deltaTime;

		float angle = 300f * Time.time; 
		transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
	}
}
