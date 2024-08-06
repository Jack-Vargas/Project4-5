using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Mic : MonoBehaviour
{
    public AudioSource src;
    public bool Ready = false;
    public AudioClip sfx;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.GetComponent<Collider2D>().tag == "Player")
        {
            Ready = true;
        }
    }


    private void Update()
    {
        if (Ready == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                src.clip = sfx;
                src.Play();
                //PlaySound();
            }
        }
    }

    /*public void PlaySound()
    {
        
    }*/

    void OnTriggerExit2D()
    {
        Ready = false;
    }
}
