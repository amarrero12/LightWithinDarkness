using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveFinal : MonoBehaviour
{

	public int speed;
	float horz;
	float vert;
	public Animator anim;
    public Vector2 cameraChange;
    public Vector2 cameraChangeMin;
    public Vector3 playerChange;
    public Vector3 hitChange;
    private CamMoveFinal cam;
    public GameControllerFinal GCF;
    public Vector2 cameraChange2;
    public Vector2 cameraChangeMin2;
    public Vector3 playerChange2;
    public GameObject Trayvon;
    public GameObject Z;
    public bool saveThem;
    public ZFails ZScript;
    public PopoScript CopScript;
    public GameObject newPortal;

    // Start is called before the first frame update
    void Start()
    {
		speed = 10;
        cam = Camera.main.GetComponent<CamMoveFinal>();
        saveThem = false;
    }

    // Update is called once per frame
    void Update()
    {
		vert = Input.GetAxisRaw ("Vertical")*speed;
		horz = Input.GetAxisRaw ("Horizontal")*speed;
		vert *= Time.deltaTime;
		horz *= Time.deltaTime;

		transform.Translate(horz, vert, 0);

		anim = GetComponent<Animator>();
		if (Input.GetButtonDown("Jump"))
		{
			anim.SetTrigger("AttacRight");
		}

        if(saveThem == true)
        {
            if (Input.GetKey("x"))
            {
                ZScript.ZAnim.SetTrigger("itsOver");
                CopScript.saveTrayvon = true;
                newPortal.SetActive(true);
            }
        }

        if (Input.GetKey("left"))
        {
            anim.SetTrigger("LookLeft");
        }
        if (Input.GetKey("right"))
        {
            anim.SetTrigger("LookRight");
        }
        if (Input.GetKey("a"))
        {
            anim.SetTrigger("LookLeft");
        }
        if (Input.GetKey("d"))
        {
            anim.SetTrigger("LookRight");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
    	if(other.gameObject.tag == "portal1")
    	{
            SceneManager.LoadScene("Trayvon");
    		// Debug.Log("collision");
    	}
    	if(other.gameObject.tag == "enemy")
    	{
    		if (Input.GetButtonDown("Jump"))
    		{
    			return;
    		}else
            {
                GCF.lives -= 1;
                
                transform.position -= hitChange;
               
                Debug.Log("catchshmoke");
            }
    	}
        if(other.gameObject.tag == "rt")
        {
            cam.minPosition += cameraChangeMin;
            cam.maxPosition += cameraChange;
            transform.position += playerChange;
        }
        if(other.gameObject.tag == "walltotruth")
        {
            cam.minPosition += cameraChangeMin2;
            cam.maxPosition += cameraChange2;
            transform.position += playerChange2;
            Trayvon.SetActive(true);
            Z.SetActive(true);
        }
        if(other.gameObject.tag == "shot")
        {
            Destroy(other.gameObject);
            GCF.lives -= 1;
        }
        if(other.gameObject.tag == "nextworld")
        {
            SceneManager.LoadScene("Kids");
        }
    }

    // void OnCollisionStay2D(Collision2D other)
    // {
    // 	if(other.gameObject.tag == "enemy")
    // 	{
    // 		if (Input.GetButtonDown("Jump"))
    // 		{
    // 			Destroy(other.gameObject);
    // 		}
    // 	}
    // }


}
