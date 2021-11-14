using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowAttack : MonoBehaviour{
	
	//public Animator anim;
	//public AudioSource throwSFX;
	public Transform weaponPoint;
	public bool haveFood = false; 
	
	public GameObject loadedFood;
	public float thrust = 100f;
	
	public GameObject spicyAttack;
	//public GameObject freezeAttack;
	//public GameObject fullAttack;		
	
	void Update(){
		if (Input.GetKeyDown("q")){
			if (haveFood==true){
                  ThrowFood();
               // anim.SetTrigger("Throw");
               // throwSFX.Play();
			}
			else {Debug.Log("You don't have anything ready to throw");}
        }
	}
	
	
    public void LoadFood(string attack){
        if (haveFood==false){
			if (attack=="spicypopper"){
				loadedFood = Instantiate(spicyAttack, weaponPoint.position, Quaternion.identity);
				loadedFood.transform.SetParent(weaponPoint);
				DisableThrowComponents(loadedFood);
				haveFood = true;
			}
			//else if(attack=="icecream"){
			//	loadedFood = Instantiate(freezeAttack, weaponPoint.position, Quaternion.identity);
			//  loadedFood.transform.SetParent(weaponPoint);
			//  haveFood = true;
			//}
			//else if(attack=="meatball"){
			//	loadedFood = Instantiate(fullAttack, weaponPoint.position, Quaternion.identity);
			//  loadedFood.transform.SetParent(weaponPoint);
			//  haveFood = true;
			//}
			
		}
    }

    public void ThrowFood(){
        //add listener to throw food in current direction player is facing 
		EnableThrowComponents(loadedFood);
		Rigidbody2D rb = loadedFood.GetComponent<Rigidbody2D>();
		loadedFood.transform.parent = null;   //loadedFood.transform.DetachChildren();
		rb.AddForce(transform.forward * thrust); // meant to be in fixed update...? need impulse?
		
		haveFood = false;
    }
	
	//turn off these components when object is held by player
	public void DisableThrowComponents(GameObject attack){
		attack.GetComponent<PickUp>().enabled = false;
		attack.GetComponent<PickUp_Inventory>().enabled = false;
		attack.GetComponent<BoxCollider2D>().enabled = false;
		attack.GetComponent<Rigidbody2D>().simulated = false;  // or .isKinematic=true (for 3d) 
		attack.GetComponent<PickUp_Projectile>().enabled = false;
	}
	
	//turn on these components when object is thrown by player
	public void EnableThrowComponents(GameObject attack){
		attack.GetComponent<PickUp>().enabled = true;
		attack.GetComponent<PickUp_Inventory>().enabled = true;
		attack.GetComponent<BoxCollider2D>().enabled = true;
		attack.GetComponent<Rigidbody2D>().simulated = true;
		attack.GetComponent<PickUp_Projectile>().enabled = true;
	}
	
}
 