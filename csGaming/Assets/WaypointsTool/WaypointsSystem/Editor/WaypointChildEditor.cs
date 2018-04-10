using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace WaypointsTool
{

    [CustomEditor(typeof(WaypointsChildScript))]

    public class WaypointChildEditor : Editor
    {
        WaypointsScript wps;
        WaypointsChildScript script;

        private void OnEnable()
        {
            script = (WaypointsChildScript)target;
            wps = script.transform.parent.GetComponent<WaypointsScript>();
        }

        //to override what is shown on the inspector
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            //creating a button to add nodes at the end
            if (GUILayout.Button("Add node at the end"))
            {
                wps.CreateWaypoints();
            }

            //creating a button to delete the nodes
            if (GUILayout.Button("Delete node"))
            {
                wps.DeleteWaypoints(script.transform.gameObject);
            }
        }
    }
}