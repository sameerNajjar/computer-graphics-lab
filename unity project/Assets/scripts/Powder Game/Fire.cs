using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private bool wood = false;

    public bool isWood() {
        return wood;
    }
    public void setSalty(bool flag) {
        wood = flag;
    }
}
