using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKey (KeyCode.Return)) {
						
						Application.LoadLevel ("MundoBase");
				} else if (Input.GetKey (KeyCode.Space)) {
						PlayerPrefs.SetString ("mapedit", "true");
						Application.LoadLevel ("LevelEditor");
				} else if (Input.GetKey (KeyCode.Escape)) {
						Application.Quit ();		
				}
		}
}
