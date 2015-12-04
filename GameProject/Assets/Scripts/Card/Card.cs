using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Transform parentToReturnTo = null;
    public CardResources zasoby;
    public Properties properties;
    public Statistics statistics;

    public Text Title;
    public Text Description;
    public Text attackText;
    public Text defenseText;
    public Text descriptionText;
    public GameObject DescriptionImage;


    public void Start(){
        zasoby = gameObject.GetComponent<CardResources>();
        properties = gameObject.GetComponent<Properties>();
        statistics = gameObject.GetComponent<Statistics>();

        //Transform DescriptionTrans = this.transform.Find("Description");
        Transform attackTextTrans = this.transform.Find("Attack").transform.Find("Text");
        attackText = attackTextTrans.GetComponentInChildren<Text>();

        Transform defeseTextTrans = this.transform.Find("Defense").transform.Find("Text");
        defenseText = defeseTextTrans.GetComponentInChildren<Text>();


        DescriptionImage = this.transform.Find("DescriptionPanel").gameObject;

        descriptionText = DescriptionImage.GetComponentInChildren<Text>();
        descriptionText.text = properties.description;

        DescriptionImage.SetActive(false);

       
        //descriptionText = DescriptionImage.GetComponentInChildren<Text>();
        //descriptionText.text = "OPIS";

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (properties.isEnemy == false)
        {
            parentToReturnTo = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent, true);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            //Debug.Log("CIAGNE");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GameObject.Find("Player").GetComponent<whoseTurn>().isMyTurn) // is my Turn ?
        {
            if (properties.isEnemy == false)
            {
                //Debug.Log("BLADASDSADWE");
                this.transform.position = Input.mousePosition;
            }
        }
        else
        {
            Debug.Log("Nie towja tura !");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (properties.isEnemy == false)
        {
            this.transform.SetParent(parentToReturnTo);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    public CardResources getResources()
    {
        return this.zasoby;
    }
    public Properties getProperties()
    {
        return this.properties;
    }

    public int getID()
    {
        return this.properties.CardId;
    }

    public void Update()
    {
        defenseText.text = statistics.hp.ToString();
        attackText.text = statistics.atk.ToString();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DescriptionImage.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        DescriptionImage.SetActive(true);
    }
}
