using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
	void Update ()
    {
        transform.position += transform.TransformDirection(0f, -1f, 0f);
	}
}
