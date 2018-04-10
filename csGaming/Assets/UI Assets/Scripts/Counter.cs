using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public Button increment;
    public Button decrement;
    public int n = 0;
    public Text counter;

    // Use this for initialization
    void Start()
    {
        Button btn = increment.GetComponent<Button>();
        Button btn1 = decrement.GetComponent<Button>();
        n = int.Parse(GameObject.Find("count").GetComponent<Text>().text);
        counter = GameObject.Find("count").GetComponent<Text>();

        btn.onClick.AddListener(IncrementN);
        btn1.onClick.AddListener(DecrementN);
    }

    void IncrementN()
    {
        if (n < 100)
        {
            n += 1;
        }
    }

    void DecrementN()
    {
        if (n > 0)
        {
            n -= 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = "" + n;
    }
}
