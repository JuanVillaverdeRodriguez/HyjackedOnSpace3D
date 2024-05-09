using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CageController : MonoBehaviour, Interactable
{
    public string InteractPrompt => throw new System.NotImplementedException();

    private float timePassed = 0.0f;
    public Slider UISlider;

    public TextMeshProUGUI UIRemainingHostajesText;
    public void Interact(Interactor interactor)
    {
        timePassed = interactor.getTimePressed();
        if (timePassed > 1.0f) {
            Destroy(gameObject);
        }
        
        UISlider.value = interactor.getTimePressed();

    }
    void OnDestroy() {
        if (UIRemainingHostajesText != null) {
            UIRemainingHostajesText.GetComponent<UIRemainingHostajesText>().UpdateText();
        }
        UISlider.value = 0.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
