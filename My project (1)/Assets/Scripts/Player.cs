using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float jumpForce;


    private Rigidbody2D rigidbody;
    private Transform playerTransform;


    private bool canJump = true;
    private int doubleJump = 0;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
    }


    void Update()
    {
        print(doubleJump);
        float movex = Input.GetAxis("Horizontal") * velocity * Time.deltaTime;
        playerTransform.Translate(new Vector3(movex, 0));

        if (Input.GetButtonDown("Jump") && canJump)
        {
            doubleJump++;
            rigidbody.AddForce(Vector2.up * jumpForce);
            if (doubleJump >= 2)
            {
                canJump = false;
            }


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        doubleJump = 0;
        canJump = true;

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }

    }
}
