using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Text;

public class CardCreation : MonoBehaviour {

    public List<CardScript> list;

	// Use this for initialization
	public void Start ()
        {
        const int BufferSize = 128;
        using (var fileStream = File.OpenRead("cardData.txt"))
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
        {
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                list = GameObject.Find("GameManager").GetComponent<GameManager>().deck;


                string temp1, temp2;
                string[] value = line.Split(',');

                temp1 = value[3];
                temp2 = value[4];


                CardScript Card = new CardScript();
                Card.id = value[0];
                Card.cardName = value[1];
                Card.text = value[2];
                Card.cost = Int32.Parse(temp1);
                Card.damage = Int32.Parse(temp2);

                list.Add(Card);



            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
