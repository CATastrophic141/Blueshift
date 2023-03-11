//unity// changes speed and does it by an angle

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class CeratosAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public float walkSpeed, runSpeed;

    // for freezing time
    public bool timeIsNotFrozen = true;
    int frozenTime = 0;
    public InputActionReference actionReference = null;

    // for passing by player while hiding
    public bool playerIsNotHiding = true;
    int tick = 0;

    // for patrolling
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    // for chasing player
    public Transform player;
    public LayerMask whatIsPlayer;

    // checks if enemy is aware of player
    //public bool awareOfPlayer { get; private set;}
    public float sightRange, viewAngle, hearRange;
    public bool playerInSightRange, playerInHearRange;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = walkSpeed;
        updateWaypointDestination();
    }

    private void Awake()
    {
        // sets player to player object in game
        player = GameObject.Find("Player").transform;

        // assign a toggle for freezing time
        actionReference.action.started += FreezeTime;
    }

    private void OnDestroy()
    {
        actionReference.action.started -= FreezeTime;
    }

    // Update is called once per frame
    void Update()
    {
        tick++;
        //playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (timeIsNotFrozen)
        {
            environmentView();

            if ((playerInSightRange && playerIsNotHiding) || (playerInHearRange && playerIsNotHiding))
            {
                //Debug.Log("Chasing");
                chasePlayer();
            }
            else
            {
                //Debug.Log("Patrolling");
                patroll();
            }
        }

        // The entity is frozen. Wait for it to time out.
        else
        {

            // Wait
            frozenTime++;

            // 5 seconds pass. Unfreeze the monster
            if (frozenTime >= 300)
            {
                frozenTime = 0;
                timeIsNotFrozen = true;

                agent.isStopped = false;
                agent.speed = walkSpeed;
                updateWaypointDestination();
            }
        }



        /*if(Vector3.Distance(transform.position, target) < 1) {
            iterateWaypointIndex();
            updateWaypointDestination();
        }*/
    }

    public void environmentView()
    {
        // creates an imaginary sphere around the enemy so that it can detect the player when it is near the view radius, returns an array of all the colliders that are overlapping
        Collider[] enemySphere = Physics.OverlapSphere(transform.position, sightRange, whatIsPlayer);

        for (int i = 0; i < enemySphere.Length; i++)
        {
            player = enemySphere[i].transform;

            // calculates how far awya the player is and in what direction, then sets it to dirToPlayer
            Vector3 dirToPlayer = (player.position - transform.position).normalized;

            // saves player's old position
            Vector3 playerOldPostion = player.position;

            // if the angle between the direction to the player and the enemy's forward vector is less than the set view angle then it sets playerInSightRanger to true
            if (Vector3.Angle(transform.forward, dirToPlayer) < viewAngle)
            {
                playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            }

            if ((playerOldPostion != player.position) && (Vector3.Angle(transform.forward, dirToPlayer) < hearRange/2))
            {
                playerInHearRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            }
        }
    }

    // chases player once it sees it
    public void chasePlayer()
    {
        agent.speed = runSpeed;
        agent.SetDestination(player.position);

        // checks if the player is within sight range
        if (Vector3.Distance(transform.position, player.position) > sightRange)
        {
            playerInSightRange = false;
            agent.speed = walkSpeed;
            iterateWaypointIndex();
            updateWaypointDestination();
            //patroll();
        }
    }

    public void patroll()
    {

        if (Vector3.Distance(transform.position, target) < 1)
        {
            iterateWaypointIndex();
            updateWaypointDestination();
        }
    }

    public void updateWaypointDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);

    }

    public void stoppped()
    {
        agent.isStopped = true;
        agent.speed = 0;
    }

    public void iterateWaypointIndex()
    {
        waypointIndex++;

        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    // call the freeze time mechanic
    public void FreezeTime(InputAction.CallbackContext context)
    {
        timeIsNotFrozen = false;
        stoppped();
    }

    // change the hiding bool depending on the state of the player
    public void playerEnterHide()
    {
        Debug.Log(tick + " HIDE");
        playerIsNotHiding = false;
        updateWaypointDestination();
    }

    public void playerLeaveHide()
    {
        Debug.Log(tick + " LEAVE HIDE");
        playerIsNotHiding = true;
    }

}