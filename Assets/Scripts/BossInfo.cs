using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInfo : MonoBehaviour
{
    int damage;

    public static bool isBossDead = false;

	void Start ()
    {
		
	}
	

	void Update ()
    {
        if (damage == 25)
        {
            isBossDead = true;
            gameObject.SetActive(false);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>())
        {
            Score.AddScore(10);
            damage++;
            Destroy(collision.gameObject);
            Debug.Log(damage);
        }
    }
}
