using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine;

public class WhileLoopConfirm : MonoBehaviour
{
    Button confirm;
    GameObject whilePanel;
    WhileCommand whileCommand;
    ButtonClick btnInstance;
    MethodCommand methodCommand;

    int loopCount = 0;
    //public List<List<string>> jaggedCommandList = new List<List<string>>();

	// Use this for initialization
	void Start ()
    {

        //confirm = GameObject.Find("confirm").GetComponent<Button>();
        //whilePanel = GameObject.Find("WhileField");

        whileCommand = GetComponent<WhileCommand>();
        btnInstance = GetComponent<ButtonClick>();
        methodCommand = GetComponent<MethodCommand>();

        whilePanel = whileCommand.whilePanel;
        confirm = whileCommand.confirm;

        confirm.onClick.AddListener(TaskOnClick);
	}

    void TaskOnClick()
    {
        whilePanel.SetActive(false);
        whileCommand.whileFieldActive = false;
        print("k = " + btnInstance.k);

        if (btnInstance.whileList.Count <= 0)
        {
            print("Cannot add empty while loop!");
        }
        else if (btnInstance.methodActive)
        {
            btnInstance.jaggedMethodLoopList.Add(new MethodLoopParameters() {MethodName = methodCommand.methodName, LoopCount = btnInstance.k, LoopCommands = btnInstance.whileList.ToList()});
            btnInstance.methodList.Add("while()");
            btnInstance.methodLoopCount.Add(methodCommand.methodName, btnInstance.k);
            btnInstance.whileList.Clear();
        }
        else
        {
            btnInstance.jaggedWhileList.Add(btnInstance.whileList.ToList());
            btnInstance.commandList.Add("while()");
            btnInstance.whileList.Clear();
        }
        print("Number of lists in JaggedWhileList " + btnInstance.jaggedWhileList.Count);

        foreach(List<string> subList in btnInstance.jaggedWhileList)
        {
            print("Beginning of new list");

            foreach(string command in subList)
            {
                print("command = " + command);
            }
        }


        print("Added to list!");
        btnInstance.k = 0;
        print("Confirm button pressed!");
    }
	
	// Update is called once per frame
	void Update ()
    {
       /* confirm = GameObject.Find("confirm").GetComponent<Button>();
        confirm.onClick.AddListener(TaskOnClick);*/
    }
}
