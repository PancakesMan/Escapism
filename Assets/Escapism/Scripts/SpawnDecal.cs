using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnDecal : MonoBehaviour {

    public Canvas worldspaceCanvas;
    public Image decal;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            Image newDecal = Instantiate(decal);
            newDecal.transform.position = collision.contacts[0].point;
            newDecal.transform.rotation = Quaternion.Euler(collision.contacts[0].normal);
            newDecal.transform.SetParent(worldspaceCanvas.transform);
        }
    }
}
