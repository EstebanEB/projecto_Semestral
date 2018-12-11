using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitRecolector : BaseUnit
{
    [SerializeField]
    protected float CapMaxMaterial = 10;
    [SerializeField]
    protected float CapActMaterial = 0;
    [SerializeField]
    protected string MaterialAsigned;
     
    public bool Recolection = false;
    public bool TransportingOrder = false;

    public Vector3 MineralPosition;
    public Vector3 GasPosition;
    public Vector3 DropSite;

    public GameObject Mineral;
    public GameObject Gas;
    public GameObject ComandCenter;
    public GameObject RecolectioCar;

    public GameObject ui;
    public Text Recursos;

    public float TimeToCollect = 3f;
    float collecting = 0;

	void Start ()
    {
        collecting = TimeToCollect;
	}
	
	void Update ()
    {
        Mover();
        recoleccion();
        if (Input.GetKeyDown(KeyCode.T))
        {
            EjecuteOrder();
        }

        if (Selected.isSelected == true)
        {
            //Recursos.text += " " + MaterialAsigned + ": " + CapActMaterial;
            ui.SetActive(true);
        }
        else
        {
            ui.SetActive(false);
        }
	}

    public void EjecuteOrder()
    {
        Recolection = false;
        CapActMaterial = 0;
        TransportingOrder = true;
        Unidad.SetDestination(RecolectioCar.transform.position);
    }

    public void recoleccion()
    {
        if (Input.GetMouseButtonDown(1) && Selected.isSelected == true) //para saber cuando el jugador da click
        {
            Ray ray = Gamecamera.ScreenPointToRay(Input.mousePosition); //crea un rayo sobre la posicion del mouse del mapa
            RaycastHit hitRecolector;

            if (Physics.Raycast(ray, out hitRecolector))  //sirve para conocer si el rayo coliciono con algun objeto
            {
                if (hitRecolector.collider.tag == "Mineral" || hitRecolector.collider.tag == "Gas" && Selected.isSelected == true)
                {
                    MaterialAsigned = hitRecolector.collider.tag;
                    Debug.Log("Deberia Recolectar");
                    MineralPosition = hitRecolector.point;
                    DropSite = ComandCenter.transform.position;
                    Unidad.SetDestination(hitRecolector.point);
                    Recolection = true;
                    OrdenRecoleccion();
                }
            }
        }
        ////////////////////////////////////////// Esta seccion dice que si la unidad recolecotra es seleccionada y se da click izq dobre el carro el recolector cambiara su lugar de drop//////////////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.A) && Selected.isSelected == true && Recolection == true) 
        {
            changeDropSite();
        }
    }

    public void changeDropSite()
    {
        DropSite = RecolectioCar.transform.position;
    }

    void OrdenRecoleccion()
    {
        if (CapActMaterial == 0 && MaterialAsigned == "Mineral")
        {
            Unidad.SetDestination(Mineral.transform.position);
            Debug.Log("Recolectando");
        }
        if (CapActMaterial == 0 && MaterialAsigned == "Gas")
        {
            Unidad.SetDestination(Gas.transform.position);
            Debug.Log("Recolectando");
        }
    }
    private void OnTriggerStay(Collider obj)
    {
        if (obj.CompareTag("Mineral") && Recolection == true)
        {
            collecting -= Time.deltaTime;
        }
        if (obj.CompareTag("Gas") && Recolection == true)
        {
            collecting -= Time.deltaTime;
        }
        if (collecting <= 0)
        {
            CapActMaterial = CapMaxMaterial;
            OrdenRecoleccion();
            Unidad.SetDestination(DropSite);
        }
    }

    private void OnTriggerEnter(Collider obj2)
    {
        if (obj2.CompareTag("Comand") && Recolection == true  && MaterialAsigned == "Mineral")
        {
            collecting = TimeToCollect;
            CapActMaterial = 0;
            Unidad.SetDestination(Mineral.transform.position);
        }
        if (obj2.CompareTag("Comand") && Recolection == true && MaterialAsigned == "Gas")
        {
            collecting = TimeToCollect;
            CapActMaterial = 0;
            Unidad.SetDestination(Gas.transform.position);
        }



        if (obj2.CompareTag("RCar") && Recolection == true && MaterialAsigned == "Mineral")
        {
            collecting = TimeToCollect;
            CapActMaterial = 0;
            Unidad.SetDestination(Mineral.transform.position);
        }
        if (obj2.CompareTag("RCar") && Recolection == true  && MaterialAsigned == "Gas")
        {
            collecting = TimeToCollect;
            CapActMaterial = 0;
            Unidad.SetDestination(Gas.transform.position);
        }

        if (obj2.CompareTag("RCar") && TransportingOrder == true)
        {
            gameObject.SetActive(false);
        }
    }

}
