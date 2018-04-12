using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearingCubes : MonoBehaviour {

    pb_Object[] cubes;
    List<GameObject> individualCubes = new List<GameObject>();

	// Use this for initialization
	void Start () {

        cubes = GetComponentsInChildren<pb_Object>();

        for (int i = 0; i < cubes.Length; i++)
        {

            individualCubes.Add(cubes[i].gameObject);

        }

       
        Debug.Log(cubes.Length);

        print(individualCubes[0].name);

        print(individualCubes[0].GetComponent<Rigidbody>().useGravity);


	}
	


	// Update is called once per frame
	void Update () {

       


	}
}
