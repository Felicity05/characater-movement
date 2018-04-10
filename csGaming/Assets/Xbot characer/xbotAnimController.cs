using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class xbotAnimController : MonoBehaviour {

    static Animator anim;

    public PathFollower character;

    public float speed = 2.0f;

    public float rotationSpeed = 75.0f;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        Debug.Log(translation);

        if (Input.GetKeyDown(KeyCode.UpArrow)){ 
        //if(translation != 0){
            anim.SetBool("isWalking", true);
            if(character.currentNode == 6){
                transform.Rotate(0, 90, 0);
            }
        }
        else {
            anim.SetBool("isWalking", false);
        }
	}
}
