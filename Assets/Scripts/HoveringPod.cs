using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveringPod : MonoBehaviour {
    public float hoverHeight = 2f;
    public float turnSpeed = 2f;
    public float maxSpeed = 2f;
    
    private PlayerInput input;
    private float actualGravityInducedSpeed = 0f;

    void Start () {
        input = GetComponent<PlayerInput>();
	}
	
	void Update () {
        Vector3 forwardVector = Vector3.zero;
        Vector3 backwardVector = Vector3.zero;
        Vector3 leftVector = Vector3.zero;
        Vector3 rightVector = Vector3.zero;

        if (input.forward)
        {
            forwardVector = transform.forward * maxSpeed;
        }
        if (input.backward)
        {
            backwardVector = -transform.forward * maxSpeed;
        }
        if (input.left)
        {
            leftVector.y = turnSpeed;
        }
        if (input.right)
        {
            rightVector.y = turnSpeed;
        }

        RaycastHit hitInfo;
        Vector3 altitudeVector = Vector3.zero;
        Vector3 gravitySpeedVevtor = Vector3.zero;

        if(Physics.Raycast(transform.position, -transform.up, out hitInfo, hoverHeight))
        {
            Debug.Log("ca touche");
            // transform.position = Vector3.Lerp(transform.position, hitInfo.normal, Time.deltaTime);
            altitudeVector.y = hoverHeight - hitInfo.distance;
            actualGravityInducedSpeed = 0f;
        }
        else
        {
            actualGravityInducedSpeed += 9.81f * Time.deltaTime;
            gravitySpeedVevtor.y = (transform.up.y - actualGravityInducedSpeed);
            Debug.Log("ca touche pas");
        }

        //transform.localPosition += forwardVector + backwardVector + altitudeVector;
        transform.Translate((forwardVector + backwardVector + gravitySpeedVevtor) * Time.deltaTime + altitudeVector, Space.World);
        transform.Rotate(transform.up, (-leftVector.y+rightVector.y) * Time.deltaTime, Space.Self);
	}
}
