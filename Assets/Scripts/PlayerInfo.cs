using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static bool isDead = false;
    [SerializeField] Animator anim;
    [SerializeField] GameOver go;

    public static int lives = 3;

    private void Start()
    {
        go = FindObjectOfType<GameOver>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Mine>()) isDead = true;
        if (collision.GetComponent<Asteroids>()) isDead = true;
        if (collision.GetComponent<Bullet>()) isDead = true;
        if (collision.GetComponent<BossBullet>()) isDead = true;
    }

    private void Update()
    {
        if (lives <= 0)
        {
            GetComponent<PlayerController>().enabled = false;
            gameObject.transform.GetChild(0).GetComponent<FirePoint>().enabled = false;
            go.Defeat();
            //gameObject.SetActive(false);
        }

        if(isDead && lives >= 1)
        {
            lives--;
            anim.SetBool("IsDead", isDead);
            Debug.Log(lives);
            isDead = false;
            if(Loader.level1 && lives > 0) go.ResetLevel1();
        }
        else if(isDead == false) anim.SetBool("IsDead", isDead);
    }
}
