using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableDocument : Interactable
{
    public GameObject documentViewer;
    
    public override void EnterInteraction()
    {
        base.EnterInteraction();
        documentViewer.SetActive(true);  
    }
    

}
