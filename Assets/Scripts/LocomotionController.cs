using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController leftTeleportRay;
    public XRController rightTeleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;
    private XRRayInteractor rightRayInteractor;
    private XRRayInteractor leftRayInteractor;
    public bool useLeftAndRightSimultaneously = false;

    private void Start()
    {
        // Get rightTeleportRay reference
        if (rightTeleportRay)
            rightRayInteractor = rightTeleportRay.gameObject.GetComponent<XRRayInteractor>();
        // Get leftTeleportRay reference
        if (leftTeleportRay)
            leftRayInteractor = leftTeleportRay.gameObject.GetComponent<XRRayInteractor>();

        // Check if we got it
        if (leftTeleportRay == null)
            Debug.LogError("No leftTeleportRay reference found");

        // Check if we got it
        if (rightTeleportRay == null)
            Debug.LogError("No rightTeleportRay reference found");
    }
    private void Update()
    {
        if (!useLeftAndRightSimultaneously)
        {
            // Check if left controller is active (pressed button)
            var leftIsActive = CheckIfActivated(leftTeleportRay);
            // Check if right controller is active (pressed button)
            var rightIsActive = CheckIfActivated(rightTeleportRay);

            // We can use left controller if we press the left trigger button controller while we are NOT using the right trigger button controller.
            if (leftTeleportRay && !rightIsActive)
            {
                // Get trigger status
                leftRayInteractor.allowSelect = leftIsActive;
                // Change status (active / not active)
                leftTeleportRay.gameObject.SetActive(CheckIfActivated(leftTeleportRay));
            }

            // We can use right controller if we press the right trigger button controller while we are NOT using the left trigger button controller.
            if (rightTeleportRay && !leftIsActive)
            {
                // Get trigger status
                rightRayInteractor.allowSelect = rightIsActive;
                // Change status (active / not active)
                rightTeleportRay.gameObject.SetActive(CheckIfActivated(rightTeleportRay));
            }
        }
        else
        {
            // We can use left controller if we press the left trigger button controller while we are NOT using the right trigger button controller.
            if (leftTeleportRay)
            {
                // Get trigger status
                leftRayInteractor.allowSelect = CheckIfActivated(leftTeleportRay);
                // Change status (active / not active)
                leftTeleportRay.gameObject.SetActive(CheckIfActivated(leftTeleportRay));
            }

            // We can use right controller if we press the right trigger button controller while we are NOT using the left trigger button controller.
            if (rightTeleportRay)
            {
                // Get trigger status
                rightRayInteractor.allowSelect = CheckIfActivated(rightTeleportRay);
                // Change status (active / not active)
                rightTeleportRay.gameObject.SetActive(CheckIfActivated(rightTeleportRay));
            }
        }
    }
    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }
}
