using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Koopa : MonoBehaviour
{
    public bool inShell = false;
    public float speed;
    public Rigidbody2D rb2d;
    public GameObject Player;
    public bool hitByPlayer;
    private SpriteRenderer spriteR;
    public Sprite shellSprite;
    public bool moving;

    private void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.GetComponent<BoxCollider2D>().tag == "Player")
        {
            if (inShell == false)
            {  
                Shell();
            }
            hitByPlayer = true;
            moving = true;
        }
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        
    }

    private void Update()
    {
        if (moving == true)
        {
            Debug.Log("i should be moving");
            if (Player.transform.position.x >= gameObject.transform.position.x)
            {
                rb2d.velocity = new Vector2(speed * -1, rb2d.velocity.y);
            }
            else if (Player.transform.position.x < gameObject.transform.position.x)
            {
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            }
        }
    }


    void Shell()
    {
        spriteR.sprite = shellSprite;

        inShell = true;
    }
}
