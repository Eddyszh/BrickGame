using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    float randomDirection;
    public int speed;

    public Vector2 movement;
    public Vector2 movementWait;
    public Vector2 wait;

    Rigidbody2D rb;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Move());
	}
	
	// Update is called once per frame

    IEnumerator Move()
    {
        /*yield return new WaitForSeconds(Random.Range(wait.x, wait.y));
        while (true)
        {
            randomDirection = Random.Range(1, 8) * Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(movementTime.x, movementTime.y));
            randomDirection = 0;
            yield return new WaitForSeconds(Random.Range(movementWait.x, movementWait.y));
        }*/
        yield return new WaitForSeconds(3);
        if (movement == Vector2.right) movement = Vector2.left;
        else movement = Vector2.right;
    }

	void FixedUpdate ()
    {
        float amountToMove = speed * Time.fixedDeltaTime;
        transform.Translate(movement * amountToMove);
        //float movementt = Mathf.MoveTowards(rb.velocity.x, randomDirection, speed * Time.deltaTime);
        //rb.velocity = new Vector2(movementt, 0);
        //rb.position = new Vector2(Mathf.Clamp(rb.position.x, 1f, 8f), 13);
	}
}
