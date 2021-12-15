using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyPatrolHit : MonoBehaviour {

       public float speed = 2f;
       public Rigidbody2D rb;
       public LayerMask groundLayers;
       public Transform groundCheck;
       bool isFacingRight = true;
       RaycastHit2D hitGround;
	   RaycastHit2D hitWall;

       public int damage = 10;
       private GameHandler gameHandler;

       void Start(){
              rb = GetComponent<Rigidbody2D>();
              //anim.SetBool("Walk", true);
              if (GameObject.FindWithTag ("GameHandler") != null) {
                  gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
              }
       }

       void Update(){
              hitGround = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);
       }

       void FixedUpdate(){
              if (hitGround.collider != false){
				 //Debug.Log("Ground is there");
                     if (isFacingRight){
                            rb.velocity = new Vector2(speed, rb.velocity.y);
                     } else {
                            rb.velocity = new Vector2(-speed, rb.velocity.y);
                     }
              } else {
                     isFacingRight = !isFacingRight;
                     transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
					//Debug.Log("Change Direction"); 
              }
       }

	//public void OnCollisionEnter2D(Collision2D other){
    //          if (other.gameObject.tag == "Player") {
                     //anim.SetBool("Attack", false);
    //                 gameHandlerObj.playerGetHit(damage);
                     //rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
                     //StartCoroutine(HitEnemy());
    //          }
    //   }

    //   public void OnCollisionExit2D(Collision2D other){
    //          if (other.gameObject.tag == "Player") {
                     //anim.SetBool("Attack", true);
    //          }
    //   }
}