using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	private float seconds = 0.0f;
	private float minutes = 0.0f;
	private float hours = 0.0f;

	public Text clockText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		UpdateText ();
		seconds += Time.deltaTime;
		if(seconds > 60)
		{
			minutes += 1;
			seconds = 0;
		}
		if(minutes > 60)
		{
			hours += 1;
			minutes = 0;
		}
			//print("Hours: " + hours + " " + "Minutes: " + minutes + " " + "Seconds" + seconds);
	}

	void UpdateText()
	{
		int sec = (int)seconds;
        clockText.text = minutes.ToString("00") + ":" + sec.ToString("00");

	}
}
