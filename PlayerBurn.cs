using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBurn : MonoBehaviour
{
    public GameObject fireVisual;
    public bool onFire;

    public void StartBurn(float rate, int noBurn)
    {
        StartCoroutine(Burn(rate, noBurn));
    }

    public IEnumerator Burn(float rate, int noBurn)
    {
        for (int i = 0; i < noBurn; i ++)
        {
            yield return new WaitForSeconds(rate);
            fireVisual.SetActive(true);
            yield return new WaitForSeconds(1f);
            fireVisual.SetActive(false);
        }
        onFire = false;
    }
}
