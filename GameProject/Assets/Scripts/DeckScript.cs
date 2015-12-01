using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeckScript : MonoBehaviour {
    public GameObject b;
    //public Transform cardPrefab;

    public void draftCard()
    {
        var panel = GameObject.Find("Hand");
        if (panel != null)
        {
            Debug.Log("drafting card");

            GameObject nCard = (GameObject)Instantiate(b);
            nCard.transform.SetParent(panel.transform, false);
            nCard.GetComponent<Statistics>().hp = 5;
            nCard.GetComponent<Statistics>().atk = 11;
            nCard.GetComponent<Resources>().like = 1;
            nCard.GetComponent<Resources>().tweet = 2;
            nCard.GetComponent<Resources>().snap = 3;
            nCard.GetComponent<Properties>().isEnemy = false;
            nCard.GetComponent<Properties>().type = Properties.typy.Archers;

            Text Title;
            Transform TitleTrans = nCard.transform.Find("TitleImage").transform.Find("Title") ;
            Title = TitleTrans.GetComponentInChildren<Text>();
            Title.text = "TytulKarty";
            
            Text Description;
            Transform DescriptionTrans = nCard.transform.Find("Description");
            Description = DescriptionTrans.GetComponentInChildren<Text>();
            Description.text = "l: " + nCard.GetComponent<Resources>().like + " t: " + nCard.GetComponent<Resources>().tweet + " s: " + nCard.GetComponent<Resources>().snap;

            Text Like;
            Transform LikeTrans = nCard.transform.Find("TitleImage").transform.Find("Panel").transform.Find("LikesText"); ;
            Like = LikeTrans.GetComponentInChildren<Text>();
            Like.text = nCard.GetComponent<Resources>().like.ToString();

            Text Snap;
            Transform SnapTrans = nCard.transform.Find("TitleImage").transform.Find("Panel").transform.Find("SnapText"); ;
            Snap = SnapTrans.GetComponentInChildren<Text>();
            Snap.text = nCard.GetComponent<Resources>().tweet.ToString();

            Text Tweet;
            Transform TweetTrans = nCard.transform.Find("TitleImage").transform.Find("Panel").transform.Find("TweetText"); ;
            Tweet = TweetTrans.GetComponentInChildren<Text>();
            Tweet.text = nCard.GetComponent<Resources>().snap.ToString();

            var gameWorld = GameObject.Find("GameWorld");
            nCard.GetComponent<Properties>().CardId = gameWorld.GetComponent<AssignID>().giveID();

            //Debug.Log("Dodaje karte " + nCard.GetComponent<Statistics>().hp);
        }



    }
}
