using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endlessrunner : MonoBehaviour
{
    //public GameObject terrain;
    public List<GameObject> terrains;
    public List<GameObject> roads;
    float offsetZ = 902.09583f;
    float offsetZ2 = 902.195F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveTerrain()
    {
        GameObject movedroad = roads[0];
        GameObject movedterrain = terrains[0];
        movedterrain.GetComponentInChildren<BoxCollider>().enabled = true;
        terrains.Remove(movedterrain);
        roads.Remove(movedroad);
        float newZ = terrains[terrains.Count - 1].transform.position.z + offsetZ;
        float newZ2 = roads[roads.Count - 1].transform.position.z + offsetZ2;
        movedterrain.transform.position = new Vector3 (movedterrain.transform.position.x, movedterrain.transform.position.y, newZ);
        movedroad.transform.position = new Vector3 (movedroad.transform.position.x, movedroad.transform.position.y, newZ2);
        terrains.Add(movedterrain);
        roads.Add(movedroad);
    }
}
