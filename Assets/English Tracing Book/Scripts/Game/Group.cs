using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Group : MonoBehaviour
{
		public int Index;

		public static GameObject CreateGroup (GameObject levelsGroupPrefab, Transform groupsParent, int groupIndex, int columnsPerGroup)
		{
				
				GameObject levelsGroup = Instantiate (levelsGroupPrefab, Vector3.zero, Quaternion.identity) as GameObject;
				levelsGroup.transform.SetParent (groupsParent);
				levelsGroup.name = "Group-" + CommonUtil.IntToString(groupIndex + 1);
				levelsGroup.transform.localScale = Vector3.one;
				levelsGroup.GetComponent<RectTransform> ().offsetMax = Vector2.zero;
				levelsGroup.GetComponent<RectTransform> ().offsetMin = Vector2.zero;
				levelsGroup.GetComponent<Group> ().Index = groupIndex;
				levelsGroup.GetComponent<GridLayoutGroup> ().constraint = GridLayoutGroup.Constraint.FixedColumnCount;
				levelsGroup.GetComponent<GridLayoutGroup> ().constraintCount = columnsPerGroup;
				return levelsGroup;
		}
}
