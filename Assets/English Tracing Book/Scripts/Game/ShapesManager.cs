using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class ShapesManager : MonoBehaviour
{
	
	public List<Shape> shapes = new List<Shape> ();
	public string shapeLabel = "Shape";
    public string shapePrefix = "Shape";	
	public string sceneName = "";
	[HideInInspector]
	public int lastSelectedGroup;

	public static string shapesManagerReference = "";
		
	
	
	public static Hashtable initFlags = new Hashtable ();

	void Awake ()
	{
		if (initFlags.Contains (gameObject.name)) {
			Destroy (gameObject);
		} else {
			initFlags.Add (gameObject.name, true);
			DontDestroyOnLoad (gameObject);
			lastSelectedGroup = 0;
		}
	}

	[System.Serializable]
	public class Shape
	{
		public bool showContents = true;
		public GameObject gamePrefab;
		public Sprite picture;
	}
}
