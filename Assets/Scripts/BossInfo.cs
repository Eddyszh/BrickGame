using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInfo : MonoBehaviour
{
    int damage;

	void Start ()
    {
		
	}
	

	void Update ()
    {
        if (damage == 25)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>())
        {
            damage++;
            Destroy(collision.gameObject);
        }
    }
}
