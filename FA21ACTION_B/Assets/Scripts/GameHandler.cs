using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour {

	private GameObject player;
	private GameObject cameraMain;
	private GameObject skyBG;
	
	public static int playerHealth;
	public int StartPlayerHealth = 100;
	public GameObject healthText;
	public GameObject ButtonSceneCaves;
	public GameObject ButtonSceneMarsh;
	public GameObject ButtonScenePueblo;
	//note: accept and reject buttons are on GameInventory

	//location control
	private string sceneName;
	public static Vector2 playerMapStart = new Vector2(-140, -6);
	public Vector2 backFromCaveStart = new Vector2(148,-7);
	public Vector2 backFromMarshStart = new Vector2(160,16);
	public static bool backFromCaves = false;
	public static bool backFromMarsh = false; 

	//Don Chicote Dialogue
	private NPCDialogueChickenChief DonChicote;
		public GameObject ButtonAcceptOffer;
		public GameObject ButtonRejectOffer;
	public static bool finalOffer = false;
		
	public bool isDefending = false;

	public static bool GameisPaused = false;
	public GameObject pauseMenuUI;
	public AudioMixer mixer;
	public static float volumeLevel = 1.0f;
	private Slider sliderVolumeCtrl;

	void Awake (){
		player = GameObject.FindWithTag("Player");
		cameraMain = GameObject.FindWithTag("MainCamera");
		if (GameObject.FindWithTag("Sky")!=null){
			skyBG = GameObject.FindWithTag("Sky");
		}
		if (GameObject.FindWithTag("DonChicote")!=null){
			DonChicote = GameObject.FindWithTag("DonChicote").GetComponent<NPCDialogueChickenChief>();
		}
		
		sceneName = SceneManager.GetActiveScene().name;
		if (sceneName == "Caves"){
			backFromCaves = true; 
			playerMapStart= backFromCaveStart; 
			//Debug.Log("CavesStart");
			DonChicote.SetChiefDialogue("noTaco");
			}
		if (sceneName == "Marsh"){
			backFromMarsh = true; 
			playerMapStart= backFromMarshStart; 
			//Debug.Log("MarshStart");
			DonChicote.SetChiefDialogue("noSushi");
			}
		if (sceneName == "Pueblo"){
			Debug.Log("PlayerPos: " + playerMapStart);
			player.transform.position = new Vector2(playerMapStart.x, playerMapStart.y);
			cameraMain.transform.position = new Vector3(playerMapStart.x, playerMapStart.y, -10);
			skyBG.transform.position = new Vector2(playerMapStart.x, playerMapStart.y);
			if (backFromCaves == true){backFromCaves = false;}
			else if (backFromMarsh == true){backFromMarsh = false;}
			else {DonChicote.SetChiefDialogue("start");}
		}
		
		SetLevel (volumeLevel);
		GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
		if (sliderTemp != null){
			sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
			sliderVolumeCtrl.value = volumeLevel;
		}
	}

	void Start(){		
		pauseMenuUI.SetActive(false);
		ButtonSceneCaves.SetActive(false);
		ButtonSceneMarsh.SetActive(false);
		ButtonScenePueblo.SetActive(false);
		
			ButtonAcceptOffer.SetActive(false);
			ButtonRejectOffer.SetActive(false);
		
		playerHealth = StartPlayerHealth;
		updateStatsDisplay();       
	}

	void Update (){
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (GameisPaused){
				Resume();
			}
			else{
				Pause();
			}
		}
	}

	public void Pause(){
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameisPaused = true;
	}

	public void Resume(){
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameisPaused = false;
	}

	public void SetLevel (float sliderValue){
		mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
		volumeLevel = sliderValue;
	}

	public void ButtonActiveCaves(){
		ButtonSceneCaves.SetActive(true);
	}
		
	public void ButtonInactiveCaves(){
		ButtonSceneCaves.SetActive(false);
	}
		
      //public void playerGetTokens(int newTokens){
      //      gotTokens += newTokens;
      //      updateStatsDisplay();
      //}

	public void playerGetHit(int damage){
		if (isDefending == false){
			playerHealth -= damage;
				  
			if (playerHealth >= StartPlayerHealth){
				playerHealth = StartPlayerHealth;
			}
				  
			if (playerHealth <= 0){
				playerHealth = 0;
				playerDies();
			}
				  
			updateStatsDisplay();
			player.GetComponent<PlayerHurt>().playerHit();
		}
	}

      public void updateStatsDisplay(){
            Text healthTextTemp = healthText.GetComponent<Text>();
            healthTextTemp.text = " " + playerHealth;

            //Text tokensTextTemp = tokensText.GetComponent<Text>();
            //tokensTextTemp.text = "GOLD: " + gotTokens;
      }

      public void playerDies(){
            player.GetComponent<PlayerHurt>().playerDead();
            StartCoroutine(DeathPause());
      }

      IEnumerator DeathPause(){
            player.GetComponent<PlayerMove>().isAlive = false;
            player.GetComponent<PlayerJump>().isAlive = false;
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("End_Lose");
      }

	public void StartGame() {
		Time.timeScale = 1f;
		SceneManager.LoadScene("Pueblo");
	}

	public void RestartGame() {
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
		playerHealth = StartPlayerHealth;
	}

      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

      public void Credits() {
            SceneManager.LoadScene("Credits");
      }
	  
	  public void ChangeSceneCaves() {
		  SceneManager.LoadScene("Caves");
	  }
	  
	   public void ChangeSceneMarsh() {
		  SceneManager.LoadScene("Marsh");
	  }
	  
	  public void ChangeScenePueblo() {
		  SceneManager.LoadScene("Pueblo");
	  }
	  
	  
	public void DisplayOfferButtons(){
		if (finalOffer == true){
			ButtonAcceptOffer.SetActive(true);
			ButtonRejectOffer.SetActive(true);
		}
	}
	  
	  public void ChangeSceneAccept() {
		  SceneManager.LoadScene("End_Win");
	  }
	  
	  public void ChangeSceneReject() {
		  SceneManager.LoadScene("End_Win");
	  }
	  
}