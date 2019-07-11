using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionBank : MonoBehaviour {

    // change to singleton

    enum QuestionType {

        Type_Trivia,    // Alex's list + random
        Type_Trivia2,   // Tim's CSV list
        Type_AnimalLegs,
        Type_ChemicalSymbol,
        Type_Acronym,
        Type_MentalSums,
        Type_Phrases,
        Type_Vocab,
        Types_Total
    }

	private QuestionsList questionsList;    // for trivia questions
	[SerializeField]
	private TextAsset jsonQuestions;

	// Use this for initialization
	void Awake() {
		questionsList = JsonUtility.FromJson<QuestionsList>(jsonQuestions.text);

        // initialise for all generators' use
        Random.InitState((int)System.DateTime.Now.Ticks);
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	public Question GetQuestion() {
        
        int randomType = Random.Range(0, (int)QuestionType.Types_Total);
        QuestionType qnType = (QuestionType)randomType;
        //QuestionType qnType = QuestionType.Type_MentalSums;
        switch (qnType)
        {
            case QuestionType.Type_Trivia:
            {
                int idx = Random.Range(0, questionsList.questions.Length);
                return questionsList.questions[idx];
            }
            case QuestionType.Type_Trivia2:
                return this.GetComponent<TriviaQuestions>().GenerateQuestion();
            case QuestionType.Type_AnimalLegs:
                return this.GetComponent<AnimalLegsQuestionGenerator>().GenerateQuestion();
            case QuestionType.Type_ChemicalSymbol:
                return this.GetComponent<ChemicalSymbolGenerator>().GenerateQuestion();
            case QuestionType.Type_Acronym:
                return this.GetComponent<AcronymGenerator>().GenerateQuestion();
            case QuestionType.Type_MentalSums:
                return this.GetComponent<MentalSumsGenerator>().GenerateQuestion();
            case QuestionType.Type_Phrases:
                return this.GetComponent<FillPhrasesGenerator>().GenerateQuestion();
            case QuestionType.Type_Vocab:
                return this.GetComponent<VocabGenerator>().GenerateQuestion();
            default:
                return new Question("", "");
        }
	}
}
