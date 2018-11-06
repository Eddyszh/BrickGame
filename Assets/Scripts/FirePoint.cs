using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject bullet;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Fire();
	}

    void Fire()
    {
        //ObjectPool.Instance.SpawnBullet(transform);
        GameObject go = Instantiate(bullet,transform.position, Quaternion.identity) as GameObject;
    }
}
