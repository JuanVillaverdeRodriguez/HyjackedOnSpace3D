using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pasarelaOrdenador : MonoBehaviour
{
    [SerializeField] private string _prompt;

    public string InteractPrompt => _prompt;

    private bool rotating = false;
    private float rate = -20.0f;
    private float count = 0.0f;

    public void Interact(Interactor interactor)
    {
        if (count == 0){
            rotating = true;
        }
        Debug.Log("RotandoPasarela");
    }

    void Update()
    {
        if(rotating){
            if(count > -90.0f){
                GameObject pasarela = GameObject.Find("PasarelaMovil");
                if(pasarela != null)
                {
                    pasarela.transform.Rotate(Vector3.up*rate*Time.deltaTime);
                }
                count += Time.deltaTime * rate;
            }else{
                count=0.0f;
                rotating=false;
            }
        }
    }
}
