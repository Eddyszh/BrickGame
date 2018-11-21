using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    int randomDirection;
    public int speed;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Move());
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {		
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, 1f, 8f), 13, 0);
	}

    IEnumerator Move()
    {
        randomDirection = Random.Range(0, 2);
        if (randomDirection == 0) transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        if (randomDirection == 1) transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        yield return new WaitForSeconds(2);
    }
}
