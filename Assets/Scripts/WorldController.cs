using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public Rigidbody grass;
    public Rigidbody rabbit;
    public Transform transformGrass;
    public Transform transformRabbit;
    public Vector3 grassPos;
    public Vector3 rabbitPos;

    public float xPos;
    public float zPos;

    public float rXPos;
    public float rZPos;

    public float xRotat;
    public float yRotat;
    public float zRotat;

    public int initalGrass;
    public int initalRabbits;
    public int grassInterval;
    
    void Start()
    {   
         grassInterval = Random.Range(5, 12);
        
        // Spawn the inital number of grass
        int count = 0;
         while (count < initalGrass)
        {
            SpawnGrass();
            count++;
        }


        // Spawn some inital Rabbits
        int count2 = 0;

        while (count2 < initalRabbits)
        {
            SpawnRabbits();
            count2++;
        }


        // Spawn grass after a random number of seconds
       InvokeRepeating("SpawnGrass", Random.Range(5, 12), grassInterval);

        

    }

    
    void Update()
    {
        
    }

    
    
    public void SpawnGrass()
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
        //grassInterval = Random.Range(5, 12);
      
    }

    public void SpawnRabbits()
    {
        // Pick a random position to spawn a Rabbit then spawn it
        rXPos = Random.Range(0, 160);
        rZPos = Random.Range(0, 160);
        rabbitPos = new Vector3(rXPos, 0, rZPos);
        rabbitPos.y = Terrain.activeTerrain.SampleHeight(rabbitPos);



       
        Instantiate(rabbit, rabbitPos, transformRabbit.rotation);
        
    }
}
