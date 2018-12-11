using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Controljugador : MonoBehaviour {

    public NavMeshAgent agenteplayer;

    public Camera gameCamera;
	void Start ()
    {
		
	}
	
	
	void Update ()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);  //raycast en la posicion del clik del maus
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))  // se guarda la colision we
            {
                agenteplayer.SetDestination(hit.point);
            }
        }
		
	}
}
