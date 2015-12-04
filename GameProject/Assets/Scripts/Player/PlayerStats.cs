using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    CardResources zasoby;
    Text textStats;
    GameObject player;

    void Start () {
        player = GameObject.Find("Gracz");
        zasoby = player.GetComponent<CardResources>();
        textStats = this.GetComponentInChildren<Text>();
        zasoby.like = Const.startMana;
        zasoby.tweet = Const.startMana;
        zasoby.snap = Const.startMana;
        player.GetComponent<Statistics>().hp = Const.life;
        player.GetComponent<Statistics>().isCard = false;
    }

    void subtractLife(int damage)
    {
        player.GetComponent<Statistics>().hp -= damage;
    }

    void Update () {
        textStats.text = "Life: " + player.GetComponent<Statistics>().hp.ToString() + "\nLikes: " + zasoby.like.ToString() + "\nTweets: " + zasoby.tweet.ToString() + "\nSnaps: " + zasoby.snap.ToString();
    }
}
