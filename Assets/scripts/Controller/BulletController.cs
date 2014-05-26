﻿using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	public float destroyTime;
	protected float speed;
	protected float dmg;
	protected bool piercing;
	protected int critChance;
	void Start () 
	{
		Destroy(gameObject, destroyTime);
	}

	public void setStats(float _speed, float _dmg, bool _piercing,int _critChance/*, Texture _bullet*/)
	{
		speed 	= _speed;
		dmg 	= _dmg;
		piercing = _piercing;
		critChance = _critChance;
		//this.renderer.material.SetTexture
	}
	protected virtual void Update () 
	{
		if(DC.paused != true)
		{
			this.transform.Translate (new Vector2(0,1) * speed * Time.deltaTime);
<<<<<<< HEAD
			bool fireTrail = GameObject.FindGameObjectWithTag("Gun").GetComponent<GunSort>().fireTrail;
			if(fireTrail)
			{
				//instantiate fireTrail
			}
=======
>>>>>>> 68fa94deee70146a95b5cccee90969ceed552fe3
		}
	}
	protected virtual void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag == "Enemy")
		{
			int criticalStrike = Random.Range(0,101);

			if(criticalStrike > critChance){
				int extradmg = (int)Random.Range(dmg*0.1f,dmg*0.5f);
				other.gameObject.GetComponent<EnemyController>().LoseHealth(dmg + extradmg, false);
			} else {
				int extradmg = (int)Random.Range(dmg*0.10f,dmg*0.20f);
				other.gameObject.GetComponent<EnemyController>().LoseHealth(dmg + extradmg, true);
			}
			if(!piercing)
			{
				Destroy(this.gameObject);
			}
		}
<<<<<<< HEAD

=======
>>>>>>> 68fa94deee70146a95b5cccee90969ceed552fe3
		if(other.transform.tag == "Barrier") 
		{
			Destroy(this.gameObject);
		}

	}
}
