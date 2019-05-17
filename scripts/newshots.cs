using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newshots : MonoBehaviour
{
    public float shotSpeed;
	SpriteRenderer SR;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Time.deltaTime * shotSpeed),0,0);
		removeShots();
    }

    void removeShots(){
		if (transform.position.x >= -71.2) {
			Destroy (this.gameObject);			
		}
	}
}
