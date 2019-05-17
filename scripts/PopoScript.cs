using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopoScript : MonoBehaviour
{
	public float speed;
	public GameObject patrolpoint;
	float distToPatrolPoint;

	public bool saveTrayvon;
	public GameObject Platanoman;

    // Start is called before the first frame update
    void Start()
    {
        saveTrayvon = false;
    }

    // Update is called once per frame
    void Update()
    {
    	distToPatrolPoint = Vector3.Distance(transform.position, patrolpoint.transform.position);

        if(saveTrayvon == true)
        {
        	transform.position = Vector3.MoveTowards(transform.position, patrolpoint.transform.position, Time.deltaTime * speed);
        }
        if (distToPatrolPoint <= 0.01)
        {
        	Platanoman.SetActive(true);
        }
    }
}
