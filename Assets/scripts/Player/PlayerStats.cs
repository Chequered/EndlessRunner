﻿using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public static int level;

	public GameObject prefab_healthBar;

	public float gold;
	public float health;
	public float exp;

	private float expTillLevel;
	private GameObject healthBar;

	void Start () {
		health = 100;
		gold = 0;
		exp = 0;
		level = 1;
		expTillLevel = 500;
		Vector3 HPPos;
		HPPos.x = 0;
		HPPos.y = -8;
		HPPos.z = -0.1f;

		healthBar = GameObject.Instantiate(prefab_healthBar, HPPos, Quaternion.identity) as GameObject;
		healthBar.GetComponent<Healthbar>().Init(15f, 1f, false, HPPos.x, HPPos.y);
		healthBar.GetComponent<Healthbar>().InitHealthText(this.health);
		healthBar.tag = "PlayerHealthBar";
		healthBar.GetComponent<Healthbar>().SetTextTag("PlayerHealthText");
	}

	public void LoseHealth(float _dmg)
	{
		health -= _dmg;
		healthBar.GetComponent<Healthbar>().UpdateBar(this.health, _dmg, false);

		if(health <= 0)
		{
			Death();
		}
	}

	void Death()
	{
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().ResetStage ();
	}

	public void AddGold(float _gold)
	{
		gold += _gold;
	}

	public float GetGold(){
		return gold;
	}

	public float GetLevel(){
		return level;
	}

	public float GetXP(){
		return exp;
	}

	public float GetXPTillLevel(){
		return expTillLevel;
	}

	public void AddExp(float _exp)
	{
		exp += _exp;
		if (expTillLevel <= exp) 
		{
			expTillLevel += expTillLevel * 0.75f;
			level += 1;
			exp = 0;
		}
	}
}
