using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHighlighter : MonoBehaviour
{

    private void Awake()
    {
        var outline = gameObject.AddComponent<Outline>();
        outline.OutlineColor = Color.yellow;
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.enabled = false;
    }
    
  

    
}
