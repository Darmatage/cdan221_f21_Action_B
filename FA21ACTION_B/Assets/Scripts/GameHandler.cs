using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour {


      private GameObject player;
      public static int playerHealth;
      public int StartPlayerHealth = 100;
      public GameObject healthText;

      //public static int gotTokens = 0;
      //public GameObject tokensText;

      public bool isDefending = false;

      //public static bool stairCaseUnlocked = false;
      //this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true;

        public static bool GameisPaused = false;
        public GameObject pauseMenuUI;
        public AudioMixer mixer;
        public static float volumeLevel = 1.0f;
        private Slider sliderVolumeCtrl;

        void Awake (){
                SetLevel (volumeLevel);
                GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                if (sliderTemp != null){
                        sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                        sliderVolumeCtrl.value = volumeLevel;
                }
        }

      void Start(){
		   pauseMenuUI.SetActive(false);
            player = GameObject.FindWithTag("Player");
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

        void Pause(){
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
            SceneManager.LoadScene("EndLose");
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
}