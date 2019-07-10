using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriviaQuestions : QuestionGenerator {

    [SerializeField]
    private TextAsset file; // file containing questions

    private List<string> questionsList; // list of questions
    private List<string> answersList;   // list of answers corresponding to question (via index)

    // Use this for initialization
    void Start () {

        questionsList = new List<string>();
        answersList = new List<string>();

        ReadCSV();
        //GenerateQuestion();
    }

    public override Question GenerateQuestion() {

        int randomIdx = Random.Range(0, questionsList.Count);

        //Debug.Log(question);
        //Debug.Log("Answer: " + answer);

        return new Question(questionsList[randomIdx], answersList[randomIdx]);
    }

    private void ReadCSV() {

        string[,] arr = CSVReader.GetCSVGridString(file.text);
        for (int i = 0; i < arr.GetLength(0); i++) {
            string question = arr[i,0];
            if (question == "" || question == null)
                continue;
            string answer = arr[i,1];
            questionsList.Add(question);
            answersList.Add(answer);
        }
    }
}
