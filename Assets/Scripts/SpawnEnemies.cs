using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : GridUpdateTool
{
    public GameObject mines;
    public int[] value = new int[9];
    bool isFree;
    bool isGettingDown = false;
    int randomPos;
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
	}

    IEnumerator SpawnNewRow()
    {
        randonMines = Random.Range(3, 8);
        for (int x = 0; x < randonMines; x++)
        {
            GameObject go = Instantiate(mines) as GameObject;
            Vector2 position = new Vector2(value[x], 15);
            //ObjectPool.Instance.SpawnMine(position, value, x, 15);
            go.transform.position = position;
            Grid2D.grid[value[x], 15] = go.transform;
        }
        yield return new WaitForSeconds(5);
        isGettingDown = true;
        Down();
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

    void Down()
    {
        for (int y = 0; y < 16; y++)
        {
            if (isGettingDown)
            {
                Grid2D.RowDownAll(y + 1);
                y--;
                isGettingDown = false;
            }
        }
    }
}
