using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AttackRound : MonoBehaviour {

    public List<Attack> listOfAttacks;

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
            setAttackImages(Attacker, Target, listOfAttacks.Count);
        }
        else
        {
            Debug.Log("Dana jednostka już atakuje kogoś!");
        }
    }

    public void startAttack() {
        foreach (Attack attck in listOfAttacks)
        {
            Statistics zycie = attck.Target.GetComponent<Statistics>();
            bool destroyBool = zycie.attack(attck.Attacker.GetComponent<Statistics>().atk);
            attck.Attacker.transform.GetComponent<Image>().color = Color.black;

            if (destroyBool) zycie.isAlive = false;
        }
        listOfAttacks.Clear();
        clearAttackPanel();
    }

    private void clearAttackPanel()
    {
        for(int i=1; i <= 5; i++)
        {
            Transform panel = GameObject.Find("Panel" + i).transform.Find("Card1").transform;
            Transform panel2 = GameObject.Find("Panel" + i).transform.Find("Card2").transform;

            var children = new List<GameObject>();
            foreach (Transform child in panel) children.Add(child.gameObject);
            children.ForEach(child => Destroy(child));
            children.Clear();

            foreach (Transform child in panel2) children.Add(child.gameObject);
            children.ForEach(child => Destroy(child));
        }  
    }

    private void setAttackImages(GameObject Attacker, GameObject Target, int numberOfAttack)
    {
        var panel = GameObject.Find("Panel" + numberOfAttack).transform.Find("Card1"); //wyciagniecie paneli
        var panel2 = GameObject.Find("Panel" + numberOfAttack).transform.Find("Card2");

        GameObject AttackerImage = Attacker.transform.Find("CardImage").gameObject; // wyciagniecie zdjec
        GameObject TargetImage = Target.transform.Find("CardImage").gameObject;

        GameObject miniCard2 = Instantiate(TargetImage); // nowe instancje
        miniCard2.transform.SetParent(panel2.transform, false);

        GameObject miniCard = Instantiate(AttackerImage);
        miniCard.transform.SetParent(panel.transform, false);

        var children = new List<GameObject>(); // usuniecie napisow
        foreach (Transform child in miniCard2.transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));

        children.Clear();
        foreach (Transform child in miniCard.transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));
    }
}
