using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayvonLives : MonoBehaviour
{
	public float speed;
	public Animator TAnim;
	public GameObject[] patrolPoints;
	public int whichPoint;
    float distToPatrolPoint;

    //timer
    private float waitTime;
    public float startWaitTime;

    //a bunch of bools as triggers
    public bool TisLeft;
    public bool TReady;

    public ZFails ZScript;
    public PlayerMoveFinal PScript;

    // Start is called before the first frame update
    void Start()
    {
        whichPoint = 0;
        waitTime = startWaitTime;
        TisLeft = false;
        TReady = false;
    }

    // Update is called once per frame
    void Update()
    {
    	TAnim = GetComponent<Animator>();
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[whichPoint].transform.position, Time.deltaTime * speed);
        distToPatrolPoint = Vector3.Distance(transform.position, patrolPoints[whichPoint].transform.position);

        if(ZScript.ZReachP1 == true)
        {
        	TAnim.SetTrigger("lookleftboy");
        	TisLeft = true;
        }
        if(ZScript.Zotw == true)
        {
        	ZScript.ZReachP1 = false;
        	waitTime -= Time.deltaTime;
        	if (waitTime <= 0)
        	{
        		TAnim.SetTrigger("getready");
        		TReady = true;
        	}
        }
        // if(ZScript.FallBackKid == true);
        // {
        // 	Debug.Log("mohong");
        // 	whichPoint = 1;
        // 	waitTime = startWaitTime;
        // 	waitTime -= Time.deltaTime;
        // 	if(waitTime <= 0);
        // 	{
        // 		TAnim.SetTrigger("fallsdown");
        // 	}
        // }
    }
    void OnCollisionEnter2D (Collision2D other)
    {
    	Debug.Log("mohong");
    	if (other.gameObject.tag == "Z")
    	{
    		whichPoint = 1;
    		TAnim.SetTrigger("fallsdown");
    	}
    	if (other.gameObject.tag == "guntrigger")
    	{
    		ZScript.ZAnim.SetTrigger("AimGun");
    		PScript.saveThem = true;
    	}
    }
}
