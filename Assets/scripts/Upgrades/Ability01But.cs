﻿using UnityEngine;
using System.Collections;

public class Ability01But : MonoBehaviour {
	void OnMouseDown()
	{
		if(PlayerStats.statPoints != 0)
		{
			PlayerStats.statPoints -= 1;
			GameObject.FindGameObjectWithTag("AbilityController").GetComponent<AbilityController>().UnlockAbility(0);
			DC.setTexture(this.gameObject, DC.soldTexture);
		}
	}
}
