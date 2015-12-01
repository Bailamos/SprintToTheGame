using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackRound : MonoBehaviour {

    public List<Attack> listOfAttacks;
    public int liczbaAtakow;

    void Start () {
        listOfAttacks = new List<Attack>();
        liczbaAtakow = 0;
    }
	
	public void addAttack(GameObject Attacker, GameObject Target)
    {
        listOfAttacks.Add(new Attack(Attacker, Target));
        Debug.Log("Ilosc atakow w liscie: " + listOfAttacks.Count);
        liczbaAtakow = listOfAttacks.Count;
    }

    public void startAttack()
    {
        Debug.Log("Zaczynam Atak!" + listOfAttacks.Count);

        foreach (Attack attck in listOfAttacks)
        {
            Debug.Log("bylem!");
            Statistics zycie = attck.Target.GetComponent<Statistics>();
            bool destroyBool = zycie.attack(attck.Attacker.GetComponent<Statistics>().atk);

            if (destroyBool) zycie.isAlive = false;       
        }

        Debug.Log("Koniec Ataku!" + " pojemnsoc listy: " + listOfAttacks.Count);
    }
}
