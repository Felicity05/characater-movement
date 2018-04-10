using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Node : MonoBehaviour {
   

    //collection of nodes to move the caracter 
    public List<GameObject> waypoints = new List<GameObject>();

    private void OnDrawGizmos()
    {
        //to draw the nodes
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, (float)0.3);

        //to draw the lines connecting the nodes
        if (waypoints.Count > 1){
            for (int i = 0; i < waypoints.Count - 1; i++){

                Vector3 wp1 = waypoints[i].transform.position;
                Vector3 wp2 = waypoints[i+1].transform.position;
                Vector3 wpConnector = wp2 - wp1;

                //draw the line
                Gizmos.color = Color.red;
                Gizmos.DrawRay(wp1, wpConnector);
            }
        }


    }
}
