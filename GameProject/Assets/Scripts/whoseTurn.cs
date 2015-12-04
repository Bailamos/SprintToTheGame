using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class whoseTurn : MonoBehaviour {

    public bool isMyTurn;

    // Use this for initialization
    void Start () {
        isMyTurn = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isMyTurn) this.transform.Find("PlayerPlanel").GetComponent<Image>().color = Color.green;
        else this.transform.Find("PlayerPlanel").GetComponent<Image>().color = new Color(255,255,255, 100);
    }
}
