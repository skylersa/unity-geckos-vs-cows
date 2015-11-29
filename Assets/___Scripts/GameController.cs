using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	public Text leveltext;

	int lvl;

	public void NextLevel ()
	{
		lvl++;
		leveltext.text = "Lvl " + lvl;
	}

	// Use this for initialization
	void Start ()
	{
		leveltext.text = "";

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
