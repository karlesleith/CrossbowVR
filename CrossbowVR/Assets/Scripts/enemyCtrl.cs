
using UnityEngine;


public class enemyCtrl : MonoBehaviour
{
    //declare the transform of our goal (where the navmesh agent will move towards) and our navmesh agent (in this case our zombie)
    private Transform goal;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator anim;

    // Use this for initialization
    void Start()
    {

        //create references
        //finding the gameobject "Goal" and letting the gobilns move toward the goal
        goal = GameObject.Find("Goal").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        //set the navmesh agent's desination equal to the main camera's position (our first person character)
        agent.destination = goal.position;
    }

    //for this to work both need colliders, one must have rigid body, and the zombie must have is trigger checked.
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "Bolt(Clone)")
        {
            //first disable the zombie's collider so multiple collisions cannot occur
            GetComponent<CapsuleCollider>().enabled = false;
            //destroy the bullet
            Destroy(col.gameObject);
            //stop the zombie from moving forward by setting its destination to it's current position
            agent.speed = 0;
            //stop the walking animation and play the falling back animation
            //GetComponent<Animation>().Stop();
            anim.Play("Death");
            //GetComponent<Animation>().Play("death");
            //destroy this goblin in three seconds.
            Destroy(gameObject, 3);

        }
        
        //instantiate a new zombie
        //GameObject zombie = Instantiate(Resources.Load("goblin", typeof(GameObject))) as GameObject;

        //set the coordinates for a new vector 3
        //float randomX = UnityEngine.Random.Range(-12f, 12f);
        //float constantY = .01f;
        //float randomZ = UnityEngine.Random.Range(-13f, 13f);
        //set the zombies position equal to these new coordinates
        //zombie.transform.position = new Vector3(randomX, constantY, randomZ);

        //if the zombie gets positioned less than or equal to 3 scene units away from the camera we won't be able to shoot it
        //so keep repositioning the zombie until it is greater than 3 scene units away. 
        //while (Vector3.Distance(zombie.transform.position, Camera.main.transform.position) <= 3)
       // {

           // randomX = UnityEngine.Random.Range(-12f, 12f);
            //randomZ = UnityEngine.Random.Range(-13f, 13f);

            //zombie.transform.position = new Vector3(randomX, constantY, randomZ);
       // }

    }





}