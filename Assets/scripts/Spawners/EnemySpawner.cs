﻿using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	//Daan

	private bool enemySpawnable;
	private float spawnTimer;
	private Vector2 spawnPoint;

	private void Start(){
		enemySpawnable = true;
		spawnTimer = 0f;
	}

	private void Update () {
		if(!DC.paused){
			spawnTimer -= 0.1f;
			if(enemySpawnable && spawnTimer <= 0){
				SpawnEnemy();
			}
		}
	}

	private float getRandomX(){
		float r =  Random.Range(DC.LEVEL_X_MIN, DC.LEVEL_X_MAX);
		return r;
	}

	private float getRandomY(){
		float r =  Random.Range(DC.LEVEL_Y_MIN, DC.LEVEL_Y_MAX);
		return r;
	}

	private void SpawnEnemy(){
		spawnTimer = 12.5f + PlayerStats.level*3;
		for(int i = 0; i < PlayerStats.level; i++){
			spawnPoint.x = getRandomX();
			spawnPoint.y = getRandomY();
			GameObject enem = Instantiate(DC.enemies[DC.GetRandomRange(DC.enemies.Length)], spawnPoint, Quaternion.identity) as GameObject;
			enem.transform.parent = this.transform;
			GameController.enemies.Add(enem);
			enemySpawnable = true;
			if(enem.GetComponent<EnemyController>().GetEnemType().Equals("stationary")){
				enem.GetComponent<StationaryEnemy>().SetGoToPos(DC.LEVEL_Y_MIN - Random.Range (12, 18));
			}
		}
	}
}
