using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OpenAndCloseWristMenu : MonoBehaviour
{
    public InputHelpers.Button inputHelpers = InputHelpers.Button.MenuButton;
    public XRNode controller = XRNode.LeftHand;
    public GameObject canvasObject; //Drag canvas obj to this variable in the editor
    private bool isPressed;
    private bool pressed;
    public GameObject PlayerVrRig;
    public float targetScale = 0.1f;
    public float shrinkSpeed = 2f;

    private void Start() {
        pressed = false;
    }

    void Update()
    {
        //When left controller's y button is pressed, check if menu is active or inactive.
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(controller), inputHelpers, out isPressed);

        if (isPressed && !pressed)
        {
            //If the canvas menu is inactive, activate it
            if (canvasObject.activeSelf == false)
            {
                canvasObject.SetActive(true);
            }
            //If the canvas menu is active, deactivate it
            else
            {
                canvasObject.SetActive(false);
            }
            pressed = true;
        }
        else if (!isPressed) {
            pressed = false;
        }
    }

    public void AskForHelp()
    {
        //If the canvas menu is inactive, activate it
            if (canvasObject.activeSelf == false)
            {
                canvasObject.SetActive(true);
            }
        //If the canvas menu is active, deactivate it
        else
        {
            canvasObject.SetActive(false);
        }
    }

    public void Shrink()
    {
        //This will shrink the player so they can find the Easter Egg
        PlayerVrRig.transform.localScale = Vector3.Lerp(PlayerVrRig.transform.localScale, new Vector3(targetScale, targetScale, targetScale), Time.deltaTime * shrinkSpeed);
        Debug.Log("Congrats you have shrunk and started the Easter Egg!");
    }

    public void StartGame_EasterEgg()
    {
        Debug.Log("You have entered the Easter Egg scene");
        //Go to the EasterEgg scene
        SceneManager.LoadScene(2);
    }

    public void EndGame_EasterEgg()
    {
        Debug.Log("You have left the EasterEgg scene");
        //Go back to the main GroceryStore scene
        SceneManager.LoadScene(1);
    }
}
