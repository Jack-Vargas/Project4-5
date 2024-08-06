using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public bool dashAv;
    public PlayerMove script;
    private float clDwn;
    public float dashRate;
    public float dashPwr;
    public float dashDur; //time spent dashing
    public bool isDashing;

    void Update()
    {      
        if (Input.GetKeyDown(KeyCode.R) && dashAv == true && Time.time > clDwn)
        {
            StartCoroutine(DashGo());

            clDwn = Time.time + 1f / dashRate;
            dashAv = false;
        }
    }

    public IEnumerator DashGo()
    {
        isDashing = true;
        float origonalGravity = script.rb2D.gravityScale; 
        script.rb2D.gravityScale = 0f;

        if (script.IsFacingRight == true)
        {
            script.rb2D.velocity = new Vector2(transform.localScale.x * dashPwr, 0f);
        }

        else
        {
            script.rb2D.velocity = new Vector2(transform.localScale.x * dashPwr * -1, 0f);
        }

        yield return new WaitForSeconds(dashDur);
        script.rb2D.gravityScale = origonalGravity;
        isDashing = false;
    }
}

