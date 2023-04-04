using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Interact : MonoBehaviour
{
    [SerializeField] private string message;
    [SerializeField] private string interactText;

    public void baseInteraxt() {
        interact();
    }
    public virtual void interact() {
    }
    public virtual string getMSG() {
        return message;
    }
    public virtual string getinteractText() {
        return interactText;
    }
}
