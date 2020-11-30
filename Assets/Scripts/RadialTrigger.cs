using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{
    public Transform origin;
    public Transform target;

    [Range(0, 5)] 
    public float radius = 1.0f;
    
    private void OnDrawGizmos()
    {
        Vector3 originPos = origin.position;
        Vector3 targetPos = target.position;

        float distance = Vector3.Distance(originPos, targetPos);
        bool isInside = distance < radius;

        Handles.color = isInside ? Color.green : Color.red;
        
        Handles.DrawWireDisc(originPos, Vector3.forward, radius);
    }
}
