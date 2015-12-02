using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    public Resources zasoby;
    public Properties properties;
    public Statistics statistics;

    public Text Title;
    public Text Description;
    public Text attackText;
    public Text defenseText;

    public void Start(){
        zasoby = gameObject.GetComponent<Resources>();
        properties = gameObject.GetComponent<Properties>();
        statistics = gameObject.GetComponent<Statistics>();

        //Transform DescriptionTrans = this.transform.Find("Description");
        Transform attackTextTrans = this.transform.Find("Attack").transform.Find("Text");
        attackText = attackTextTrans.GetComponentInChildren<Text>();

        Transform defeseTextTrans = this.transform.Find("Defense").transform.Find("Text");
        defenseText = defeseTextTrans.GetComponentInChildren<Text>();
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
        if (properties.isEnemy == false)
        {
            //Debug.Log("BLADASDSADWE");
            this.transform.position = Input.mousePosition;
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

    public Resources getResources()
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
}
