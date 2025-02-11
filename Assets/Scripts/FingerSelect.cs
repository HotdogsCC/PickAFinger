using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FingerSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [Header("Object References")]
    [SerializeField] private FingerManager fingerManager;

    [Header("Attributes")]
    [SerializeField] private FingerManager.Finger finger;
    [Range(0f, 10f)]
    [SerializeField] private float outlineWidth;
    
    private Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();

        if(outline == null)
        {
            Debug.LogWarning("You need to include the Outline script for FingerSelect");
        }
        if(fingerManager == null)
        {
            Debug.LogWarning("You need to include the FingerManager reference for FingerSelect");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        outline.OutlineWidth = outlineWidth;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        outline.OutlineWidth = 0f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("chop chop");
        //removes the finger from the hand
        fingerManager.RemoveFinger(finger);
        Destroy(gameObject);
        
    }
}
