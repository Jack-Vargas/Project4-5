using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallOneWay : MonoBehaviour
{
    public GameObject CurrentPlatform;
    [SerializeField] private BoxCollider2D playerCollider;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            if (CurrentPlatform != null)
            {
                StartCoroutine(DissableCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OWPlatform"))
        {
            CurrentPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OWPlatform"))
        {
            CurrentPlatform = null;
        }
    }

    private IEnumerator DissableCollision()
    {
        BoxCollider2D platformCollider = CurrentPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }

}
