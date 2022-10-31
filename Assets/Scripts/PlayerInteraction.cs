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
                    
                    interactionText.text = interactableObject.GetInteraction();
                    
                    NameText.text = interactableObject.GetName();

                    HandleInteraction(interactableObject);

                    successfulHit = true;
                    
                    Debug.Log("Looking at " + interactableObject.name);
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

            Debug.Log("Looking at nothing");
        }

        if (!successfulHit)
        {
            interactionText.text = "";
            NameText.text = "";
        }
        

        Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.yellow);
    }

    private void HandleInteraction(Interactable interactable)
    {
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
                if (Input.GetKeyDown(interactKey))
                {
                    interactable.Interact();
                }
                break;
            case Interactable.InteractionType.Puzzle:
                //make puzzle appear
                break;
            default:
                break;
        }
    }
}

