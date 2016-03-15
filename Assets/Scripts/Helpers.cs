using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Helpers
{
	public static bool Is_Index_Correct(int index, ICollection collection)
	{
		return (index >= 0 && index < collection.Count);
	}
}
