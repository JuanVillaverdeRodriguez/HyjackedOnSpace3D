using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIRemainingHostajesText : MonoBehaviour
{
    public int numberOfHostajes = 0;

    public void UpdateText() {
        TextMeshProUGUI textField = gameObject.GetComponent<TextMeshProUGUI>();

        int newNumber = int.Parse(textField.text) - 1;

        gameObject.GetComponent<TextMeshProUGUI>().text = newNumber.ToString();
        if (newNumber <= 0)
        {
            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
        
 
    }
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = numberOfHostajes.ToString();
    }

}
