using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AttackRound : MonoBehaviour
{
    public List<Attack> listOfAttacks;
    //public List<Attack> attacksOnPLayer;
    public List<AttackPanel> panelAttakcs;
    int numberOfPanel; // number of Panel in Planned Attacks, which is needed in assigning Fight to Panel
    
    void Start()
    {
        listOfAttacks = new List<Attack>();
        panelAttakcs = new List<AttackPanel>();
        
        numberOfPanel = 1;
    }

    public void addAttack(GameObject Attacker, GameObject Target, bool enemyAttk)
    {
        Attack attkTemp = new Attack(Attacker, Target, enemyAttk);
        if (listOfAttacks.Find(e => e.Attacker.Equals(Attacker)) == null)
        {
            setAttackImages(Attacker, Target, enemyAttk);
            listOfAttacks.Add(attkTemp);
            Attacker.transform.GetComponent<Image>().color = Color.red;
        }
        else
        {
            Debug.Log("Dana jednostka już atakuje kogoś!");
        }
    }

    public void startAttack()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("sendStartAttack", PhotonTargets.Others);
        attack();
    }

    [PunRPC]
    void sendStartAttack()
    {
        attack();
    }
    private void attack()
    {
        foreach (Attack attck in listOfAttacks)
        {
            Statistics zycie = attck.Target.GetComponent<Statistics>();

            bool destroyBool = zycie.attack(attck.Attacker.GetComponent<Statistics>().atk);
            if (destroyBool) zycie.isAlive = false;

            attck.Attacker.transform.GetComponent<Image>().color = Color.black;
        }

        listOfAttacks.Clear();
        panelAttakcs.Clear();
        clearAttackPanel();
        numberOfPanel = 1;
    }

    private void clearAttackPanel()
    {
        for (int i = 1; i <= 5; i++)
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

    private void setAttackImages(GameObject Attacker, GameObject Target, bool enemyAttk)
    {
        bool isTargetUnderAttack = false;
        GameObject panel;

        if (listOfAttacks.Find(e => e.Target.Equals(Target)) != null) //is this creature under attack ?
        {
            isTargetUnderAttack = true;

            int tmpPanelNumber = panelAttakcs.Find(t => t.Target.Equals(Target)).panelNumber;
            panel = GameObject.Find("Panel" + tmpPanelNumber);
        }
        else
        {
            panel = GameObject.Find("Panel" + numberOfPanel); //wyciagniecie paneli
            panelAttakcs.Add(new AttackPanel(Attacker, Target, numberOfPanel));
        }

        var card1 = panel.transform.Find("Card1");

        Image attackerImage = Attacker.transform.Find("CardImage").gameObject.GetComponent<Image>(); // wyciagniecie zdjec
        Image miniImage = Instantiate(attackerImage); // nowe instancje
        miniImage.transform.SetParent(card1.transform, false); // dodanie rodzica

        var children = new List<GameObject>(); // usuniecie napisow --------- do usuniecia jak nie bedzie napisu w zdjeciu  
        foreach (Transform child in miniImage.transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));

        if (!isTargetUnderAttack)
        {
            var card2 = panel.transform.Find("Card2");
            Image TargetImage;
            if(Target.GetComponent<Statistics>().isCard == true)
            {
                TargetImage = Target.transform.Find("CardImage").gameObject.GetComponent<Image>();
            }
            else
            {  
                if(enemyAttk) TargetImage = GameObject.Find("PlayerImage").GetComponent<Image>();
                else TargetImage = GameObject.Find("EnemyPlayerImage").GetComponent<Image>();
            }
            
            Image miniImage2 = Instantiate(TargetImage); ;
            miniImage2.transform.SetParent(card2.transform, false);

            children.Clear();
            foreach (Transform child in miniImage2.transform) children.Add(child.gameObject);
            children.ForEach(child => Destroy(child));

            numberOfPanel++;
        }
    }
}
