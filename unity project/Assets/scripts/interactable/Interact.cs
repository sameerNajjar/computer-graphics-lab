using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interact : MonoBehaviour
{
    [SerializeField] private string message;

    public void baseInteraxt() {
        interact();
    }
    public virtual void interact() {
    }
    public virtual string getMSG() {
        return message;
    }
}
