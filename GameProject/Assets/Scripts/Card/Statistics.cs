using UnityEngine;
using System.Collections;

public class Statistics : MonoBehaviour {

    public int hp;
    public int atk;
    public bool isAlive;
    public bool isCard = true;

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
            
            if (isCard == true)
            {
                GameObject gameWorld = GameObject.Find("GameWorld");
                gameWorld.GetComponent<AssignID>().allCards.Remove(this.gameObject);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("Przegales!");
            }
        }
    }
}
