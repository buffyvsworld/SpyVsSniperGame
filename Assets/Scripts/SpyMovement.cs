using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 moveVelocity;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      MovementLogic();
    }

    private void MovementLogic()
    {
      Vector2 moveInput = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
      moveVelocity = moveInput.normalized * speed;

      if(Input.GetAxis("Horizontal") < 0)
      {
        sr.flipX = true;
      }
      else if (Input.GetAxis("Horizontal") > 0)
      {
        sr.flipX = false;
      }

      rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }
}
