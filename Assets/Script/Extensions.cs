using UnityEngine;

public static partial class Extensions
{
	public static void SetInactive(this Component component)
	{
		component.gameObject.SetActive(false);
	}

	public static void SetActive(this Component component)
	{
		component.gameObject.SetActive(true);
	}

	public static void SetInactive(this GameObject gameObject)
	{
		gameObject.SetActive(false);
	}

	public static void SetActive(this GameObject gameObject)
	{
		gameObject.SetActive(true);
	}
}
