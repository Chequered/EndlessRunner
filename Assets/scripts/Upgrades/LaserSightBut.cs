﻿using UnityEngine;
using System.Collections;

public class LaserSightBut : MonoBehaviour {
	void OnMouseDown () {
		if(PlayerStats.statPoints >= 1)
		{
			PlayerStats.statPoints -= 1;
			GameObject.FindGameObjectWithTag("Gun").GetComponent<GunSort>().laserSight = true;
		}
	}
}
