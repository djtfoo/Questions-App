using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FillPhrasesGenerator : QuestionGenerator {
    
    [SerializeField]
    private TextAsset file; // file containing questions

    private List<string> phrasesList;   // list of phrases with blanks
    private List<string> answersList;   // list of answers corresponding to question (via index)

    // Use this for initialization
    void Start () {

        phrasesList = new List<string>();
        answersList = new List<string>();

        ReadCSV();
        InitAvailableInt(phrasesList.Count);
    }

    public override Question GenerateQuestion() {

        //int randomIdx = Random.Range(0, phrasesList.Count);
        int randomIdx = GetRandomIdx();
        if (randomIdx == -1)    // no more available questions
        {
            InitAvailableInt(phrasesList.Count);
            randomIdx = GetRandomIdx();
        }
        
        //Debug.Log(question);
        //Debug.Log("Answer: " + answer);

        string question = "Complete the following phrase:\n" + phrasesList[randomIdx];

        return new Question(question, answersList[randomIdx]);
    }

    private string GenerateQuestionString(string fill)
    {
        string question = "Complete the phrase:\n" + fill;
        return question;
    }

    private void ReadCSV() {

        QuestionsList questionsList = new QuestionsList();

        string[,] arr = CSVReader.GetCSVGridString(file.text, ";");
        for (int i = 0; i < arr.GetLength(0); i++) {
            string phrase = arr[i,0];
            if (phrase == "" || phrase == null)
                continue;
            string answer = arr[i,1].Replace("\r", "");
            phrasesList.Add(phrase);
            answersList.Add(answer);

            questionsList.questions.Add(new Question(GenerateQuestionString(phrase), answer));
        }

        // write to JSON
        string jsonString = JsonUtility.ToJson(questionsList);

        StreamWriter outStream = System.IO.File.CreateText(Application.dataPath + "/TextAssets/Fill-Phrases.json");
        outStream.WriteLine(jsonString);
        outStream.Close();
    }
}
