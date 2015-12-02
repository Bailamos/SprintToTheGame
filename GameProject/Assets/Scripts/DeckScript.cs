using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
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
        Debug.Log("Drafting Card");

        var panel = GameObject.Find("Hand");
        if (panel != null)
        {
            string filePath = Application.dataPath;

            if (GetComponent<LoadCards>().Deck.Count != 0 )
            {
                LoadCards.cardProperties a = GetComponent<LoadCards>().Deck[0];

                GameObject nCard = (GameObject)Instantiate(b);
                nCard.transform.SetParent(panel.transform, false);
                nCard.GetComponent<Statistics>().hp = a.obrona;
                nCard.GetComponent<Statistics>().atk = a.atak;
                nCard.GetComponent<Resources>().like = 1;
                nCard.GetComponent<Resources>().tweet = 2;
                nCard.GetComponent<Resources>().snap = 1;
                nCard.GetComponent<Properties>().isEnemy = false;
                nCard.GetComponent<Properties>().type = Properties.typy.Archers;

                Text Title;
                Transform TitleTrans = nCard.transform.Find("UpperPanel").transform.Find("TitleImage").transform.Find("Text");
                Title = TitleTrans.GetComponentInChildren<Text>();
                Title.text = a.nazwa;

                //Text Description;
                //Transform DescriptionTrans = nCard.transform.Find("Description");
                //Description = DescriptionTrans.GetComponentInChildren<Text>();
                //Description.text = "l: " + nCard.GetComponent<Resources>().like + " t: " + nCard.GetComponent<Resources>().tweet + " s: " + nCard.GetComponent<Resources>().snap;

                Text Like;
                Transform LikeTrans = nCard.transform.Find("BottomPanel").transform.Find("LikeText"); ;
                Like = LikeTrans.GetComponentInChildren<Text>();
                Like.text = nCard.GetComponent<Resources>().like.ToString();

                Text Snap;
                Transform SnapTrans = nCard.transform.Find("BottomPanel").transform.Find("SnapText"); ;
                Snap = SnapTrans.GetComponentInChildren<Text>();
                Snap.text = nCard.GetComponent<Resources>().tweet.ToString();

                Text Tweet;
                Transform TweetTrans = nCard.transform.Find("BottomPanel").transform.Find("TweetText"); ;
                Tweet = TweetTrans.GetComponentInChildren<Text>();
                Tweet.text = nCard.GetComponent<Resources>().snap.ToString();

                if (File.Exists(filePath + "\\Tekstury\\blondyna.jpeg"))
                {
                    byte[] data = File.ReadAllBytes(Application.dataPath + "\\Tekstury\\blondyna.jpeg");
                    Texture2D texture = new Texture2D(64, 64, TextureFormat.ARGB32, false);
                    texture.LoadImage(data);
                    Sprite s = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                    nCard.transform.Find("CardImage").GetComponent<Image>().sprite = s;
                }

                var gameWorld = GameObject.Find("GameWorld");
                nCard.GetComponent<Properties>().CardId = gameWorld.GetComponent<AssignID>().giveID();

                GetComponent<LoadCards>().Deck.RemoveAt(0);
            }
            else
            {
                Debug.Log("KONIEC GRY, PRZEGRAŁEŚ");
            }
            
           

            //Debug.Log("Dodaje karte " + nCard.GetComponent<Statistics>().hp);
        }



    }
}
