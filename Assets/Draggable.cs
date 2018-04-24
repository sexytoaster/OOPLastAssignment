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

    public void OnEndDrag(PointerEventData eventData)
    {
        bool OverTable = false;

        if(eventData.pointerCurrentRaycast.gameObject.tag == "TableTop")
            {
                OverTable = true;
            }

        if (OverTable == true)
            {
                GetComponent<CanvasGroup>().blocksRaycasts = true;




                Debug.Log("OnEndDrag");

                Debug.Log(eventData.pointerCurrentRaycast.gameObject.tag);
                this.transform.SetParent(parentToReturnTo);
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());

                Destroy(placeholder);

                int cost = GetComponent<CardScript>().cost;
                int damage = GetComponent<CardScript>().damage;
                int block = GetComponent<CardScript>().block;
                int strength = GetComponent<CardScript>().strength;
                int weak = GetComponent<CardScript>().weak;
                int vunerable = GetComponent<CardScript>().vunerable;


                enemyScript = GameObject.Find("Enemy").GetComponent<EnemyScript>();
                
                enemyScript.health = enemyScript.health - damage;
            }
        else
            {
                GetComponent<CanvasGroup>().blocksRaycasts = true;

                Debug.Log("OnEndDrag");

                Debug.Log(eventData.pointerCurrentRaycast.gameObject.tag);
                this.transform.SetParent(parentToReturnTo);
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());

                Destroy(placeholder);
            }   
        }
}
