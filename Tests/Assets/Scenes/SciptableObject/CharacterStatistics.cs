using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Character", menuName
= "Character Creation/Player Units")]
public class CharacterStatistics : ScriptableObject
{
	public string characterName;
	public int attack;
	public int defense;
	public int speed;
	public int maxHealth;
	public Color color;

	public void RandomizeStats()
	{
		attack = Random.Range(1, 20);
		defense = Random.Range(1, 20);
		speed = Random.Range(1, 20);
		maxHealth = Random.Range(1, 20);
		color = Random.ColorHSV();
	}
}

