using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class DragZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    private Player player;
    private Card d;

    public void Start()
    {
        player = GameObject.Find("Gracz").GetComponent<Player>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        d = eventData.pointerDrag.GetComponent<Card>();

        if (this.name != "EnemiesHand" && this.name != "EnemiesArchers" && this.name != "EnemiesMelee")
        {
            if (this.name == d.getProperties().type.ToString())
                if (checkIfEnoughResources(player.getResources(), d.getResources()))
                {
                    drainResources(player.getResources(), d.getResources());
                    d.parentToReturnTo = this.transform;
                }
        }
    }

    public bool checkIfEnoughResources(CardResources player, CardResources karta)
    {
        if (player.like >= karta.like && player.snap >= karta.snap && player.tweet >= karta.tweet)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void drainResources(CardResources player, CardResources karta)
    {
        player.like -= karta.like;
        player.snap -= karta.snap;
        player.tweet -= karta.tweet;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log(gameObject.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log(gameObject.name);
    }
}
