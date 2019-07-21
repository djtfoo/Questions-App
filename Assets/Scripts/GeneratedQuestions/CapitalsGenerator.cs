using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CapitalsGenerator : MonoBehaviour {

    [SerializeField]
    private TextAsset file; // file containing questions

    // Use this for initialization
    void Start () {

        ReadCSV();
    }
	
	// Update is called once per frame
	void Update () {

    }

    private string GenerateQuestionString(string fill)
    {
        string question = "What is the capital of " + fill + "?";
        return question;
    }

    private void ReadCSV()
    {

        QuestionsList questionsList = new QuestionsList();

        string[,] arr = CSVReader.GetCSVGridString(file.text);
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            string country = arr[i, 0];
            if (country == "" || country == null)
                continue;
            string capital = arr[i, 1].Replace("\r", "");

            questionsList.questions.Add(new Question(GenerateQuestionString(country), capital));
        }

        // write to JSON
        string jsonString = JsonUtility.ToJson(questionsList);

        StreamWriter outStream = System.IO.File.CreateText(Application.dataPath + "/TextAssets/Capitals.json");
        outStream.WriteLine(jsonString);
        outStream.Close();
    }
}
