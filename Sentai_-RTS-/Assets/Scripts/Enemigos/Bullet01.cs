using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet01 : MonoBehaviour {

    public int damageBullet = 20;

    public float speed=50f;
    public GameObject Target;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        Target = GameObject.FindGameObjectWithTag("Units");

        rb.AddForce(new Vector3((Target.transform.position.x - transform.position.x), (Target.transform.position.y - transform.position.y), (Target.transform.position.z - transform.position.z)) * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Units")
        {
          /*  collision.gameObject.GetComponent<IDamage>().UpdateHealth(damageBullet);*/
            gameObject.SetActive(false);
        }
    }
}
