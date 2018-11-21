using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject mine;
    [SerializeField] GameObject bullet;
    private static ObjectPool instance;

    public static ObjectPool Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<ObjectPool>();
            return instance;
        }
    }

    Stack<GameObject> list = new Stack<GameObject>();


    Stack<GameObject> mineList = new Stack<GameObject>();

    public Stack<GameObject> MineList
    {
        get
        {
            return mineList;
        }

        set
        {
            mineList = value;
        }
    }

    Stack<GameObject> bulletList = new Stack<GameObject>();

    public Stack<GameObject> BulletList
    {
        get
        {
            return bulletList;
        }

        set
        {
            bulletList = value;
        }
    }

    public Stack<GameObject> List
    {
        get
        {
            return list;
        }

        set
        {
            list = value;
        }
    }


    // Use this for initialization
    void Start ()
    {
        CreateMines(20);
        CreateBullets(20);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateMines(int ammount)
    {
        for (int i = 0; i < ammount; i++)
        {
            list.Push(Instantiate(mine));
            list.Peek().name = "Mine";
            list.Peek().SetActive(false);
        }
    }

    void CreateBullets(int ammount)
    {
        for (int i = 0; i < ammount; i++)
        {
            bulletList.Push(Instantiate(bullet));
            bulletList.Peek().name = "Bullet";
            bulletList.Peek().SetActive(false);
        }
    }

    public void SpawnMine(Vector2 t, int[] value, int x, int y)
    {
        if (list.Count == 0) CreateMines(4);
        GameObject go = mineList.Pop();
        go.SetActive(true);
        go.transform.position = t;
        Grid2D.grid[value[x], y] = go.transform;
        go.GetComponent<Mine>().enabled = true;
        go.GetComponent<Bullet>().enabled = false;
    }
    
    public void SpawnBullet(Transform t)
    {
        if (list.Count == 0) CreateBullets(4);
        GameObject go = bulletList.Pop();
        go.SetActive(true);
        go.transform.position = t.position;
        go.GetComponent<Bullet>().enabled = true;
        go.GetComponent<Mine>().enabled = false;
        //return go;
    }
}
