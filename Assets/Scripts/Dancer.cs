using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour
{
    public float sensitivity;
    public float enhancer;
    public GameObject particles;

    public void Dance(float volume)
    {
        volume -= 0.15f;
        if (volume < 0) volume = 0f;
        if (volume > 0.2f) Instantiate(particles, transform.position, Quaternion.identity);
        
        transform.localScale = Vector3.one * (0.5f + Mathf.Pow(volume, sensitivity)) * enhancer;
    }
}
