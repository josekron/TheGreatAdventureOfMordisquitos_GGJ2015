using UnityEngine;
using System.Collections;

public class CheckPlayerForDead : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Destroy (col.gameObject);
            col.GetComponent<MovePlayer>().activeDead();
        }
    }

}
