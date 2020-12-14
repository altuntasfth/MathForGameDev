using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpaceTransformation : MonoBehaviour
{
    public Transform child1;
    public Transform localObject;
    
    public Vector2 pointPos;
    
    private void OnDrawGizmos()
    {
        Vector2 child1Pos = child1.position;
        Vector2 right = child1.right;
        Vector2 up = child1.up;
        
        DrawBasicVector(Vector2.zero, Vector2.right, Vector2.up);
        DrawBasicVector(child1Pos, right, up);
        
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(pointPos, 0.1f);

        Vector2 LocalToWorld(Vector2 localPointPos)
        {
            Vector2 worldOffset = right * localPointPos.x + up * localPointPos.y;
            return (Vector2)child1Pos + worldOffset;
        }

        Vector2 pointWorldPos = LocalToWorld(pointPos);
        Gizmos.DrawSphere(pointWorldPos, 0.1f);

        Vector2 WorldToLocal(Vector2 worldPointPos)
        {
            Vector2 localOffset = worldPointPos - child1Pos;

            float x = Vector2.Dot(localOffset, right);
            float y = Vector2.Dot(localOffset, up);
            
            return new Vector2(x, y);
        }

        localObject.localPosition = WorldToLocal(pointPos);    
    }

    void DrawBasicVector(Vector2 origin, Vector2 right, Vector2 up)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(origin, right);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(origin, up);
        Gizmos.color = Color.white;
    }
}
