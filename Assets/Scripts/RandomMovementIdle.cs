using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //important

//if you use this code you are contractually obligated to like the YT video
public class RandomMovementIdle : MonoBehaviour //don't forget to change the script name if you haven't
{
    private NavMeshAgent agent;
    private float range = 20; //radius of sphere

    private float idleTimer = 3f, idleCounter = 0f;
    private Animator myAnimator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            idleCounter -= Time.deltaTime;

            if (idleCounter < 0)
            {
                Vector3 point;
                if (RandomPoint(transform.position, range, out point)) //pass in our centre point and radius of area
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                    agent.SetDestination(point);
                    myAnimator.SetBool("Idle?", false);
                }
            }
        }
        else if (agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            idleCounter = Random.Range(idleTimer - 2, idleTimer+1);
            myAnimator.SetBool("Idle?", true);
        }
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }


}
