using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndTurn : MonoBehaviour {

    public bool x;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        GameObject.Find("GameManager").GetComponent<BoardManager>().playerTurn = false;
        Debug.Log(x);
    }
}
