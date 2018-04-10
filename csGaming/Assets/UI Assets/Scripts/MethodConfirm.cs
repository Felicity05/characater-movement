using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine;

public class MethodConfirm : MonoBehaviour
{
    public Button confirm;
    public List<Button> savedMethods = new List<Button>();

    public GameObject methodPanel;
    public GameObject methodPrefab;
    public GameObject methodContainer;
    public GameObject textObject;

    Button method1;
    Button method2;
    Button method3;
    Button method4;
    Button method5;

    MethodCommand methodCommand;
    ButtonClick btnInstance;
	// Use this for initialization
	void Start ()
    {
        //confirm = GameObject.Find("confirmMethod").GetComponent<Button>();
        Button btn = confirm.GetComponent<Button>();

        method1 = GameObject.Find("method1").GetComponent<Button>();
        method2 = GameObject.Find("method2").GetComponent<Button>();
        method3 = GameObject.Find("method3").GetComponent<Button>();
        method4 = GameObject.Find("method4").GetComponent<Button>();
        method5 = GameObject.Find("method5").GetComponent<Button>();

        methodCommand = GetComponent<MethodCommand>();
        btnInstance = GetComponent<ButtonClick>();

        foreach(Button b in savedMethods)
        {
            Button methodButton = b;
            methodButton.interactable = false;
        }

        methodPanel = methodCommand.methodPanel;

        btn.onClick.AddListener(TaskOnClick);
        method1.onClick.AddListener(MethodClick);
        method2.onClick.AddListener(MethodClick);
        method3.onClick.AddListener(MethodClick);
        method4.onClick.AddListener(MethodClick);
        method5.onClick.AddListener(MethodClick);
    }

    void TaskOnClick()
    {
        print("Size of list now is: " + methodCommand.methodName);
        print("method confirm pressed!");
        methodCommand.methodFieldActive = false;
        methodPanel.SetActive(false);
        if (btnInstance.methodList.Count <= 0)
        {
            print("cannot add empty method!");
        }
        else
        {
            btnInstance.jaggedMethodList.Add(methodCommand.methodName, btnInstance.methodList.ToList());
            print("Size of list now is: " + btnInstance.jaggedMethodList.Count);

            btnInstance.commandList.Add(methodCommand.methodName);
            btnInstance.savedMethodButtons.Add(methodCommand.methodName);
            AddButton(methodCommand.methodName);
        }
    }

    void MethodClick()
    {
        textObject = EventSystem.current.currentSelectedGameObject;

        string btnText = textObject.GetComponentInChildren<Text>().text;
        btnInstance.commandList.Add(btnText);
    }

    void AddButton(string methodName)
    {
        if (method1.GetComponentInChildren<Text>().text == "" || !(method1.interactable))
        {
            method1.GetComponentInChildren<Text>().text = methodName;
            method1.interactable = true;
        }
        else if (method2.GetComponentInChildren<Text>().text == "" || !(method2.interactable))
        {
            method2.GetComponentInChildren<Text>().text = methodName;
            method2.interactable = true;
        }
        else if (method3.GetComponentInChildren<Text>().text == "" || !(method3.interactable))
        {
            method3.GetComponentInChildren<Text>().text = methodName;
            method3.interactable = true;
        }
        else if (method4.GetComponentInChildren<Text>().text == "" || !(method4.interactable))
        {
            method4.GetComponentInChildren<Text>().text = methodName;
            method4.interactable = true;
        }
        else if (method5.GetComponentInChildren<Text>().text == "" || !(method5.interactable))
        {
            method5.GetComponentInChildren<Text>().text = methodName;
            method5.interactable = true;
        }
        else
        {
            print("No more methods may be saved! You must delete a method.");
        }
    }

	// Update is called once per frame
	void Update ()
    {
        if (methodCommand.methodFieldActive)
        {
            confirm = GameObject.Find("confirmMethod").GetComponent<Button>();
        }
        
    }
}
