using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
		private float time;
		// Use this for initialization
		void Start ()
		{
		}
	
		// Update is called once per frame
		void Update ()
		{
				comprobar ();
		}
		
		void comprobar ()
		{
				time += Time.deltaTime;
				if (time > 15) {
						Destroy (this.gameObject);
				}
		}

		void OnCollisionEnter (Collision col)
		{
            /*if (col.gameObject.tag == "Player")
            {
                //Destroy (col.gameObject);
                col.GetComponent<MovePlayer>().activeDead();
            }*/
                Destroy(this.gameObject);	
		}

		void OnTriggerEnter (Collider col)
		{
            if (col.gameObject.tag == "Player")
            {
                //Destroy (col.gameObject);
                col.GetComponent<MovePlayer>().activeDead();
            }
                Destroy(this.gameObject);	
		}
}
