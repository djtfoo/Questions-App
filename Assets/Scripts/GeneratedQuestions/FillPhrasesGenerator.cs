using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //GenerateQuestion();
    }

    public override Question GenerateQuestion() {

        int randomIdx = Random.Range(0, phrasesList.Count);

        //Debug.Log(question);
        //Debug.Log("Answer: " + answer);

        string question = "Complete the following phrase:\n" + phrasesList[randomIdx];

        return new Question(question, answersList[randomIdx]);
    }

    private void ReadCSV() {

        string[,] arr = CSVReader.GetCSVGridString(file.text, ";");
        for (int i = 0; i < arr.GetLength(0); i++) {
            string phrase = arr[i,0];
            if (phrase == "" || phrase == null)
                continue;
            string answer = arr[i,1];
            phrasesList.Add(phrase);
            answersList.Add(answer);
        }
    }
}
