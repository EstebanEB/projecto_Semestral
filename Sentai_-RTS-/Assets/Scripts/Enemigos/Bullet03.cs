using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet03 : MonoBehaviour {

    public int damageBullet = 20;

    public float speed=20f;
    public GameObject Target;
    Rigidbody rb;


    //public int random =Random.Range(-10,10);

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        Target = GameObject.FindGameObjectWithTag("Units");

       // rb.AddForce(new Vector3((Target.transform.position.x - random), (Target.transform.position.y - random), (Target.transform.position.z - random)) * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Units")
        {
            /*collision.gameObject.GetComponent<IDamage>().UpdateHealth(damageBullet);*/
            gameObject.SetActive(false);
        }
    }
}
