using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour
{
	[SerializeField] private GameObject ButtonSceneCaves;
	
	void OnTriggerEnter2D(Collider2D other)
	{
	 if(other.CompareTag("Player"))
		{	ButtonSceneCaves.SetActive(true);
		}else{ ButtonSceneCaves.SetActive(false);
			 }
	}
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
