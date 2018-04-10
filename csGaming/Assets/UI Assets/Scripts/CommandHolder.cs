using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CommandHolder : MonoBehaviour
{
    ButtonClick btnInstance;
    public Text input;

    // Use this for initialization
    void Start()
    {
         btnInstance = GetComponent<ButtonClick>();
    }

    // Update is called once per frame
    void Update()
    {
        btnInstance = GetComponent<ButtonClick>();

        /* input.text = "" + btnInstance.commandList[0] + " ;\n" +
                      "" + btnInstance.commandList[1] + " ;\n" +
                      "" + btnInstance.commandList[2] + " ;\n" +
                      "" + btnInstance.commandList[3] + " ;\n" +
                      "" + btnInstance.commandList[4] + " ;\n" +
                      "" + btnInstance.commandList[5] + " ;\n" +
                      "" + btnInstance.commandList[6] + " ;\n" +
                      "" + btnInstance.commandList[7] + " ;\n" +
                      "" + btnInstance.commandList[8] + " ;\n" +
                      "" + btnInstance.commandList[9] + " ;\n" ;*/

    }
}
