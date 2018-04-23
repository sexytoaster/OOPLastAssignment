using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public GameObject Card;
    
    

    public void OnPointerEnter(PointerEventData eventData)
    {

    }


    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " Was dropped on " + gameObject.name);

        

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        //Debug.Log(eventData.pointerEnter.gameObject.tag);
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.tag);


        if (d != null)
        {
            d.parentToReturnTo = this.transform;


            
        }

    }

}
