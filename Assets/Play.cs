﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick()
    {
        SceneManager.LoadScene("backupBreslav", LoadSceneMode.Single);
        
    }
}
