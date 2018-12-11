using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectionCar : BaseUnit
{
    public GameObject ComandCenter;
    public GameObject Recoletor;

    public float CapMaxMineral = 40;
    public float ActualMineral = 0;
    public string MaterialAsigned;

    public Vector3 Position;
    public Vector3 ActualPosition;

    [SerializeField]
    public List<GameObject> UnitsTransporting;

    public string UnitType = "";

    void Start ()
    {
        UnitsTransporting = new List<GameObject>();
    }
	
	void Update ()
    {
        Mover();
        ActualPosition = transform.position;
        if (ActualMineral == CapMaxMineral)
        {
            IsFull();
        }     
	}

    void IsFull()
    {
        Unidad.SetDestination(ComandCenter.transform.position);
    }

    private void OnTriggerEnter(Collider obj)
    {

///////////////////////////////////////////////////Cuando el carro lleva los minerales a la base///////////////////////////////////////////////////////
        if (obj.CompareTag("Comand") && ActualMineral == CapMaxMineral && MaterialAsigned == "Mineral")
        {
            ActualMineral = 0;
            Unidad.SetDestination(Position);
        }
        if (obj.CompareTag("Comand") && ActualMineral == CapMaxMineral && MaterialAsigned == "Gas")
        {
            ActualMineral = 0;
            Unidad.SetDestination(Position);
        }


////////////////////////////////////////////////////Cuando una unidad recolectora coliciona con el////////////////////////////////////////////////////
        if (obj.CompareTag("UnidadRec"))
        {
            ActualMineral += 10;
            MaterialAsigned = "Mineral";
            Position = transform.position;
        }
    }
}
