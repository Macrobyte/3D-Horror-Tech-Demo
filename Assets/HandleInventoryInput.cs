using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HandleInventoryInput : MonoBehaviour
{
    private GameObject inventory;
    
    public void Awake()
    {
        inventory = GameObject.Find("Inventory");
        inventory.SetActive(false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventory.activeSelf)
            {
                SetCursorState(true);
                inventory.SetActive(false);
                Time.timeScale = 1;
            }
                
            else
            {
                SetCursorState(false);
                inventory.SetActive(true);
                Time.timeScale = 0;
            }
        }
        
    }

    private void SetCursorState(bool newState)
    {
        UnityEngine.Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
