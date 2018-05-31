using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    [HideInInspector]
    public bool forward = false;
    [HideInInspector]
    public bool backward = false;
    [HideInInspector]
    public bool left = false;
    [HideInInspector]
    public bool right = false;

	// Update is called once per frame
	void Update () {
        forward = Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow);
        backward = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        left = Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow);
        right = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
    }
}
