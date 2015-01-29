using UnityEngine;
using System.Collections;

public class Alpha4 : MonoBehaviour {

    private Color color;

	// Use this for initialization
	void Start () {
        color = renderer.material.color;
        color.a = 0.2f;
        renderer.material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}