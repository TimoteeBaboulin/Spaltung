using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : Singleton<DialogueSystem>
{

	public ELEMENTS elements;

	/// <summary>
	/// Say something and show it on the speech box.
	/// </summary>
	public void Say(string speech, string speaker = "")
	{
		StopSpeaking();

		Player.Instance.pause = true;
		speechPanel.SetActive(true);
		speaking = StartCoroutine(Speaking(speech, false, speaker));
	}
	
	public IEnumerator SayMultiple(List<string> speech, string speaker = "")
	{
		foreach (var text in speech)
		{
			speechPanel.SetActive(true);
			StartCoroutine(Speaking(text, false));
			
			yield return new WaitForEndOfFrame();
			
			while (isSpeaking != true)
			{
				yield return new WaitForEndOfFrame();
			}
		}
	}

	/// <summary>
	/// Say something to be added to what is already on the speech box.
	/// </summary>
	public void SayAdd(string speech, string speaker = "")
	{
		StopSpeaking();

		speechText.text = targetSpeech;

		speaking = StartCoroutine(Speaking(speech, true, speaker));
	}

	public void StopSpeaking()
	{
		if (isSpeaking)
		{
			StopCoroutine(speaking);
		}
		speaking = null;

		Player.Instance.pause = false;
		speechPanel.SetActive(false);
	}
		
	public bool isSpeaking {get{return speaking != null;}}
	[HideInInspector] public bool isWaitingForUserInput = false;

	public string targetSpeech = "";
	Coroutine speaking = null;
	IEnumerator Speaking(string speech, bool additive, string speaker = "")
	{
		speechPanel.SetActive(true);
		targetSpeech = speech;

		if (!additive)
			speechText.text = "";
		else
			targetSpeech = speechText.text + targetSpeech;

		speakerNameText.text = DetermineSpeaker(speaker);//temporary

		isWaitingForUserInput = false;

		while(speechText.text != targetSpeech)
		{
			speechText.text += targetSpeech[speechText.text.Length];
			yield return new WaitForEndOfFrame();
		}

		//text finished
		isWaitingForUserInput = true;
		while(isWaitingForUserInput)
		{
			yield return new WaitForEndOfFrame();
			
		}

		StopSpeaking();
	}

	string DetermineSpeaker(string s)
	{
		string retVal = speakerNameText.text;//default return is the current name
		if (s != speakerNameText.text && s != "")
			retVal = (s.ToLower().Contains("narrator")) ? "" : s;

		return retVal;
	}

	[System.Serializable]
	public class ELEMENTS
	{
		/// <summary>
		/// The main panel containing all dialogue related elements on the UI
		/// </summary>
		public GameObject speechPanel;
		public Text speakerNameText;
		public Text speechText;
	}
	public GameObject speechPanel {get{return elements.speechPanel;}}
	public Text speakerNameText {get{return elements.speakerNameText;}}
	public Text speechText {get{return elements.speechText;}}
}