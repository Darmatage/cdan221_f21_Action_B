using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
	public GameObject testButton;
    // Start is called before the first frame update
    void Start()
    {
        testButton.SetActive(true);
    }

    public void test()
	{
		Debug.Log("I am Debugging");
	}
		
	
    void Update()
    {
        
    }
	
}
