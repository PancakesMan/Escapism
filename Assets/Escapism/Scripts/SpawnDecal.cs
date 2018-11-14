using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnDecal : MonoBehaviour {

    [Tooltip("Canvas to display the image on when it is spawned")]
    public Canvas canvas;

    [Tooltip("Image to spawn. Must be a prefab made from an image placed on a canvas")]
    public Image decal;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            Image newDecal = Instantiate(decal);
            newDecal.transform.position = Camera.main.WorldToScreenPoint(collision.contacts[0].point);
            newDecal.transform.rotation = Quaternion.Euler(collision.contacts[0].normal);
            newDecal.transform.SetParent(canvas.transform);
        }
    }
}
