using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public new Camera camera;

    [SerializeField][Range(1,5)]public float interactionDistance;

    private TMPro.TextMeshProUGUI interactionText;
    private TMPro.TextMeshProUGUI NameText;

    KeyCode interactKey = KeyCode.E;

    public Interactable interactableObject;

    
    
    void Start()
    {
        interactionText = GameObject.FindGameObjectWithTag("InteractionText").GetComponent<TMPro.TextMeshProUGUI>();
        NameText = GameObject.FindGameObjectWithTag("NameText").GetComponent<TMPro.TextMeshProUGUI>();
    }


    void Update()
    {
        HandleInteractableDetection();
    }

    private void HandleInteractableDetection()
    {
        RaycastHit hit;

        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

        bool successfulHit = false;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.transform.GetComponent<Interactable>() != null)
            {
                interactableObject = hit.transform.GetComponent<Interactable>();

                if (interactableObject != null)
                {
                    interactableObject.GetComponent<Outline>().enabled = true;

                    interactionText.text = interactableObject.GetInteractionDescription();

                    NameText.text = interactableObject.GetName();

                    HandleInteraction(interactableObject);

                    successfulHit = true;
                }
            }
            else
            {
                if (interactableObject != null)
                {
                    interactableObject.GetComponent<Outline>().enabled = false;
                    interactableObject = null;
                }
            }
        }
        else
        {
            if (interactableObject != null)
            {
                interactableObject.GetComponent<Outline>().enabled = false;
                interactableObject = null;
            }       
        }

        if (!successfulHit)
        {
            interactionText.text = "";
            NameText.text = "";
        } 
    }

    
    private void HandleInteraction(Interactable interactable)
    {
        switch (interactable.interactableType)
        {
            case Interactable.InteractableType.Item:
                if (Input.GetKeyDown(interactKey))
                {
                    interactable.EnterInteraction();
                }
                break;
            case Interactable.InteractableType.Keypad:
                if (Input.GetKeyDown(interactKey))
                {
                    interactable.EnterInteraction();
                }
                break;
            case Interactable.InteractableType.Document:
                if (Input.GetKeyDown(interactKey))
                {
                    interactable.EnterInteraction();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
      
    }

    private void OnDisable()
    {
        interactionText.text = "";
        NameText.text = "";
    }
}

