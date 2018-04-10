using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine;

public class MethodCommand : MonoBehaviour
{
    public Button methodButton;
    public GameObject methodNamePanel;
    public GameObject methodPanel;

    Text methodNameText;
    public string methodName;

    public bool methodNameActive;
    public bool methodFieldActive;
    // Use this for initialization
    void Start ()
    {
        methodNamePanel = GameObject.Find("methodName");
        Button btn = methodButton.GetComponent<Button>();

        methodPanel = GameObject.Find("MethodField");
        methodNameText = GameObject.Find("methodText").GetComponent<Text>();

        methodNameActive = false;
        methodFieldActive = false;

        /*methodNamePanel.SetActive(false);
        methodPanel.SetActive(false);*/
        GameObject.Find("methodName").SetActive(false);
        GameObject.Find("MethodField").SetActive(false);

        btn.onClick.AddListener(TaskOnClick);
	}
	
    void TaskOnClick()
    {
        print("method button pressed");
        if(!methodNameActive)
        {
            methodNamePanel.SetActive(true);
            methodNameActive = true;
        }
        else if( ! (string.IsNullOrEmpty(GameObject.Find("name").GetComponent<Text>().text) ) )
        {
            methodName = GameObject.Find("name").GetComponent<Text>().text;
            print("methodname = " + methodName);

            methodPanel.SetActive(true);
           // methodNameText.text = "" + methodName + "()\n{\n\n\n\n\n\n\n\n}";
            print("methodname under .text = " + methodName);

            methodNamePanel.SetActive(false);
            methodNameActive = false;

            methodFieldActive = true;
            //print("we entered here methodNameActive = " + methodNameActive);
        }
        else
        {
            print("Method name must not be blank!");
            methodNamePanel.SetActive(false);
            methodNameActive = false;
        }
    }

	// Update is called once per frame
	void Update ()
    {
        if (methodNameActive)
        {
            methodName = GameObject.Find("name").GetComponent<Text>().text;
        }
    }
}
