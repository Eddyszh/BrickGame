﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    [SerializeField] GameObject bullet;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1)
            Fire();
	}

    void Fire()
    {
        //ObjectPool.Instance.SpawnBullet(transform);
        Instantiate(bullet,transform.position, Quaternion.identity);
    }
}
