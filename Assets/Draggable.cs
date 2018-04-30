using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    //public GameObject Card;

    //private CardScript card;

    //private EnemyScript enemyScript;

    //public GameObject enemy = GameObject.FindWithTag("Enemy");

    private EnemyScript enemyScript;
    private GameObject Hand;


    public Transform parentToReturnTo = null;

    GameObject placeholder = null;

	public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;

        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        this.transform.position = eventData.position;
    }

    //a lot of stuff is contained in onEndDrag
    //i wanted this to be in Dropzones onDrop but this triggers first so this is the way it needs to be for the moment
    public void OnEndDrag(PointerEventData eventData)
    {
        //get the players current mana
        int currentMana = GameObject.Find("Player").GetComponent<Player>().currentMana;
        //get card cost
        int cost = GetComponent<CardScript>().cost;

        //get a reference to hand object so you can send objects back to hand if not player turn, wont be played
        GameObject Hand = GameObject.Find("Hand");
        
        //bool to see if over table when dropped
        bool OverTable = false;

        if(eventData.pointerCurrentRaycast.gameObject.tag == "TableTop")
            {
                OverTable = true;
            }

        //if it is, check its player turn so if it isnt the card isnt played
        if (OverTable == true)
            {
                bool x = GameObject.Find("GameManager").GetComponent<BoardManager>().playerTurn;

            //make it go back to hand
                if (x == false || currentMana - cost < 0)
                {
                    GetComponent<CanvasGroup>().blocksRaycasts = true;




                    Debug.Log("OnEndDragTrue");

                    Debug.Log(eventData.pointerCurrentRaycast.gameObject.tag);
                    //transform to hand
                    this.transform.SetParent(Hand.transform);
                    this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());

                    Destroy(placeholder);
                }
                //else its the players turn and he played the card so he can do as he likes
                else
                {
                    //cards block rays
                    GetComponent<CanvasGroup>().blocksRaycasts = true;




                    Debug.Log("OnEndDragTrue");
                    //put it on tabletop
                    Debug.Log(eventData.pointerCurrentRaycast.gameObject.tag);
                    this.transform.SetParent(parentToReturnTo);
                    this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());

                    Destroy(placeholder);

                    GameObject.Find("Player").GetComponent<Player>().currentMana = currentMana - cost;
                    //execute info on the card you dropped, unique info too. r/iamverysmart
                    int damage = GetComponent<CardScript>().damage;
                    int block = GetComponent<CardScript>().block;
                    int strength = GetComponent<CardScript>().strength;
                    int weak = GetComponent<CardScript>().weak;
                    int vunerable = GetComponent<CardScript>().vunerable;

                    //get the script for the specific enemy in scene and change its shit, will add 
                    //the other values effects later

                    enemyScript = GameObject.Find("Enemy").GetComponent<EnemyScript>();
                    if (block > 0)
                    {
                        GameObject.Find("Player").GetComponent<Player>().playerBlock = GameObject.Find("Player").GetComponent<Player>().playerBlock + block;
                    }

                    if (strength > 0)
                    {
                        GameObject.Find("Player").GetComponent<Player>().strength = GameObject.Find("Player").GetComponent<Player>().strength + strength;
                    }
                    if (weak > 0)
                    {
                        GameObject.Find("Enemy").GetComponent<EnemyScript>().weak = GameObject.Find("Enemy").GetComponent<EnemyScript>().weak + weak;
                    }
                    if (vunerable > 0)
                    {
                        GameObject.Find("Enemy").GetComponent<EnemyScript>().vunerable = GameObject.Find("Enemy").GetComponent<EnemyScript>().vunerable + vunerable;
                    }

                    if(GameObject.Find("Enemy").GetComponent<EnemyScript>().vunerable > 0)
                    {
                        damage = damage + (damage / 2);
                    }
                    enemyScript.health = enemyScript.health - damage - GameObject.Find("Player").GetComponent<Player>().strength;

                GameObject Table = GameObject.Find("TableTop");
                foreach (Transform child in Table.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
            }
            }
        else
            {
                //this is getting a bit redundant, and you can see this part could be a lot more elegant by the fact i do the same thing 4 times but it works so its ok for now, gotta focus on stuff that doesnt
                GetComponent<CanvasGroup>().blocksRaycasts = true;

                Debug.Log("OnEndDrag");

                Debug.Log(eventData.pointerCurrentRaycast.gameObject.tag);
                this.transform.SetParent(parentToReturnTo);
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());

                Destroy(placeholder);
            }   
        }
}
