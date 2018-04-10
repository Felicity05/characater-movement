using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace WaypointsTool
{

    public class WaypointsToolAboutMenu : EditorWindow
    {
        //to create an about menu
        [MenuItem("WaypointsTool/About WaypointsTool...")]

        static void Init()
        {
            //creating a window to display a message and making a reference to it
            WaypointsToolAboutMenu window = ScriptableObject.CreateInstance<WaypointsToolAboutMenu>();

            window.position = new Rect(Screen.width / 4, Screen.height / 4, 250, 150);
            window.ShowUtility();
        }

        //to add content to the window already created
        void OnGUI(){
            GUIStyle titleStyle = new GUIStyle();
            titleStyle.fontStyle = UnityEngine.FontStyle.Bold;
            titleStyle.fontSize = 15;

            float margin = 10;
            GUILayout.BeginArea(new Rect(margin, margin, this.position.width - margin * 2,
                             this.position.height - margin * 2), "About Waypoints Tool", titleStyle);


            GUILayout.Space(20);

            GUIStyle detailsStyle = new GUIStyle();
            detailsStyle.fontStyle = UnityEngine.FontStyle.Normal;
            detailsStyle.fontSize = 12;
            detailsStyle.wordWrap = true;
            EditorGUILayout.LabelField("This is a tool for creating waypoints.\n" +
                                       "It was created for educational purposes.\n" +
                                       "It was inspired in a previous tool.", detailsStyle);

            GUILayout.Space(10);

            GUIStyle versionStyle = new GUIStyle();
            versionStyle.fontStyle = UnityEngine.FontStyle.Italic;
            versionStyle.fontSize = 12;
            versionStyle.wordWrap = true;
            EditorGUILayout.LabelField("Version: 1.0.0", versionStyle);
            EditorGUILayout.LabelField("Last Modified: 2018 - 04 - 04", versionStyle);


            GUILayout.Space(10);

            if (GUILayout.Button("Ok got it!"))
                Close();

			GUILayout.EndArea ();
        }








    }
}