using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {
    public Transform transformToFollow;

	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, transformToFollow.position, 0.1f);
        transform.rotation = transformToFollow.rotation;
	}
}
