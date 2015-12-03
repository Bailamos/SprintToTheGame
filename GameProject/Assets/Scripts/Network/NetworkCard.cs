using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NetworkCard : MonoBehaviour
{
    public GameObject b;
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {

    }

    // Update is called once per frame
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //Debug.Log("OnPhotonSerializeView");
        if (stream.isWriting)
        {
            //stream.SendNext(this.transform.parent.name);
            //Debug.Log("Wysylam");
            stream.SendNext(this.GetComponent<Card>().Title);
        }
        else
        {
            Debug.Log("Odbieram");
            var panel = GameObject.Find("EnemiesHand");
            GameObject nCard = (GameObject)Instantiate(b);
            nCard.transform.SetParent(panel.transform, false);
            nCard.GetComponent<Statistics>().hp = 1;
            nCard.GetComponent<Statistics>().atk = 1;
            nCard.GetComponent<CardResources>().like = 1;
            nCard.GetComponent<CardResources>().tweet = 2;
            nCard.GetComponent<CardResources>().snap = 1;
            nCard.GetComponent<Properties>().isEnemy = false;
            nCard.GetComponent<Properties>().type = Properties.typy.Archers;
            Debug.Log((string)stream.ReceiveNext());

        }
    }
}
