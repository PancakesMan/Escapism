using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSelector : MonoBehaviour {

    public Material[] Materials;

    public void Start()
    {
        SetMaterialRandomly();
    }

    public void SetMaterial(int index)
    {
        if (index > Materials.Length) index = 0;

        gameObject.GetComponent<MeshRenderer>().material = Materials[index];
        gameObject.name = Materials[index].name;
    }

    public void SetMaterialRandomly()
    {
        int index = Random.Range(0, Materials.Length);

        gameObject.GetComponent<MeshRenderer>().material = Materials[index];
        gameObject.name = Materials[index].name;
    }
}
