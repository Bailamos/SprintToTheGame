using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

    private bool close;
	// Use this for initialization
	void Start () {
        close = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (close)
            Application.Quit();

    }

    public void closeTheGameMethod()
    {
        close = true;
    }
}
