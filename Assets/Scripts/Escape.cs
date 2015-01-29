using UnityEngine;
using System.Collections;

public class Escape : MonoBehaviour {

	private bool showDialog = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(showDialog){
				showDialog = false;
			}else{
				showDialog = true;
			}
		}
	}

	void OnGUI(){
		if(showDialog){
			GUI.Box (new Rect ((Screen.width / 2) - 50, (Screen.height / 2) - 40, 100, 80), "¿Quieres salir?");
			if(GUI.Button(new Rect(((Screen.width / 2) - 50)+30,((Screen.height / 2) - 40)+20,40,40),"Salir")){
				Application.LoadLevel("Menu");
			}
		}
	}
}
