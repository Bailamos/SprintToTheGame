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
        like = snap = tweet = 0;
        textStats = this.GetComponentInChildren<Text>();
    }

    void Update()
    {
        textStats.text = "Likes: " + like.ToString() + "\nTweets: " + tweet.ToString() + "\nSnaps: " + snap.ToString();
    }
}
