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

    //public bool isWalking = false;

    //for the buttons to stay inactive
    public Button submit;
    public Button clear;
    GameObject[] editBtn;

    public int playerRot = 0;

    bool rotated = false;


	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player"); //get the player

        btnInstance = GetComponent<UIButtonClick>(); //get the list of commands 

        path = GameObject.FindObjectOfType(typeof(PathNodes)) as PathNodes;  //to get the nodes to move the character

        nodes = path.getNodes(); //return the list of nodes

	}

    public void TaskOnClick() {
        
    }




    public float targetAngle, rotation;



	public IEnumerator ExecuteCommand(){
        int cmdUp = 0, cmdDown = 0, right = 0, left = 0, j = 0;

        playerRot = (int)Player.transform.localEulerAngles.y;

        for (int i = 0; i < btnInstance.commandList.Count; i++)
        {
            //print("numbers of commands(i) = " + i);

            if (btnInstance.commandList[i].Equals("MoveRight()")) //to turn right
            {
                right++;
                print("right commands " + right);

                //to get the angle to rotate the character

                //rotation = Player.transform.localRotation.eulerAngles.y;

                print("targetAngle = " + targetAngle);
                targetAngle = (targetAngle + 90) % 360;


                Player.transform.Rotate(0, targetAngle, 0);

                targetAngle = 0;
                   
                //yield return StartCoroutine(Rotate());
                    
            }

            else if (btnInstance.commandList[i].Equals("MoveLeft()")) // to turn left
            { 
                
                Player.transform.Rotate(0, -90, 0);

                print("player rotated to the left");

                yield return new WaitForSeconds(1f);

            }

            else if (btnInstance.commandList[i].Equals("MoveUp()"))
            {
                cmdUp++;

                print("index node: " + indexNode+ "commands up: "+ cmdUp);


                if (targetAngle == 0){
                    yield return StartCoroutine(Walk()); //where player moves
                }
               

                //inverse logic for move down
                if(indexNode < cmdUp){
                    indexNode++;
                }


            }

            //if (btnInstance.commandList[i].Equals("MoveDown()")){

            //    cmdDown++;

            //    print("index node: " + indexNode + "commands down: " + cmdDown);

            //    yield return StartCoroutine(Walk());

            //    if (indexNode == cmdDown)
            //    {
            //        indexNode--;
            //    }
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

        //yield return new WaitForSeconds(1f);

        print("REPEATING FUNCTION");
    }

    public IEnumerator Walk()
    {
        if (path.isValidNode(indexNode))
        {
            currentPosition = nodes[indexNode].transform.localPosition;

            while (Vector3.Distance(Player.transform.localPosition, currentPosition) > 0.01f)
            {

                //to increase the speed between the gap 
                if (Vector3.Distance(Player.transform.localPosition, currentPosition) > 1.6){
                    speed = 25f;
                } else {
                    speed = 0.5f;
                }


                anim.SetBool("isWalking", true);
                Player.transform.localPosition = Vector3.MoveTowards(Player.transform.localPosition, currentPosition, speed * Time.deltaTime);

                yield return null;
            }

            //indexNode++;
            anim.SetBool("isWalking", false);

        }
    }

    IEnumerator Rotate(){

        //Player.transform.Rotate(0, 90, 0);

        Quaternion endRot = Quaternion.AngleAxis(targetAngle, Vector3.up);

        float elapsed = 0;
        while (elapsed < 5)
        {
            elapsed += Time.deltaTime;

            Player.transform.Rotate(0, targetAngle, 0);
            targetAngle = 0;

            //Player.transform.rotation = Quaternion.Slerp(Player.transform.localRotation, endRot, elapsed / 5);

            yield return null;
        }

        //yield return new WaitForSeconds(1f);
    }

}
