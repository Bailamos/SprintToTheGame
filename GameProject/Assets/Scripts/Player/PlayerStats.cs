using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    Resources zasoby;
    Text textStats;

    void Start () {
        var player = GameObject.Find("Gracz");
        zasoby = player.GetComponent<Resources>();
        textStats = this.GetComponentInChildren<Text>();
    }
	
	void Update () {
        textStats.text = "Likes: " + zasoby.like.ToString() + "\nTweets: " + zasoby.tweet.ToString() + "\nSnaps: " + zasoby.snap.ToString();
    }
}
