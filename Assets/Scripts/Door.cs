using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform openDoorStopPoint;
    public Transform closeDoorStopPoint;
    public Transform door; 

    private void Awake()
    {
       
    }
    public void OpenDoor()
    {  
        StartCoroutine(OpenDoorCoroutine());
    }

    public void CloseDoor()
    {
        StartCoroutine(CloseDoorCoroutine());
    }

    IEnumerator OpenDoorCoroutine()
    {
        
        while (door.position != openDoorStopPoint.position)
        {
            door.position = Vector3.MoveTowards(door.position, openDoorStopPoint.position, 1f * Time.deltaTime);
            yield return null;
        }
    }


    IEnumerator CloseDoorCoroutine()
    {
        while (door.position != closeDoorStopPoint.position)
        {
            door.position = Vector3.MoveTowards(door.position, closeDoorStopPoint.position, 3f * Time.deltaTime);
            yield return null;
        }
    }


}
