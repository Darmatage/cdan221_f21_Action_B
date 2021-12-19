using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogueChickenChief : MonoBehaviour{
	//private Animator anim;
	private NPCDialogueManager dialogueMNGR;

	//enter the dialogue lines into the inpsector for each NPC
	public string[] dialogueA;
	public string[] dialogueB;
	public string[] dialogueC;
	public string[] dialogueD;
	public string[] dialogueE;
	
	private int dialogueLength;
	private string[] theDialogue;
	
	public bool playerInRange = false;

    void Start()
    {
		//anim = gameObject.GetComponentInChildren<Animator>();
		
        if (GameObject.FindWithTag("DialogueManager")!= null){
			dialogueMNGR = GameObject.FindWithTag("DialogueManager").GetComponent<NPCDialogueManager>();
		}
    }
	
	public void SetChiefDialogue(string condition){
		if (condition=="start"){theDialogue = dialogueA;}
		else if (condition=="noTaco"){theDialogue = dialogueB;}
		else if (condition=="Taco"){theDialogue = dialogueC;}
		else if (condition=="noSushi"){theDialogue = dialogueD;}
		else if (condition=="Sushi"){theDialogue = dialogueE;}	
	}
	
	
	private void OnTriggerEnter2D(Collider2D other){
		dialogueLength = theDialogue.Length;
		if (other.gameObject.tag == "Player") {
			playerInRange = true;
			dialogueMNGR.OpenDialogue();
			dialogueMNGR.LoadDialogueArray(theDialogue, dialogueLength);
			//anim.SetBool("Chat", true);
			//Debug.Log("Player in range");
		}
	}
                        
	private void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag =="Player") {
			playerInRange = false;
			dialogueMNGR.CloseDialogue();
			//anim.SetBool("Chat", false);
			//Debug.Log("Player left range");
		}
	}
	
}
