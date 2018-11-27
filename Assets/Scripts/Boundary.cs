using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>()) Debug.Log("Morí");
        if (collision.GetComponent<Mine>()) Debug.Log("Moríx2");
        if (collision.GetComponent<Asteroids>()) Debug.Log("Destruido");

    }
}
