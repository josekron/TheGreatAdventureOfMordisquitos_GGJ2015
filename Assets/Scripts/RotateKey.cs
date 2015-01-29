using UnityEngine;
using System.Collections;

public class RotateKey : MonoBehaviour {

    private float speed = 40f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(speed * Time.deltaTime, 0, speed * Time.deltaTime);
	}
}
