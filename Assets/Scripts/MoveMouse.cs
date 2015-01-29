using UnityEngine;
using System.Collections;

public class MoveMouse : MonoBehaviour {

	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;
	public KeyCode remove;
	public KeyCode add;
	public KeyCode nextProp;
	public KeyCode prevProp;

	Vector3 mousePosition = new Vector3(0,0,0);

	GameObject globalscripts;
	GameObject editor;

	bool mouseDisabled = true;

	bool isUp;
	bool isDown;
	bool isLeft;
	bool isRight;
	bool isRemove;
	bool isAdd;
	bool isNextProp;
	bool isPrevProp;
	// Use this for initialization
	void Start () {
		globalscripts = GameObject.Find ("GlobalScripts");
		editor = GameObject.Find("Editor");
	}
	
	// Update is called once per frame
	void Update () {
		if(mouseDisabled){return;}
		isUp = Input.GetKeyDown(up);
		isDown = Input.GetKeyDown(down);
		isLeft = Input.GetKeyDown (left);
		isRight = Input.GetKeyDown (right);

		isRemove = Input.GetKeyDown (remove);
		isAdd = Input.GetKeyDown (add);

		isNextProp = Input.GetKeyDown (nextProp);
		isPrevProp = Input.GetKeyDown (prevProp);

		if(isUp){
			mousePosition.y += 1;
		}else if(isDown){
			mousePosition.y -= 1;
		}

		if(isLeft){
			mousePosition.x -= 1;
		}else if(isRight){
			mousePosition.x += 1;
		}

		this.transform.position = mousePosition;

		if(isRemove){
			GameObject box = (GameObject)globalscripts.GetComponent<GridLoader>().boxes[mousePosition.x + "-" + mousePosition.y];
			Destroy(box);
			globalscripts.GetComponent<GridLoader>().boxes[mousePosition.x + "-" + mousePosition.y] = null;
			globalscripts.GetComponent<GridLoader>().boxesPrefabName[mousePosition.x + "-" + mousePosition.y] = null;
		}

		if(isAdd){
			if(globalscripts.GetComponent<GridLoader>().boxes[(int)mousePosition.x + "-" + (int)mousePosition.y] == null){
				GameObject go = globalscripts.GetComponent<GridLoader>().DrawBox(editor.GetComponent<Editor>().selectedProp, (int)mousePosition.x, (int)mousePosition.y);
				if(globalscripts.GetComponent<GridLoader>().dieAt > ((int)go.transform.position.y + 2)){
					globalscripts.GetComponent<GridLoader>().dieAt = go.transform.position.y + 2;
				}
			}else{
				Debug.Log ("Ya existe");
			}
		}

		if(isNextProp){
			editor.GetComponent<Editor>().NextProp();
		}

		if(isPrevProp){
			editor.GetComponent<Editor>().PrevProp();
		}
	}

	public void disableMouse(bool action){
		mouseDisabled = action;
		if(action){
			gameObject.SetActive(false);
		}else{
			gameObject.SetActive(true);
		}
	}
}
