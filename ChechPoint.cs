using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChechPoint : MonoBehaviour
{
    private GameManager GM;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GM.lastCheckPointPos = transform.position;
        }
    }
   
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }
}
