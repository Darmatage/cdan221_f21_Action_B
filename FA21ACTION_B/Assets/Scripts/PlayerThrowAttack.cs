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
                  ThrowFood();
               // anim.SetTrigger("Throw");
               // throwSFX.Play();
            }
	}
	
	
    public void LoadFood(string attack){
        if (haveFood==false){
			if (attack=="spicypopper"){
				loadedFood = Instantiate(spicyAttack, weaponPoint.position, Quaternion.identity);
				loadedFood.transform.SetParent(weaponPoint);
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
		Rigidbody rb = loadedFood.GetComponent<Rigidbody>();
		rb.AddForce(transform.forward * thrust); // meant to be in fixed update...? need impulse?
		loadedFood.transform.DetachChildren();
		//loadedFood.transform.parent = null;

		haveFood = false;
    }
}
 