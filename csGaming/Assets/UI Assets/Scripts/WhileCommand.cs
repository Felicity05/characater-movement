using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class WhileCommand : MonoBehaviour
{
    public Button whileButton;
    public Button confirm;
    public GameObject counterPanel;
    public GameObject whilePanel;
    public int n;
    Text loopCountText;
    public bool active;
    public bool whileFieldActive;
    public List<int> listCount = new List<int>();
	// Use this for initialization
	void Start ()
    {
        counterPanel = GameObject.Find("counterPanel");
        Button btn = whileButton.GetComponent<Button>();

        whilePanel = GameObject.Find("WhileField");
        loopCountText = GameObject.Find("loopCountText").GetComponent<Text>();

        active = false;
        whileFieldActive = false;

        GameObject.Find("counterPanel").SetActive(false);
        GameObject.Find("WhileField").SetActive(false);

        btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
    {
        if (!active)
        {
            counterPanel.SetActive(true);
            active = true;
        }
        else
        {
            n = int.Parse(GameObject.Find("count").GetComponent<Text>().text);
            if (n > 0)
            {
                whilePanel.SetActive(true);
                listCount.Add(n);
                loopCountText.text = "While(counter = " + n + ")\n{\n\n\n\n\n\n\n\n}";
            }
            else
            {
                print("Counter must be larger than 0!");
            }
            counterPanel.SetActive(false);
            active = false;
            print("whileFieldActive = (should be false) " + whileFieldActive);
            whileFieldActive = true;
            print("whileFieldActive = (should be true) " + whileFieldActive);

        }
    }

	
    // Update is called once per frame
	void Update ()
    {
       // print("whileFieldActive = " + whileFieldActive);
    }
}
