using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationCtrl : MonoBehaviour {


    const float locomotionAnimationSmoothTime = .1f;

    NavMeshAgent agent;
    Animator animator;

    // Use this for initialization
    void Start () {

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        FaceTarget(GameObject.Find("Goal").transform);
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);
        Attack();

    }

    // Face model to target direction
    void FaceTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void Attack()
    {
        float distance = Vector3.Distance(agent.destination, transform.position);
        if (distance <= agent.stoppingDistance)
        {
            animator.Play("Attack");
        }
    }

}
