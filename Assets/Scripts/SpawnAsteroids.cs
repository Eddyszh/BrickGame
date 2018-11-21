using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : GridUpdateTool
{
    public GameObject asteroid;
    public int[] value = new int[3];
    bool isFree;
    int randomPos;
    int randomAsteroids;
    int index;
	// Use this for initialization
	void Start ()
    {
        RandomValue();
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    IEnumerator Spawn()
    {
        randomAsteroids = Random.Range(1, 4);
        for (int x = 0; x < randomAsteroids; x++)
        {
            GameObject go = Instantiate(asteroid) as GameObject;
            Vector2 position = new Vector2(value[x], 15);
            go.transform.position = position;
            Grid2D.grid[value[x], 15] = go.transform;
        }
        yield return new WaitForSeconds(1);
        RandomValue();
    }

    void RandomValue()
    {
        do
        {
            isFree = true;
            randomPos = Random.Range(3, 7);
            for (int i = 0; i < value.Length; i++)
            {
                if (randomPos == value[i])
                {
                    isFree = false;
                    break;
                }
            }

            if (isFree)
            {
                value[index] = randomPos;
                index++;
            }
        } while (index < value.Length);
        StartCoroutine(Spawn());
        index = 0;
    }
}
