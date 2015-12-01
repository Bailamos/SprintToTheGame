using UnityEngine;
using System.Collections;

public class Attack {

    public GameObject Attacker;
    public GameObject Target;

    public Attack(GameObject Attck, GameObject Trgt)
    {
        Attacker = Attck;
        Target = Trgt;
    }

    public void setCards(GameObject Attck, GameObject Trgt)
    {
        Attacker = Attck;
        Target = Trgt;
    }
    
}
