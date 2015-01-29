using UnityEngine;
using System.Collections;

public class MovePlay : MonoBehaviour {
	public KeyCode forwardKey;
	public KeyCode backwardKey;
	public KeyCode rightKey;
	public KeyCode leftKey;

	public float velocity;

	bool isForward;
	bool isBackward;
	bool isRight;
	bool isLeft;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		isForward = Input.GetKey (forwardKey);
		isBackward = Input.GetKey (backwardKey);
		isRight = Input.GetKey (rightKey);
		isLeft = Input.GetKey (leftKey);
		
		if(isForward){
			rigidbody.AddForce(Vector3.forward * velocity);
		}else if(isBackward){
			rigidbody.AddForce(Vector3.back * velocity);
		}
		
		if(isRight){
			rigidbody.AddForce(Vector3.right * velocity);
		}else if(isLeft){
			rigidbody.AddForce(Vector3.left * velocity);
		}
	}
}
