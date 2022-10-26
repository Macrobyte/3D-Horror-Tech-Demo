using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public new Camera camera;

    [SerializeField][Range(1,5)]public float interactionDistance;

    public TMPro.TextMeshProUGUI interactionText;

    KeyCode interactKey = KeyCode.E;

    public Interactable interactableObject;

    void Start()
    {
       
    }


    void Update()
    {
        RaycastHit hit;
        
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

        bool successfulHit = false;
        
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            Transform objectHit = hit.transform;

            if (objectHit.GetComponent<Interactable>() != null)
            {
                if (interactableObject != objectHit && interactableObject != null)
                {
                    interactableObject.Highlight(false);
                    interactableObject = null;
                }

                if (interactableObject == null)
                {
                    interactableObject = objectHit.GetComponent<Interactable>();
                    interactableObject.Highlight(true);

                    HandleInteraction(interactableObject);

                    interactionText.text = interactableObject.GetDescription();

                    successfulHit = true;
                }

                

                Debug.Log("Looking at " + interactableObject.name);
            }
        }
        else if (interactableObject != null)
        {
            interactableObject.Highlight(false);
            interactableObject = null;
            Debug.Log("No interactable in range");
        }

        if (!successfulHit) interactionText.text = "";
        

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

