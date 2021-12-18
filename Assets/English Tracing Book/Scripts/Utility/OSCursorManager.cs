using UnityEngine;
using System.Collections;


[DisallowMultipleComponent]
public class OSCursorManager : MonoBehaviour
{
	
	public CursorStatus status = CursorStatus.ENABLED;

	
	void Start ()
	{
		#if (!(UNITY_ANDROID || UNITY_IPHONE) || UNITY_EDITOR)
			if (status == CursorStatus.ENABLED) {
				Cursor.visible = true;
			} else if (status == CursorStatus.DISABLED) {
				Cursor.visible = false;
			}
		#endif
	}

	public enum CursorStatus
	{
		ENABLED,
		DISABLED
	};
}
