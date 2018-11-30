using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            PlayerInfo.isDead = true;
            if(collision.gameObject.transform.position.x > 6)
                collision.gameObject.transform.position += new Vector3(-1, 0, 0);
            else if(collision.gameObject.transform.position.x < 3)
                collision.gameObject.transform.position += new Vector3(1, 0, 0);
        }

    }
}
