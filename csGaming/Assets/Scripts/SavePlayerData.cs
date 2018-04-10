using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerData : MonoBehaviour {

	public static void SaveData(string email, string fname, string lname, int age,
								string gender, string school, string major,
								string schoolYear)
	{
		new GameSparks.Api.Requests.LogEventRequest()
			.SetEventKey("SAVE_PLAYER")
			.SetEventAttribute("EMAIL", email)
			.SetEventAttribute("FNAME", fname)
			.SetEventAttribute("LNAME", lname)
			.SetEventAttribute("AGE", age)
			.SetEventAttribute("GENDER", gender)
			.SetEventAttribute("SCHOOL", school)
			.SetEventAttribute("MAJOR", major)
			.SetEventAttribute("LEVEL", schoolYear)
			.Send((response) => {
			if (!response.HasErrors) {
				Debug.Log("Player Saved To GameSparks...");
				
			} else {
				Debug.Log("Error Saving Player Data...");
			}
		});
	}
}
