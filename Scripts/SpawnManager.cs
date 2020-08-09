using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject CubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawncube",4f,2f);
    }

    // Update is called once per frame
    void SpawnCube()
    {
        Instantiate(CubePrefab,new Vector3(CubePrefab.transform.position.x,CubePrefab.transform.position.y*Random.Range(3f,-3f),CubePrefab.transform.position.z),Quaternion.identity);
    }
}
