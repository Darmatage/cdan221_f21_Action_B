using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp_Inventory: MonoBehaviour {

	public GameInventory CookBook;
	public string ItemName = "item1";

	public bool isHotPopper = false;
	public int dmgHotPopper = 50;

	void Awake(){
		if (GameObject.FindWithTag("GameHandler") != null) {
			CookBook = GameObject.FindWithTag("GameHandler").GetComponent<GameInventory>();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			//Debug.Log("You found an" + ItemName);
			GetComponent<Collider2D>().enabled = false;
			CookBook.InventoryAdd(ItemName);
			//CookBook.removeObjectFromLevel(ItemName);
			//Destroy(gameObject);
		}
			
			//check for player
		if (other.gameObject.tag == "Player"){
			//Debug.Log("You found an" + ItemName);
			GetComponent<Collider2D>().enabled = false;
			CookBook.InventoryAdd(ItemName);
			//CookBook.removeObjectFromLevel(ItemName);
			//Destroy(gameObject);
		}	
		
			//check for enemies
		if (other.gameObject.tag == "enemyShooter"){
			//Debug.Log("enemyShooter hit a pickup"); 
			if (isHotPopper==true){
				other.gameObject.GetComponent<EnemyMeleeDamage>().TakeDamage(dmgHotPopper); 
				//Debug.Log("The pickup was a jalepenos and did damage:" + dmgHotPopper);
				Destroy(gameObject);
			}
			
		}
	}

}
