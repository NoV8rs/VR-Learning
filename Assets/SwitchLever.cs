using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SwitchLever : XRBaseInteractable // Inherit from XRBaseInteractable to use the XR Interaction Toolkit
{
    private Quaternion startRotation; // The initial rotation of the lever
    public bool isOn = false; // The state of the lever
    
    public GameObject[] targetObject;

    protected override void Awake()
    {
        base.Awake();
        startRotation = transform.localRotation;
    }
    
    private void Start()
    {
        SetTargetObjectsActive(false);
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        ToggleSwitch();
    }
    
    private void ToggleSwitch()
    {
        isOn = !isOn;
        if (isOn)
        {
            // Rotate the lever to the "on" position
            transform.localRotation = startRotation * Quaternion.Euler(5, 0, 0);
            // Activate the target object
            if (targetObject != null)
            {
                foreach (GameObject obj in targetObject)
                {
                    obj.SetActive(true);
                }
            }
        }
        else
        {
            // Rotate the lever back to the "off" position
            transform.localRotation = startRotation;
            // Deactivate the target object
            if (targetObject != null)
            {
                foreach (GameObject obj in targetObject)
                {
                    obj.SetActive(false);
                }
            }
        }
    }
    
    private void SetTargetObjectsActive(bool isActive)
    {
        if (targetObject != null)
        {
            foreach (GameObject obj in targetObject)
            {
                obj.SetActive(isActive);
            }
        }
    }
}
