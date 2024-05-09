using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public float scrollSpeedX = 0.5f;
    public float scrollSpeedY = 0.5f;
    public string textureName = "_MainTex";

    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer> ();
    }

    void Update()
    {
        float offsetX = Time.time * scrollSpeedX;
        float offsetY = Time.time * scrollSpeedY;

        rend.material.SetTextureOffset(textureName, new Vector2(offsetX, offsetY));
        
    }
}
