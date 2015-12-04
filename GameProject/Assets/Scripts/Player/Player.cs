using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    CardResources zasoby;

	void Start () {
        zasoby = gameObject.GetComponent<CardResources>();
        zasoby.like = Const.startMana;
        zasoby.tweet = Const.startMana;
        zasoby.snap = Const.startMana;
    }

    public void addMana()
    {
        zasoby.like += 2;
        zasoby.tweet += 2;
        zasoby.snap += 2;
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("updateMana", PhotonTargets.Others, 2, 2 ,2);
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
