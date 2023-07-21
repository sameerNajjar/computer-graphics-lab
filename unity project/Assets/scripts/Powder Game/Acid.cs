using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour {
    private bool destroy = false;

    public bool getDestroy() {
        return destroy;
    }
    public void setSalty(bool flag) {
        destroy = flag;
    }
} 
