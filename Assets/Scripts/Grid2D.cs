using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid2D : MonoBehaviour
{
    public static int width = 10;
    public static int height = 16;
    public static Transform[,] grid = new Transform[width, height];

    public static Vector2 round(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    public static bool isInsideGrid(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < width && (int)pos.y >= 0 && (int)pos.y < height);
    }

    public static void Delete(int y)
    {
        for (int x = 0; x < width; ++x)
        {
            Destroy(grid[x, y].gameObject);
            //ObjectPool.Instance.List.Push(grid[x, y].gameObject);
            //grid[x, y].gameObject.SetActive(false);
            grid[x, y] = null;
        }
    }

    public static bool isFull(int y)
    {
        for (int x = 0; x < width; ++x)
			if (grid[x, y] == null)
                return false;
        return true;
    }

    public static void DeleteRow()
    {
        for (int y = 15; y > 0; y--)
        {
            if (isFull(y))
            {
                Delete(y);
                RowUpAll(y - 1);
                ++y;
                Score.isDetroying = true;
                AnimationController.isFull = true;
            }
        }
    }

    public static void RowUp(int y)
    {
        for (int x = 0; x < width; ++x)
        {
            if (grid[x, y] != null)
            {
                grid[x, y + 1] = grid[x, y];
                grid[x, y] = null;
                grid[x, y + 1].position += new Vector3(0, 1, 0);
            }
        }
    }

    public static void RowUpAll(int y)
    {
        for (int i = y; i > 0; i--)
			RowUp(i);
    }

    public static void RowDown(int y)
    {
        for (int x = 0; x < width; ++x)
        {
            if (grid[x, y] != null)
            {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public static void RowDownAll(int y)
    {
        for (int i = y; i < height; ++i)
			RowDown(i);
    }
}