using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newboss : MonoBehaviour
{
    //patroller
	public float speed;
    public GameObject[] patrolPoints;
    int whichPoint;
    float distToPatrolPoint;

    //timer
    private float waitTime;
    public float startWaitTime;
    
    //shot stuff
    public GameObject pewpew;
    public Transform shotLoc;
    bool doShoot;
    public GameObject player;

    public int hits;
    float distToPlayer;
    public GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        whichPoint = 0;
        waitTime = startWaitTime;
        doShoot = false;
        hits = 0;
    }

    // Update is called once per frame
    void Update()
    {
    	distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[whichPoint].transform.position, Time.deltaTime * speed);

        distToPatrolPoint = Vector3.Distance(transform.position, patrolPoints[whichPoint].transform.position);

        TakeTheShot();


        if (player.transform.position.x <= 10)
        {
        	if (distToPatrolPoint < 0.02f)
        	{
        		if (waitTime <= 0)
            	{

                	whichPoint++;
               		//doShoot = false;
                	if (whichPoint >= patrolPoints.Length)
                	{
                		whichPoint = 0;
                	}
                	waitTime = startWaitTime;
            	}
            	else
            	{
            		//if waitTime hasn't ended, subtract it
                	waitTime -= Time.deltaTime;
            	}
            	//shoots at the last second
            	if (waitTime < 0.001)
            	{
            		doShoot = true;
            	}
        	}
        }

        GetSmacked();
        if(hits == 4)
        {
            portal.SetActive(true);
        	Destroy(this.gameObject);
        }
    }

    void TakeTheShot()
    {
    	if (doShoot)
    	{
    		Instantiate (pewpew, shotLoc.position, shotLoc.rotation);
    		doShoot = false;
    	}
    }

    void GetSmacked()
    {
    	if(distToPlayer <= 6)
    	{
    		if(Input.GetButtonDown("Jump"))
    		{
    			hits += 1;
    			Debug.Log("Hits"+hits);
    		}
    	}
    }
}
