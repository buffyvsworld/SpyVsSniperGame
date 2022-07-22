using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botMovementLogic : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private float timeBtwBotMove;
    [SerializeField] private bool isBotStopped;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator animator;
    private bool facingRight = true;
    private Vector3 oldPosition;

    private Random rnd = new Random();


    private void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      animator = GetComponentInChildren<Animator>() as Animator;

      StartCoroutine(MoveCoroutine());
    }

    private void FixedUpdate()
    {
      if(!isBotStopped)
      {
        StartMove();
      }

      if(oldPosition == transform.position)
      {
        animator.SetBool("isWalking", false);
      }

      else if(oldPosition != transform.position)
      {
        animator.SetBool("isWalking", true);
        oldPosition = transform.position;
      }

    }

    private IEnumerator MoveCoroutine()
    {
      while (true)
      {
        yield return new WaitForSeconds(timeBtwBotMove);

        int checkAction = Random.Range(0, 2);

        if(checkAction == 0)
        {
          isBotStopped = true;
          StopMove();
        }
        else if (checkAction == 1)
        {
          RandomizeMoveDirection();
          isBotStopped = false;
        }
      }

    }

    private void StartMove()
    {
      moveVelocity = moveDirection.normalized * speed;

      if(facingRight && moveDirection.x < 0)
      {
        Flip();
      }
      else if (!facingRight && moveDirection.x > 0)
      {
        Flip();
      }

      rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }

    private void StopMove()
    {
      rb.velocity = new Vector2(0f,0f);
    }

    private void RandomizeMoveDirection()
    {
      moveDirection = new Vector2(Random.Range(-1,2), Random.Range(-1,2));
    }

    private void Flip()
   {
       facingRight = !facingRight;
       Vector3 Scaler = transform.localScale;
       Scaler.x *= -1;
       transform.localScale = Scaler;
   }

}
