using UnityEngine;
using System.Collections;
using System.IO;

public class Editor : MonoBehaviour {
	public bool enableEditor;
	// Use this for initialization

	Vector3 mousePosition = new Vector3 (0, 0, 0);

	string stringToEdit = "newMap";
	GameObject mouse;
	GameObject player;

	MapsLoader mapsloader;
	GridLoader gridloader;

	bool mustEnableEditor = false;
	bool lastMustEnableEditor = false;

	public string[] proplist = new string[2]{"Cube","Base"};

	public string selectedProp;
	public int selectedPropIndex;

	public void NextProp(){
		selectedPropIndex--;
		selectedPropIndex = (selectedPropIndex + proplist.Length) % proplist.Length;
		selectedProp = proplist [selectedPropIndex];
	}

	public void PrevProp(){
		selectedPropIndex++;
		selectedPropIndex = (selectedPropIndex + proplist.Length) % proplist.Length;
		selectedProp = proplist [selectedPropIndex];
	}

	void Start () {
		mapsloader = GameObject.Find ("GlobalScripts").GetComponent<MapsLoader>();
		gridloader = GameObject.Find ("GlobalScripts").GetComponent<GridLoader>();
		selectedProp = proplist [0];
		selectedPropIndex = 0;
		mouse = GameObject.Find ("Mouse");
		player = GameObject.Find ("Player");
		mouse.SetActive(false);
	}

	void OnGUI () {
		if(PlayerPrefs.GetString("mapedit") == "false"){return;}

		// Make a background box
		if (enableEditor) {
			int boxHeight = (proplist.Length * 20) + 90;
			GUI.Box(new Rect(10,10,190,boxHeight), "Editor");
		}else{
			GUI.Box(new Rect(10,10,190,20), "Editor");
		}


		mustEnableEditor = GUI.Toggle(new Rect(130, 10, 150, 20), mustEnableEditor, "Enable");
		
		if (lastMustEnableEditor != mustEnableEditor) {
			ToggleEditor();
		}
		lastMustEnableEditor = mustEnableEditor;

		if(!enableEditor){return;}

		stringToEdit = GUI.TextField(new Rect(20, 40, 170, 20), stringToEdit, 25);

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,70,80,20), "Load")) {
			Debug.Log("Pulsado Load");
			gridloader.StartMap(stringToEdit);
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(110,70,80,20), "Save")) {
			Map m = CreateMap();
			MapUtils.SetMap(stringToEdit,m);
		}
		int hc = 95;

		string textToWrite;

		for(int i = 0; i < proplist.Length; i++){
			textToWrite = proplist[i];
			if(proplist[i] == selectedProp){
				textToWrite = "> " + textToWrite;
			}
			GUI.Label(new Rect(20,hc,170,20), textToWrite);
			hc += 20;
		}

	}

	Map CreateMap (){
		Map newMap = new Map ();
		foreach(DictionaryEntry entry in gridloader.boxes){
			if(entry.Value != null){
				GameObject go = (GameObject)entry.Value;
				Map.Field newField = new Map.Field();

				FirstPosition fp = go.GetComponent<FirstPosition>();
				if(fp != null) {
					newField.x = (int)fp.firstPosition.x;
					newField.y = (int)fp.firstPosition.y;
				}else{
					newField.x = (int)go.transform.position.x;
					newField.y = (int)go.transform.position.y;
				}
				newField.prefabName = (string)gridloader.boxesPrefabName[entry.Key];
				newMap.AddField(newField);
			}
		}
		return newMap;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void ToggleEditor (){

		if (enableEditor) {
			enableEditor = false;
		} else {
			enableEditor = true;
		}

		if(enableEditor){
			player.GetComponent<MovePlayer>().disablePlayer(true);
			mouse.GetComponent<MoveMouse>().disableMouse(false);
			GameObject.Find("Main Camera").GetComponent<SideFollow>().target = mouse;
		}else{
			player.GetComponent<MovePlayer>().disablePlayer(false);
			mouse.GetComponent<MoveMouse>().disableMouse(true);
			GameObject.Find("Main Camera").GetComponent<SideFollow>().target = player;
		}
	}
}
