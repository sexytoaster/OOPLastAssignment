﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private BoardManager boardScript;

    private int level = 0;

	// Use this for initialization
	void Awake () {
        //Check if instance already exists
        /*if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);*/

        //Get a component reference to the attached BoardManager script
        boardScript = GetComponent<BoardManager>();

        //Call the InitGame function to initialize the first level 
        InitGame();
		
	}

    void InitGame()
    {
        boardScript.SetUpScene(level);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
