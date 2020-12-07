using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LookAtTrigger : MonoBehaviour
{
    public Transform player;
    public Transform trigger;

    [Range(0f, 1f)] 
    public float preciseness = 0.5f;

    private void OnDrawGizmos()
    {
        Vector2 playerPos = player.localPosition;
        Vector2 triggerPos = trigger.position;
        
        Vector2 playerLookDir = player.right;
        Vector2 playerToTriggerDir = (triggerPos - playerPos).normalized;

        float lookness = Vector2.Dot(playerToTriggerDir, playerLookDir);

        bool isLooking = lookness >= preciseness;

        Handles.color = isLooking ? Color.green : Color.red;
        Handles.DrawDottedLine(playerPos, playerPos + playerToTriggerDir, 10f);
        
        Handles.color = Color.blue;
        Handles.DrawLine(playerPos, playerPos + playerLookDir);
        
    }
}
