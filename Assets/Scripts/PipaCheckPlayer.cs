using UnityEngine;
using System.Collections;

public class PipaCheckPlayer : MonoBehaviour {

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
            int numObjects = PlayerPrefs.GetInt("pipas");
            numObjects++;
            PlayerPrefs.SetInt("pipas", numObjects);

            Destroy(gameObject);

        }

    }
}
