using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public BoxCollider doorCloseTrigger;
    public Transform openDoorStopPoint;
    public Transform closeDoorStopPoint;
    public Transform door;
    public CinemachineVirtualCamera doorOpenCamera;
    public CinemachineVirtualCamera doorCloseCamera;
    

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
        doorOpenCamera.enabled = true;
        yield return new WaitForSeconds(1f);
        while (door.position != openDoorStopPoint.position)
        {
            door.position = Vector3.MoveTowards(door.position, openDoorStopPoint.position, 1f * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        doorOpenCamera.enabled = false;
    }


    IEnumerator CloseDoorCoroutine()
    {
        doorCloseCamera.enabled = true;
        while (door.position != closeDoorStopPoint.position)
        {
            door.position = Vector3.MoveTowards(door.position, closeDoorStopPoint.position, 3f * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        doorCloseCamera.enabled = false;
    }


}
