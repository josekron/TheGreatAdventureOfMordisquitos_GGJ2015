using UnityEngine;
using System.Collections;
using System.IO;

public class LevelLoader : MonoBehaviour {
	private bool showLevelBox = false;
	private string levelName;
	private string[] ruta;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag.Equals("Point") && col.GetComponent<InfoMap>().getInstanced()){
			showLevelBox=true;
			Debug.Log("Carga el nivel");
			levelName=col.GetComponent<InfoMap>().getName();
			ruta = levelName.Split(Path.DirectorySeparatorChar);
			ruta=ruta[ruta.Length-1].Split('.');	
			levelName= ruta[0];
		}
	}

	void OnTriggerExit(Collider col){
		if (col.GetComponent<InfoMap> ().getInstanced()) {
						if (col.gameObject.tag.Equals ("Point")) {
								showLevelBox = false;
						}
				}

	}

	void OnGUI(){
		if(showLevelBox){
			GUI.Box(new Rect(Screen.width/2-100,Screen.height/2,200,50),"Quieres cargar el nivel "+ levelName);
			if(GUI.Button(new Rect(Screen.width/2-40,Screen.height/2+20,80,30),"Jugar")){
				PlayerPrefs.SetString("mapname",levelName);
				PlayerPrefs.SetString("mapedit","false");
				Application.LoadLevel("LevelEditor");
			}
			/*if(GUI.Button(new Rect(Screen.width/2+10,Screen.height/2+20,70,30),"Cancelar")){
				showLevelBox=false;
			}*/
		}
	}

}
