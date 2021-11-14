using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Projectile : MonoBehaviour{
	public float thrust = 10f;
    private Rigidbody2D rb2D;
	   
	public LayerMask enemies;
	public string paralysisType = "spicy";
	
    public bool oneTimeThrow = true;

	//thrust for throwing
    void FixedUpdate (){
        if (oneTimeThrow){
			rb2D.GetComponent<Rigidbody2D>();
            rb2D.AddForce(thrust, 0, 0, ForceMode2D.Impulse);
			//GetComponent<Rigidbody2D>().AddForce(transform.forward * thrust, ForceMode2D.Impulse);
			//GetComponent<Rigidbody2D>().AddForce(transform.up * thrust * 0.2f, ForceMode2D.Impulse);
            oneTimeThrow = false;
            }
    }
	
	//collide with enemy
	public void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.layer == enemies){
			other.transform.GetComponent<EnemyMeleeDamage>().ParalizeEnemy(paralysisType);
		}
	}

}
