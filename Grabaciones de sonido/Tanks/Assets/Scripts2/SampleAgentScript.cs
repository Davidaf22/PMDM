using UnityEngine;
using UnityEngine.AI;

public class SampleAgentScript : MonoBehaviour {
       public Transform goal;

	   private NavMeshAgent agent;
       
	   //public Animator animator;

	   //public float proximidad;
    void Start (){
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.autoBraking = false;
        // asiganmos el animator del player para poder cambiar la bool
        //animator = goal.GetComponent<Animator>();
    }
	void Update(){
        // con el player/target
        agent.SetDestination(goal.position);
        // comparamos la distancia al enemigo
        // cambiamos la variable bool
        // de esta manera forzamos la transicion desde Tarnquilo a Peligro
        // y vice versa
        /*if (!agent.pathPending && agent.remainingDistance < proximidad){
            Debug.Log("Peligro");
            // cambiamos a true la variable del animator
            animator.SetBool("estarPeligro", true);
        }
        else{
            Debug.Log("Tranquilo");
            // cambiamos a false la variable del animator
            animator.SetBool("estarPeligro", false);
        }*/
    }
}