using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class SignUp : MonoBehaviour {

	/*input fields*/

	public GameObject Nickname;
	public GameObject Email;
	public GameObject Password;
	public GameObject ConfPass;
	public GameObject Firstname;
	public GameObject LastName; //lastname object
	public Dropdown Gender;    
	public GameObject Age;
	public Dropdown Major;      
	public Dropdown SchoolYear;
	public Dropdown School;


	private string nickname;
	private string email;
	private string password;
	private string confPass;
	private string firstname;
	private string lastname;   //lastname
	private string age;
	private string selectedGender; 
	private string selectedMajor;
	private string selectedSchoolyear;
	private string selectedSchool;


	//flags
	private  bool isGenderValid = false; 
	private  bool isSchoolYearValid = false; 
	private bool isMajorValid = false;
	private bool isSchoolValid = false;

	/*Dropdown object lists*/

	List<string> genderList = new List<string>(){"Gender", "Male", "Female", "Other"};
	List<string> schoolYearList = new List<string>(){"School Level", "Freshman", "Sophmore", "Junior", "Senior"};
	List<string> majorList = new List<string>(){"Major", "Aerospace Engineering",
		"Applied Analytics",
		"Applied Mathematics",
		"Applied Physics",
		"Architecture",
		"Architectural Engineering",
		"Astrophysics",
		"Behavioral Health and Wellness",
		"Bioanalytical Chemistry",
		"Biochemistry",
		"Bioinformatics",
		"Biology",
		"Biology and Psychology",
		"Biomedical Engineering",
		"Business Administration",
		"Chemical Engineering",
		"Chemistry",
		"Civil Engineering",
		"Communication",
		"Computer Engineering",
		"Computer Information Systems",
		"Computer Science",
		"Digital Humanities",
		"Electrical Engineering",
		"Engineering Management",
		"Environmental Chemistry",
		"Forensic Chemistry",
		"Global Studies",
		"Humanities",
		"Information Technology and Management",
		"Industrial Technology and Management",
		"Materials Science and Engineering",
		"Mechanical Engineering",
		"Medicinal Chemistry",
		"Molecular Biochemistry and Biophysics",
		"Physics",
		"Psychological Science",
		"Social and Economic Development Policy",
		"Undecided Engineering",
		"Undecided Human Science",
		"Undecided Science"

	};
	List<string> schoolList = new List<string>(){"School","Broward College (Davie)", "Florida Atlantic University (Boca Raton)",
		"Florida Gulf Coast University (Ft. Myers)",
		"Florida International University (Miami)",
		"Florida Polytechnic University (Lakeland)",
		"Florida State University (Tallahassee)" ,
		"Miami Dade College (Miami)",
		"New College of Florida (Sarasota)",
		"North Florida Community College (Madison)",
		"University of Central Florida (Orlando)",
		"University of Florida (Gainesville)",
		"University of North Florida (Jacksonville)",
		"University of South Florida (Tampa)",
		"University of West Florida (Pensacola)"

	};

	//Error messages objects
	public Text usernameError;
	public Text firstnameError;
	public Text lastnameError;       //lastnameError object
	public Text passError; 
	public Text confPassError ;
	public Text emError;
	public Text ageError; 
	public Text genderError;
	public Text majorError;
	public Text schoolError;
	public Text schoolYearError;


	/*Confirmation Form Fields*/
	public Text succefullReg;
	public GameObject start;
	public GameObject goBack;
	public GameObject panel;

	void Start(){

		/*initilizing each dropdown with lists */

		Gender.AddOptions (genderList);
		SchoolYear.AddOptions (schoolYearList);
		Major.AddOptions (majorList);
		School.AddOptions (schoolList);

		/*registration confirmation fields inactive when scene displays*/

		panel.SetActive (false);
		start.SetActive (false);
		goBack.SetActive (false);
	}



	/* Get options in dropdonw lists */

	public void genderOptions(int i){

		selectedGender = genderList[i];

		if (selectedGender != genderList [0]) {
			isGenderValid = true;
		} else {
			isGenderValid = false;
		}

	}

	public void schoolYearOptions(int i){

		selectedSchoolyear = schoolYearList[i];

		if (selectedSchoolyear != schoolYearList [0]) {
			isSchoolYearValid = true;
		} else {
			isSchoolYearValid = false;
		}
	}

	public void majorOptions(int i){

		selectedMajor = majorList[i];

		if (selectedMajor != majorList [0]) {
			isMajorValid = true;
		} else {
			isMajorValid = false;
		}
	}

	public void schoolOptions(int i){

		selectedSchool = schoolList[i];

		if (selectedSchool != schoolList [0]) {
			isSchoolValid = true;
		} else {
			isSchoolValid = false;
		}
	}

	/* Handling Start Button of the Registration Confirmation form */

	public void RegisterUser (){  

		SceneManager.LoadScene("Level_01");

	}

	/* Handling GoBacktoMainMenu Button of the Registration Confirmation form */

	public void GoBackMainMenu (){  

		SceneManager.LoadScene("WelcomeForm");

	}


	/*   Loading next scene  for a valid player. 
	 * Is used by "Create account" object in the scene*/

	public void LoadingScene(){
		


		bool isUsernameValid = Validation.validateUsername (nickname);
		bool isNameValid = Validation.validateName(firstname);
		bool isEmailValid = Validation.validateEmail(email);
		bool isPasswordValid = Validation.validatePassword(password);
		bool isPasswordConf = Validation.confirmPassword(password, confPass);
		bool isAgeValid = Validation.validateAge(age);

		if (isUsernameValid && isNameValid && isEmailValid && isPasswordValid && isPasswordConf && isGenderValid
		    && isSchoolYearValid && isMajorValid && isSchoolValid /* && isLastnameValid */) {

			RegisterPlayer.RegisterPlayerBttn (nickname, password, email, firstname,
				lastname, Int32.Parse(age), selectedGender,
				selectedSchool, selectedMajor, selectedSchoolyear, usernameError , panel, start ,goBack, succefullReg);
			

		}else { //show erros

		

			print ("invalid player");

			//***just missing the validation for last name***

			errorMessages.usernameError (usernameError, isUsernameValid);
			errorMessages.nameError (firstnameError, isNameValid);
			errorMessages.emailError (emError, isEmailValid);
			errorMessages.passwordError (passError, isPasswordValid);
			errorMessages.confPasswordError (confPassError, isPasswordConf);
			errorMessages.AgeError (ageError, isAgeValid);
			errorMessages.GenderError (genderError, isGenderValid);
			errorMessages.MajorError (majorError, isMajorValid);
			errorMessages.SchoolError (schoolError, isSchoolValid);
			errorMessages.SchoolYearError (schoolYearError, isSchoolYearValid);

			/* if (!isLastnameValid) {                        
				errorMessages.lastNameError (lastnameError, isLastnameValid);
			}else{
				errorMessages.lastNameError (lastnameError, isLastnameValid);
			} */


		}


	}


	void Update () {

		if(Input.GetKeyDown(KeyCode.Tab)){
			if (Nickname.GetComponent<InputField> ().isFocused) {
				Email.GetComponent<InputField> ().Select ();
			}
			if (Email.GetComponent<InputField> ().isFocused) {
				Password.GetComponent<InputField> ().Select ();
			}
			if (Password.GetComponent<InputField> ().isFocused) {
				ConfPass.GetComponent<InputField> ().Select ();
			}
			if (ConfPass.GetComponent<InputField> ().isFocused) {
				Firstname.GetComponent<InputField> ().Select ();
			}
			if (Firstname.GetComponent<InputField> ().isFocused) {
				LastName.GetComponent<InputField> ().Select ();
			}
			if (LastName.GetComponent<InputField> ().isFocused) {
				Age.GetComponent<InputField> ().Select ();
			}


		}

		//filling string variabls with game objects

		nickname = Nickname.GetComponent<InputField> ().text;
		email = Email.GetComponent<InputField> ().text;
		password = Password.GetComponent<InputField> ().text;
		confPass = ConfPass.GetComponent<InputField> ().text;
		firstname = Firstname.GetComponent<InputField> ().text;
		lastname = LastName.GetComponent<InputField> ().text;
		age = Age.GetComponent<InputField> ().text;


		//Loading next scence if hit return for a valid player

		if(Input.GetKeyDown(KeyCode.Return) ){ 

			LoadingScene();
		}
	}




}
