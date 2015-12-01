using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DropCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    bool destroyBool = false;
    //HetlthScript zycie;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(gameObject.name);
        Card d = eventData.pointerDrag.GetComponent<Card>();
        Card a = this.GetComponent<Card>();
        Debug.Log("Walka: " + d.name +"  "+ a.name);
        Statistics zycie = gameObject.GetComponent<Statistics>();
        destroyBool = zycie.attack(d.GetComponent<Statistics>().atk);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log(gameObject.name);
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log(this.gameObject.name);
    }

    void Update()
    { 
        if (destroyBool)
        {
            Debug.Log("Niszcze: " + this.gameObject.name);
            Destroy(this.gameObject);
        }
    }
}
