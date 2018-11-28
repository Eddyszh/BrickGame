using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFirePoint : MonoBehaviour
{
    [SerializeField] GameObject bullet;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Fire());
	}

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            Instantiate(bullet,transform.position, transform.rotation);
            yield return new WaitForSeconds(2.4f);
        }
    }
}
