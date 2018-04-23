using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {


    public GameObject[] enemy;
    public GameObject[] cardsInHand;
    public GameObject[] background;
    public GameObject endTurn;

    //private Transform boardHolder;

    /* not sure if best way
     void BoardSetup()
    {
        //pick a random background image
        boardHolder = new GameObject("Board").transform;
        GameObject toInstantiate = background[Random.Range(0, background.Length)];

        GameObject instance = Instantiate(toInstantiate) as GameObject;
        instance.transform.SetParent(boardHolder);
     }
    */
    
    void SpawnEnemys(GameObject[] enemyList)
    {
        GameObject enemyChoice = enemyList[Random.Range(0, enemyList.Length)];
        Instantiate(enemyChoice, new Vector3(20, 50, 0), Quaternion.identity);
    }

    public void SetUpScene(int level)
    {
        //BoardSetup();
        SpawnEnemys(enemy);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
}
