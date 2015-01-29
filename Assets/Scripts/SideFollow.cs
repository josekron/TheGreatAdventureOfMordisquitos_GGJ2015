using UnityEngine;
using System.Collections;

public class SideFollow : MonoBehaviour {
	public GameObject target;
	public float distance;
	private Vector3 newPos;
	private Vector3 velocity = Vector3.zero;
	// Use this for initialization
	void Start () {
		
	}

	Vector3 point;
	Vector3 delta;
	Vector3 destination;

	// Update is called once per frame
	void Update () {
		//newPos = target.transform.position;
		//newPos.z = distance;
		//this.transform.position = newPos;



		point = camera.WorldToViewportPoint(target.transform.position);
		delta = target.transform.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
		destination = this.transform.position + delta;
		//camera.transform.LookAt (target.transform);
		this.transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, 0.5f);

		//this.transform.position = Vector3.SmoothDamp(this.transform.position, newPos, ref velocity, 0.15f);

	}


}
