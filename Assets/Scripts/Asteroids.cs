﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public int speed;
    int randomSprite;

    void Start()
    {
        randomSprite = Random.Range(0, 4);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Spaceship_art/Asteroids/asteroid_" + randomSprite.ToString());
    }

    void Update()
    {
        transform.position += transform.TransformDirection(0, -speed * Time.deltaTime, 0);
        if (Score.score >= 300 && Score.score < 500) speed = 15;
        if (Score.score >= 500 && Score.score < 700) speed = 20;
        if (Score.score >= 700) speed = 25;
        //if(transform.position < ) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>()) 
        {
            Debug.Log("muere");
            GameManager.Instance.GameState = States.GameOver;
        }

        if (collision.CompareTag("Boundary"))
        {
            Score.isDetroying = true;
            Destroy(gameObject);
        }
    }
}
