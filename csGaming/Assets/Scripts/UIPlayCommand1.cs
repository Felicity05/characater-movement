using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayCommand1 : MonoBehaviour {

    UIButtonClick btnInstance; //script with the list of commands 

    GameObject Player; //to get the player 

    PathNodes path; //script with the list of nodes

    List<GameObject> nodes; //to get the list of nodes in this script

    public int indexNode;          //to hold the number of the current node

    static Vector3 currentPosition; //vector3 to hold the current position of the node 

    public float speed;

    public Animator anim;

    public bool isWalking = false;

    //for the buttons to stay inactive
    public Button submit;
    public Button clear;
    GameObject[] editBtn;

    public float playerRot = 0;

    bool rotated = false;

    /*float[] anglesR = {90, 180, 270, 360};

    float[] anglesL = {-90, -180, -270, 0};*/
    float[] angles = { -270, -180, -90, 0, 90, 180, 270, 360 };
    int angleCount = 3;

    public float targetAngle;


	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player"); //get the player

        btnInstance = GetComponent<UIButtonClick>(); //get the list of commands 

        path = GameObject.FindObjectOfType(typeof(PathNodes)) as PathNodes;  //to get the nodes to move the character

        nodes = path.getNodes(); //return the list of nodes

	}

    public void TaskOnClick() {
        angleCount = 3;
        StartCoroutine(ExecuteCommand());
    }


	private void FixedUpdate()
	{
        
        if(rotated){
            StartCoroutine(Rotate());
            //print("Rotating INSIDE OF THE FIXED UPDATE");
        }

        if(isWalking){
            anim.SetBool("isWalking", true);
        } else {
            anim.SetBool("isWalking", false);
        }
            

	}



	public IEnumerator ExecuteCommand(){
        int cmdUp = 0;//cmdDown = 0, right = 0, left = 0, j = 0, rotations = 0;

        //playerRot = (int)Player.transform.localEulerAngles.y;
        print("Entered ExecuteCommand method");

        foreach(string command in btnInstance.commandList)
        {
            //print("numbers of commands(i) = " + i);

            if (command.Equals("MoveRight()")) //to turn right
            {
                //right++; //count the amount of moveUp commands issued
                angleCount++;
                //print("right commands " + right);
                print("Angle Count = " + angleCount);
                print("Turn right entered!");
                //to get the angle to rotate the character
                //targetAngle = anglesR[(right-1) % anglesR.Length];
                targetAngle = angles[angleCount % angles.Length];
                //print("targetAngle angle RIGHT = " + targetAngle);

                playerRot = Player.transform.localRotation.eulerAngles.y; //gets the local rotation of the character

                rotated = true;

                yield return new WaitForSeconds(1f);

            }

            else if (command.Equals("MoveLeft()")) // to turn left
            {

                //left++; //count the amount of moveLeft commands issued
                angleCount--;
                if(angleCount < 0 )
                {
                    angleCount = 3;
                }
                //print("LEFT commands " + left);
                print("Angle Count = " + angleCount);
                print("Turn left entered!");
                //targetAngle = anglesL[(left - 1) % anglesL.Length];
                targetAngle = angles[angleCount % angles.Length];
                print("targetAngle angle LEFT = " + targetAngle);

                playerRot = Player.transform.localRotation.eulerAngles.y; //gets the local rotation of the character

                rotated = true;

                //print("player rotated to the left");

                yield return new WaitForSeconds(1f);

            }

            else if (command.Equals("MoveUp()"))
            {
                cmdUp++; //count the amount of moveUp commands issued

                print("index node: " + indexNode + "commands up: " + cmdUp);

                isWalking = true; //start walking animation 

                //to prevent the player from moving when it is not facing the correct way
                if (indexNode < 7 && (targetAngle == 0 || targetAngle == 360))
                {
                    yield return StartCoroutine(Walk()); //where the player moves
                }

                //make logic for walking after the node 7, I have to put the nodes on the scene


                //inverse logic for move down
                if (indexNode < cmdUp)
                {
                    indexNode++;
                }

                //to stop the animation once the player has reached the end node
                if (indexNode == cmdUp)
                {
                    isWalking = false;
                }

            }

            //isWalking = false;

            //COMPLETE THIS LOGIC
            //else if (btnInstance.commandList[i].Equals("MoveDown()")){

            //cmdDown++;

            //print("index node: " + indexNode + "commands down: " + cmdDown);

            //yield return StartCoroutine(Walk());

            //if (indexNode == cmdDown)
            //{
            //    indexNode--;
            //    isWalking = false;
            //}
            //}

        }
        //yield return new WaitForSeconds(1f);

        btnInstance.i = 0;
        btnInstance.commandList.Clear();

        /* Enable all controls */
        submit.interactable = true;
        clear.interactable = true;

        editBtn = GameObject.FindGameObjectsWithTag("Edits");

        foreach (GameObject btn in editBtn)
        {
            btn.GetComponent<Button>().interactable = true;
        }

        yield return new WaitForFixedUpdate();
        //print("REPEATING FUNCTION ======================================");

        //yield return new WaitForSeconds(1f);


    }

    /*Function to move the player throught the waypoints*/

    public IEnumerator Walk()
    {
        if (path.isValidNode(indexNode)) //check if there exits a node to move to 
        {
            //get the local position of that node
            currentPosition = nodes[indexNode].transform.localPosition;

            /*if the distance between the position of the player and the node is bigger than 0 then move the player to that node
             when the node is reaced the distance between the position of the node and the position of the player should be 0 */
            while (Vector3.Distance(Player.transform.localPosition, currentPosition) > 0.01f)
            {

                //to increase the speed between the gap 
                //if (Vector3.Distance(Player.transform.localPosition, currentPosition) > 1.6){  //1.128 is the distande between each node
                if (indexNode == 1) { //when node 1 is reached increase speed to walk between the gap
                    speed = 73 * Time.deltaTime;
                } else {
                    speed = 0.3f; //to mantain a fixed speed between the nodes
                }


                anim.SetBool("isWalking", true); //starts the walking animation 
                //perform the movement of the player from one node to the other
                Player.transform.localPosition = Vector3.MoveTowards(Player.transform.localPosition, currentPosition, speed * Time.deltaTime);

                yield return null; //waits for the function to end
            }

            anim.SetBool("isWalking", false); //stopt the walking animation

        }
    }


    /*Function to rotate the player */

    IEnumerator Rotate(){

        Quaternion endRot = Quaternion.AngleAxis(targetAngle, Vector3.up); //desired rotation 

        if (Player.transform.rotation != endRot) 
        {
            
            //perform the rotation of the player
            Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, endRot, 5 * Time.deltaTime);
          
            //print("after rotating player rotation = " + Player.transform.rotation + "desired rotation = " + endRot);
            //print("player rotation = " + playerRot);
        }
        else
        {
            //playerRot = Player.transform.localRotation.eulerAngles.y;
            //print("after rotating Player rotation " + playerRot);
            rotated = false;
            //print("player rotation and target rotation are equals");
        }

        yield return null;
    }

}
