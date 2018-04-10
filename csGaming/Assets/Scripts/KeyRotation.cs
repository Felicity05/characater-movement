using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotation : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Rotate(Time.deltaTime * 90,0, 0);
	}
}
