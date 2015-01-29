using UnityEngine;
using System.Collections;

public class ParticleTimeDestroy : MonoBehaviour {

    public float TICK_DESTROY_INITIAL = 3f;
    private float tiempoLoad = 0;

	// Use this for initialization
	void Start () {
        TICK_DESTROY_INITIAL = 2f;
	}
	
	// Update is called once per frame
	void Update () {
        tiempoLoad += Time.deltaTime;
        if (tiempoLoad > TICK_DESTROY_INITIAL)
        {
			Application.LoadLevel("Laberinto");
            tiempoLoad = tiempoLoad - TICK_DESTROY_INITIAL;
            Destroy(gameObject);
        }
	}


}
