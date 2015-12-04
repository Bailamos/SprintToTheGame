using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DropCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    //HetlthScript zycie;
   // public int numberOfAttack; // number of Cards witch attack is already planned

    public void OnDrop(PointerEventData eventData)
    {
        Card Attacker = eventData.pointerDrag.GetComponent<Card>();
        Card Target = this.GetComponent<Card>();

        Debug.Log("Walka: Atakujacy---> " + Attacker.name + " Target---> " + Target.name);
        GameObject gameWorld = GameObject.Find("GameWorld");

        if (isAttackPossible(Attacker, Target))
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("SendAttack", PhotonTargets.Others, Attacker.GetComponent<Properties>().CardId, Target.GetComponent<Properties>().CardId);
            gameWorld.GetComponent<AttackRound>().addAttack(Attacker.gameObject, Target.gameObject, false); // add new planned Attack when player drop his Card on enemy Card
        }
    }

    [PunRPC]
    void SendAttack(int attackerID, int targetID)
    {
        GameObject gameWorld = GameObject.Find("GameWorld");
        GameObject Attacker = gameWorld.GetComponent<AssignID>().allCards.Find(card => card.GetComponent<Properties>().CardId.Equals(attackerID));
        GameObject Target = gameWorld.GetComponent<AssignID>().allCards.Find(card => card.GetComponent<Properties>().CardId.Equals(targetID));
        gameWorld.GetComponent<AttackRound>().addAttack(Attacker.gameObject, Target.gameObject, true);
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
            if (Target.parentToReturnTo.Equals(GameObject.Find("Hand").transform))
            {
                Debug.Log("Nie możesz atakować ręki przeciwnika!");
                return false;
            }
            if (!(Attacker.properties.type == Properties.typy.Melee && Target.properties.type == Properties.typy.Archers))
            {
                return true;
            }        
            Debug.Log("Melee nie mogą atakować Archerów!");
            return false;
        }
        Debug.Log("Nie można atakować z ręki!");
        return false;
    }

    
}
