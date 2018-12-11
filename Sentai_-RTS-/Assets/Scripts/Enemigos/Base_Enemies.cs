using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public abstract class Base_Enemies : MonoBehaviour {

    public enum EstadoAgent { Formacion, MovimientoEnem, Estatico, Ataque1, Ataque2, Recoleccion };
    public EstadoAgent estadoActual;

    //FLOATS.
    public float distanciaTarget;//Distancia en la que se puede detectar a un target.
    public float distanciaPS;//Distancia en la que se puede detectar el jugador.
    
    public float FormationPosition = 0.0f;//Variable que indica la proximidad del target de "posicionInicial".
    public float NpcSpeed = 10f; //Variable en indica la velocidad en la que el NPC se translada.
    public float timeActions = 3f; //Variable de tiempo que puede usarse para la realización de una acción.
    public float TiempoDisparo = 2f;//Variable de tiempo que puede usarse para el disparo.
    public float currentTime; //Variable que almacena la transformación del tiempo hasta el limite desigando en "timeActions".

    //BOOLEANS.
    public bool InPosition = false; //Variable booleana que indica si el NPC está en cierta zona (collider).

    //INTS.
    public int maxVida = 100;
    public int vida;


    //GAMEOBJECTS.
    public GameObject NPCPosition;
    public GameObject posicionInicial;
    public GameObject TargetPosition;


    public GameObject bulletPref1;
    public GameObject bulletPref2;

    //OTRAS COSITAS.
    public Camera gameCamera;
    public NavMeshAgent agentNPC;
    public LayerMask layer;
    public RaycastHit ray;
    public Vector3 target;


    //SCRIPTS.
    /*public SystemSelection sSelection;
    public UnitSelect uSelection;
    public Selection SeleccionU;

    public MineralProperties mp;
    public GasProperties gp;
    public AlmacenProperties ap;*/


    protected virtual void Start()
    {


        vida = maxVida;
        agentNPC = GetComponent<NavMeshAgent>();
        /*sSelection = GetComponent<SystemSelection>();
        uSelection = GetComponent<UnitSelect>();
        SeleccionU = GetComponent<Selection>();

        mp = GetComponent<MineralProperties>();
        gp = GetComponent<GasProperties>();
        ap = GetComponent<AlmacenProperties>();*/

        // gameCamera = GetComponent<Camera>();

    }

    protected abstract void FormacionEnemiga();

    protected abstract void MovimientoEnemigo();

    protected abstract void EnemigoEstatico();

    protected abstract void AtaqueEnemigo();

    protected abstract void AtaqueEspecialEnemigo();

    protected abstract void DeteccionAmbiente();

}
