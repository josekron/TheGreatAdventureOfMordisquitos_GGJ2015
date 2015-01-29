using UnityEngine;
using System.Collections;

public class HamsterDentroRueda : MonoBehaviour {

    private Vector3 posRueda;

    public static bool leftNew;
    private bool leftAct;
	// Use this for initialization
	void Start () {
        leftNew = false;
        leftAct = false;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag("Player");
        if (objetos[0] != null) {
            GameObject rueda = objetos[0];
            posRueda = rueda.transform.position;
            posRueda.y -= 0.4f;
            transform.position = posRueda;
        }

        if (leftAct != leftNew) {
            leftAct = leftNew;
            if (leftAct)
            {
                transform.Rotate(0, 180, 0);
            }
            else {
                transform.Rotate(0, -180, 0);
            }
        }
        
	
	}
}
