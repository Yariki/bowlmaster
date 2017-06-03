using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScroDisplayController : MonoBehaviour 
{

	public Text[] rollsTexts, scoreTexts;


	// Use this for initialization
	void Start () 
	{
		if (rollsTexts != null && rollsTexts.Length > 0) 
		{
			foreach (Text roll in rollsTexts) 
			{
				roll.text = string.Empty;
			}
		}
		if (scoreTexts != null && scoreTexts.Length > 0) 
		{
			foreach (Text score in scoreTexts) 
			{
				score.text = string.Empty;	
			}
		}
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
