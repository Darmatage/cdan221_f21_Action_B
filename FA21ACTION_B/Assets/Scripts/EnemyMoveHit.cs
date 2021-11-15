using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyMoveHit : MonoBehaviour {

    //public Animator anim;
    public float speed = 4f;
    private Transform target;
    public int damage = 10;

    public int EnemyLives = 3;
    private Renderer rend;
    private GameHandler gameHandler;

    public float attackRange = 10;
    public bool isAttacking = false;

    void Start () {
        rend = GetComponentInChildren<Renderer> ();

        if (GameObject.FindGameObjectWithTag ("Player") != null) {
            target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
        }

        if (GameObject.FindWithTag ("GameHandler") != null) {
            gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
        }
    }

	void Update () {
        float DistToPlayer = Vector3.Distance(transform.position, target.position);
		
		//check for frozen by food attack
		if (GetComponent<EnemyMeleeDamage>().enemyFrozen==false){
            if ((target != null) && (DistToPlayer <= attackRange)){
				transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
				if (isAttacking == false) {
					//anim.SetBool("Walk", true);
                }
                //else  { anim.SetBool("Walk", false);}
            } 
            //else { anim.SetBool("Walk", false);}
		}
    }

    public void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player") {
			//check for frozen by food attack
			if (GetComponent<EnemyMeleeDamage>().enemyFrozen==false){
				isAttacking = true;
                //anim.SetBool("Attack", true);
                gameHandler.playerGetHit(damage);
                //rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
                //StartCoroutine(HitEnemy());
            }
		}
    }

    public void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.tag == "Player") {
            isAttacking = false;
            //anim.SetBool("Attack", false);
        }
    }

    IEnumerator HitEnemy(){
        yield return new WaitForSeconds(0.5f);
        rend.material.color = Color.white;
    }

       //DISPLAY the range of enemy's attack when selected in the Editor
    void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}