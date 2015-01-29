using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
		public float velocity = 1;
        private bool left = false;

        public float TICK_CHECKWALL_INITIAL = 0.02f;
        private float tiempoLoad = 0;
        private bool activateEspera = false;

		// Use this for initialization
		void Start ()
		{	
		}
	
		// Update is called once per frame
		void Update ()
		{
            checkActiveEspera();
            if (!left)
            {
                transform.Translate(velocity * Time.deltaTime, 0, 0);
                
            }
            else
            {
                transform.Translate(-velocity*Time.deltaTime, 0, 0);
                
            }
				
		}


		void OnTriggerEnter (Collider col)
		{
            if (!activateEspera && col.gameObject.tag != "Player" && col.gameObject.tag == "wall")
            {
                    if (!left)
                    {
                        left = true;
                        activateEspera = true;
                       
                    }
                    else
                    {
                        left = false;
                        activateEspera = true;
                        
                    }
				}
                //Debug.Log("trigger: " + col.gameObject.tag);
				
		}

        private void checkActiveEspera()
        {
            if (activateEspera)
            {
                tiempoLoad += Time.deltaTime;
                if (tiempoLoad > TICK_CHECKWALL_INITIAL)
                {
                    activateEspera = false;
                    tiempoLoad = tiempoLoad - TICK_CHECKWALL_INITIAL;
                }

            }

        }

        

}
