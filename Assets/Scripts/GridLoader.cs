using UnityEngine;
using System.Collections;

public class GridLoader : MonoBehaviour {
	public string prefabName;
	public int rows;
	public int columns;

	public Hashtable boxes = new Hashtable();
	public Hashtable boxesPrefabName = new Hashtable ();
	private Hashtable prefabs;

	public float dieAt;

	// Use this for initialization
	void Start () {
		StartMap ("test");
	}

	public void StartMap(string mapname){
		Map m = MapUtils.GetMap (mapname);
		
		dieAt = m.dieAt;
		
		prefabs = new Hashtable ();

		foreach(DictionaryEntry entry in boxes){
			if(entry.Value != null){
				Destroy((GameObject)entry.Value);
				boxesPrefabName[entry.Key] = null;
			}
		}

		boxes = new Hashtable ();
		boxesPrefabName = new Hashtable ();

		for(int i = 0; i < m.fieldsC; i++)
		{
			DrawBox(m.fields[i].prefabName, m.fields[i].x, m.fields[i].y);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject DrawBox(string prefabName, int x, int y){
		if(prefabs[prefabName] == null){
			prefabs.Add(prefabName, Resources.Load (prefabName));
		}
		Vector3 newPos = new Vector3(x,y,0);
		GameObject go = Instantiate((Object)prefabs[prefabName]) as GameObject;
		go.transform.position = newPos;
		FirstPosition fp = go.GetComponent<FirstPosition> ();
		if(fp != null){
			Vector3 np = new Vector3(x,y,0);
			fp.firstPosition = np;
		}
		boxes[x + "-" + y] = go;
		boxesPrefabName [x + "-" + y] = prefabName;
		return go;
	}
}
