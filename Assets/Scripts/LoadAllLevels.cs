using UnityEngine;
using System.Collections;
using System.IO;

public class LoadAllLevels : MonoBehaviour
{
		private DirectoryInfo directory;
		private string path;
		private GameObject[] pointList;
		public GameObject door;
		// Use this for initialization
		void Start ()
		{
				path = Application.dataPath + Path.DirectorySeparatorChar + "maps" + Path.DirectorySeparatorChar;
				directory = new DirectoryInfo (path);
				//FileInfo[] files = 
				string [] files=Directory.GetFiles (path, "*.xml");
				//Return all objects with the "Point" tah
				pointList = GameObject.FindGameObjectsWithTag ("Point");
				for (int i=0; i<pointList.Length; i++) {
						if (i < files.Length) {			
								if (files [i] != null) {
										Instantiate (door, pointList [i].transform.position, Quaternion.identity);
										pointList [i].GetComponent<InfoMap> ().setName (files [i]);
					pointList[i].GetComponent<InfoMap>().setInstanced(true);
										Debug.Log (files [i]);
								}
						}
				}
		}
		
		// Update is called once per frame
		void Update ()
		{

		}
}
