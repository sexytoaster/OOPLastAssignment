using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

    private BoardManager boardScript;

    private int level = 0;

	// Use this for initialization
	void Awake () {

        //init board manager
        boardScript = GetComponent<BoardManager>();
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
