using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace WaypointsTool
{
    public class WaypoinntsToolMenu {

        //menu item for the waypoints tool
        [MenuItem("WaypointsTool/Create/Waypoints")]

        //function to create the waypoints
        static void CreateWaypoints(){
            GameObject wpo = new GameObject();
            wpo.AddComponent<WaypointsScript>();
            wpo.name = "Waypoints";

            Selection.activeObject = wpo;
            Undo.RegisterCreatedObjectUndo(wpo, "Created " + wpo.name);
        }

    }
}