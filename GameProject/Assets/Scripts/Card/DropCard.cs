using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DropCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    //HetlthScript zycie;
    public void OnDrop(PointerEventData eventData)
    {
        Card Attacker = eventData.pointerDrag.GetComponent<Card>();
        Card Target = this.GetComponent<Card>();

        Debug.Log("Walka: Atakujacy---> " + Attacker.name + " Target---> "+ Target.name);
        GameObject gameWorld = GameObject.Find("GameWorld");
        gameWorld.GetComponent<AttackRound>().addAttack(Attacker.gameObject, Target.gameObject); // add new planned Attack when player drop his Card on enemy Card
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
        
    }
}
