using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;


public class Login : MonoBehaviour {


	public GameObject Username;
	public GameObject Password;

	private string username;
	private string password;

	public Text assk1;
	public Text assk2;

	public Text playerValidMessage; 

	public void uploadScene() {
		AuthenticatePlayer.AunthenticatePlayerBttn (username, password, playerValidMessage);

	}

	void Update () {

		if(Input.GetKeyDown(KeyCode.Tab)){
			if (Username.GetComponent<InputField> ().isFocused) {
				Password.GetComponent<InputField> ().Select ();
			}
		}

		/*filling string variabls with game objects*/

		username = Username.GetComponent<InputField> ().text;
		password = Password.GetComponent<InputField> ().text;

		/*loads next scene by pressing <Return>*/

		if( Input.GetKeyDown(KeyCode.Return) ) { 

			uploadScene();
		}



	}

}

