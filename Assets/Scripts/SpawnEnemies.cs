using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : GridUpdateTool
{
    public GameObject mines;
    int[] value = new int[10];
    bool isFree;
    int index;
    int pos;

	void Start ()
    {
        StartCoroutine(SpawnNewRow());
	}
	
	void Update ()
    {
		
	}

    IEnumerator SpawnNewRow()
    {
        yield return new WaitForSeconds(5);
        int randonMines = Random.Range(3, 8);
        for (int x = 0; x < randonMines; x++)
        {
            GameObject go = Instantiate(mines) as GameObject;
            Vector2 position = new Vector2(RandomPos(randonMines), 15);
            go.transform.position = position;
            Grid2D.grid[RandomPos(randonMines), 15] = go.transform;
        }
    }

    int RandomPos(int randomMines)
    {
        do
        {
            isFree = true;
            index = 0;
            int randomPos = Random.Range(0, 10);
            for (int i = 0; i < randomMines; i++)
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
                pos = value[index];
                index++;
            }
            return pos;
        } while (index < randomMines);
    }
}
