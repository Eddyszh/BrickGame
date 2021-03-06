﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : GridUpdateTool
{
    public int speed;
    public static Animator anim;

    void Update ()
    {
        if (Loader.level1)
        {
            transform.position += transform.TransformDirection(new Vector3(0, 1, 0));
            if (isValidPosition()) GridUpdate();
            else
            {
                transform.position += new Vector3(0, -1, 0);
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/spaceship_art/Blue/space_bomb_blue");
                GetComponent<Animator>().enabled = true;
                GetComponent<Collider2D>().enabled = true;
                Grid2D.DeleteRow();
                enabled = false;
            }
        }

        if (Loader.level3)
        {
            GetComponent<Collider2D>().enabled = true;
            transform.position += transform.TransformDirection(new Vector3(0, 1, 0));
        }
	}

    public override bool isValidPosition()
    {
        Vector2 v = Grid2D.round(transform.position);
        if (!Grid2D.isInsideGrid(v))
            return false;
        if (Grid2D.grid[(int)v.x, (int)v.y] != null &&
            Grid2D.grid[(int)v.x, (int)v.y] != transform)
            return false;
        return true;
    }

    public override void GridUpdate()
    {
        for (int y = 0; y < Grid2D.height; ++y)
            for (int x = 0; x < Grid2D.width; ++x)
                if (Grid2D.grid[x, y] != null)
                    if (Grid2D.grid[x, y] == transform)
                        Grid2D.grid[x, y] = null;

        Vector2 v = Grid2D.round(transform.position);
        Grid2D.grid[(int)v.x, (int)v.y] = transform;
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            //GameManager.Instance.GameState = States.GameOver;
            Debug.Log("Morí");
        }
    }*/
}
