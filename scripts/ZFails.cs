using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZFails : MonoBehaviour
{

	public float speed;
	public GameObject[] patrolPoints;
	int whichPoint;
    float distToPatrolPoint;
    public TrayvonLives TLBoy;
    public Animator ZAnim;

    //timer
    private float waitTime;
    public float startWaitTime;

    //a bunch of bools as triggers
    public bool ZReachP1;
    public bool Zotw;
    public bool FallBackKid;
    public bool aimbitch;

    // Start is called before the first frame update
    void Start()
    {
        whichPoint = 0;
        waitTime = startWaitTime;
        ZReachP1 = false;
        Zotw = false;
        FallBackKid = false;
        // aimbitch = false;


    }

    // Update is called once per frame
    void Update()
    {
    	ZAnim = GetComponent<Animator>();
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[whichPoint].transform.position, Time.deltaTime * speed);
        distToPatrolPoint = Vector3.Distance(transform.position, patrolPoints[whichPoint].transform.position);

        if(distToPatrolPoint <= 0.1)
        {
        	ZReachP1 = true;
        }
        if(TLBoy.TisLeft == true)
        {
        	waitTime -= Time.deltaTime;
        	if (waitTime <= 0)
        	{
	        	whichPoint = 1;
	        	Debug.Log("I work");
	        	ZAnim.SetTrigger("ZSquareUp");
	        	Zotw = true;
	        	waitTime = startWaitTime;
	        	// TLBoy.TisLeft = false;
	        	// ZAnim.SetTrigger("ZSquareUp");
        	}
        }
        // if(whichPoint == 1)
        // {
        // 	if(distToPatrolPoint <= 0.1)
        // 	{
        // 		FallBackKid = true;
        // 		Debug.Log("well???");
        // 	}
        

        // if(aimbitch == true);
        // {
        // 	ZAnim.SetTrigger("AimGun");
        // }
    }


}
