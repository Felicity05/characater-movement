using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Core;
using UnityEngine.SceneManagement;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;


public class PasswordRecoveryRequest : MonoBehaviour {

	public void retrievePassword() {
		GSRequestData sd = new GSRequestData().
			AddString("action", "passwordRecoveryRequest").
			AddString("email", "fhern103@fiu.edu");


		new GameSparks.Api.Requests.AuthenticationRequest().
		SetUserName("").
		SetPassword("").
		SetScriptData (sd).
			Send ((response) => {
				if (!response.HasErrors)
				{
					Debug.Log("Password retrieval request sent");
				}
				else
				{
					Debug.Log("Password Reset Error" + response.Errors.JSON.ToString());
				}
				
		});


	}
}
