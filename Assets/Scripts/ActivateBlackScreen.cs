using UnityEngine;
using System.Collections;

public class ActivateBlackScreen : MonoBehaviour {

    private Color color;
    public float TICK_DEGRADED_INITIAL = 0.0001f;
    private float tiempoLoad = 0;


	// Use this for initialization
	void Start () {
        color = renderer.material.color;
        color.a = 0.1f;
        renderer.material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
        tiempoLoad += Time.deltaTime;
        if (tiempoLoad > TICK_DEGRADED_INITIAL)
        {
            tiempoLoad = tiempoLoad - TICK_DEGRADED_INITIAL;

            color = renderer.material.color;
            if (color.a < 1f) {
                color.a = color.a + 0.2f;
            }
            if (color.a >= 1f) {
                Application.LoadLevel("EscenaPrueba");
            }
            renderer.material.color = color;
        }
	}

    public void activateBlackScreen() { 
    
    }
}
