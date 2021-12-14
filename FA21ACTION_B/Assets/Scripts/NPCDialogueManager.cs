using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogueManager : MonoBehaviour
{
	public GameObject dialogueBox;
	public Text dialogueText;
	
	public string[] dialogue; //move into NPC script
	public int counter = 0;
	public int dialogueLength;
	
    // Start is called before the first frame update
    void Start(){
		dialogueBox.SetActive(false);

        dialogueLength = dialogue.Length; //move into NPC script
		Debug.Log("number of lines = " + dialogueLength); //move into NPC script
		
    }

	void Update(){
		//temporary testing (move this content into public functiosn for the NPC collisions to activate)
		if (Input.GetKeyDown("o")){
			dialogueBox.SetActive(true);
		}
		if (Input.GetKeyDown("p")){
			dialogueBox.SetActive(false);
			dialogueText.text = "..."; 		//reset text
			counter = 0;					//reset counter
		}
	}

	public void OpenDialogue(){
		dialogueBox.SetActive(true);
	}

	public void CloseDialogue(){
		dialogueBox.SetActive(false);
		dialogueText.text = "..."; 		//reset text
		counter = 0;					//reset counter
	}

	public void LoadDialogueArray(){
	//not yet implemented:
	//in order to have individual NPCDialogue scripts, load the array of contents into here

	}

	//function for the button to display next line of dialogue
    public void DialogueNext(){
        if (counter < dialogueLength){
			dialogueText.text = dialogue[counter];
			counter += 1;
		}
		else {
			dialogueBox.SetActive(false);	//when lines complete
			dialogueText.text = "..."; 		//reset text
			counter = 0;					//reset counter
		}
    }
	
}
