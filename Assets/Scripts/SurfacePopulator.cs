using UnityEngine;
using System.Collections;
using System;

public class SurfacePopulator //: $$anonymous$$onoBehaviour
{

    public int numberOfObjects;
    public int currentObjects;
    public GameObject objectToPlace;

    private float randomX;
    private float randomZ;
    private Renderer r;

    void Start()
    {

     /*
        r = GetComponent<Renderer>();
        randomX = Random.Range(r.bounds.$$anonymous$$.x, r.bounds.max.x);
        randomZ = Random.Range(r.bounds.$$anonymous$$.z, r.bounds.max.z);
    */

    }

    void Update()
    {
        RaycastHit hit;
        if (currentObjects <= numberOfObjects)
        {
            if (Physics.Raycast(new Vector3(randomX, r.bounds.max.y + 5f, randomZ), -Vector3.up, out hit))
            {
                Instantiate(objectToPlace, hit.point, Quaternion.identity);
                currentObjects += 1;
            }
        }
    }

    private void Instantiate(GameObject objectToPlace, Vector3 point, Quaternion identity)
    {
        throw new NotImplementedException();
    }
}