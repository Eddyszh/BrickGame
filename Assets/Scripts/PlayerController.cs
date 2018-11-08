using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GridUpdateTool
{		
	void Update ()
    {
        Move();
	}

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (isValidPosition()) GridUpdate();
            else transform.position += new Vector3(1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);
            if (isValidPosition()) GridUpdate();
            else transform.position += new Vector3(-1, 0, 0);
        }
    }    
}
