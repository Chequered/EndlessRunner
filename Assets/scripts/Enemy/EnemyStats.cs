﻿using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {
	protected const float MAX_HEALTH = 100f;
	protected float health = 150f;
	protected float gold = 250f;
	protected float exp = 100f;
	protected float speed = Random.Range(1f, 1.2f);
	protected float shootCooldown = 0.05f;
}
