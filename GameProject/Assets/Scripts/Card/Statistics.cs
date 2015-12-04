using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Statistics : MonoBehaviour {

    public int hp;
    public int atk;
    public bool isAlive;
    public bool isCard = true;

    public bool attack(int dmg)
    {
        hp -= dmg;
        if(hp <= 0) return true;
        return false;
    }

    void Start()
    {
        isAlive = true;
    }

    void Update()
    {
        if (!isAlive)
        {
            Debug.Log("Niszcze: " + this.gameObject.name);
            
            if (isCard == true)
            {
                GameObject gameWorld = GameObject.Find("GameWorld");
                gameWorld.GetComponent<AssignID>().allCards.Remove(this.gameObject);
                Destroy(this.gameObject);
            }
            else
            {
                if (GameObject.Find("Gracz").GetComponent<Statistics>().hp <= 0)
                {
                    Transform panel = GameObject.Find("Canvas").transform.FindChild("Waiting");
                    panel.GetComponent<Text>().text = "PRZEGRALES!";

                    Transform panel2 = GameObject.Find("Canvas").transform.FindChild("WinOrLose");
                    panel2.gameObject.SetActive(true);
                    panel2.GetComponent<Text>().text = "JESTES PRZEGRANYM!";

                    PhotonView photonView = PhotonView.Get(this);
                    photonView.RPC("winMessage", PhotonTargets.Others);
                }
            }
        }
    }

    [PunRPC]
    void winMessage()
    {
        Transform panel = GameObject.Find("Canvas").transform.FindChild("Waiting");
        panel.GetComponent<Text>().text = "WYGRALES!";

        Transform panel2 = GameObject.Find("Canvas").transform.FindChild("WinOrLose");
        panel2.gameObject.SetActive(true);
        panel2.GetComponent<Text>().text = "JESTES ZWYCIEZCA!";
    }
}
