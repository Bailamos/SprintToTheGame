using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    CardResources zasoby;

	void Start () {
        zasoby = gameObject.GetComponent<CardResources>();
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
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("updateMana", PhotonTargets.Others, 1, 1 ,1);

            Debug.Log("Adding +1 to all of Mana !");
        }
    }

    public CardResources getResources()
    {
        return zasoby;
    }

    [PunRPC]
    void updateMana(int l, int s, int t)
    {
        GameObject.Find("Enemy").GetComponent<EnemyStats>().addMana(l, s, t);
    }
}
