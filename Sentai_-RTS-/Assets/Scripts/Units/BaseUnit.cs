using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseUnit : MonoBehaviour {

    public NavMeshAgent Unidad;

    public Camera Gamecamera;

    public UnitSelected Selected;


    void Start()
    {

    }

    public void Mover()
    {
        if (Input.GetMouseButtonDown(1)) //para saber cuando el jugador da click
        {
            Ray ray = Gamecamera.ScreenPointToRay(Input.mousePosition); //crea un rayo sobre la posicion del mouse del mapa
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))  //sirve para conocer si el rayo coliciono con algun objeto
            {
                if (hit.collider.tag == "Ground" && Selected.isSelected == true)
                {
                    Debug.Log("Deberia moverse");
                    Unidad.SetDestination(hit.point);
                }
            }
        }
    }
}
