﻿using UnityEngine;
using System.Collections;

public enum Mouse_Button
{
	Left = 0,
	Right = 1,
	Middle = 2
}

public static class InputTracker 
{
	#region Click detection
	
	public static bool Has_Clicked(Mouse_Button button)
	{
		return Input.GetMouseButtonDown((int)button);
	}

	public static bool Is_Clicking(Mouse_Button button)
	{
		return Input.GetMouseButton((int)button);
	}

	public static bool Has_Released_Click(Mouse_Button button)
	{
		return Input.GetMouseButtonUp((int)button);
	}
	
	#endregion

	#region Object detection

	public static GameObject Get_Object_Under_Mouse(string layerName = "")
	{
		Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 posicion = new Vector2(wp.x, wp.y);
		Collider2D col = null;

		col = (layerName == "") ? (Physics2D.OverlapPoint(posicion)) : (Physics2D.OverlapPoint(posicion, 1<<LayerMask.NameToLayer(layerName)));

		if(col != null)
		{
			return col.gameObject;
		}

		return null;
	}

	#endregion

	#region Key detection

	public static bool Has_Pressed_Key(KeyCode key)
	{
		return Input.GetKeyDown(key);
	}

	public static bool Is_Pressing_Key(KeyCode key)
	{
		return Input.GetKey(key);
	}

	public static bool Has_Released_Key(KeyCode key)
	{
		return Input.GetKeyUp(key);
	}

	#endregion
}
