using UnityEngine;
using System.Collections;

public class EnemyUpDown : MonoBehaviour {

    //Public variables and constants:
    public float TICK_SLEEP_DOWN_INITIAL = 1f;
    public float speed = 1f;
    

    //Private variables:
    Vector3 posMove;
    private bool up;
    private float tiempoLoad = 0;
    private float posInitialY;
    private bool activeTime = false;
    private float elevation = 1f;

	// Use this for initialization
	void Start () {
        posInitialY = this.transform.position.y;
        up = false;
	}
	
	// Update is called once per frame
	void Update () {
        moveUpDown();
       
	}

    /**
     * Move up and down this object
     */
    private void moveUpDown() {
        if (up)
        {
            //Move up:
            transform.Translate(0, 0, speed * Time.deltaTime);

            if (this.transform.position.y > posInitialY) {
                up = false;
            }

           
        }
        else
        {
            if (!activeTime) {
                transform.Translate(0, 0, -speed * Time.deltaTime);
            }

            if (this.transform.position.y < posInitialY - elevation)
            {
                activeTime = true;
            }
            //Check time:
            if (activeTime) {
                tiempoLoad += Time.deltaTime;
                if (tiempoLoad > TICK_SLEEP_DOWN_INITIAL)
                {
                    tiempoLoad = tiempoLoad - TICK_SLEEP_DOWN_INITIAL;
                    up = true;
                    activeTime = false;
                }
            }
        }
    
    }
}
