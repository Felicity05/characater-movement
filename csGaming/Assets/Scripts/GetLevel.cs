using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetLevel : MonoBehaviour {

	public static void getLevel() {
		string level = "";

		new GameSparks.Api.Requests.LogEventRequest ()
			.SetEventKey ("GET_LEVEL")
			.Send ((response) => {
			if (!response.HasErrors) {
				level = response.ScriptData.GetString ("level");
				SceneManager.LoadScene(level);
			} else {
				Debug.Log ("Error " + response.Errors.JSON.ToString ());
			}
		});
	}


}
