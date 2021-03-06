﻿using UnityEngine;
using System.Collections;

public class EnemyController : EnemyStats {

	//Daan

	public GameObject bullet;
	public Transform bulletSpawnPoint;
	public GameObject HPBarPrefab;
	public AudioClip gunSound;

	protected bool alive;
	protected bool inRange;
	protected Vector2 pos;
	protected Vector3 player;
	protected GameObject healthBar;
	protected Vector3 barPos;
	
	public bool canShoot;
	public string type;
	//types (no caps):
	//moving
	//stationary
	//chasing

	private float shootTimer;

	protected virtual void Start () {
		shootTimer = 0f;
		alive = true;
		pos = new Vector2(this.transform.position.x, this.transform.position.y);
		player = GameObject.FindGameObjectWithTag("PlayerController").transform.position;

		barPos.x = this.transform.position.x;
		barPos.y = this.transform.position.y + 1f;
		barPos.z = - 0.2f;

		healthBar = Instantiate(HPBarPrefab, barPos, Quaternion.identity) as GameObject;
		health += 10f * (PlayerStats.level-1);
		speed += 0.5f * (PlayerStats.level-1);
		shootCooldown -= 0.01f * (PlayerStats.level-1);
		healthBar.GetComponent<Healthbar>().Init(2.6f, 0.45f, true, this.transform.position.x, this.transform.position.y);
		healthBar.GetComponent<Healthbar>().InitHealthText(this.health);
	}
	
	protected virtual void Update () {
		if(DC.paused != true){
				player = GameObject.FindGameObjectWithTag("PlayerController").transform.position;
				Vector3 dir = player - this.transform.position;
				dir.z = this.transform.rotation.z;
				float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

			barPos.x = this.transform.position.x - healthBar.GetComponent<Healthbar>().GetXOffset();
			barPos.y = this.transform.position.y + 1f;

			healthBar.transform.position = barPos;
			if(canShoot && inRange){
				shootCooldown = 0.35f + (PlayerStats.level*0.01f);
				shootTimer -= shootCooldown;
				if(shootTimer <= 0){
					Shoot();
				}
			}
			if(DC.isOutOfBounds(this.gameObject)){
				DestroyMe(1);
			}
		}
	}
	private void Shoot(){
		Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
		shootTimer = Random.Range(10, 14);
		audio.PlayOneShot(gunSound);
		audio.pitch = Random.Range (1f, 1.5f);
	}
	
	public void LoseHealth(float _dmg, bool _crit){
		health -= _dmg;
		if(health <= 0)
		{
			DestroyMe();
			GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerStats>().AddGold(gold);
			GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerStats>().AddExp(exp);
		}

		healthBar.GetComponent<Healthbar>().UpdateBar(this.health, _dmg, _crit);
	}

	public void setRangeState(bool state){
		inRange = state;
	}

	public string GetEnemType(){
		return this.type;
	}

	public void DestroyMe(){
		Destroy(this.gameObject);
		Destroy(healthBar.gameObject);
		Destroy(healthBar.GetComponent<Healthbar>().GetText());
	}

	public void DestroyMe(float _time){
		Destroy(this.gameObject, _time);
		Destroy(healthBar.gameObject, _time);
		Destroy(healthBar.GetComponent<Healthbar>().GetText(), _time);
	}
}
