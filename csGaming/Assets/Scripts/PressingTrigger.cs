using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressingTrigger : MonoBehaviour {

	public BlocksRotator bl;
    public GameObject player;
    public GameObject wall;
    public GameObject cube;

	void Start() {
		bl = GameObject.FindObjectOfType<BlocksRotator>();
	}

    /*void OnMouseDown()
    {

		transform.localScale = new Vector3(0.8F, 0.01f, 0.8f);
		bl.Rotate();
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            transform.localScale = new Vector3(0.8F, 0.01f, 0.8f);
            bl.Rotate();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            transform.localScale = new Vector3(0.8F, 0.01f, 0.8f);
            bl.Rotate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            transform.localScale = new Vector3(0.8F, 0.01f, 0.8f);
            bl.Rotate();
        }
    }

    private void Update()
    {
       // print(cube.transform.position);
        if(cube.transform.position == new Vector3(-4.5F, 9.5f, -1.5f))
        {
            //print("Rotated successfully");
            wall.GetComponent<Collider>().enabled = false;
        }
    }
}
