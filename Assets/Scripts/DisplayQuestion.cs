using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayQuestion : MonoBehaviour {

	public Text questionText;
	public Text answerText;
	public QuestionBank qns;

	// Use this for initialization
	void Start () {
		ShowQuestion();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowQuestion() {
		Question q = qns.GetQuestion();
		questionText.text = q.question;
		answerText.text = q.answer;
	}
}
