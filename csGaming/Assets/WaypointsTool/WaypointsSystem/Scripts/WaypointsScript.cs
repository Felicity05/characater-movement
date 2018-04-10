using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace WaypointsTool
{

    public class WaypointsScript : MonoBehaviour
    {

        //collection of nodes to move the caracter 
        public List<GameObject> waypoints = new List<GameObject>();
        private GameObject wp;

        [Header("Detail Settings")]
        public float markerLength = 3.0f;
        public int labelSize = 15;
        public Color labelColor = Color.blue;

        public Color connectorColor = Color.green;
        public Color markerColor = Color.magenta;
        public Color nodeColor = Color.cyan;

        public bool forceHeightValue = false;
        public float heightValue = 0.0f;


        //if i do OnDrawGizmosSelected() it hides the gizmos if I don't have the game object selected, since i want all the time shown here i won't do that
        private void OnDrawGizmos()
        {
            //to chech if in there iare empty objects o the inspector and delete them
            waypoints.RemoveAll(item => item == null); //if the condition is true it will remove the empty items


            //to draw the lines connecting the nodes
            if (waypoints.Count > 1)
            {

                for (int i = 0; i < waypoints.Count - 1; i++)
                {

                    Vector3 wp1 = waypoints[i].transform.position;
                    if (forceHeightValue)
                        wp1 = new Vector3(wp1.x, heightValue, wp1.z);
                    Vector3 wp2 = waypoints[i + 1].transform.position;
                    if (forceHeightValue)
                        wp2 = new Vector3(wp2.x, heightValue, wp2.z);
                    Vector3 wpConnector = wp2 - wp1;

                    //draw the line
                    Gizmos.color = connectorColor;
                    Gizmos.DrawRay(wp1, wpConnector);
                }
            }

            //to draw the nodes 
            if (waypoints.Count > 0)
            {
                for (int j = 0; j < waypoints.Count; j++)
                {
                    //draw node
                    Gizmos.color = nodeColor;
                    Vector3 node = waypoints[j].transform.position;
                    if (forceHeightValue)
                        node = new Vector3(node.x, heightValue, node.z);
                    Gizmos.DrawSphere(node, (float)0.3);

                    //draw marker
                    Vector3 markerStart = waypoints[j].transform.position;
                    if (forceHeightValue)
                        markerStart = new Vector3(markerStart.x, heightValue, markerStart.z);
                    Vector3 markerEnd = markerStart + new Vector3(0, markerLength, 0);
                    Gizmos.color = markerColor;
                    Gizmos.DrawLine(markerStart, markerEnd);

                    //draw marker text
                    GUIStyle style = new GUIStyle();
                    style.fontSize = labelSize;
                    style.fontStyle = UnityEngine.FontStyle.Bold;
                    style.normal.textColor = labelColor;
                    UnityEditor.Handles.Label(markerEnd, (j + 1).ToString(), style);

                }
            }
            else
            {
                CreateWaypoints(); // to automatically create a waypoint when we drag the waypoints prefab to the scene
            }


        }

        //to automaticly create the waypoints when clicking add waypoint button on the inspector
        public void CreateWaypoints()
        {

            wp = new GameObject();

            wp.transform.SetParent(transform);

            if (waypoints.Count == 0)
            {
                //to place the position of the newly created node over the base of the maze 
                wp.transform.localPosition = new Vector3(0, 0, 0);
            }
            else
            { // to place the newly created nodes 1 unit from the beginin node
                Vector3 lastPos = waypoints[waypoints.Count - 1].transform.position;
                Vector3 newPos = lastPos + new Vector3(0, 0, 1.128f);
                wp.transform.position = newPos;

            }

            //to name each new waypoint Node and the number of the node
            wp.name = "Node " + (waypoints.Count + 1);
            wp.AddComponent<WaypointsChildScript>();
            waypoints.Add(wp);

            //to select the newly created object
            Selection.activeGameObject = wp;

            //to undo if a node was created by mistake
            Undo.RegisterCreatedObjectUndo(wp, "Created " + wp.name);
        }


        //to delete one node at a time
        public void DeleteWaypoints(GameObject wp)
        {
            int index = waypoints.IndexOf(wp);
            waypoints.RemoveAt(index);
            GameObject.DestroyImmediate(wp);
            Selection.activeObject = gameObject;
            CleanWaypoints();
        }


        //to delete all the waypoints
        public void ResetWaypoints()
        {
            foreach (GameObject wp in waypoints)
            {
                GameObject.DestroyImmediate(wp);
            }
        }

        //to reorganize and change the name in the hierarchy when deleteing a single node
        private void CleanWaypoints()
        {
            for (int i = 0; i < waypoints.Count; i++)
            {
                waypoints[i].name = "Node " + (i + 1);
            }
        }
    }
}