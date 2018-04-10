using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {

    //collection of nodes to move the caracter 
    Node [] PathNodes;

    //character to be moved along the nodes
    public GameObject character;

    //speed of the character
    public float characterSpeed;

    //default time
    float timer;

    //to hold the position of the current node
    public int currentNode;

    //vector3 to hold the current position of each node
     static Vector3 currentPosition;


	// Use this for initialization
	void Start () {
        PathNodes = GetComponentsInChildren<Node>();
       // anim.GetComponent<Animator>();
        checkNode();
	}

    //function to check current node and move to it 
    //by saving the node position to currentPosition 
    void checkNode(){
        if(currentNode < PathNodes.Length)
        timer = 0; //reset the time each time the character moves
        //to hold the current position of each node to currentPosition
        currentPosition = PathNodes[currentNode].transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(currentNode);
        //to keep the speed equal in every computer
        timer += Time.deltaTime * characterSpeed;
       // float translation = Input.GetAxis("Vertical") * 1.0f;

        if(character.transform.position != currentPosition){
            //if player position not equal node position then move it to the node 
            character.transform.position = Vector3.Lerp(character.transform.position, currentPosition, timer);
        }
        // else {
        //if(Input.GetMouseButtonDown(0)){


        float angleX = character.transform.localEulerAngles.x;
        float angleY = character.transform.localEulerAngles.y; //orientation of the character, to where it is facing
        float angleZ = character.transform.localEulerAngles.z;

        Debug.Log("local coordinates x,y,z: " + angleX + " " + angleY + " " + angleZ);
       // These return local coordinates.
       
        if (Input.GetKeyDown(KeyCode.UpArrow) && angleY == 0){
        //if(translation != 0){ //&& angleY == 0){
            if (currentNode < PathNodes.Length - 1)
            {
                //if player position is equal to the node position then move it to the next node
                currentNode++;
               // character.transform.position = currentPosition;
                checkNode();
            }
        }
	}
}
