using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling2 : MonoBehaviour
{
    public float speed;
    public GameObject[] patrolPoints;
    int whichPoint;
    float distToPatrolPoint;
    float distToPlayer;
    bool followPlayer;

    public GameObject player;
    public GameControllerFinal2 GCF;

    // Start is called before the first frame update
    void Start()
    {
        whichPoint = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector3.Distance(transform.position, player.transform.position);


        if (distToPlayer <= 7) 
	        {

	            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
	        
	        }
	        else
	        {

	            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[whichPoint].transform.position, Time.deltaTime * speed);

	            distToPatrolPoint = Vector3.Distance(transform.position, patrolPoints[whichPoint].transform.position);

	            if (distToPatrolPoint < 0.02f) 
	            {
	                whichPoint++;
	                if (whichPoint >= patrolPoints.Length) 
	                {
	                    whichPoint = 0;
	                }
	            }
	        }
    	

        if (distToPlayer <= 4)
        {
        	if(Input.GetButtonDown("Jump"))
    	 	{
                GCF.killCount += 1;
    	 		Destroy(this.gameObject);
    	 	}
        }
    }
}
