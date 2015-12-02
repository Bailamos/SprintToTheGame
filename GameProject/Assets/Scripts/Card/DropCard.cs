using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DropCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    //HetlthScript zycie;
    public int numberOfAttack; // number of Cards witch attack is already planned

    public void OnDrop(PointerEventData eventData)
    {
        Card Attacker = eventData.pointerDrag.GetComponent<Card>();
        Card Target = this.GetComponent<Card>();

        Debug.Log("Walka: Atakujacy---> " + Attacker.name + " Target---> " + Target.name);
        GameObject gameWorld = GameObject.Find("GameWorld");

        if (isAttackPossible(Attacker, Target))
        {
            gameWorld.GetComponent<AttackRound>().addAttack(Attacker.gameObject, Target.gameObject); // add new planned Attack when player drop his Card on enemy Card
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log(gameObject.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log(this.gameObject.name);
    }

    private bool isAttackPossible(Card Attacker, Card Target)
    {
        if (!(Attacker.parentToReturnTo.Equals(GameObject.Find("Hand").transform)))
        {
            if (!(Attacker.properties.type == Properties.typy.Melee && Target.properties.type == Properties.typy.Archers))
            {
                return true;
            }
            Debug.Log("Melee nie mogą atakować Archerów!");
        }
        Debug.Log("Nie można atakować z ręki!");
        return false;
    }

    
}
