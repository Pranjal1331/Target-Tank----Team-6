using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnterrain : MonoBehaviour
{
    public Endlessrunner endlessrunner;
    void Start()
    {
        endlessrunner = FindObjectOfType<Endlessrunner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Terrainspawner")
        {
            endlessrunner.MoveTerrain();
            other.GetComponent<BoxCollider>().enabled = false;

        }
    }
}
