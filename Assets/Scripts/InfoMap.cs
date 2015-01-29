using UnityEngine;
using System.Collections;

public class InfoMap : MonoBehaviour {
	private string nameMap;
	private bool instanced=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setName(string name){
		this.nameMap = name;
	}

	public string getName(){
		return this.nameMap;
	}

	public void setInstanced(bool value){
		this.instanced = value;
	}

	public bool getInstanced(){
		return this.instanced;
	}
}
