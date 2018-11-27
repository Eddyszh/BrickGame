using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    bool isDead = false;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Mine>()) Debug.Log("Moríi"); isDead = true;
        if (collision.GetComponent<Asteroids>()) Debug.Log("Moríx7"); isDead = true;
        if (collision.GetComponent<Bullet>()) Debug.Log("Moríx32"); isDead = true;
    }

    private void Update()
    {
        if(isDead)
            anim.SetBool("IsDead", isDead);
    }
}
