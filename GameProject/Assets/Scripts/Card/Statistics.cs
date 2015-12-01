using UnityEngine;
using System.Collections;

public class Statistics : MonoBehaviour {

    public int hp;
    public int atk;
    public bool isAlive;

    public bool attack(int dmg)
    {
        hp -= dmg;
        if(hp < 0) return true;
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
            Destroy(this.gameObject);
        }
    }
}
