using UnityEngine;
using System.Collections;

public class Statistics : MonoBehaviour {

    public int hp;
    public int atk;

    public bool attack(int dmg)
    {
        hp -= dmg;
        if(hp < 0)
        {
            return true;
        }

        return false;
    }
}
