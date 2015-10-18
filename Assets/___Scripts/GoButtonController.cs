using UnityEngine;
using System.Collections;

public class GoButtonController : MonoBehaviour
{

	public GameObject spawns;
	private int speedLevel;

	void Start ()
	{
		spawns.SetActive (false);
	}

	public void ClickGoButton ()
	{
		spawns.SetActive (true);
		speedLevel = (speedLevel + 1) % 4;
		Time.timeScale = Mathf.Pow (2, speedLevel);
	}
}
