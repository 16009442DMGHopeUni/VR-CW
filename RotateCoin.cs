﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{

	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3 (0, 0, 90) * Time.deltaTime); //Rotate on the Z-Axis 
	}
}
