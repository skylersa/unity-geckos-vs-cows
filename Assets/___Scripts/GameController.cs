using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject cowSpawnPrefab;
	public Text leveltext;

	int lvl;

	void Start ()
	{
		leveltext.text = "";
	}

	void CreateSpawn (int x, int y, int spawnCount)
	{
		GameObject clone = Instantiate (cowSpawnPrefab);
		clone.transform.SetParent (transform, false);
		clone.transform.position = new Vector2 (x, y);
		SpawnController controller = clone.GetComponent<SpawnController> ();
		controller.spawncount = spawnCount;
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
		Time.timeScale = 0;
	}

}
