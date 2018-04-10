using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class DeleteCommand : MonoBehaviour
{
    ButtonClick btnInstance;

    public Button resetButton;

	// Use this for initialization
	void Start ()
    {
        Button btn = resetButton.GetComponent<Button>();
        btnInstance = GetComponent<ButtonClick>();

        btn.onClick.AddListener(TaskOnClick);
	}

    void TaskOnClick ()
    {
        Debug.Log(message: "Reset button pressed!");

       // commands = btnInstance.commandList;

        /*for(int i = 0; i < btnInstance.commandList.Length; i++)
        {
            btnInstance.commandList[i] = "";
        }*/

        btnInstance.i = 0;
	}
}
