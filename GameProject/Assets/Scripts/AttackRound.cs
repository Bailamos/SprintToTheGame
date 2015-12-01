using UnityEngine;
using UnityEngine.UI;
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
        Attack attkTemp = new Attack(Attacker, Target);
        if (listOfAttacks.Find(e => e.Attacker.Equals(Attacker)) == null)
        {
            listOfAttacks.Add(attkTemp);
            Attacker.transform.GetComponent<Image>().color = Color.red;
        }
        else
        {
            Debug.Log("Dana jednostka już atakuje kogoś!");
        }
    }

    public void startAttack() {
        //Debug.Log(listOfAttacks.Count);
        foreach (Attack attck in listOfAttacks)
        {


            Statistics zycie = attck.Target.GetComponent<Statistics>();
            bool destroyBool = zycie.attack(attck.Attacker.GetComponent<Statistics>().atk);
            attck.Attacker.transform.GetComponent<Image>().color = Color.black;   
        }
        listOfAttacks.Clear();
    }
}
