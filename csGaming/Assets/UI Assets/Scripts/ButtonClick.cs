using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;
    public Button upButton;
    public Button downButton;
    public Button whileButton;
    public Button methodButton;

    public GameObject textObject;
   // public GameObject methodContainer;

    public struct myStruct
    {
        string methodName;
        int loopCount;
        int whileLoopNumber;
    }

    string[] commands = new string[] {"moveLeft()", "moveRight()", "moveUp()", "moveDown()"};
    public List<string> commandList;
    public List<string> whileList;
    public List<string> methodList;
    public List<List<string>> jaggedWhileList;
    public List<string> savedMethodButtons;
    public Dictionary<string, List<string>> jaggedMethodList = new Dictionary<string, List<string>>();
    //public Dictionary<List<string>, string> jaggedMethodLoopList = new Dictionary<List<string>, string>();
    public List<MethodLoopParameters> jaggedMethodLoopList = new List<MethodLoopParameters>();
    public Dictionary<string, int> methodLoopCount = new Dictionary<string, int>();


    public string buttonName;
    public int i = 0;
    public int k = 0;

    WhileCommand whileInstance;
    MethodCommand methodInstance;
    Text input;

    bool whileActive;
    bool panelActive;
    public bool methodActive;
    bool methodNameActive;

	// Use this for initialization
	void Start ()
    {
        Button btn = leftButton.GetComponent<Button>();
        Button btn1 = rightButton.GetComponent<Button>();
        Button btn2 = upButton.GetComponent<Button>();
        Button btn3 = downButton.GetComponent<Button>();
        Button btn4 = whileButton.GetComponent<Button>();
        Button btn5 = methodButton.GetComponent<Button>();

       // methodContainer = GameObject.Find("methodContainer");

        commandList = new List<string>();
        whileList = new List<string>();
        methodList = new List<string>();
        jaggedWhileList = new List<List<string>>();

        //whileActive = false;
        whileInstance = GetComponent<WhileCommand>();
        methodInstance = GetComponent<MethodCommand>();

        btn.onClick.AddListener(TaskOnClick);
        btn1.onClick.AddListener(TaskOnClick);
        btn2.onClick.AddListener(TaskOnClick);
        btn3.onClick.AddListener(TaskOnClick);
        btn4.onClick.AddListener(TaskOnClick);
        btn5.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void TaskOnClick()
    {

        textObject = EventSystem.current.currentSelectedGameObject;

        string btnText = textObject.GetComponentInChildren<Text>().text;
        Debug.Log("You clicked on " + btnText + " button!");

           /* if ("while()".Equals(btnText) && !whileActive && !panelActive && !methodActive)
            {
                commandList.Add(btnText);
                i++;
            }*/
            if(!"while()".Equals(btnText) && whileActive && k < 10)
            {
                whileList.Add(btnText);
                k++;

            }
            else if ("method".Equals(btnText) && !methodActive && methodNameActive)
            {
                //commandList.Add(methodInstance.methodName);
                methodList.Clear();
                print("methodname = " + methodInstance.methodName);
                i++;
            }
            else if(!"while()".Equals(btnText) && commands.Any(btnText.Contains) && !methodActive)
            {
                commandList.Add(btnText);
                i++;
            }
            else if(commands.Any(btnText.Contains) && methodActive)
            {
                methodList.Add(btnText); ;
            }
            else if( !( commands.Any(btnText.Contains) ) && ( !"while()".Equals(btnText) ) && ( !"method".Equals(btnText) ) )
            {
                print("In last while loop");
                commandList.Add(btnText);
            }



	}

    private void Update()
    {
        panelActive = whileInstance.active;
        whileActive = whileInstance.whileFieldActive;
        methodActive = methodInstance.methodFieldActive;
        methodNameActive = methodInstance.methodNameActive;

    // print("whileActive = " + methodActive);
}

}
