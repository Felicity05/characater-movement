﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondRotation : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,Time.deltaTime*90, 0);
	}
}
