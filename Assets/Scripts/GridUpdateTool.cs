using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUpdateTool : MonoBehaviour
{
    public virtual bool isValidPosition()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Grid2D.round(child.position);
            if (!Grid2D.isInsideGrid(v))
                return false;
            if (Grid2D.grid[(int)v.x, (int)v.y] != null &&
                Grid2D.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }

    public virtual void GridUpdate()
    {
        for (int y = 0; y < Grid2D.height; ++y)
            for (int x = 0; x < Grid2D.width; ++x)
                if (Grid2D.grid[x, y] != null)
                    if (Grid2D.grid[x, y].parent == transform)
                        Grid2D.grid[x, y] = null;
        foreach (Transform child in transform)
        {
            Vector2 v = Grid2D.round(child.position);
            Grid2D.grid[(int)v.x, (int)v.y] = child;
        }
    }
}