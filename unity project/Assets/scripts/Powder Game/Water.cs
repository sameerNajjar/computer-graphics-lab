using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
     private bool Salty = false;

    public bool isSalry() {
        return Salty;
    }
    public void setSalty(bool flag) {
        Salty = flag;
    }
}
