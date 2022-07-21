using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyMovement : MonoBehaviour
{
    [SerializeField] private float speed;


    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private bool facingRight = true;
    private Animator animator;

    private Vector3 oldPosition;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>() as Animator;

        oldPosition = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
      if(oldPosition == transform.position)
      {
        animator.SetBool("isWalking", false);
      }

      else if(oldPosition != transform.position)
      {
        animator.SetBool("isWalking", true);
        oldPosition = transform.position;
      }

      MovementLogic();
    }

    private void MovementLogic()
    {
      Vector2 moveInput = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
      moveVelocity = moveInput.normalized * speed;

      if(facingRight && Input.GetAxis("Horizontal") < 0)
      {
        Flip();
      }
      else if(!facingRight && Input.GetAxis("Horizontal") > 0)
      {
        Flip();
      }

      if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
      {

      }

      rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }

    private void Flip()
   {
       facingRight = !facingRight;
       Vector3 Scaler = transform.localScale;
       Scaler.x *= -1;
       transform.localScale = Scaler;
   }
}
