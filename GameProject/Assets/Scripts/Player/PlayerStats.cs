using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    CardResources zasoby;
    public int life;
    Text textStats;

    void Start () {
        var player = GameObject.Find("Gracz");
        zasoby = player.GetComponent<CardResources>();
        textStats = this.GetComponentInChildren<Text>();
        zasoby.like = Const.startMana;
        zasoby.tweet = Const.startMana;
        zasoby.snap = Const.startMana;
        life = Const.life;
    }

    void subtractLife(int damage)
    {
        life -= damage;
    }

    void Update () {
        textStats.text = "Life: " + life + "\nLikes: " + zasoby.like.ToString() + "\nTweets: " + zasoby.tweet.ToString() + "\nSnaps: " + zasoby.snap.ToString();
    }
}
