using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIRemainingHostajesText : MonoBehaviour
{
    public int numberOfHostajes = 0;

    public void UpdateText() {
        TextMeshProUGUI textField = gameObject.GetComponent<TextMeshProUGUI>();

        int newNumber = int.Parse(textField.text) - 1;

        gameObject.GetComponent<TextMeshProUGUI>().text = newNumber.ToString();
        
 
    }
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "5";
    }

}
