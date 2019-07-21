using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StudyOfGenerator : MonoBehaviour {

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
        string question = fill + " is the study of?";
        return question;
    }

    private void ReadCSV() {

        QuestionsList questionsList = new QuestionsList();

        string[,] arr = CSVReader.GetCSVGridString(file.text);
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            string discipline = arr[i, 0];
            if (discipline == "" || discipline == null)
                continue;
            string field = arr[i, 1].Replace("\r", "");
            discipline = discipline.ToUpper()[0] + discipline.Substring(1, discipline.Length - 1); // first letter caps

            questionsList.questions.Add(new Question(GenerateQuestionString(discipline), field));
        }

        // write to JSON
        string jsonString = JsonUtility.ToJson(questionsList);

        StreamWriter outStream = System.IO.File.CreateText(Application.dataPath + "/TextAssets/StudyOf.json");
        outStream.WriteLine(jsonString);
        outStream.Close();
    }
}
