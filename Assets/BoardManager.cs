using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {


    private List<CardScript> list;
    private CardScript script;
    public GameObject Card;
    public GameObject Hand;

    private int cardsDrawn = 0;
    public GameObject[] enemy;
    public GameObject[] cardsInHand;
    public GameObject[] background;
    public GameObject endTurn;

    Text[] textArray;

    // public Text cardName = null;
    //public Text desc = null;
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

    public void DrawHand()
    {
        for (cardsDrawn = 0; cardsDrawn < 5; cardsDrawn++)
        {
            list = GameObject.Find("GameManager").GetComponent<GameManager>().deck;
            System.Random randNum = new System.Random();

            
            CardScript card;



            card = list[randNum.Next(0, list.Count)];

            var newCard = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
            newCard.transform.parent = GameObject.Find("Hand").transform;

            
            textArray = newCard.GetComponentsInChildren<Text>();

            script = newCard.GetComponent<CardScript>();
            script.id = card.id;
            script.cardName = card.cardName;
            script.text = card.text;
            script.cost = card.cost;
            script.damage = card.damage;
            script.block = card.block;
            script.strength = card.strength;
            script.weak = card.weak;
            script.vunerable = card.vunerable;


            textArray[0].text = card.cardName;
            textArray[1].text = card.text;

        }
    }

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
}
