using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : GridUpdateTool
{
    public GameObject mines;
    public int[] value = new int[9];
    int randomPos;
    bool isFree;
    int index = 0;
    int pos;
    int randonMines;


    void Start ()
    {
        for (int i = 0; i < value.Length; i++)
        {
            value[i] = 11;
        }
        RandomValue();
        //StartCoroutine(SpawnNewRow());
	}
	
	void Update ()
    {
		
	}

    IEnumerator SpawnNewRow()
    {
        randonMines = Random.Range(3, 8);
        for (int x = 0; x < randonMines; x++)
        {
            GameObject go = Instantiate(mines) as GameObject;
            Vector2 position = new Vector2(value[x], 15);
            go.transform.position = position;
            Grid2D.grid[value[x], 15] = go.transform;
        }
        yield return new WaitForSeconds(5);
        Grid2D.Down();
        RandomValue();
    }

    void RandomValue()
    {
        do
        {
            isFree = true;
            randomPos = Random.Range(0, 10);
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
        StartCoroutine(SpawnNewRow());
        index = 0;
    }
}
