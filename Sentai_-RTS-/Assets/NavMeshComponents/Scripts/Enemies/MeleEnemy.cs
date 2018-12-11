using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemy : BaseEnemy {

    bool Detection;
    public float enemyRadarSize = 5;

	protected override void Start ()
    {
		
	}
	
	
	void Update ()
    {
        selector();
	}

    public void selector()
    {
        if (Detection == false)
        {
            walk();
        }
        else
        {
           follow();
        }
    }

    public void follow()
    {



    }


   
}
