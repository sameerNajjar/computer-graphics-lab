using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Sand : MonoBehaviour {

    private void Update() {
        Vector3 sandPos = transform.position;

        float radius = 0.5f; 
        Bounds region = new Bounds(sandPos, Vector3.one * radius * 2f);
        Collider[] colliders = Physics.OverlapBox(region.center, region.extents);
        foreach (Collider collider in colliders) {
        }
    }

}