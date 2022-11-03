using Cinemachine;
using UnityEngine;

public class InteractableKeypad : Interactable
{
    public CinemachineVirtualCamera keypadCamera;
    

    private new void Awake()
    {
        base.Awake();
        keypadCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }
    public override void EnterInteraction()
    {
        base.EnterInteraction();
        keypadCamera.enabled = true;
    }

    public override void ExitInteraction()
    {
        base.ExitInteraction();
        keypadCamera.enabled = false;
    }

 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ExitInteraction();
        }
    }
}

