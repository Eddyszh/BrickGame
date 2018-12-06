using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    [SerializeField] GameOver go;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>())
        {
            PlayerInfo.isDead = true;
            Destroy(collision.gameObject);
        }
        if (collision.GetComponent<Mine>())
        {
            PlayerInfo.isDead = true;
            Destroy(collision.gameObject);
        }
        if (collision.GetComponent<Asteroids>())
        {
            Score.AddScore(10);
            Destroy(collision.gameObject);
        }
        if (collision.GetComponent<BossBullet>()) Destroy(collision.gameObject);
    }
}
