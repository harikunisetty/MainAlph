/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class DataManager
{
	
	public static void SaveShapeStars (int ID, TableShape.StarsNumber stars,ShapesManager shapesManager)
	{
		PlayerPrefs.SetInt (GetStarsStrKey(ID,shapesManager), CommonUtil.ShapeStarsNumberEnumToIntNumber (stars));
		PlayerPrefs.Save ();
	}

	
	public static TableShape.StarsNumber GetShapeStars (int ID,ShapesManager shapesManager)
	{
		TableShape.StarsNumber stars = TableShape.StarsNumber.ZERO;
		string key = GetStarsStrKey(ID,shapesManager);
		if (PlayerPrefs.HasKey (key)) {
			stars = CommonUtil.IntNumberToShapeStarsNumberEnum (PlayerPrefs.GetInt (key));
		}
		return stars;
	}

	
	public static void SaveShapePathColor (int shapeID,int compundID, int from, int to, Color color,ShapesManager shapesManager)
	{
		string key = GetPathStrKey(shapeID,compundID,from,to,shapesManager);
		string value = color.r + "," + color.g + "," + color.b + "," + color.a;

		PlayerPrefs.SetString (key, value);
		PlayerPrefs.Save ();
	}


	public static Color GetShapePathColor (int shapeID, int compundID,int from, int to,ShapesManager shapesManager)
	{
		Color color = Color.white;
		string key = GetPathStrKey(shapeID,compundID,from,to,shapesManager);

		if (PlayerPrefs.HasKey (key)) {
			color = CommonUtil.StringRGBAToColor (PlayerPrefs.GetString (key));
		}
	
		return color;
	}


	
	public static string GetPathStrKey(int shapeID, int compundID,int from, int to,ShapesManager shapesManager){
		return shapesManager.shapePrefix + "-Shape-" + shapeID + "-Compound-" + compundID + "-Path-" + from + "-" + to;
	}


	public static string GetLockedStrKey(int ID,ShapesManager shapesManager){
		return shapesManager.shapePrefix + "-Shape-" + ID + "-isLocked";
	}

	
	public static string GetStarsStrKey(int ID,ShapesManager shapesManager){
		return shapesManager.shapePrefix + "-Shape-" + ID + "-Stars";
	}

	
	public static bool IsShapeLocked (int ID,ShapesManager shapesManager)
	{
		bool isLocked = true;
		string key = GetLockedStrKey(ID,shapesManager);
		if (PlayerPrefs.HasKey (key)) {
			isLocked = CommonUtil.ZeroOneToTrueFalseBool (PlayerPrefs.GetInt (key));
		}
		return isLocked;
	}

	
	public static void SaveShapeLockedStatus (int ID, bool isLocked,ShapesManager shapesManager)
	{
		PlayerPrefs.SetInt (GetLockedStrKey(ID,shapesManager), CommonUtil.TrueFalseBoolToZeroOne (isLocked));
		PlayerPrefs.Save ();
	}

	
	public static int GetCollectedStars(ShapesManager shapesManager){

		int ID = 0;
		int cs = 0;
		for (int i = 0; i < shapesManager.shapes.Count; i++) {
			ID = (i + 1);
			TableShape.StarsNumber sn = GetShapeStars (ID, shapesManager);
			if (sn == TableShape.StarsNumber.ONE) {
				cs+=1;
			} else if (sn == TableShape.StarsNumber.TWO) {
				cs+=2;
			} else if (sn == TableShape.StarsNumber.THREE) {
				cs+=3;
			}
		}
		return cs;
	}

	
	public static void ResetGame ()
	{
		PlayerPrefs.DeleteAll ();
	}
}*/