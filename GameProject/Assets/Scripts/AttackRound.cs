using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackRound : MonoBehaviour {

    List<Attack> listOfAttacks;
    List<int> listOfInts;
    int liczba;

    void Start () {
        listOfAttacks = new List<Attack>();
        listOfInts = new List<int>();
        liczba = 0;
    }
	
	public void addAttack(GameObject Attacker, GameObject Target)
    {
        listOfAttacks.Add(new Attack(Attacker, Target));
        listOfInts.Add(++liczba);

        Debug.Log("dodaje atak do lsity! pojemnsoc listy atakow: " + listOfAttacks.Capacity + "poj liczb: " + listOfInts.Capacity);
    }

    public void startAttack()
    {
        Debug.Log("Zaczynam Atak!");

        for(int i = 0; i < listOfAttacks.Capacity; i++)
        {
            Debug.Log("petla dziala! razy: " + i+1);
            Statistics zycie = listOfAttacks[i].Target.GetComponent<Statistics>();
            bool destroyBool = zycie.attack(listOfAttacks[i].Attacker.GetComponent<Statistics>().atk);

            if (destroyBool) zycie.isAlive = false;
        }

        foreach (int number in listOfInts)
        {
            Debug.Log(number);
        }

        foreach (Attack attck in listOfAttacks)
        {
            Debug.Log("bylem!");
            Statistics zycie = attck.Target.GetComponent<Statistics>();
            bool destroyBool = zycie.attack(attck.Attacker.GetComponent<Statistics>().atk);

            if (destroyBool) zycie.isAlive = false;       
        }

        Debug.Log("Koniec Ataku!" +  " pojemnsoc listy: " + listOfAttacks.Capacity);
    }
}
