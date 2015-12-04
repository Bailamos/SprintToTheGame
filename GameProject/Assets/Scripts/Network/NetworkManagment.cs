using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class NetworkManagment : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Connect();
	}
	
	// Update is called once per frame
    void Connect()
    {
        PhotonNetwork.ConnectUsingSettings("CardGamev1");
    }
    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null);
    }
    void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Player", Vector2.zero, Quaternion.identity, 0);

        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("Connected", PhotonTargets.Others); 
    }

    [PunRPC]
    void Connected()
    {
        Transform panel = GameObject.Find("Canvas").transform.FindChild("Waiting");
        panel.GetComponent<Text>().text = "Dołączył";
        Debug.Log("Przeciwnik dołączył");

        GameObject.Find("Player").GetComponent<whoseTurn>().isMyTurn = true; // Turn belongs to player who connetcted first
        GameObject.Find("DraftButton").transform.GetComponent<Image>().color = Color.green;
        for (int i = 0; i < 5; i++) GameObject.Find("EventSystem").GetComponent<DeckScript>().draftCard();

        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("Potwierdz", PhotonTargets.Others);
        //panel.gameObject.SetActive(false);
    }
    [PunRPC]
    void Potwierdz()
    {
        Transform panel = GameObject.Find("Canvas").transform.FindChild("Waiting");
        panel.GetComponent<Text>().text = "Potwierdzam";

        GameObject.Find("Player").GetComponent<whoseTurn>().isMyTurn = true;
        for (int i = 0; i < 5; i++) GameObject.Find("EventSystem").GetComponent<DeckScript>().draftCard();
        GameObject.Find("Player").GetComponent<whoseTurn>().isMyTurn = false;

        Debug.Log("Przeciwnik dołączył");
        //panel.gameObject.SetActive(false);
    }
    




}
