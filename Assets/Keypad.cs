using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Keypad : MonoBehaviour, Interactable
{
    public string InteractPrompt => throw new System.NotImplementedException();

    public int correctPassword = 1234;

    private int pressedButton = 0;

    public Canvas keypadGUI;

    public TextMeshProUGUI keypadText;

    public GameObject player;

    public GameObject door;

    public void Interact(Interactor interactor)
    {
        clearPassword();
        openKeypad();
    }

    public void buttonPressed(int number) {
        pressedButton = number;
        keypadText.text += number.ToString();
    }

    public void checkPassword() {
        if (keypadText.text != null) {
            int inputPassword = int.Parse(keypadText.text);
            if (inputPassword == correctPassword) {
            closeKeypad();
            openDoor();
            // Reproducir sonido de acierto
            }
            else {
                // Reproducir sonido de error
            }

        }

    }

    public void clearPassword() {
        keypadText.text = "";
    }
    private void openKeypad() {
        keypadGUI.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<PlayerMovement>().blockMovement();
    }

    public void openDoor() {
        Destroy(door);
    }

    public void closeKeypad() {
        keypadGUI.enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<PlayerMovement>().enableMovement();


    }
    void Start()
    {
        keypadGUI.enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
    }
}
