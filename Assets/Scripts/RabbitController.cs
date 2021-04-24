using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RabbitController : MonoBehaviour
{
    public int rabbitHealth = 14;
    public int rabbitHunger = 0;
    public int rabbitThirst = 0;
    public int rabbitViewDistance = 20;
    public NavMeshAgent agent;

    float xPos;
    float yPos;
    float zPos;
    float rabbitXPos;
    float rabbitZPos;
    
    Vector3 movePos;
    void Start()
    {
        

        

       
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            RandomPosition();

        }
    }

     public void RandomPosition() 
     {   
         // get current rabbit position

         rabbitXPos = transform.position.x;
         rabbitZPos = transform.position.z;


         // get random x and z positions within a radius
         xPos = Random.Range((rabbitXPos - rabbitViewDistance), (rabbitXPos + rabbitViewDistance));
         zPos = Random.Range((rabbitZPos - rabbitViewDistance), (rabbitZPos + rabbitViewDistance));

         // move rabbit to the random location
         movePos = new Vector3(xPos, 0, zPos);

         movePos.y = Terrain.activeTerrain.SampleHeight(movePos);

         Debug.Log("x " + rabbitXPos + " z " + rabbitZPos + " xPos " + xPos + " zPos " + zPos + " movePos " + movePos);

         agent.SetDestination(movePos); }

    /*public static Vector3 RandomNavSphere (Vector3 origin, float distance, int layermask) {

        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);
        
        test = navHit.position;
        
        return navHit.position;

        
    }*/



}
