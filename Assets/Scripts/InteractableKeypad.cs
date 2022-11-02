using Cinemachine;
using UnityEngine;

public class InteractableKeypad : Interactable
{
    public CinemachineVirtualCamera keypadCamera;
    public GameObject player;

    private new void Awake()
    {
        base.Awake();
        keypadCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }
    public override void EnterInteraction()
    {

        player.GetComponent<PlayerInteraction>().enabled = false;
        player.SetActive(false);
        keypadCamera.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ExitInteraction()
    {
        player.GetComponent<PlayerInteraction>().enabled = true;
        player.SetActive(true);
        keypadCamera.enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitInteraction();
        }
    }
}

