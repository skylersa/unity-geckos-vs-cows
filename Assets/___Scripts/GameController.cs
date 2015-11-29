using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	public Text leveltext;

	SpawnController[] cowSpawns;
	int lvl;

	public void NextLevel ()
	{
		lvl++;
		leveltext.text = "Lvl " + lvl;

		foreach (SpawnController controller in cowSpawns) {
			controller.spawncount = lvl;
		}
	}

	void Start ()
	{
		leveltext.text = "";
		cowSpawns = GetComponentsInChildren<SpawnController> ();
	}
	
	void Update ()
	{
	
	}
}
