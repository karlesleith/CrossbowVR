
using UnityEngine;
using UnityEngine.UI;

public class enemyCtrl : MonoBehaviour
{
    //declare the transform of our goal (where the navmesh agent will move towards) and our navmesh agent (in this case our zombie)
    private Transform goal;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator anim;

    public int killPoints;
  

    public int damageToGive;


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

    //for this to work both need colliders, one must have rigid body, and the goblin must have is trigger checked.
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "Bolt(Clone)")
        {
            //first disable the goblins's collider so multiple collisions cannot occur
            GetComponent<CapsuleCollider>().enabled = false;
            //destroy the bullet
            Destroy(col.gameObject);
            //stop the goblins from moving forward by setting its destination to it's current position
            agent.speed = 0;
            //stop the walking animation and play the falling back animation
            //GetComponent<Animation>().Stop();
            anim.Play("Death");
            //GetComponent<Animation>().Play("death");
            //destroy this goblin in three seconds.
            Destroy(gameObject, 1.5f);
            Score();

        }

        if (col.gameObject.name == "TargetBarricade")
        {

            Debug.Log("Damaging Gate: " + damageToGive);

            col.gameObject.GetComponent<GateHealthCtrl>().DamageGate(damageToGive);


        }


    }

    void Score()
    {
        
        FindObjectOfType<GameLoopCtrl>().scoreCnt +=killPoints;
    }


}