using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootScript : MonoBehaviour
{
    public float Speed = 1.8f;
    private Rigidbody2D ThisRigidBody;
    private Vector2 ScreenBounds;
    public AudioSource GrabSound;
    private float PrevAddSpeed;

    void Start()
    {
        PrevAddSpeed = GlobalVariableScript.AdditionalSpeed;
        if (GlobalVariableScript.SelectedCharacter == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load("apple_resize", typeof(Sprite)) as Sprite;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load("money", typeof(Sprite)) as Sprite;
        }

        ThisRigidBody = this.GetComponent<Rigidbody2D>();
        ThisRigidBody.velocity = new Vector2(Speed + PrevAddSpeed, 0);
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {

        if (PrevAddSpeed != GlobalVariableScript.AdditionalSpeed)
        {
            PrevAddSpeed = GlobalVariableScript.AdditionalSpeed;
            ThisRigidBody.velocity = new Vector2(Speed + PrevAddSpeed, 0);
        }

        if (transform.position.x > ScreenBounds.x * 1.5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BIDA")
        {
            this.gameObject.transform.position = new Vector2(-10, 6); //move the object outside the screen
            GrabSound.Play();
            GlobalVariableScript.GameScore += 5;

            switch(GlobalVariableScript.GameScore)
            {
                case 50:
                case 100:
                case 200:
                case 400:
                case 600:
                case 900:
                case 1000:
                case 4000:
                case 9000:
                    GlobalVariableScript.AdditionalSpeed += 0.50f;
                    GlobalVariableScript.GlobMultiplier += 1f;
                    break;
            }

            while (!GrabSound.isPlaying)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        BidaScript bs = GameObject.Find("bida").GetComponent<BidaScript>();
        bs.Jump();
    }
}
