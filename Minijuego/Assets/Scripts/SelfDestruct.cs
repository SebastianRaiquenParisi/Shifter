﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
