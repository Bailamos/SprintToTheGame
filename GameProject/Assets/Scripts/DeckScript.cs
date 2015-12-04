using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.EventSystems;

public class DeckScript : MonoBehaviour
{
    private class kartyProperties
    {
        string nazwa;
        int atak;
        int obrona;
    }
    public GameObject b;
    //public Transform cardPrefab;

    public void draftCard()
    {
        if (GameObject.Find("Player").GetComponent<whoseTurn>().isMyTurn) // is my Turn ?
        {
            Debug.Log("Drafting Card");

            var panel = GameObject.Find("Hand");
            if (panel != null)
            {
                if (GetComponent<LoadCards>().Deck.Count != 0)
                {
                    LoadCards.cardProperties a = GetComponent<LoadCards>().Deck[0];
                    GameObject nCard = (GameObject)PhotonNetwork.Instantiate("PomyslKarty", Vector2.zero, Quaternion.identity, 0);
                    initCard(panel, nCard, a, false);

                    GetComponent<LoadCards>().Deck.RemoveAt(0);

                    PhotonView photonView = PhotonView.Get(this);
                    photonView.RPC("AddCard", PhotonTargets.Others, a.nazwa, a.atak, a.obrona, a.like, a.tweet, a.snap, true, a.opis, a.typ);
                }
                else
                {
                    Debug.Log("KONIEC GRY, PRZEGRAŁEŚ");
                }
            }
        }
        else
        {
            Transform panel = GameObject.Find("Canvas").transform.FindChild("Waiting");
            panel.GetComponent<Text>().text = "Nie twoja tura !";
        }
    }


    [PunRPC]
    void AddCard(string nazwa, int atak, int obrona, int like, int tweet, int snap, bool isEnemy, string opis,string typ)
    {
        GameObject panel = GameObject.Find("EnemiesHand");
        if (panel != null)
        {
            LoadCards.cardProperties cp = new LoadCards.cardProperties(nazwa, atak.ToString(), obrona.ToString(), like.ToString(), tweet.ToString(), snap.ToString(), opis, typ);
            GameObject nCard = (GameObject)PhotonNetwork.Instantiate("PomyslKarty", Vector2.zero, Quaternion.identity, 0);
            initCard(panel, nCard, cp,isEnemy);
        }
    }

    void Start()
    {
        Transform panel = GameObject.Find("Canvas").transform.FindChild("WinOrLose");
        panel.gameObject.SetActive(false);
    }

    public void initCard(GameObject panel, GameObject nCard, LoadCards.cardProperties a,  bool tisEnemy)
     {
         string filePath = Application.dataPath;

        if(tisEnemy) nCard.transform.Find("BackOfCard").gameObject.SetActive(true);
        else nCard.transform.Find("BackOfCard").gameObject.SetActive(false);

        nCard.transform.SetParent(panel.transform, false);
         nCard.GetComponent<Statistics>().hp = a.obrona;
         nCard.GetComponent<Statistics>().atk = a.atak;
         nCard.GetComponent<CardResources>().like = a.like;
         nCard.GetComponent<CardResources>().tweet = a.tweet;
         nCard.GetComponent<CardResources>().snap = a.snap;
         nCard.GetComponent<Properties>().isEnemy = tisEnemy;
         if (a.typ.Equals("Archer"))
         {
             nCard.GetComponent<Properties>().type = Properties.typy.Archers;
         }
         else
         {
             nCard.GetComponent<Properties>().type = Properties.typy.Melee;
         }
        
         Text Title;
         Transform TitleTrans = nCard.transform.Find("UpperPanel").transform.Find("TitleImage").transform.Find("Text");
         Title = TitleTrans.GetComponentInChildren<Text>();
         Title.text = a.nazwa;

         //Text Description;
         //Transform DescriptionTrans = nCard.transform.Find("Description");
         //Description = DescriptionTrans.GetComponentInChildren<Text>();
         //Description.text = "l: " + nCard.GetComponent<Resources>().like + " t: " + nCard.GetComponent<Resources>().tweet + " s: " + nCard.GetComponent<Resources>().snap;

         Text Like;
         Transform LikeTrans = nCard.transform.Find("BottomPanel").transform.Find("LikeText");
         Like = LikeTrans.GetComponentInChildren<Text>();
         Like.text = nCard.GetComponent<CardResources>().like.ToString();

         Text Snap;
         Transform SnapTrans = nCard.transform.Find("BottomPanel").transform.Find("SnapText");
         Snap = SnapTrans.GetComponentInChildren<Text>();
         Snap.text = nCard.GetComponent<CardResources>().snap.ToString();

         Text Tweet;
         Transform TweetTrans = nCard.transform.Find("BottomPanel").transform.Find("TweetText");
         Tweet = TweetTrans.GetComponentInChildren<Text>();
         Tweet.text = nCard.GetComponent<CardResources>().tweet.ToString();

        nCard.GetComponent<Properties>().description = a.opis + "\n Typ: " + a.typ.ToString();
        

         if (File.Exists(filePath + "\\Tekstury\\" + a.nazwa + ".jpg"))
         {
             byte[] data = File.ReadAllBytes(Application.dataPath + "\\Tekstury\\" + a.nazwa + ".jpg");
             Texture2D texture = new Texture2D(64, 64, TextureFormat.ARGB32, false);
             texture.LoadImage(data);
             Sprite s = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
             nCard.transform.Find("CardImage").GetComponent<Image>().sprite = s;
         }
         else
         {
             byte[] data = File.ReadAllBytes(Application.dataPath + "\\Tekstury\\tmp.jpg");
             Texture2D texture = new Texture2D(64, 64, TextureFormat.ARGB32, false);
             texture.LoadImage(data);
             Sprite s = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
             nCard.transform.Find("CardImage").GetComponent<Image>().sprite = s;
         }


        GameObject panelToReturn = GameObject.Find("Hand");
        nCard.GetComponent<Card>().parentToReturnTo = panelToReturn.transform;

        // Assign ID to card
        var gameWorld = GameObject.Find("GameWorld"); 
        nCard.GetComponent<Properties>().CardId = gameWorld.GetComponent<AssignID>().giveID();
        gameWorld.GetComponent<AssignID>().allCards.Add(nCard);
        Debug.Log("Nazwa: " + nCard.name + " Id: " + nCard.GetComponent<Properties>().CardId);
    }
}

