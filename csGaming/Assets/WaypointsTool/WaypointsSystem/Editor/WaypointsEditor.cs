using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace WaypointsTool
{

    [CustomEditor(typeof(WaypointsScript))]

    public class WaypointsEditor : Editor
    {
        WaypointsScript script;

        private void OnEnable()
        {
            script = (WaypointsScript)target;
        }

        //to override what is shown on the inspector
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Add node"))
            { //creating a button to add waypoints
                script.CreateWaypoints();
            }

            if (GUILayout.Button("Delete all"))
            { //creating a button to add waypoints
                script.ResetWaypoints();
            }
        }
    }
}