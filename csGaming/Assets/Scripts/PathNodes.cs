using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaypointsTool;


public class PathNodes : MonoBehaviour
{

	//collection of nodes to move the caracter 
	public WaypointsChildScript[] nodeCollections;
    List<GameObject> nodes = new List<GameObject>(); 


	// Use this for initialization
	void Awake()
	{
        nodeCollections = GetComponentsInChildren<WaypointsChildScript>();
		// anim.GetComponent<Animator>();
		//checkNode();

        for (int i = 0; i < nodeCollections.Length; i++) {
            nodes.Add (nodeCollections [i].gameObject);
		}
	}

	public List<GameObject> getNodes() {
		return nodes;
	}

	public bool isValidNode(int nodePos) {
        if (nodePos < nodeCollections.Length){
            return true;
        }
			

		return false;
	}

    public int getSize() {
        return nodes.Count;
    }
		
	//function to check current node and move to it by saving the node position to currentPosition 
	/*void checkNode()
	{
		if (currentNode < PathNodes.Length)
			timer = 0; //reset the time each time the character moves
		//to hold the current position of each node to currentPosition
		currentPosition = PathNodes[currentNode].transform.position;
		print("list: " + PathNodes.Length);
		//Debug.Log("current position: " + PathNodes[currentNode].transform.localPosition);
	}*/


	// Update is called once per frame
	//void Update () {

}

