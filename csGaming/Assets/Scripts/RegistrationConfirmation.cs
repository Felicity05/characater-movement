using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegistrationConfirmation: MonoBehaviour {

	public static  void Confirmation(GameObject panel, GameObject start, GameObject goBack , Text message) {


		/* All this is gonna happen */

		panel.SetActive (true); //panel
		start.SetActive (true);
		goBack.SetActive (true);
		message.text = "Succesfull registration!!"; 


		//add another button so we dont have to press enter


	}
}