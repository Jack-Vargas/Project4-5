using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CampFire : MonoBehaviour
{
    public Sanji script;
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (script.talkedToSanji == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
