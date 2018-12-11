using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSystem : MonoBehaviour
{

    [SerializeField]
    private LayerMask unit;

    Camera thisCamera;

    public List<GameObject> currentSelected;

    [SerializeField]
    public List<GameObject> unitsToSelect;

    Vector3 mouseInicialPosition;
    Vector3 mouseFinalPosition;

    void Awake()
    {
        thisCamera = GetComponent<Camera>();
        currentSelected = new List<GameObject>();
        unitsToSelect = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseInicialPosition = thisCamera.ScreenToViewportPoint(Input.mousePosition);

            RaycastHit rayHit;
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, unit))
            {
                UnitSelected unitSelected = rayHit.collider.GetComponent<UnitSelected>();

                if (Input.GetKey("left ctrl"))
                {
                    if (!unitSelected.isSelected)
                    {
                        currentSelected.Add(rayHit.collider.gameObject);
                        unitSelected.isSelected = true;
                        unitSelected.UpdateStatus();
                    }
                    else
                    {
                        currentSelected.Remove(rayHit.collider.gameObject);
                        unitSelected.isSelected = false;
                        unitSelected.UpdateStatus();
                    }
                }
                else
                {
                    ClearListSelection();
                    currentSelected.Add(rayHit.collider.gameObject);
                    unitSelected.isSelected = true;
                    unitSelected.UpdateStatus();
                }
            }
            else
            {
                ClearListSelection();
            }
        }

        if (Input.GetMouseButton(0))
        {
            mouseFinalPosition = thisCamera.ScreenToViewportPoint(Input.mousePosition);

            if (mouseInicialPosition != mouseFinalPosition)
            {
                Selector5Mil();
            }
        }
    }

    void Selector5Mil()
    {
        if (Input.GetKey("left ctrl") == false)
        {
            ClearListSelection();
        }

        Rect boxSelect = new Rect(mouseInicialPosition.x, mouseInicialPosition.y, mouseFinalPosition.x - mouseInicialPosition.x, mouseFinalPosition.y - mouseInicialPosition.y);

        foreach (GameObject currentUnit in unitsToSelect)
        {
            if (boxSelect.Contains(thisCamera.WorldToViewportPoint(currentUnit.transform.position), true))
            {
                currentSelected.Add(currentUnit);
                currentUnit.GetComponent<UnitSelected>().isSelected = true;
                currentUnit.GetComponent<UnitSelected>().UpdateStatus();
            }
        }
    }

    void ClearListSelection()
    {
        //UnitSelected unnidadSeleccionada = GetComponent<UnitSelected>();
        foreach (GameObject unidad in currentSelected)
        {
            unidad.GetComponent<UnitSelected>().isSelected = false;
            unidad.GetComponent<UnitSelected>().UpdateStatus();
        }
        currentSelected.Clear();
    }
}

