using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private BoardManager boardScript;
    public GameObject CardHolder;
    private int enemyHealth;

    public List<CardScript> deck = new List<CardScript>();

    public int level = 1;

    //this is where the cards are read from file into an array, i think it works well. The cards dont actually draw properly yet though so need to fix that
    void CardCreation()
    {
        //relatively small buffer but it works for what im doing
        const int BufferSize = 128;
        //open up the file
        using (var fileStream = File.OpenRead("Assets/cardData.txt"))
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
        {
            //take in the fie line by line
            string line;
            while ((line = streamReader.ReadLine()) != null)// && !streamReader.EndOfStream)
            {
                //unfortunately i need like 6 temps because i need to parse all the different pieces. I could think of a better way but again it works and at this point i dont wanna mess with it too much
                string temp1, temp2, temp3, temp4, temp5, temp6;
                //we split the line into a string array called value at each comma in the string
                string[] value = line.Split(',');
                

                Debug.Log(value[0]);
                temp1 = value[3];
                temp2 = value[4];
                temp3 = value[5];
                temp4 = value[6];
                temp5 = value[7];
                temp6 = value[8];



                CardScript Card = CardHolder.AddComponent<CardScript>();

                //Card = gameObject.GetComponent<CardScript>();

                //this just assigns the values pulled from the file into the string array to the respective parts of the card object they're supossed to go to
                //lots of parsing i know
                Card.id = value[0];
                Card.cardName = value[1];
                Card.text = value[2];
                Card.cost = Int32.Parse(temp1);
                Card.damage = Int32.Parse(temp2);
                Card.block = Int32.Parse(temp3);
                Card.strength = Int32.Parse(temp4);
                Card.weak = Int32.Parse(temp5);
                Card.vunerable = Int32.Parse(temp6);

                //add the newly made card to the deck and repeat for all the cards in the file
                deck.Add(Card);
            }

            Debug.Log(deck[0].damage);
            Debug.Log(deck[1].damage);
            Debug.Log(deck[2].damage);
        }
    }

   

        // Use this for initialization
    void Awake () {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene*/
        DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script
        boardScript = GetComponent<BoardManager>();

        //Call the InitGame function to initialize the first level 

        InitGame();
		 
	}

    public void InitGame()
    {
        //boardScript.SetUpScene(level);
        //call card creation when the game starts
        CardCreation();
        boardScript.ShuffleDeck();
        boardScript.DrawHand();
}
	
	// Update is called once per frame
	void Update () {
        //currently throwing nullreferenceexception when it loads new scene because this is only for the battle scene, will fix 
        enemyHealth = GameObject.Find("Enemy").GetComponent<EnemyScript>().health;
        if (enemyHealth <= 0)
        {
            SceneManager.LoadScene("Victory", LoadSceneMode.Single);
        }
	}
}
