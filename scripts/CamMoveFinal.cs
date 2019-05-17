using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoveFinal : MonoBehaviour
{
	//place the player in so that the camera follows it
	public Transform target;
	
	//how fast the camera will follow the player (lower = slower)
	public float smoothing;
	
	public Vector2 maxPosition;
	public Vector2 minPosition;

    //LateUpdate is called last in the frame
    //we're using late update so that this script won't get called before the player script, glitching the camera
    void LateUpdate()
    {
        if(transform.position != target.position)
        {
        	//this is to reference where the target(player) position is, z stays as its own so that the camera isn't right on the 2D game space
        	Vector3 targetPosition = new Vector3 (target.position.x, target.position.y, transform.position.z);

        	//this is to modify the target position when you reach the edge of the map
        	//clamp takes in the value you want to bound, and the minimum and maximum values you want
        	targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);

        	targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

        	//lerp finds a distance between the current position and the target and moves a percentage of that distance each frame
        	transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
