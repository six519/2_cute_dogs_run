using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidaScript : MonoBehaviour
{
    private Animator thisAnimator;
    private Rigidbody2D rb;
    public AudioSource BarkSound;
    private float previousAnimSpeed;
    private float baseAnimSpeed;
    private bool canJump = true;
    private float PrevAddSpeed;
    public ParticleSystem dust;
    void Start()
    {
        PrevAddSpeed = GlobalVariableScript.AdditionalSpeed;
        thisAnimator = this.GetComponent<Animator>();
        previousAnimSpeed = thisAnimator.speed;
        baseAnimSpeed = previousAnimSpeed;
        rb = this.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(GameObject.Find("close").GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(GameObject.Find("clicker").GetComponent<Collider2D>(), this.GetComponent<Collider2D>());

        if (GlobalVariableScript.SelectedCharacter == 0)
        {
            thisAnimator.runtimeAnimatorController = Resources.Load("1") as RuntimeAnimatorController;
        } else
        {
            thisAnimator.runtimeAnimatorController = Resources.Load("2_1") as RuntimeAnimatorController;
        }
    }

    private void Update()
    {
        if (PrevAddSpeed != GlobalVariableScript.AdditionalSpeed)
        {
            PrevAddSpeed = GlobalVariableScript.AdditionalSpeed;
            previousAnimSpeed = baseAnimSpeed + PrevAddSpeed;

            if (canJump)
            {
                thisAnimator.speed = baseAnimSpeed + PrevAddSpeed;
            }
        }
    }

    public void Jump()
    {
        if (canJump)
        {
            ShowDust();
            float jumpVelocity = 23.5f;
            rb.velocity = Vector2.up * jumpVelocity;
            BarkSound.Play();
            thisAnimator.speed = 0;
            canJump = false;
        }
    }

    private void OnMouseDown()
    {
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "INVI_PLATFORM")
        {
            thisAnimator.speed = previousAnimSpeed;
            canJump = true;
        } else if (collision.gameObject.tag == "LOOT")
        {
            Destroy(collision.gameObject);
        }
    }

    private void ShowDust()
    {
        dust.Play();
    }
}
