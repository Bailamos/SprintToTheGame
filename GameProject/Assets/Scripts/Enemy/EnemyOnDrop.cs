using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public class EnemyOnDrop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject Attacker = eventData.pointerDrag;
        GameObject Target = this.gameObject;
        Debug.Log("Walka: Atakujacy---> " + Attacker.name + " Target---> " + Target.name);

        if (isAttackPossible(Attacker, Target))
        {
            GameObject gameWorld = GameObject.Find("GameWorld");
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("SendAttack", PhotonTargets.Others, Attacker.GetComponent<Properties>().CardId);
            gameWorld.GetComponent<AttackRound>().addAttack(Attacker.gameObject, Target.gameObject); // add new planned Attack when player drop his Card on enemy Card
        }
    }

    [PunRPC]
    void SendAttack(int attackerID)
    {
        GameObject gameWorld = GameObject.Find("GameWorld");
        GameObject Attacker = gameWorld.GetComponent<AssignID>().allCards.Find(card => card.GetComponent<Properties>().CardId.Equals(attackerID));
        GameObject Target = GameObject.Find("Enemy").gameObject;
        gameWorld.GetComponent<AttackRound>().addAttack(Attacker.gameObject, Target.gameObject);
    }

    private bool isAttackPossible(GameObject Attacker, GameObject Target)
    {
        if (!(Attacker.GetComponent<Card>().parentToReturnTo.Equals(GameObject.Find("Hand").transform)))
           return true;

        Debug.Log("Nie można atakować z ręki!");
        return false;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
