﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoButtonController : MonoBehaviour
{
	public Text timeScaleText;
	public GameObject spawns;
	public GameController gameController;

	private static int[] speeds = {0, 1, 2, 4, 8};
	private int speedIndex;

	void Start ()
	{
		UpdateTimeScale (0);
	}

	void UpdateTimeScale (int index)
	{
		Time.timeScale = speeds [index];
		timeScaleText.text = "" + Time.timeScale + "x";
	}

	public void ClickGoButton ()
	{
		if (Time.timeScale == 0) {
			gameController.NextLevel ();
		}
		speedIndex = (speedIndex + 1) % speeds.Length;
		if (speedIndex == 0) {
			speedIndex++;
		}
		UpdateTimeScale (speedIndex);
	}
}
