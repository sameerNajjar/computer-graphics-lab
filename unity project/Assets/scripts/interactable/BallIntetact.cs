using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallIntetact : Interact
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void interact() {
        Debug.Log("Ball ");
        Destroy(gameObject);
    }
}
