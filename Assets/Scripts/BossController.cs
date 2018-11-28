using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public int speed;

    int count = 0;

    Vector2 movement;

	void Update ()
    {
        Move();
	}

    void Move()
    {
        if (transform.position.x >= 8f)
        {
            movement = Vector2.left;
            count++;
        }
        if (transform.position.x <= 1f) movement = Vector2.right;

        float amountToMove = speed * Time.deltaTime;
        transform.Translate(movement * amountToMove);

        if (count == 4)
        {
            transform.position += new Vector3(0, -1, 0);
            speed++;
            count = 0;
        }

        if (transform.position.y == 2) transform.position = new Vector3(0, 15, 0);
    }
}
