using UnityEngine;
using System.Collections;

public class LoadBase : MonoBehaviour
{
		public string mapname;
		private bool showLevelBox = false;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{

		}

		void OnTriggerEnter (Collider col)
		{
		showLevelBox = true;

		}

	void OnTriggerExit(Collider col){
		showLevelBox = false;
	}

		void OnGUI ()
		{
				if (showLevelBox) {
						GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 2, 200, 50), "Quieres cargar el nivel " + mapname);
						if (GUI.Button (new Rect (Screen.width / 2 - 40, Screen.height / 2 + 20, 80, 30), "Jugar")) {
								
								Application.LoadLevel (mapname);
						}
						/*if(GUI.Button(new Rect(Screen.width/2+10,Screen.height/2+20,70,30),"Cancelar")){
				showLevelBox=false;
			}*/
				}
		}
}
