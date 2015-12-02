using UnityEngine;
using System.Collections;

public class AssignID : MonoBehaviour {

    private int worldID;

    void start()
    {
        worldID = 0;
    }

    public int giveID()
    {
        return ++worldID;
    } 
}
