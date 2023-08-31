using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public float Speed = 3.0f;
    private Rigidbody2D ThisRigidBody;
    private Vector2 ScreenBounds;
    private float PrevAddSpeed;
    void Start()
    {
        PrevAddSpeed = GlobalVariableScript.AdditionalSpeed;
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

        //Speed = PrevSpeed + GlobalVariableScript.AdditionalSpeed;
        if (transform.position.x > ScreenBounds.x * 1.5)
        {
            Destroy(this.gameObject);
        }
    }
}
