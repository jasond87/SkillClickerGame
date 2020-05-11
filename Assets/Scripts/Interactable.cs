using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 3f; // interact distance.

    public Transform interactionTransform;

    bool mouseMovedOver = false;


    private void Awake()
    {
        SetTransform();
    }

    public virtual void Interact() {


        Debug.Log("Interactive with " + transform.name);
    
    }

    private void Update()
    {
        if (mouseMovedOver) {
            Interact();
        }       
    }


    public void OnMouseOver()
    {
        mouseMovedOver = true;        
    }

    public void OnMouseExit()
    {
        mouseMovedOver = false;
    }

    private void SetTransform() {

        if (interactionTransform == null)
        {
            Debug.Log("transform is null - setting transform");
            interactionTransform = transform;
        }
    }

}
