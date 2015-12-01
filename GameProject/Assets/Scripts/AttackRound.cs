using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackRound : MonoBehaviour {

    public List<Attack> listOfAttacks;
    public int liczbaAtakow;

    void Start () {
        listOfAttacks = new List<Attack>();
    }
	
	public void addAttack(GameObject Attacker, GameObject Target)
    {
        listOfAttacks.Add(new Attack(Attacker, Target));
    }

    public void startAttack() {
        Debug.Log(listOfAttacks.Count);
        foreach (Attack attck in listOfAttacks)
        {
            Statistics zycie = attck.Target.GetComponent<Statistics>();
            bool destroyBool = zycie.attack(attck.Attacker.GetComponent<Statistics>().atk);

            if (destroyBool) zycie.isAlive = false;       
        }
        listOfAttacks.Clear();
    }
}
