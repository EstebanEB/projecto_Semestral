using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSelection : MonoBehaviour
{

    [SerializeField]
    private RectTransform boxSeleccion;

    Vector3 mouseinitialPosition;
    Vector3 mouseFinalPosition;

    Camera thisCamera;

    void Start()
    {
        boxSeleccion.gameObject.SetActive(false);
        thisCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit rayhit;
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayhit, Mathf.Infinity))
            {
                mouseinitialPosition = rayhit.point;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            boxSeleccion.gameObject.SetActive(false);
        }

        if (Input.GetMouseButton(0))
        {
            if (!boxSeleccion.gameObject.activeInHierarchy)
            {
                boxSeleccion.gameObject.SetActive(true);
            }

            mouseFinalPosition = Input.mousePosition;

            Vector3 boxStart = thisCamera.WorldToScreenPoint(mouseinitialPosition);
            boxStart.z = 0;

            Vector3 center = (boxStart + mouseFinalPosition) / 2;

            boxSeleccion.position = center;
            float axisX = Mathf.Abs(boxStart.x - mouseFinalPosition.x);
            float axisY = Mathf.Abs(boxStart.y - mouseFinalPosition.y);

            boxSeleccion.sizeDelta = new Vector2(axisX, axisY);
        }
    }
}

