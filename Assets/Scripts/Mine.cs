using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : GridUpdateTool
{
    
	void Start ()
    {
        StartCoroutine(Down());
	}
	
	void Update ()
    {
		
	}

    IEnumerator Down()
    {
        for (int y = 0; y < 14; y++)
        {
            Grid2D.RowDownAll(y + 1);
        }
        yield return new WaitForSeconds(5f);
    }

    public override bool isValidPosition()
    {
        Vector2 v = Grid2D.round(transform.position);
        if (!Grid2D.isInsideGrid(v))
            return false;
        if (Grid2D.grid[(int)v.x, (int)v.y] != null &&
            Grid2D.grid[(int)v.x, (int)v.y] != transform)
            return false;
        return true;
    }

    public override void GridUpdate()
    {
        for (int y = 0; y < Grid2D.height; ++y)
            for (int x = 0; x < Grid2D.width; ++x)
                if (Grid2D.grid[x, y] != null)
                    if (Grid2D.grid[x, y] == transform)
                        Grid2D.grid[x, y] = null;

        Vector2 v = Grid2D.round(transform.position);
        Grid2D.grid[(int)v.x, (int)v.y] = transform;
    }
}
