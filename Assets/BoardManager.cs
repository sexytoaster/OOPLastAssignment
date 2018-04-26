using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {


    private List<CardScript> list;
    //private CardScript script;
    public GameObject Card;
    public GameObject Hand;
    public bool playerTurn;
    public int deckCount = 0;

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
        //not actually using this anymore so idk why its here XD. Will remove after im sure i dont need it
        GameObject enemyChoice = enemyList[Random.Range(0, enemyList.Length)];
        Instantiate(enemyChoice, new Vector3(20, 50, 0), Quaternion.identity);
    }

    public void SetUpScene(int level)
    {
        //BoardSetup();
        SpawnEnemys(enemy);
    }

    public void ShuffleDeck()
    {
        List<CardScript> deckShuffle = GameObject.Find("GameManager").GetComponent<GameManager>().deck;

        CardScript t;
        int m = deckShuffle.Count, i;

        // While there remain elements to shuffle…
        while (m!=0)
        {

            System.Random rNum = new System.Random();
            // Pick a remaining element…
            i = rNum.Next(0, m--);

            // And swap it with the current element.
            t = deckShuffle[m];
            deckShuffle[m] = deckShuffle[i];
            deckShuffle[i] = t;
        }
        
    }


    public void DrawHand()
    {
        //draw hand fills the players hand with random cards from the deck. this is an issue at the moment
        //because the way it works doesnt remove cards from the deck and discard them, it just instanciates a card with the info from the list
        //so there is no cycling going on whichis not what we want, also you can draw the same instance of a card multiple times. Will Fix   NB!!!!!
        //also doesnt discard current hand when you draw a new one which is what i want
        for (cardsDrawn = 0; cardsDrawn < 5; cardsDrawn++)
        {
            
            //get a reference to the deck
            list = GameObject.Find("GameManager").GetComponent<GameManager>().deck;

            if (deckCount >= list.Count)
            {
                deckCount = 0;
                ShuffleDeck();
            }    

            CardScript card;
            CardScript script;


            //choose a card using the random number from the deck(((gonna change)))
            card = list[deckCount];

            //instanciate a card
            var newCard = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
            //put it in the hand
            newCard.transform.parent = GameObject.Find("Hand").transform;

            //get a reference to the 2 text boxes attatched to each card so i can print the name and flavour (yum)
            textArray = newCard.GetComponentsInChildren<Text>();

            //take the blank card you just made and give it the details you randomly selected
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

            //put text in text boxes
            textArray[0].text = card.cardName;
            textArray[1].text = card.text;


            playerTurn = true;

            deckCount++;
        }
    }

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
}
