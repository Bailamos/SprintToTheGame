using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour {

    public int like, snap, tweet;
    Text textStats;

    public void addMana(int l, int s, int t)
    {
        like += l;
        snap += s;
        tweet += t;
    }

    public void drainMana(int l, int s, int t)
    {
        like -= l;
        snap -= s;
        tweet -= t;
    }

    void Start()
    {
        this.GetComponent<Statistics>().hp = Const.life;
        this.GetComponent<Statistics>().isCard = false;
        like = snap = tweet = Const.startMana;
        textStats = this.GetComponentInChildren<Text>();
    }

    void Update()
    {
        textStats.text = "Life: " + this.GetComponent<Statistics>().hp.ToString() + "\nLikes: " + like.ToString() + "\nTweets: " + tweet.ToString() + "\nSnaps: " + snap.ToString();
    }
}
