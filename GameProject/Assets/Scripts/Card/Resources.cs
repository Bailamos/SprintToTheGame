using UnityEngine;
using System.Collections;

public class Resources : MonoBehaviour {

    public int like, snap, tweet;



    public void drainResources(int l, int s, int t){
        if ( checkIfEnough(l,s,t)){
            this.like -= l;
            this.snap -= s;
            this.tweet -= t;
        }
    }

    private bool checkIfEnough(int l, int s, int t){
        if ( like >= l && snap >= s && tweet >= t){
            return true;
        }else{
            return false;
        }
    }
}
