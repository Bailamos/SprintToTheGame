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

    public void Start(){
        zasoby = gameObject.GetComponent<Resources>();
        properties = gameObject.GetComponent<Properties>();
        statistics = gameObject.GetComponent<Statistics>();

        //Transform TitleTrans = this.transform.Find("TitleImage").gameObject.transform.Find("Title").gameObject.transform;
        //Title = TitleTrans.GetComponentInChildren<Text>();
        //Debug.Log(Title.text);
        //Title.text = "a: " + statistics.atk.ToString() + " d: " + statistics.hp.ToString();
     
        Transform DescriptionTrans = this.transform.Find("Description");
        Description = DescriptionTrans.GetComponentInChildren<Text>();
        //Description.text = "Koszt: l" + zasoby.like + " t: " + zasoby.tweet +  " s: " + zasoby.snap;
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
        Description.text = "Att: " + statistics.atk.ToString() +  "Def: " + statistics.hp.ToString();
    }
}
