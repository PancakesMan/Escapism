using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSelector : MonoBehaviour {

    public bool RandomiseOnStart = true;
    public bool RenameObjectToMaterial = false;
    public Material[] Materials;

    public void Start()
    {
        // If the objects material should be random when scene is loaded
        // Set the material of the object to a random one in the list
        if (RandomiseOnStart) SetMaterialRandomly();
    }

    // Set material to a specific material in the material list
    public void SetMaterial(int index)
    {
        // If index would cause an out of bounds exception, set index to 0
        if (index > Materials.Length) index = 0;

        // Set mateerial
        gameObject.GetComponent<MeshRenderer>().material = Materials[index];

        // If object should be renamed to match material, rename it
        if (RenameObjectToMaterial) gameObject.name = Materials[index].name;
    }

    // Set material to a random material in the material lsit
    public void SetMaterialRandomly()
    {
        // Select index randomly
        int index = Random.Range(0, Materials.Length);

        // Set material
        gameObject.GetComponent<MeshRenderer>().material = Materials[index];

        // If object should be renamed to match material, rename it
        if (RenameObjectToMaterial) gameObject.name = Materials[index].name;
    }
}
