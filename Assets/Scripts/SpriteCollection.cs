using UnityEngine;
using System.Collections;

public class SpriteCollection{

	private static Sprite[] sprites;
	private static string[] names;

	public static void Init(string spritesheet){
		sprites = Resources.LoadAll<Sprite>(spritesheet);
		names = new string[sprites.Length];

		for(var i = 0; i < names.Length; i++)
		{
			names[i] = sprites[i].name;
		}
	}
	public static Sprite GetSprite(string name)
	{
		return sprites[System.Array.IndexOf(names, name)];
	}
}
