using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public Rigidbody grass;
    public Vector3 grassPos;
    public float xPos;
    public float zPos;
    public float xRotat;
    public float yRotat;
    public float zRotat;
    public Transform transformGrass;
    public int initGrass = 20;
    public int grassInterval;
    
    void Start()
    {   
         grassInterval = Random.Range(5, 12);
        
        // Spawn the inital number of grass
        int count = 0;
         while (count < initGrass)
        {
            createGrass();
            count++;
        }
        
        // Spawn grass after a random number of seconds
        InvokeRepeating("createGrass", Random.Range(5, 12), grassInterval);
        

    }

    
    void Update()
    {
        
    }

    
    
    public void createGrass()
    {
        // Pick a random position to spawn grass then spawn it at that point with a random rotation
        xPos = Random.Range(0, 160);
        zPos = Random.Range(0, 160);
        grassPos = new Vector3(xPos, 0, zPos);
        grassPos.y = Terrain.activeTerrain.SampleHeight(grassPos);

        xRotat = Random.Range(-5, 5);
        yRotat = Random.Range(0, 360);
        zRotat = Random.Range(-5, 5);
        
        
        transformGrass.transform.rotation = Quaternion.Euler(xRotat, yRotat, zRotat);
        
        
        Instantiate(grass, grassPos, transformGrass.rotation);
        grassInterval = Random.Range(5, 12);
      
    }
}
