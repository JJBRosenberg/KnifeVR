using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction;
using UnityEngine.XR;
using UnityEngine.XR.OpenXR.Input;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerRumble : MonoBehaviour
{
    [SerializeField] XRBaseController rightHand;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        rightHand.SendHapticImpulse(0.7f, 2f);
    }
}
