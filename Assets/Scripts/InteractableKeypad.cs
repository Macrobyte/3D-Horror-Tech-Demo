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
    public override void Interact()
    {

        player.GetComponent<PlayerInteraction>().enabled = false;
        player.SetActive(false);
        keypadCamera.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            keypadCamera.enabled = false;
            player.SetActive(true);
            player.GetComponent<PlayerInteraction>().enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

