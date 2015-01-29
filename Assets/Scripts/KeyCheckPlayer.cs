using UnityEngine;
using System.Collections;

public class KeyCheckPlayer : MonoBehaviour {

	// Use this for initialization
    public GameObject particleFall;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            int numObjects = PlayerPrefs.GetInt("keys");
            numObjects++;
            PlayerPrefs.SetInt("keys", numObjects);


            GameObject newParticle = (GameObject)Instantiate(particleFall, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

    }
}
