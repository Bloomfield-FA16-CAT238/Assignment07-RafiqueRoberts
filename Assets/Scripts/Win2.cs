﻿using UnityEngine;
using System.Collections;

public class Win2 : MonoBehaviour {
	public GameController gameController;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
       
		gameController.Win();
	}
}
