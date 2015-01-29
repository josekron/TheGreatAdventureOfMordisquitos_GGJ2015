using UnityEngine; 
using System.Collections; 
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text; 

public class MapsLoader: MonoBehaviour { 

} 

public class Map 
{ 
	public Field[] fields;
	public int fieldsC;
	public float dieAt;

	public Map() {
		fields = new Field[256];
	}

	public void AddField (Field f){
		fields [fieldsC] = f;
		fieldsC++;
	}

	public void BeforeSerialize(){
		Field[] newFields = new Field[fieldsC];
		for (int i = 0; i < fieldsC; i++) {
			newFields[i] = fields[i];
		}
		fields = newFields;
		int max = 0;
		for (int i = 0; i < fields.Length; i++){
			if(fields[i].y < max){
				max = fields[i].y;
			}
		}
		max -= 2;
		dieAt = max;
	}

	public struct Field
	{ 
		public string prefabName;
		public int width; 
		public int height;
		public int x;
		public int y;
	} 
}

public static class MapUtils {

	static string _FileLocation, _FileName; 
	static Map myData; 
	static string _data;

	private static void Setup(){
		_FileLocation=Application.dataPath + "\\" + "maps"; 
		myData=new Map();
	}

	public static Map GetMap(string mapname) {
		_FileName = mapname + ".xml";
		Setup ();
		LoadXML();
		if(_data.ToString() != ""){
			myData = (Map)DeserializeMap(_data); 
			return myData; 
		}else{
			return null;
		}
	}

	public static void SetMap(string mapname, Map m){
		_FileName = mapname + ".xml";
		m.BeforeSerialize ();
		_data = SerializeMap(m); 
		CreateXML();
		Debug.Log(_data); 
	}

	/* The following metods came from the referenced URL */ 
	static string UTF8ByteArrayToString(byte[] characters) 
	{      
		UTF8Encoding encoding = new UTF8Encoding(); 
		string constructedString = encoding.GetString(characters); 
		return (constructedString); 
	} 
	
	static byte[] StringToUTF8ByteArray(string pXmlString) 
	{ 
		UTF8Encoding encoding = new UTF8Encoding(); 
		byte[] byteArray = encoding.GetBytes(pXmlString); 
		return byteArray; 
	} 
	
	// Here we serialize our UserData object of myData 
	static string SerializeMap(object pObject) 
	{ 
		string XmlizedString = null; 
		MemoryStream memoryStream = new MemoryStream(); 
		XmlSerializer xs = new XmlSerializer(typeof(Map)); 
		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8); 
		xs.Serialize(xmlTextWriter, pObject); 
		memoryStream = (MemoryStream)xmlTextWriter.BaseStream; 
		XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray()); 
		return XmlizedString; 
	} 
	
	// Here we deserialize it back into its original form 
	static object DeserializeMap(string pXmlizedString) 
	{ 
		XmlSerializer xs = new XmlSerializer(typeof(Map)); 
		MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString)); 
		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8); 
		return xs.Deserialize(memoryStream); 
	} 
	
	// Finally our save and load methods for the file itself 
	static void CreateXML() 
	{ 
		StreamWriter writer; 
		FileInfo t = new FileInfo(_FileLocation+"\\"+ _FileName); 
		if(!t.Exists) 
		{ 
			writer = t.CreateText(); 
		} 
		else 
		{ 
			t.Delete(); 
			writer = t.CreateText(); 
		} 
		writer.Write(_data); 
		writer.Close(); 
		Debug.Log("File written."); 
	} 
	
	static void LoadXML() 
	{ 
		StreamReader r = File.OpenText(_FileLocation+"\\"+ _FileName); 
		string _info = r.ReadToEnd(); 
		r.Close(); 
		_data=_info; 
		Debug.Log("File Read"); 
	} 
}