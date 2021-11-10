using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp_Inventory: MonoBehaviour {

      public GameInventory CookBook;
      public string ItemName = "item1";

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
      }
}
