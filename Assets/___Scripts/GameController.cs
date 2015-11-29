using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	static int[] speeds = {1, 2, 4, 8};

	public GameObject cowSpawnPrefab;
	public Text timeScaleText;
	public Text leveltext;

	int speedIndex;
	int lvl;
	bool isPlaying;

	void Start ()
	{
		LevelOver ();
		InvokeRepeating ("CheckLevelOver", 1f, 1f);
	}

	void CreateSpawn (int x, int y, int maxSpawnCount)
	{
		GameObject clone = Instantiate (cowSpawnPrefab);
		clone.transform.SetParent (transform, false);
		clone.transform.position = new Vector2 (x, y);
		SpawnController controller = clone.GetComponent<SpawnController> ();
		controller.maxSpawnCount = maxSpawnCount;
	}
	
	public void StartNextLevel ()
	{
		isPlaying = true;

		CreateSpawn (-9, 1, lvl);
		CreateSpawn (-9, -1, lvl);
	}

	void CheckLevelOver ()
	{
		if (isPlaying && IsLevelOver ()) {
			LevelOver ();
		}
	}

	bool IsLevelOver ()
	{
		foreach (Transform cowSpawn in transform) {
			SpawnController controller = cowSpawn.GetComponent<SpawnController> ();
			if (!controller.IsEntirelyDone ()) {
				// found a controller that isn't done yet
				return false;
			}
		}
		
		// all controllers are done
		return true;
	}

	void LevelOver ()
	{
		isPlaying = false;
		SetTimeScaleIndex (0);

		lvl++;
		leveltext.text = "Lvl " + lvl;
	}

	public void ClickGoButton ()
	{
		if (isPlaying) {
			SetTimeScaleIndex ((this.speedIndex + 1) % speeds.Length);
		} else {
			StartNextLevel ();
		}
	}

	void SetTimeScaleIndex (int newSpeedIndex)
	{
		speedIndex = newSpeedIndex;
		Time.timeScale = speeds [newSpeedIndex];
		timeScaleText.text = "" + Time.timeScale + "x";
	}
}
