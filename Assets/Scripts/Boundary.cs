using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    [SerializeField] GameOver go;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>()) go.StopGame();
        if (collision.GetComponent<Mine>()) go.StopGame();
        if (collision.GetComponent<Asteroids>())
        {
            Score.isDetroying = true;
            Destroy(collision.gameObject);
        }
        if (collision.GetComponent<BossBullet>()) Destroy(collision.gameObject);
    }
}
