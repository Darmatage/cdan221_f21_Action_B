using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour{
	//private Animator anim;
	private NPCDialogueManager dialogueMNGR;

	public string[] dialogue; //enter the dialogue lines into the inpsector for each NPC
	public bool playerInRange = false;
	public int dialogueLength;
		
    void Start()
    {
		//anim = gameObject.GetComponentInChildren<Animator>();
		dialogueLength = dialogue.Length;
        if (GameObject.FindWithTag("DialogueManager")!= null){
			dialogueMNGR = GameObject.FindWithTag("DialogueManager").GetComponent<NPCDialogueManager>();
		}
    }
	
	private void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			playerInRange = true;
			dialogueMNGR.OpenDialogue();
			dialogueMNGR.LoadDialogueArray(dialogue, dialogueLength);
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
