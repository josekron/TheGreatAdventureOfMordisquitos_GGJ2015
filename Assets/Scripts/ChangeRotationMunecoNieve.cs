using UnityEngine;
using System.Collections;

public class ChangeRotationMunecoNieve : MonoBehaviour {

    private bool leftAct = false;
	// Use this for initialization
	void Start () {
        leftAct = MovimientoMunecoNieve.left;
	}
	
	// Update is called once per frame
	void Update () {

        if (leftAct != MovimientoMunecoNieve.left) {
            if (!MovimientoMunecoNieve.left)
            {
                transform.Rotate(0, 0, 180);
            }
            else {
                transform.Rotate(0, 0, -180);
            }

            leftAct = MovimientoMunecoNieve.left;
            
        }
	
	}
}
