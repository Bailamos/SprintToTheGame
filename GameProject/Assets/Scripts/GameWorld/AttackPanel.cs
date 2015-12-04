using UnityEngine;
using System.Collections;

public class AttackPanel {

    public GameObject Attacker;
    public GameObject Target;
    public int panelNumber;

    public AttackPanel(GameObject attck, GameObject trgt, int pNumber)
    {
        Attacker = attck;
        Target = trgt;
        panelNumber = pNumber;
    }
}
