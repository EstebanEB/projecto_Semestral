using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAlt : movBase {


    public float visionRadio;

    bool Detection = false;
    float time;

    public GameObject enemie; //enemigo a espawneear


    Vector3 initialPosition;


    protected override void Start()
    {
        target = GameObject.FindGameObjectWithTag("UnidadRec");
        initialPosition = transform.position;
    }


    void Update()
    {

    }

    void chasePlayer()
    {
        Vector3 playerPos = initialPosition;

        float distancia = Vector3.Distance(target.transform.position, transform.position);
        if (distancia < visionRadio)
        {
            playerPos = target.transform.position;
            Detection = true;
        }

        float fixSpeed = speedMovement * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerPos, fixSpeed);


    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadio);
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(time);

        Instantiate(enemie);

    }
}
