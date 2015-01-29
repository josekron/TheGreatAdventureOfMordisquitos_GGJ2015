using UnityEngine;
using System.Collections;

public class EnemyGira : MonoBehaviour {

    public float speed = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, speed * Time.deltaTime);
	}
}