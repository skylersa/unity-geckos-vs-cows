using UnityEngine;
using System.Collections;

public class GoButtonController : MonoBehaviour {

	private int speedLevel;

	public void ClickGoButton () {
		speedLevel = (speedLevel + 1) % 4;
		Time.timeScale = Mathf.Pow(2, speedLevel);
	}
}
