using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

      public Animator anim;
      public Rigidbody2D rb;
      public float jumpForce = 20f;
      public Transform feet;
      public LayerMask groundLayer;
      public LayerMask enemyLayer;
      public bool isAlive = true;
      //public AudioSource JumpSFX;

      void Start(){
            anim = gameObject.GetComponentInChildren<Animator>();
            rb = GetComponent<Rigidbody2D>();
      }

     void Update() {
           if ((Input.GetButtonDown("Jump")) && (IsGrounded()) && (isAlive==true)) {
				Jump();
                anim.SetTrigger("Jump");
               // JumpSFX.Play();
            }
      }

      public void Jump() {
            rb.velocity = Vector2.up * jumpForce;
            //Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
            //rb.velocity = movement;
      }

      public bool IsGrounded() {
            Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.1f, groundLayer);
            Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, 0.1f, enemyLayer);
           if ((groundCheck != null) || (enemyCheck != null)) {
                  return true;
                  Debug.Log("I can jump now!");
			} else {
				Debug.Log("no can jump :("); 
				return false;
			}
            //return false;
      }
}