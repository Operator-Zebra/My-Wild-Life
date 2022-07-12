using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrianHieghtFinder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = Terrain.activeTerrain.SampleHeight(transform.position);
        transform.position = pos;
    }
}
