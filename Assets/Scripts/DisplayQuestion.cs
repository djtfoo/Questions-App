using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayQuestion : MonoBehaviour {

	public Text questionText;
	public Text answerText;
	public QuestionBank qns;

    [SerializeField]
    private Text questionCountText;
    private int questionCount = 0;

	// Use this for initialization
	void Start () {
		ShowQuestion();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowQuestion() {
        Question q = qns.GetQuestion();
        if (q != null)
        {
            UpdateCount();
            questionText.text = q.question;
            answerText.text = q.answer;
        }
    }

    private void UpdateCount() {
        questionCount++;
        if (questionCountText)
            questionCountText.text = questionCount.ToString();
    }
}
