using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyMeleeDamage : MonoBehaviour {

      //public Animator anim;
	   public bool enemyFrozen = false;
       public GameObject healthLoot;
       public int maxHealth = 10;
       public int currentHealth;

       void Start(){
              currentHealth = maxHealth;
       }

       public void TakeDamage(int damage){
              currentHealth -= damage;
              //anim.SetTrigger ("Hurt");
              if (currentHealth <= 0){
                     Die();
              }
       }
	   
	   public void ParalizeEnemy(string pType){
		   if (pType == "spicy"){
			   //anim.setBool("ParalizedSpicy", true);
			   enemyFrozen = true;
			   //turn off enemy movement: have the script look to this script 
			   
		   }
		   
		   else if (pType == "freeze"){
			   //anim.setBool("ParalizedFrozen", true);
			   enemyFrozen = true;
			   //turn off enemy movement
		   }
		   
		   else if (pType == "full"){
				//anim.setBool("ParalizedFull", true);
				enemyFrozen = true;
				//turn off enemy movement
		   }
	   }

       void Die(){
              Instantiate (healthLoot, transform.position, Quaternion.identity);
              //anim.SetBool ("isDead", true);
              GetComponent<Collider2D>().enabled = false;
              this.enabled = false;
              StartCoroutine(Death());
       }

       IEnumerator Death(){
              yield return new WaitForSeconds(0.5f);
              Debug.Log("You Killed a baddie. You deserve loot!");
              Destroy(gameObject);
       }

}
