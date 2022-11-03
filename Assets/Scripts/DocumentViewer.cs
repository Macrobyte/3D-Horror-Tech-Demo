using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DocumentViewer : MonoBehaviour, IDragHandler
{
    
    public GameObject documentPrefab;
    private GameObject document;

    private void OnEnable()
    {
        document = Instantiate(documentPrefab, new Vector3(0, -6, 0), Quaternion.identity);
    }
    public void OnDrag(PointerEventData eventData)
    {
        document.transform.eulerAngles += new Vector3(-eventData.delta.y, -eventData.delta.x);
    }

    private void OnDisable()
    {
        Destroy(document);
    }

}
