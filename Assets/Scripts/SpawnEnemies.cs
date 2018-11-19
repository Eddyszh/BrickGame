using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : GridUpdateTool
{
    public GameObject enemy;
    public int[] value = new int[3];
    bool isFree;
    int randomPos;
    int randomEnemies;
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
        randomEnemies = Random.Range(1, 4);
        for (int x = 0; x < randomEnemies; x++)
        {
            GameObject go = Instantiate(enemy) as GameObject;
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
