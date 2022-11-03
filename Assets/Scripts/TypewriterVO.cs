using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TypewriterVO : MonoBehaviour
{
    [TextArea(3, 10)]
    public string fullText;
    
    public string currentText = "";
    
    public float typeDelay = 0.1f;
    
    public TMPro.TextMeshProUGUI displayText;
    
    public AudioClip voiceOverClip;
    
    public AudioSource voiceOverSource;

    public Collider triggerCollider;

    public UnityEvent onTextFinished;

    public void PlayText()
    {
        voiceOverSource.clip = voiceOverClip;
        StartCoroutine(TypeText());    
    }
    
    IEnumerator TypeText()
    {
      
        voiceOverSource.Play();
        
        for (int i = 0; i < fullText.Length; i++)
        {          
            currentText = fullText.Substring(0, i);
            displayText.text = currentText;
            yield return new WaitForSeconds(typeDelay);
            displayText.text = currentText;
            
        }
        yield return new WaitForSeconds(1f);
        onTextFinished.Invoke();
    }
    
}
