using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
    
{
    public AudioClip soundtoplay;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySound(soundtoplay);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
