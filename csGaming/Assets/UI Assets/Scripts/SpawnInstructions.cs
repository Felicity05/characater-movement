using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnInstructions : MonoBehaviour {

	public Button moveRight;
	public Button moveLeft;
	public Button moveUp;
	public Button moveDown;
	public Button repeat;
	public GameObject commandPrefab; 
	public GameObject repeatPrefab; 
	public string text;
	//public Canvas background;
	//public Button commands;
	//public Button[] removeButtons;
	//public Button[] editButtons;

	void Start()
	{
		Debug.Log ("You have started");

		Button moveRightButton = moveRight.GetComponent<Button>();
		moveRight.onClick.AddListener(MoveRight);

		Button moveLeftButton = moveLeft.GetComponent<Button>();
		moveLeftButton.onClick.AddListener(MoveLeft);

		Button moveUpButton = moveUp.GetComponent<Button>();
		moveUpButton.onClick.AddListener(MoveUp);

		Button moveDownButton = moveDown.GetComponent<Button>();
		moveDownButton.onClick.AddListener(MoveDown);

		//Button rpt = repeat.GetComponent<Button>();
		//rpt.onClick.AddListener(Loop);

	}

	void Update()
	{
		
	}

	 public void MoveRight()
	{
		Debug.Log ("You have clicked the move right button");

		/* This part was bugging at times CAREFUL */

		//text field will only be empty at the beginning of the game, after the first
		//command has been printed, text field will be populated and mark that the first
		//command button's text has been filled
		/*if (text.Equals ("")) {
			Debug.Log ("Empty");
			commandPrefab.GetComponent<CommandListCommand> ().SetText ("Player.MoveRight()");
			text = "Not empty";
			GameObject command = Instantiate (commandPrefab) as GameObject;
			command.SetActive (true);
			command.name = "MoveRight()";
			command.GetComponent<CommandListCommand> ().SetText ("Player.MoveRight()");
			command.transform.SetParent (commandPrefab.transform.parent, false);
		} else {
		*/
			GameObject command = Instantiate (commandPrefab) as GameObject;
			command.SetActive (true);
			command.name = "MoveRight()";
			command.GetComponent<CommandListCommand> ().SetText ("Player.MoveRight()");
			command.transform.SetParent (commandPrefab.transform.parent, false);

	}


	public void MoveLeft()
	{
		Debug.Log ("You have clicked the move left button");

		//text field will only be empty at the beginning of the game, after the first
		//command has been printed, text field will be populated and mark that the first
		//command button's text has been filled
		/*if (text.Equals ("")) {
			Debug.Log ("Empty");
			commandPrefab.GetComponent<CommandListCommand> ().SetText ("Player.MoveLeft()");
			text = "Not empty";
			GameObject command = Instantiate (commandPrefab) as GameObject;
			command.SetActive (true);
			command.GetComponent<CommandListCommand> ().SetText ("Player.MoveLeft()");
			command.transform.SetParent (commandPrefab.transform.parent, false);
		} else {*/
			GameObject command = Instantiate (commandPrefab) as GameObject;
			command.SetActive (true);
			command.name = "MoveLeft()";
			command.GetComponent<CommandListCommand> ().SetText ("Player.MoveLeft()");
			command.transform.SetParent (commandPrefab.transform.parent, false);


	}

	public void MoveUp()
	{
		Debug.Log ("You have clicked the move up button");

		//text field will only be empty at the beginning of the game, after the first
		//command has been printed, text field will be populated and mark that the first
		//command button's text has been filled
		/*if (text.Equals ("")) {
			Debug.Log ("Empty");
			commandPrefab.GetComponent<CommandListCommand> ().SetText ("Player.MoveUp()");
			text = "Not empty";
			GameObject command = Instantiate (commandPrefab) as GameObject;
			command.SetActive (true);
			command.GetComponent<CommandListCommand> ().SetText ("Player.MoveUp()");
			command.transform.SetParent (commandPrefab.transform.parent, false);
		} else {*/
			GameObject command = Instantiate (commandPrefab) as GameObject;
			command.SetActive (true);
			command.name = "MoveUp()";
			command.GetComponent<CommandListCommand> ().SetText ("Player.MoveUp()");
			command.transform.SetParent (commandPrefab.transform.parent, false);

	}

	void MoveDown()
	{
		Debug.Log ("You have clicked the move down button");

		//text field will only be empty at the beginning of the game, after the first
		//command has been printed, text field will be populated and mark that the first
		//command button's text has been filled
		/*if (text.Equals ("")) {
			Debug.Log ("Empty");
			commandPrefab.GetComponent<CommandListCommand> ().SetText ("Player.MoveDown()");
			text = "Not empty";
			GameObject command = Instantiate (commandPrefab) as GameObject;
			command.SetActive (true);
			command.GetComponent<CommandListCommand> ().SetText ("Player.MoveDown()");
			command.transform.SetParent (commandPrefab.transform.parent, false);
		} else {*/
			GameObject command = Instantiate (commandPrefab) as GameObject;
			command.SetActive (true);
			command.name = "MoveDown()";
			command.GetComponent<CommandListCommand> ().SetText ("Player.MoveDown()");
			command.transform.SetParent (commandPrefab.transform.parent, false);


	}

	void Loop()
	{
		Debug.Log ("You have clicked the repeat button");
		GameObject repeatPanel= Instantiate (repeatPrefab) as GameObject;
		repeatPanel.SetActive (true);
		//command.name = "MoveDown()";
		//command.GetComponent<CommandListCommand> ().SetText ("Player.MoveDown()");
		repeatPanel.transform.SetParent (commandPrefab.transform.parent, false);
	}


}
