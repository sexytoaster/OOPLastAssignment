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

    void CardCreation()
    {
        const int BufferSize = 128;
        using (var fileStream = File.OpenRead("Assets/cardData.txt"))
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
        {
            string line;
            while ((line = streamReader.ReadLine()) != null && !streamReader.EndOfStream)
            {

                string temp1, temp2, temp3, temp4, temp5, temp6;
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

                Card.id = value[0];
                Card.cardName = value[1];
                Card.text = value[2];
                Card.cost = Int32.Parse(temp1);
                Card.damage = Int32.Parse(temp2);
                Card.block = Int32.Parse(temp3);
                Card.strength = Int32.Parse(temp4);
                Card.weak = Int32.Parse(temp5);
                Card.vunerable = Int32.Parse(temp6);

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
        /*if (instance == null)

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

    void InitGame()
    {
        //boardScript.SetUpScene(level);

       CardCreation();
       boardScript.DrawHand();
}
	
	// Update is called once per frame
	void Update () {
        //currently throwing nullreferenceexception when it loads new scene because this is only for the battle scene, will fix 
        enemyHealth = GameObject.Find("Enemy").GetComponent<EnemyScript>().health;
        Debug.Log(enemyHealth);
        if (enemyHealth <= 0)
        {
            SceneManager.LoadScene("Victory", LoadSceneMode.Single);
        }
	}
}
