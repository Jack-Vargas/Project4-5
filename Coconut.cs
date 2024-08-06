using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour
{
    public Behaviour Dash;
    public GameObject ds;

    private void OnTriggerEnter2D()
    {
        Dash.enabled = true;
        ds.SetActive(true);
        Destroy(gameObject);
    }
}
