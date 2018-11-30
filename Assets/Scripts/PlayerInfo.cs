using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static bool isDead = false;
    [SerializeField] Animator anim;
    [SerializeField] GameOver go;

    int lifes = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Mine>()) isDead = true;
        if (collision.GetComponent<Asteroids>()) isDead = true;
        if (collision.GetComponent<Bullet>()) isDead = true;
        if (collision.GetComponent<BossBullet>()) isDead = true;
    }

    private void Update()
    {
        if(isDead && lifes > 0)
        {
            if(Loader.level1) go.ResetGame();
            lifes--;
            anim.SetBool("IsDead", isDead);
            Debug.Log(lifes);
            isDead = false;
            anim.SetBool("IsDead", isDead);
        }

        if (lifes == 0)
        {
            GetComponent<PlayerController>().enabled = false;
            gameObject.transform.GetChild(1).GetComponent<FirePoint>().enabled = false;
            go.StopGame();
        }
    }
}
