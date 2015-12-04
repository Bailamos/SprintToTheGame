using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AssignID : MonoBehaviour {

    private int worldID;
    public List<GameObject> allCards;

    void start()
    {
        worldID = 0;
        allCards = new List<GameObject>();
    }

    public int giveID()
    {
        return ++worldID;
    } 
}
