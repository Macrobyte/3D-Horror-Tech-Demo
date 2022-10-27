using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Highlighting Variables
    private Material defaultMat;
    private Material highlightMat;
    private Material[] materials;
    private MeshRenderer meshRenderer;
    private bool isHighlighted = false;

    public enum InteractionType
    {
        Click,
        Puzzle       
    }
    
    public InteractionType interactionType;


    private void Start()
    {    
        meshRenderer = GetComponent<MeshRenderer>();
        
        materials = new Material[2];

        for (int i = 0; i < meshRenderer.materials.Length; i++)
        {
            materials[i] = meshRenderer.materials[i];
        }

        defaultMat = materials[0];
        highlightMat = materials[1];
    }

    private void Update()
    {
        if (!isHighlighted)
        {
            materials[0] = defaultMat;
            materials[1] = null;
            meshRenderer.materials = materials;
        }
        else
        {
            materials[0] = defaultMat;
            materials[1] = highlightMat;
            meshRenderer.materials = materials;
        }
    }


    public abstract string GetDescription();
    public abstract void Interact();
    
    public void SetHighlight(bool highlightState)
    {
        isHighlighted = highlightState;
    }
}
