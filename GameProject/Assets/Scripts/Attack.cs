using UnityEngine;
using System.Collections;

public class Attack {

    public GameObject Attacker;
    public GameObject Target;
    bool enemyAttack;

    public Attack(GameObject Attck, GameObject Trgt, bool enemyAttk)
    {
        Attacker = Attck;
        Target = Trgt;
        enemyAttack = enemyAttk;
    }

    public void setCards(GameObject Attck, GameObject Trgt)
    {
        Attacker = Attck;
        Target = Trgt;
    }
    
}
