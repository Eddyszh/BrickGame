using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public static bool isDead = false;
    [SerializeField] Animator anim;
    [SerializeField] GameOver go;
    [SerializeField] Image[] lifeImages;
    [SerializeField] SfxManager sm;

    public static int lives = 3;

    private void Start()
    {
        go = FindObjectOfType<GameOver>();
        if(lives < 3) lifeImages[2].gameObject.SetActive(false);
        if(lives < 2) lifeImages[1].gameObject.SetActive(false);
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
            sm.PlaySFX(1);
            lifeImages[lives].gameObject.SetActive(false);
            anim.SetBool("IsDead", isDead);
            Debug.Log(lives);
            isDead = false;
            if(Loader.level1 && lives > 0) go.ResetLevel1();
        }
        else if(isDead == false) anim.SetBool("IsDead", isDead);
    }
}
