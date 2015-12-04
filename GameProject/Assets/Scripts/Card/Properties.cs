using UnityEngine;
using System.Collections;


public class Properties : MonoBehaviour {
    public enum typy { Melee,Archers,Magic};
    public bool isEnemy;
    public int CardId;
    public typy type;
    public string description;

}
