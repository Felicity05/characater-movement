using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLevel : MonoBehaviour {

	public static SaveLevel instance = null;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	public static void saveLevel() {
		string level = SceneManager.GetActiveScene().name;
		Debug.Log (level);

		if (level.Equals ("SignUp"))
			level = "Level_01";

		new GameSparks.Api.Requests.LogEventRequest ()
			.SetEventKey ("SAVE_LEVEL")
			.SetEventAttribute ("PATH", level)
			.Send ((response) => {
				if (!response.HasErrors) {
					Debug.Log("Level saved successfully");
				}
				else {
					Debug.Log("Error " + response.Errors.JSON.ToString());
				}
		});

	}


}
