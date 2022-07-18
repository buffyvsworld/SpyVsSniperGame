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
    private SpriteRenderer sr;
    private Vector2 moveVelocity;

    private Random rnd = new Random();

    private void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      sr = GetComponent<SpriteRenderer>();

      StartCoroutine(MoveCoroutine());
    }

    private void Update()
    {
      if(!isBotStopped)
      {
        StartMove();
      }
    }

    private IEnumerator MoveCoroutine()
    {
      while (true)
      {
        yield return new WaitForSeconds(timeBtwBotMove);
        RandomizeMoveDirection();

        int checkAction = Random.Range(0, 2);

        if(checkAction == 0)
        {
          isBotStopped = true;
        }
        else if (checkAction == 1)
        {
          isBotStopped = false;
        }
      }

    }

    private void StartMove()
    {
      moveVelocity = moveDirection.normalized * speed;

      if(moveDirection.x < 0)
      {
        sr.flipX = true;
      }
      else if (moveDirection.x > 0)
      {
        sr.flipX = false;
      }

      rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }

    private void RandomizeMoveDirection()
    {
      moveDirection = new Vector2(Random.Range(-1,2), Random.Range(-1,2));
    }

}
