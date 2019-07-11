using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VocabGenerator : QuestionGenerator {

    [SerializeField]
    private TextAsset file; // file containing questions

    private List<string> vocabList;   // list of vocabulary words
    private List<string> answersList;   // list of answers corresponding to question (via index)

    // Use this for initialization
    void Start () {

        vocabList = new List<string>();
        answersList = new List<string>();

        ReadCSV();
        InitAvailableInt(vocabList.Count);
    }

    public override Question GenerateQuestion() {

        //int randomIdx = Random.Range(0, vocabList.Count);
        int randomIdx = GetRandomIdx();
        if (randomIdx == -1)    // no more available questions
        {
            InitAvailableInt(vocabList.Count);
            randomIdx = GetRandomIdx();
        }
        
        //Debug.Log(question);
        //Debug.Log("Answer: " + answer);

        string question = "What is the meaning of the word/phrase " + vocabList[randomIdx] + "?";

        return new Question(question, answersList[randomIdx]);
    }

    private void ReadCSV() {

        string[,] arr = CSVReader.GetCSVGridString(file.text);
        for (int i = 0; i < arr.GetLength(0); i++) {
            string vocab = arr[i,0];
            if (vocab == "" || vocab == null)
                continue;
            string answer = arr[i,1];
            vocabList.Add(vocab);
            answersList.Add(answer);
        }
    }
}
