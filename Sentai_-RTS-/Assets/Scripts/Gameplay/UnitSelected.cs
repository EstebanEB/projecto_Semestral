using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelected : MonoBehaviour
{
    [SerializeField]
    protected Material defaulMaterial, selectedMaterial;

    private MeshRenderer theRend;

    public bool isSelected = false;

    GameObject theCamera;

    void Start()
    {
        theRend = GetComponent<MeshRenderer>();

        theCamera = GameObject.Find("Main Camera");
        theCamera.GetComponent<SelectionSystem>().unitsToSelect.Add(this.gameObject);
    }

    public void UpdateStatus()
    {
        if (!isSelected)
        {
            theRend.material = defaulMaterial;
        }
        else
        {
            theRend.material = selectedMaterial;
        }
    }
}
