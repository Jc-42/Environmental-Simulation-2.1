using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotSpawnable : MonoBehaviour
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
    public BoxCollider collide;
    public int nonSpawnableTime = 10;

    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("NonSpawableTimer", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
       
        
    }

    // When something collides with the object, check is the somthing is Grass or a Rabbit then delete the sothgin and spawn a new one  NOTE: this is to prevent things spawing in the water/mountains/etc
    void OnTriggerEnter(Collider col)
    {
        // Wait untill the nonSpawnableTime has passed then stop creatures from beong able to get close to the water and other non spawable positions
        // This is to stop creatures  from being able to touch the water collider on accident and then being deleated and respawned
        
        if (col.gameObject.name == "Grass(Clone)")
        {
            
            Destroy(col.gameObject);
            SpawnGrass();
        }
        else if (col.gameObject.name == "Rabbit Controller(Clone)")
        {
            
            if (count < nonSpawnableTime)
            {
                Destroy(col.gameObject);
                SpawnRabbits();
            }
        }
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

    
    public void NonSpawableTimer()
    {
        count = count + 1;
        if (count >= nonSpawnableTime)
        {
            CancelInvoke("NonSpawableTimer");
        }
    }
        
        
    
} 

