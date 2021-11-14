using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyMeleeDamage : MonoBehaviour {

      //public Animator anim;
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
