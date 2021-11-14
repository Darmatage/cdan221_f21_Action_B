using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameInventory : MonoBehaviour {

    //CookBook display and Buttons:
    public GameObject CookBookMenu;
	public GameObject ButtonHealingPie;
	public GameObject ButtonSpicyAttack;
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

      public GameObject healIng1image;
      public GameObject healIng2image;
      public GameObject healIng3image;
	  public GameObject healButton;
      public GameObject spicyIng1image;
      public GameObject spicyIng2image;
	  public GameObject spicyButton;
      

	  public GameObject healIng1Txt;
	  public GameObject healIng2Txt;
	  public GameObject healIng3Txt;
	  public GameObject healTxt;
	  public GameObject spicyIng1Txt;
	  public GameObject spicyIng2Txt;	  
	  public GameObject spicyTxt;


	public GameHandler gameHandler;
	public int healingAmt = 10;


    public void Start(){
		InventoryDisplay();	  
        CookBookMenu.SetActive(false);
		ButtonSpicyAttack.SetActive(false);
		ButtonHealingPie.SetActive(false);
		//gameHandler = transform.GetComponent<GameHandler>();
    }

	void Update(){
		
		if ((healIng1Num >= 1) && (healIng2Num >= 1) && (healIng3Num >= 1)){
			ButtonHealingPie.SetActive(true);}
		else {ButtonHealingPie.SetActive(false);}
		
		if ((spicyIng1Num >= 1) && (spicyIng2Num >= 1)){
			ButtonSpicyAttack.SetActive(true);}
		else {ButtonSpicyAttack.SetActive(false);}
		
	}


    public void InventoryDisplay(){
            if (healIng1bool == true) {healIng1image.SetActive(true);} else {healIng1image.SetActive(false);}
            if (healIng2bool == true) {healIng2image.SetActive(true);} else {healIng2image.SetActive(false);}
            if (healIng3bool == true) {healIng3image.SetActive(true);} else {healIng3image.SetActive(false);}
            if (healbool == true) {healButton.SetActive(true);} else {healButton.SetActive(false);}

			if (spicyIng1bool == true) {spicyIng1image.SetActive(true);} else {spicyIng1image.SetActive(false);}
            if (spicyIng2bool == true) {spicyIng2image.SetActive(true);} else {spicyIng2image.SetActive(false);}
            if (spicybool == true) {spicyButton.SetActive(true);} else {spicyButton.SetActive(false);}

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
	 

	public void ServeHealingPie(){
		Debug.Log("You hit the heal button!");
		gameHandler.playerGetHit(healingAmt * -1);
		InventoryRemove("healingpie");
	}

	public void ServeSpicyAttack(){
		//check if player canThrow = false. If so:
		InventoryRemove("spicypopper");
		//instantiate spicypopper prefab into slot over player head
		//activate player canThrow, load prefab
	}

	 
}