using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Resources zasoby;

	void Start () {
        zasoby = gameObject.GetComponent<Resources>();
        zasoby.like = 0;
        zasoby.tweet = 0;
        zasoby.snap = 0;
	}

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            zasoby.like += 1;
            zasoby.tweet += 1;
            zasoby.snap += 1;
        }
    
    }
    public Resources getResources()
    {
        return zasoby;
    }


}
