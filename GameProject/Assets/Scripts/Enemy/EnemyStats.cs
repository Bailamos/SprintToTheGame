using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour {

    public int like, snap, tweet, life;
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
        like = snap = tweet = Const.startMana;
        life = Const.life;
        textStats = this.GetComponentInChildren<Text>();
    }

    void Update()
    {
        textStats.text = "Life: " + life.ToString() + "\nLikes: " + like.ToString() + "\nTweets: " + tweet.ToString() + "\nSnaps: " + snap.ToString();
    }
}
