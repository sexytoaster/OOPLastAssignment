using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class onClickAdd : MonoBehaviour, IPointerClickHandler {

    public CardScript cardScript;
    public CardScript Card;
    public GameObject CardHolder;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(name + " Game Object Clicked!");
        cardScript = GetComponent<CardScript>();
        Card = GameObject.Find("CardHolder").AddComponent<CardScript>();

        Card.id = cardScript.id;
        Card.cardName = cardScript.cardName;
        Card.text = cardScript.text;
        Card.cost = cardScript.cost;
        Card.damage = cardScript.damage;
        Card.block = cardScript.block;
        Card.strength = cardScript.strength;
        Card.weak = cardScript.weak;
        Card.vunerable = cardScript.vunerable;


        GameObject.Find("GameManager").GetComponent<GameManager>().deck.Add(Card);
        GameObject Hand = GameObject.Find("Hand");
        foreach (Transform child in Hand.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
