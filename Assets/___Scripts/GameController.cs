using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	static int[] speeds = {0, 1, 2, 4, 8};

	public GameObject cowSpawnPrefab;
	public Text timeScaleText;
	public Text leveltext;

	int speedIndex;
	int lvl;

	void Start ()
	{
		leveltext.text = "";
		SetTimeScaleIndex (0);
	}

	void CreateSpawn (int x, int y, int maxSpawnCount)
	{
		GameObject clone = Instantiate (cowSpawnPrefab);
		clone.transform.SetParent (transform, false);
		clone.transform.position = new Vector2 (x, y);
		SpawnController controller = clone.GetComponent<SpawnController> ();
		controller.maxSpawnCount = maxSpawnCount;
	}
	
	public void NextLevel ()
	{
		lvl++;
		leveltext.text = "Lvl " + lvl;

		CreateSpawn (-9, 1, lvl);
		CreateSpawn (-9, -1, lvl);


		InvokeRepeating ("CheckLevelOver", 1f, 1f);
	}

	void CheckLevelOver ()
	{
		foreach (Transform cowSpawn in transform) {
			SpawnController controller = cowSpawn.GetComponent<SpawnController> ();
			if (!controller.IsEntirelyDone ()) {
				// found a controller that isn't done yet
				return;
			}
		}

		// all controllers are done
		LevelOver ();
	}

	void LevelOver ()
	{
		SetTimeScaleIndex (0);
	}

	public void ClickGoButton ()
	{
		if (Time.timeScale == 0) {
			NextLevel ();
		}
		int newSpeedIndex = (this.speedIndex + 1) % speeds.Length;
		if (newSpeedIndex == 0) {
			newSpeedIndex++;
		}
		SetTimeScaleIndex (newSpeedIndex);
	}

	void SetTimeScaleIndex (int newSpeedIndex)
	{
		speedIndex = newSpeedIndex;
		Time.timeScale = speeds [newSpeedIndex];
		timeScaleText.text = "" + Time.timeScale + "x";
	}
}
