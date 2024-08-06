using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public PlayerBurn script;
    public float rate;
    public int noBurn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (script.onFire == false)
        {
            script.onFire = true;
            script.StartBurn(rate, noBurn);
        }
    }
}
