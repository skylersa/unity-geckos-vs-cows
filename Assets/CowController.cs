using UnityEngine;
using System.Collections;

public class CowController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (5f, 0f, 0f) * Time.deltaTime;
	}
}
