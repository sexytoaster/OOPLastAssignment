using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CardSelection : MonoBehaviour {

    private List<CardScript> list;
    public GameObject CardSelect;
    public GameObject Hand;
    public GameObject CardHolder;
    private int cardsDrawn;
    Text[] textArray;

    
    public void Selection()
    {
        //draw hand fills the players hand with random cards from the deck. this is an issue at the moment
        //because the way it works doesnt remove cards from the deck and discard them, it just instanciates a card with the info from the list
        //so there is no cycling going on whichis not what we want, also you can draw the same instance of a card multiple times. Will Fix   NB!!!!!
        //also doesnt discard current hand when you draw a new one which is what i want
        for (cardsDrawn = 0; cardsDrawn < 3; cardsDrawn++)
        {

            //get a reference to the deck
            list = GameObject.Find("GameManager").GetComponent<GameManager>().allCards;

            CardScript card;
            CardScript script;


            System.Random rnd = new System.Random();

            card = list[rnd.Next(0, list.Count)];

            //instanciate a card
            var newCard = Instantiate(CardSelect, new Vector3(0, 0, 0), Quaternion.identity);
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
            textArray[2].text = card.cost.ToString();
        }
    }

    // Use this for initialization
    void Start () {
        Selection();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
