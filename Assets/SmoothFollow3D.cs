using UnityEngine;
using System.Collections;

public class SmoothFollow3D : MonoBehaviour {
	public GameObject target;
	public float height;

	Vector3 newPos = new Vector3();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		newPos.y = target.transform.position.y + height;
		newPos.x = target.transform.position.x;
		newPos.z = target.transform.position.z;
		camera.transform.position = newPos;
		camera.transform.LookAt (target.transform);
	}
}
