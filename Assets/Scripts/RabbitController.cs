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

    public float time = 0;

    float xPos;
    float yPos;
    float zPos;
    float rabbitXPos;
    float rabbitZPos;

    int randomTime;

    Vector3 movePos;
    void Start()
    {
        // create a random time that the creature will wait for
        randomTime = Random.Range(3, 8);

        // run the 'timer' meathod every second
        InvokeRepeating("timer", 1f , 1f );

        // make creature move to random position
        RandomPosition();
    }

    
    void Update()
    {
        

        if (time >= randomTime)
        {
            // every frame chack if the time the creature has waited has surpassed the random max wait time if so reset the random time and the wait time then..
            randomTime = Random.Range(3, 8);
            time = 0;


            //..calculate a random position and move the creature to it
            RandomPosition();
            agent.SetDestination(movePos);

        }

      
       
    }

     public void RandomPosition() 
     {   
         // get current creature position
         rabbitXPos = transform.position.x;
         rabbitZPos = transform.position.z;


         // get random x and z positions within a radius
         xPos = Random.Range((rabbitXPos - rabbitViewDistance), (rabbitXPos + rabbitViewDistance));
         zPos = Random.Range((rabbitZPos - rabbitViewDistance), (rabbitZPos + rabbitViewDistance));

         // set movPos to that location
         movePos = new Vector3(xPos, 0, zPos);

        // change the y value of the random location to the hight of the ground at that random point
         movePos.y = Terrain.activeTerrain.SampleHeight(movePos);

    }

    public void timer()
    {

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    // if the creature has stopped moving then advance the time it has waited
                    time = time + 1f;
                    







                }
            }
        }
       

    }

}
