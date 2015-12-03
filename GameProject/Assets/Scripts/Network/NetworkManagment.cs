using UnityEngine;
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
    }

    




}
