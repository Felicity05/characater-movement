using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

/* Class that contains the methods to users from entering bad data */

public class errorMessages : MonoBehaviour {

	public static void usernameError(Text text, bool valid) {
		if (!valid) {
			text.text = "Invalid username. No whitespaces allowed";
			text.color = Color.red;
		} else
			text.text = " ";

	}


	public static void nameError(Text text, bool valid){

		if (!valid) {
			text.text = "Invalid name format";
			text.color = Color.red; 
		} else {
			text.text = " ";

		}
	}

	public static void lastNameError(Text text, bool valid){

		if (!valid) {
			text.text = "Invalid Last name";
			text.color = Color.red; 
		} else {
			text.text = " ";
		}
	}

	public static void emailError(Text text, bool valid){

		if (!valid) {
			text.text = "Invalid email";
			text.color = Color.red; 
		} else {
			text.text = " ";
		}
	}

	public static void passwordError(Text text, bool valid){

		if (!valid) {
			text.text = "Password: 8-15 characters long.\n" +
				"Must have at least 1 number "; 
			text.color = Color.red; 
		} else {
			text.text = " ";
		}
	}

	public static void confPasswordError(Text text, bool valid){

		if (!valid) {
			text.text = "Passwords don't match";
			text.color = Color.red; 
		} else {
			text.text = " ";
		}

	}

	public static void AgeError(Text text, bool valid){

		if (!valid) {
			text.text = "Invalid age.\nPlayer must be between 10- 80 years old";
			text.color = Color.red; 
		} else {
			text.text = " ";
		}

	}

	public static void GenderError(Text text, bool valid){

		if (!valid) {
			text.text = "Please select an option";
			text.color = Color.red; 
		} else {
			text.text = " ";
		}

	}

	public static void SchoolError(Text text, bool valid){

		if (!valid) {
			text.text = "Please select an option";
			text.color = Color.red; 
		} else {
			text.text = " ";
		}

	}

	public static void MajorError(Text text, bool valid){

		if (!valid) {
			text.text = "Please select an option";
			text.color = Color.red; 
		} else {
			text.text = " ";
		}

	}
	public static void SchoolYearError(Text text, bool valid){

		if (!valid) {
			text.text = "Please select an option";
			text.color = Color.red; 
		} else {
			text.text = " ";
		}

	}

}
