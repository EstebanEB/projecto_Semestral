using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comandCenter : MonoBehaviour {

    public Camera gameCamera;
    public GameObject HUD;
    public GameObject SelectionRay;


	void Start ()
    {
        gameCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
	

	void Update ()
    {
        showInterface();

    }

    public void showInterface()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);  //raycast en la posicion del clik 
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))  // se guarda la colision
            {
                if (SelectionRay = GameObject.FindGameObjectWithTag("Comand"))
                     HUD.SetActive(true);
                
            }

        }
        if (Input.GetMouseButtonDown(1))
        {
            HUD.SetActive(false);
        }

    }


    public void ShowBtns()
    { }


}

