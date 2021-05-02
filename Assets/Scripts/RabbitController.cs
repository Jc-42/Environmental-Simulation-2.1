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
    public Animator[] animate;
    

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
        
       

        // Create a random time that the creature will wait for
        randomTime = Random.Range(3, 8);

        // Run the 'timer' meathod every second
        InvokeRepeating("timer", 1f , 1f );

       

    }

    
    void Update()
    {

        
            if (time >= randomTime)
        {
            


            // Calculate a random position and determin if it is reachable if so then ...
            RandomPosition();

            NavMeshPath path = new NavMeshPath();

            if (agent.CalculatePath(movePos, path) && path.status == NavMeshPathStatus.PathComplete)
            {
                // Move to target and activate animation then
                animate = GetComponentsInChildren<Animator>();
                foreach (Animator ani in animate)
                {

                    ani.enabled = true;

                }  

                agent.SetDestination(movePos);

                //  Check if the time the creature has waited has surpassed the random max wait time if so reset the random time and the wait time
                randomTime = Random.Range(3, 8);
                time = 0;
            }
            
            // If its not reachable than calculate and new path and check again
                
            

        }

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    // If the creature has stopped moving then stop the movement animation
                    animate = GetComponentsInChildren<Animator>();
                    foreach (Animator ani in animate)
                    {

                        ani.enabled = false;

                    }









                }
            }
        }



    }

     public void RandomPosition() 
     {   
         // Get current creature position
         rabbitXPos = transform.position.x;
         rabbitZPos = transform.position.z;


         // Get random x and z positions within a radius
         
         xPos = Random.Range((rabbitXPos - rabbitViewDistance), (rabbitXPos + rabbitViewDistance));
         zPos = Random.Range((rabbitZPos - rabbitViewDistance), (rabbitZPos + rabbitViewDistance));
         
        
         // Check of the agent is trying to leave the map if so set its new x or z destination to the max x or z on the map.
         if (xPos >= 154.7f)
        {
            xPos = Random.Range(153 - rabbitViewDistance, 153);
        }
         if (xPos <= 5f)
        {
            xPos = Random.Range(4 + rabbitViewDistance, 4);
        }
         if (zPos >= 154.7f)
        {
            zPos = Random.Range(153 - rabbitViewDistance, 153);
        }
         if (zPos <= 5f)
        {
            zPos = Random.Range(4 + rabbitViewDistance, 4);
        }

        
         //set movPos to the previous x and z positions
         movePos = new Vector3(xPos, 0, zPos);

        // Change the y value of the random location to the hight of the ground at that random point
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
                    // If the creature has stopped moving then advance the time it has waited
                    time = time + 1f;
                    







                }
            }
        }
       

    }

    
    public void IsHungry()
    {
        // Work in progress
    }

}
