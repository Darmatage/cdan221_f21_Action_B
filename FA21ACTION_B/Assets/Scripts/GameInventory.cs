using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameInventory : MonoBehaviour {

    //CookBook display and Buttons:
    public GameObject CookBookMenu;
	public GameObject ButtonHealingPie;
	public GameObject ButtonSpicyAttack;
	public GameObject ButtonSushi;
	//public GameObject ButtonFreezeAttack;
	//public GameObject ButtonTooFullAttack;
	//public GameObject ButtonLordDish1;
	//public GameObject ButtonLordDish2;
	//public GameObject ButtonLordDish3;
	//public GameObject ButtonLordDish4;
	//public GameObject ButtonFinalDish;
	
	
	//5 Inventory Items (Bools, Number, Images, Text):
      private static bool healIng1bool = false; // flour
      private static bool healIng2bool = false; // apples
      private static bool healIng3bool = false; // cinnamon
	  private static bool healbool = false; 	// pie
	  
	  private static bool spicyIng1bool = false; // jalapenos
      private static bool spicyIng2bool = false; // hotsauce
	  private static bool spicybool = false; 	// hotpopper dish
	  
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

	  private static int healIng1Num = 0;
	  private static int healIng2Num = 0;
	  private static int healIng3Num = 0;
	  private static int healNum = 0;
	  
      private static int spicyIng1Num = 0;
	  private static int spicyIng2Num = 0;
	  private static int spicyNum = 0;

	  private static int sushiIng1Num = 0;
	  private static int sushiIng2Num = 0;
	  private static int sushiIng3Num = 0;
	  private static int sushiNum = 0;
	  
      public GameObject healIng1image;
      public GameObject healIng2image;
      public GameObject healIng3image;
	  public GameObject healButton;
	  
      public GameObject spicyIng1image;
      public GameObject spicyIng2image;
	  public GameObject spicyButton;
      
	  public GameObject sushiIng1image;
      public GameObject sushiIng2image;
      public GameObject sushiIng3image;
	  public GameObject sushiButton;

	  public GameObject healIng1Txt;
	  public GameObject healIng2Txt;
	  public GameObject healIng3Txt;
	  public GameObject healTxt;
	  
	  public GameObject spicyIng1Txt;
	  public GameObject spicyIng2Txt;	  
	  public GameObject spicyTxt;

	  public GameObject sushiIng1Txt;
	  public GameObject sushiIng2Txt;
	  public GameObject sushiIng3Txt;
	  public GameObject sushiTxt;
	  
	public GameHandler gameHandler;
	public GameObject thePlayer;
	public int healingAmt = 10;


    public void Start(){
		InventoryDisplay();	  
        CookBookMenu.SetActive(false);
		ButtonSpicyAttack.SetActive(false);
		ButtonHealingPie.SetActive(false);
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
		
		if ((sushiIng1Num >= 1) && (sushiIng2Num >= 1) && (sushiIng3Num >= 1)){
			ButtonHealingPie.SetActive(true);}
		
		
		if (Input.GetKeyDown("1")){ServeSpicyAttack();}
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
            Text sushiIng2B = healIng2Txt.GetComponent<Text>();
            sushiIng2B.text = ("" + sushiIng2Num);
            Text sushiIng3B = sushiIng3Txt.GetComponent<Text>();
            sushiIng3B.text = ("" + healIng3Num);			
			Text sushiTxtB = sushiTxt.GetComponent<Text>();
            sushiTxtB.text = ("" + sushiNum);
		
      }

      public void InventoryAdd(string item){
            string foundItemName = item;
            if (foundItemName == "flour") {healIng1bool = true; healIng1Num += 1;}
            else if (foundItemName == "apple") {healIng2bool = true; healIng2Num += 1;}
            else if (foundItemName == "cinnamon") {healIng3bool = true; healIng3Num += 1;}
			else if (foundItemName == "healingpie") {healbool = true; healNum += 1;}
			else if (foundItemName == "spicypopper") {spicybool = true; spicyNum += 1;}
			else if (foundItemName == "jalapenos") {spicyIng1bool = true; spicyIng1Num += 1;}
            else if (foundItemName == "hotsauce") {spicyIng2bool = true; spicyIng2Num += 1;}
			else if (foundItemName == "fish") {sushiIng1bool = true; sushiIng1Num += 1;}
			else if (foundItemName == "seaweed") {sushiIng2bool = true; sushiIng2Num += 1;}
			else if (foundItemName == "hotsauce") {sushiIng3bool = true; sushiIng3Num += 1;}
			
            InventoryDisplay();
      }

      public void InventoryRemove(string item){
            string itemRemove = item;

            if (itemRemove == "flour") {
					healIng1Num -= 1;
				if (healIng1Num <= 0){healIng1bool=false;}
			}
            else if (itemRemove == "apple") {
					healIng2Num -= 1;
				if (healIng2Num <= 0){healIng2bool=false;}
			}
            else if (itemRemove == "cinnamon") {
				healIng3Num -= 1;
				if (healIng3Num <= 0){healIng3bool=false;}
			}
			else if (itemRemove == "healingpie") {
				healNum -= 1;
				if (healNum <= 0){healbool=false;}
			}
			
			else if (itemRemove == "jalapenos") {
				spicyIng1Num -= 1;
				if (spicyIng1Num <= 0){spicyIng1bool=false;}
			}
            else if (itemRemove == "hotsauce") {
				spicyIng2Num -= 1;
				if (spicyIng2Num <= 0){spicyIng2bool=false;}
			}
            else if (itemRemove == "spicypopper") {
				spicyNum -= 1;
				if (spicyNum <= 0){spicybool=false;}
			}			
			
			if (itemRemove == "fish") {
					sushiIng1Num -= 1;
				if (sushiIng1Num <= 0){sushiIng1bool=false;}
			}
            else if (itemRemove == "seaweed") {
					sushiIng2Num -= 1;
				if (sushiIng2Num <= 0){sushiIng2bool=false;}
			}
            else if (itemRemove == "rice") {
				sushiIng3Num -= 1;
				if (sushiIng3Num <= 0){sushiIng3bool=false;}
			}
			else if (itemRemove == "sushi") {
				sushiNum -= 1;
				if (sushiNum <= 0){sushibool=false;}
			}
			
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
	
	public void CookSushi(){
		InventoryRemove("fish");
		InventoryRemove("seaweed");
		InventoryRemove("rice");
		InventoryAdd("sushi");
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
}