using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShotFinal : MonoBehaviour
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
        transform.Translate(0,(Time.deltaTime * -shotSpeed),0);
		removeShots();
    }

    void removeShots(){
		if (transform.position.y <= 64) {
			Destroy (this.gameObject);			
		}
	}

}
