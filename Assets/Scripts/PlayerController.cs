﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : GridUpdateTool
{		
	void Update ()
    {
        Move();
	}

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.A) && Time.timeScale == 1)
        {
            transform.position += new Vector3(-1, 0, 0);
            if (isValidPosition()) GridUpdate();
            else transform.position += new Vector3(1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D) && Time.timeScale == 1)
        {
            transform.position += new Vector3(1, 0, 0);
            if (isValidPosition()) GridUpdate();
            else transform.position += new Vector3(-1, 0, 0);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            Debug.Log("Morí");
            GameManager.Instance.GameState = States.GameOver;
        }
    }*/
}
