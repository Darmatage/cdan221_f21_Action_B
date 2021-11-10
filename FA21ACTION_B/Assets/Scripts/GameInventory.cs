using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameInventory : MonoBehaviour {

    //Inventory display and Buttons:
    public GameObject CookBookMenu;
	public GameObject ButtonSpicyAttack;
	public GameObject ButtonHealingPie;


	//5 Inventory Items (Bools, Number, Images, Text):
      private static bool spicyIng1bool = false; // jalapenos
      private static bool spicyIng2bool = false; // hotsauce
	  //private static bool spicybool = false; 	// hotpopper
      private static bool healIng1bool = false; // flour
      private static bool healIng2bool = false; // apples
      private static bool healIng3bool = false; // cinnamon
	  //private static bool healbool = false; 	// pie
	  
      private static int spicyIng1Num = 0;
	  private static int spicyIng2Num = 0;
	  //private static int spicyNum = 0;
	  private static int healIng1Num = 0;
	  private static int healIng2Num = 0;
	  private static int healIng3Num = 0;
	  //private static int healNum = 0;

      public GameObject spicyIng1image;
      public GameObject spicyIng2image;
	  //public GameObject spicyimage;
      public GameObject healIng1image;
      public GameObject healIng2image;
      public GameObject healIng3image;
	  //public GameObject healimage;
      
	  public GameObject spicyIng1Txt;
	  public GameObject spicyIng2Txt;	  
	  //public GameObject spicyTxt
	  public GameObject healIng1Txt;
	  public GameObject healIng2Txt;
	  public GameObject healIng3Txt;
	  //public GameObject healTxt;


      void Start(){
            CookBookMenu.SetActive(false);
			ButtonSpicyAttack.SetActive(false);
			ButtonHealingPie.SetActive(false);
            InventoryDisplay();
      }

	void Update(){
		
		if ((spicyIng1Num >= 1) && (spicyIng2Num >= 1)){
			ButtonSpicyAttack.SetActive(true);}
		else {ButtonSpicyAttack.SetActive(false);}
		
		if ((healIng1Num >= 1) && (healIng2Num >= 1) && (healIng3Num >= 1)){
			ButtonHealingPie.SetActive(true);}
		else {ButtonHealingPie.SetActive(false);}
	}


      void InventoryDisplay(){
            if (spicyIng1bool == true) {spicyIng1image.SetActive(true);} else {spicyIng1image.SetActive(false);}
            if (spicyIng2bool == true) {spicyIng2image.SetActive(true);} else {spicyIng2image.SetActive(false);}
            if (healIng1bool == true) {healIng1image.SetActive(true);} else {healIng1image.SetActive(false);}
            if (healIng2bool == true) {healIng2image.SetActive(true);} else {healIng2image.SetActive(false);}
            if (healIng3bool == true) {healIng3image.SetActive(true);} else {healIng3image.SetActive(false);}

            Text spicyIng1B = spicyIng1Txt.GetComponent<Text>();
            spicyIng1B.text = ("" + spicyIng1Num);
			
            Text spicyIng2B = spicyIng2Txt.GetComponent<Text>();
            spicyIng2B.text = ("" + spicyIng2Num);

            Text healIng1B = healIng1Txt.GetComponent<Text>();
            healIng1B.text = ("" + healIng1Num);

            Text healIng2B = healIng2Txt.GetComponent<Text>();
            healIng2B.text = ("" + healIng2Num);

            Text healIng3B = healIng3Txt.GetComponent<Text>();
            healIng3B.text = ("" + healIng3Num);
      }

      public void InventoryAdd(string item){
            string foundItemName = item;
            if (foundItemName == "jalapenos") {spicyIng1bool = true; spicyIng1Num += 1;}
            else if (foundItemName == "hotsauce") {spicyIng2bool = true; spicyIng2Num += 1;}
            else if (foundItemName == "flour") {healIng1bool = true; healIng1Num += 1;}
            else if (foundItemName == "apple") {healIng2bool = true; healIng2Num += 1;}
            else if (foundItemName == "cinnamon") {healIng3bool = true; healIng3Num += 1;}
			//else if (foundItemName == "healingpie") {healbool = true; healNum += 1;}
			//else if (foundItemName == "spicypopper") {spicybool = true; spicyNum += 1;}
						
            InventoryDisplay();
      }

      public void InventoryRemove(string item){
            string itemRemove = item;
            if (itemRemove == "jalapenos") {
				spicyIng1Num -= 1;
				if (spicyIng1Num <= 0){spicyIng1bool=false;}
			}
            else if (itemRemove == "hotsauce") {
				spicyIng2Num -= 1;
				if (spicyIng2Num <= 0){spicyIng2bool=false;}
			}
            else if (itemRemove == "flour") {
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
            InventoryDisplay();
      }

      //public void CoinChange(int amount){
      //      coins +=amount;
      //      InventoryDisplay();
      //}
	  
	  
	  public void OpenCookbookMenu(){CookBookMenu.SetActive(true);}
	  public void CloseCookbookMenu(){CookBookMenu.SetActive(false);}
	  
	  
	public void CookSpicyAttack(){
		InventoryRemove("jalapenos");
		InventoryRemove("hotsauce");
		//InventoryAdd(spicypopper);
	}
	  
	public void CookHealingPie(){
		InventoryRemove("flour");
		InventoryRemove("apple");
		InventoryRemove("cinnamon");
		//InventoryAdd(healingPie);
	}
	  

	  
}