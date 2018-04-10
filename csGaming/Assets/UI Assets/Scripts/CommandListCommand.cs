using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandListCommand : MonoBehaviour {

	[SerializeField]
	private Text myText;

	public void SetText(string textString)
	{
			myText.text = textString;

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
