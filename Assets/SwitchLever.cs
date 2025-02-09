using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SwitchLever : XRBaseInteractable
{
    private Quaternion startRotation;
    private bool isOn = false;

    protected override void Awake()
    {
        base.Awake();
        startRotation = transform.localRotation;
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
            transform.localRotation = startRotation * Quaternion.Euler(0, 0, -45);
        }
        else
        {
            // Rotate the lever back to the "off" position
            transform.localRotation = startRotation;
        }
    }
}
