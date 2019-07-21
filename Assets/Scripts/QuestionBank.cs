using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionBank : QuestionGenerator {

	private QuestionsList questionsList;    // list of trivia questions
	[SerializeField]
	private TextAsset jsonQuestions;

	// Use this for initialization
	void Awake() {
		questionsList = JsonUtility.FromJson<QuestionsList>(jsonQuestions.text);

        // initialise for all generators' use
        Random.InitState((int)System.DateTime.Now.Ticks);

        InitAvailableInt(questionsList.questions.Count);
    }

	
	// Update is called once per frame
	void Update () {
		
	}

	public override Question GenerateQuestion() {

        int randomIdx = GetRandomIdx();
        if (randomIdx == -1)    // no more available questions
        {
            InitAvailableInt(questionsList.questions.Count);
            randomIdx = GetRandomIdx();
        }
        return questionsList.questions[randomIdx];
	}
}
