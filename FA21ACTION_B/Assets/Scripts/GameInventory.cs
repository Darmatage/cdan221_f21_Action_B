using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameInventory : MonoBehaviour {

    //CookBook display and Buttons:
    public GameObject CookBookMenu;
	public GameObject ButtonHealingPie;
	public GameObject ButtonSpicyAttack;
	public GameObject ButtonTaco;
	public GameObject ButtonSushi;
	//public GameObject ButtonFreezeAttack;
	//public GameObject ButtonTooFullAttack;
	//public GameObject ButtonLordDish1;
	//public GameObject ButtonLordDish2;
	//public GameObject ButtonLordDish3;
	//public GameObject ButtonLordDish4;
	//public GameObject ButtonFinalDish;
	
	
	//5 Inventory Items (Bools, Number, Images, Text):
	
	//item bools
	private static bool healIng1bool = false; // flour
	private static bool healIng2bool = false; // apples
	private static bool healIng3bool = false; // cinnamon
	private static bool healbool = false; 	// pie
	  
	private static bool spicyIng1bool = false; // jalapenos
	private static bool spicyIng2bool = false; // hotsauce
	private static bool spicybool = false; 	// hotpopper dish

	private static bool tacoIng1bool = false; // tortilla
	private static bool tacoIng2bool = false; // lettuce
	private static bool tacoIng3bool = false; // tomato
	private static bool tacobool = false; 	 // taco
	  
	private static bool sushiIng1bool = false; // fish
	private static bool sushiIng2bool = false; // seaweed
	private static bool sushiIng3bool = false; // rice
	private static bool sushibool = false; 	 // sushi
	  
	//private static bool icebool = false; 		// ice 
	//private static bool milkbool = false; 	// milk
	//private static bool sugarbool = false; 	// sugar 
	//private static bool freezebool = false; 	// icecream dish
	
	//private static bool meatbool = false; 	// meat
	//private static bool breadbool = false; 	// breadcrumbs
	//private static bool eggbool = false; 	 	// egg
	//private static bool onionbool = false; 	// onion
	//private static bool healbool = false; 	// meatballs dish

	//amount number ints
	private static int healIng1Num = 0;
	private static int healIng2Num = 0;
	private static int healIng3Num = 0;
	private static int healNum = 0;
	  
	private static int spicyIng1Num = 0;
	private static int spicyIng2Num = 0;
	private static int spicyNum = 0;

	private static int tacoIng1Num = 0;
	private static int tacoIng2Num = 0;
	private static int tacoIng3Num = 0;
	private static int tacoNum = 0;

	private static int sushiIng1Num = 0;
	private static int sushiIng2Num = 0;
	private static int sushiIng3Num = 0;
	private static int sushiNum = 0;
	  
	//image icons and buttons
	public GameObject healIng1image;
	public GameObject healIng2image;
	public GameObject healIng3image;
	public GameObject healButton;
	  
	public GameObject spicyIng1image;
	public GameObject spicyIng2image;
	public GameObject spicyButton;

	public GameObject tacoIng1image;
	public GameObject tacoIng2image;
	public GameObject tacoIng3image;
	public GameObject tacoButton;

	public GameObject sushiIng1image;
	public GameObject sushiIng2image;
	public GameObject sushiIng3image;
	public GameObject sushiButton;

	//amount texts
	public GameObject healIng1Txt;
	public GameObject healIng2Txt;
	public GameObject healIng3Txt;
	public GameObject healTxt;
	  
	public GameObject spicyIng1Txt;
	public GameObject spicyIng2Txt;	  
	public GameObject spicyTxt;

	public GameObject tacoIng1Txt;
	public GameObject tacoIng2Txt;
	public GameObject tacoIng3Txt;
	public GameObject tacoTxt; 

	public GameObject sushiIng1Txt;
	public GameObject sushiIng2Txt;
	public GameObject sushiIng3Txt;
	public GameObject sushiTxt;

	public GameHandler gameHandler;
	public GameObject thePlayer;
	public int healingAmt = 10;

	//Don Chicote Dialogue
	private NPCDialogueChickenChief DonChicote;



	void Awake(){
		if (GameObject.FindWithTag("DonChicote")!=null){
			DonChicote = GameObject.FindWithTag("DonChicote").GetComponent<NPCDialogueChickenChief>();
		}		
	}

    public void Start(){
		InventoryDisplay();	  
        CookBookMenu.SetActive(false);
		ButtonHealingPie.SetActive(false);
		ButtonSpicyAttack.SetActive(false);
		ButtonTaco.SetActive(false);
		ButtonSushi.SetActive(false);


		//gameHandler = transform.GetComponent<GameHandler>();
		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			thePlayer = GameObject.FindGameObjectWithTag ("Player");
		}
    }

	void Update(){
		if ((healIng1Num >= 1) && (healIng2Num >= 1) && (healIng3Num >= 1)){
			ButtonHealingPie.SetActive(true);}
		else {ButtonHealingPie.SetActive(false);}
		
		if ((spicyIng1Num >= 1) && (spicyIng2Num >= 1)){
			ButtonSpicyAttack.SetActive(true);}
		else {ButtonSpicyAttack.SetActive(false);}
		
		if ((tacoIng1Num >= 1) && (tacoIng2Num >= 1) && (tacoIng3Num >= 1)){
			ButtonTaco.SetActive(true);}
		else {ButtonTaco.SetActive(false);}

		if ((sushiIng1Num >= 1) && (sushiIng2Num >= 1) && (sushiIng3Num >= 1)){
			ButtonSushi.SetActive(true);}
		else {ButtonSushi.SetActive(false);}

		if ((Input.GetKeyDown("1"))&&(spicybool==true)){ServeSpicyAttack();}
		//if (Input.GetKeyDown("2")){LoadFood("icecream");}
		//if (Input.GetKeyDown("3")){LoadFood("meatball");}
		
		if (Input.GetKeyDown("m")){CookBookMenu.SetActive(!CookBookMenu.activeSelf);}
	}


    public void InventoryDisplay(){
		if (healIng1bool == true) {healIng1image.SetActive(true);} else {healIng1image.SetActive(false);}
		if (healIng2bool == true) {healIng2image.SetActive(true);} else {healIng2image.SetActive(false);}
		if (healIng3bool == true) {healIng3image.SetActive(true);} else {healIng3image.SetActive(false);}
		if (healbool == true) {healButton.SetActive(true);} else {healButton.SetActive(false);}

		if (spicyIng1bool == true) {spicyIng1image.SetActive(true);} else {spicyIng1image.SetActive(false);}
		if (spicyIng2bool == true) {spicyIng2image.SetActive(true);} else {spicyIng2image.SetActive(false);}
		if (spicybool == true) {spicyButton.SetActive(true);} else {spicyButton.SetActive(false);}

		if (tacoIng1bool == true) {tacoIng1image.SetActive(true);} else {tacoIng1image.SetActive(false);}
		if (tacoIng2bool == true) {tacoIng2image.SetActive(true);} else {tacoIng2image.SetActive(false);}
		if (tacoIng3bool == true) {tacoIng3image.SetActive(true);} else {tacoIng3image.SetActive(false);}
		if (tacobool == true) {tacoButton.SetActive(true);} else {tacoButton.SetActive(false);}

		if (sushiIng1bool == true) {sushiIng1image.SetActive(true);} else {sushiIng1image.SetActive(false);}
		if (sushiIng2bool == true) {sushiIng2image.SetActive(true);} else {sushiIng2image.SetActive(false);}
		if (sushiIng3bool == true) {sushiIng3image.SetActive(true);} else {sushiIng3image.SetActive(false);}
		if (sushibool == true) {sushiButton.SetActive(true);} else {sushiButton.SetActive(false);}

		Text healIng1B = healIng1Txt.GetComponent<Text>();
		healIng1B.text = ("" + healIng1Num);
		Text healIng2B = healIng2Txt.GetComponent<Text>();
		healIng2B.text = ("" + healIng2Num);
		Text healIng3B = healIng3Txt.GetComponent<Text>();
		healIng3B.text = ("" + healIng3Num);			
		Text healTxtB = healTxt.GetComponent<Text>();
		healTxtB.text = ("" + healNum);
			
			
		Text spicyIng1B = spicyIng1Txt.GetComponent<Text>();
		spicyIng1B.text = ("" + spicyIng1Num);			
		Text spicyIng2B = spicyIng2Txt.GetComponent<Text>();
		spicyIng2B.text = ("" + spicyIng2Num);
		Text spicyTxtB = spicyTxt.GetComponent<Text>();
		spicyTxtB.text = ("" + spicyNum);

		Text sushiIng1B = sushiIng1Txt.GetComponent<Text>();
		sushiIng1B.text = ("" + sushiIng1Num);
		Text sushiIng2B = sushiIng2Txt.GetComponent<Text>();
		sushiIng2B.text = ("" + sushiIng2Num);
		Text sushiIng3B = sushiIng3Txt.GetComponent<Text>();
		sushiIng3B.text = ("" + sushiIng3Num);			
		Text sushiTxtB = sushiTxt.GetComponent<Text>();
		sushiTxtB.text = ("" + sushiNum);

		Text tacoIng1B = tacoIng1Txt.GetComponent<Text>();
		tacoIng1B.text = ("" + tacoIng1Num);
		Text tacoIng2B = tacoIng2Txt.GetComponent<Text>();
		tacoIng2B.text = ("" + tacoIng2Num);
		Text tacoIng3B = tacoIng3Txt.GetComponent<Text>();
		tacoIng3B.text = ("" + tacoIng3Num);			
		Text tacoTxtB = tacoTxt.GetComponent<Text>();
		tacoTxtB.text = ("" + tacoNum);
	}

	public void InventoryAdd(string item){
		string foundItemName = item;
		if (foundItemName == "flour") {healIng1bool = true; healIng1Num += 1;}
            else if (foundItemName == "apple") {healIng2bool = true; healIng2Num += 1;}
            else if (foundItemName == "cinnamon") {healIng3bool = true; healIng3Num += 1;}
			else if (foundItemName == "healingpie") {healbool = true; healNum += 1;}
		else if (foundItemName == "jalapenos") {spicyIng1bool = true; spicyIng1Num += 1;}
		else if (foundItemName == "hotsauce") {spicyIng2bool = true; spicyIng2Num += 1;}
		else if (foundItemName == "spicypopper") {spicybool = true; spicyNum += 1;}
			else if (foundItemName == "tortilla") {tacoIng1bool = true; tacoIng1Num += 1;}
			else if (foundItemName == "lettuce") {tacoIng2bool = true; tacoIng2Num += 1;}
			else if (foundItemName == "tomato") {tacoIng3bool = true; tacoIng3Num += 1;}
			else if (foundItemName == "taco") {tacobool = true; tacoNum += 1;}
		else if (foundItemName == "fish") {sushiIng1bool = true; sushiIng1Num += 1;}
		else if (foundItemName == "seaweed") {sushiIng2bool = true; sushiIng2Num += 1;}
		else if (foundItemName == "rice") {sushiIng3bool = true; sushiIng3Num += 1;}
		else if (foundItemName == "sushi") {sushibool = true; sushiNum += 1;}

            InventoryDisplay();
      }

	public void InventoryRemove(string item){
		string itemRemove = item;
		if (itemRemove == "flour") {healIng1Num -= 1; if (healIng1Num <= 0){healIng1bool=false;}}
		else if (itemRemove == "apple") {healIng2Num -= 1; if (healIng2Num <= 0){healIng2bool=false;}}
		else if (itemRemove == "cinnamon") {healIng3Num -= 1; if (healIng3Num <= 0){healIng3bool=false;}}
		else if (itemRemove == "healingpie") {healNum -= 1; if (healNum <= 0){healbool=false;}}
		
		else if (itemRemove == "jalapenos") {spicyIng1Num -= 1; if (spicyIng1Num <= 0){spicyIng1bool=false;}}
		else if (itemRemove == "hotsauce") {spicyIng2Num -= 1; if (spicyIng2Num <= 0){spicyIng2bool=false;}}
		else if (itemRemove == "spicypopper") {spicyNum -= 1; if (spicyNum <= 0){spicybool=false;}}

		else if (itemRemove == "tortilla") {tacoIng1Num -= 1; if (tacoIng1Num <= 0){tacoIng1bool=false;}}
		else if (itemRemove == "lettuce") {tacoIng2Num -= 1; if (tacoIng2Num <= 0){tacoIng2bool=false;}}
		else if (itemRemove == "tomato") {tacoIng3Num -= 1; if (tacoIng3Num <= 0){tacoIng3bool=false;}}
		else if (itemRemove == "taco") {tacoNum -= 1; if (tacoNum <= 0){tacobool=false;}}	
		
		else if (itemRemove == "fish") {sushiIng1Num -= 1; if (sushiIng1Num <= 0){sushiIng1bool=false;}}
		else if (itemRemove == "seaweed") {sushiIng2Num -= 1; if (sushiIng2Num <= 0){sushiIng2bool=false;}}
		else if (itemRemove == "rice") {sushiIng3Num -= 1; if (sushiIng3Num <= 0){sushiIng3bool=false;}}
		else if (itemRemove == "sushi") {sushiNum -= 1; if (sushiNum <= 0){sushibool=false;}}
		
            InventoryDisplay();
      }

      //public void CoinChange(int amount){
      //      coins +=amount;
      //      InventoryDisplay();
      //}
	  
	  
	  public void OpenCookbookMenu(){CookBookMenu.SetActive(true);}
	  public void CloseCookbookMenu(){CookBookMenu.SetActive(false);}
	  
	 
	  
	public void CookHealingPie(){
		InventoryRemove("flour");
		InventoryRemove("apple");
		InventoryRemove("cinnamon");
		InventoryAdd("healingpie");
	}
	  
	public void CookSpicyAttack(){
		InventoryRemove("jalapenos");
		InventoryRemove("hotsauce");
		InventoryAdd("spicypopper");
		
	}
	
	public void CookTaco(){
		InventoryRemove("tortilla");
		InventoryRemove("lettuce");
		InventoryRemove("tomato");
		InventoryAdd("taco");
		DonChicote.SetChiefDialogue("Taco");
	}
	
	public void CookSushi(){
		InventoryRemove("fish");
		InventoryRemove("seaweed");
		InventoryRemove("rice");
		InventoryAdd("sushi");
		DonChicote.SetChiefDialogue("Sushi");
		GameHandler.finalOffer = true;
	}


	public void ServeHealingPie(){
		Debug.Log("You hit the heal button!");
		gameHandler.playerGetHit(healingAmt * -1);
		InventoryRemove("healingpie");
	}

	public void ServeSpicyAttack(){	
		if (thePlayer.GetComponent<PlayerThrowAttack>().haveFood == false){
			InventoryRemove("spicypopper");
			thePlayer.GetComponent<PlayerThrowAttack>().LoadFood("spicypopper");
			Debug.Log("spicy projectile ready!");
		}
		else {Debug.Log("You already have a projectile loaded");}
	} 

	public void ServeTaco(){
		Debug.Log("You Serve Tacos!");
		//InventoryRemove("taco");
	}
	
	public void ServeSushi(){
		Debug.Log("You Serve Sushi!");
		//InventoryRemove("sushi");
	}

}