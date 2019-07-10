using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcronymGenerator : QuestionGenerator {

    [SerializeField]
    private TextAsset file; // file containing acronyms

    private List<string> acronymsList;      // list of acronyms
    private List<string> acronymMeaningsList;   // list of acronym meanings corresponding to an acronym (via index)

	// Use this for initialization
	void Start () {

        acronymsList = new List<string>();
        acronymMeaningsList = new List<string>();
		
        ReadCSV();
        //GenerateQuestion();
	}

    public override Question GenerateQuestion() {

        int randomIdx = Random.Range(0, acronymsList.Count);
        string question = "What does ";
        question += acronymsList[randomIdx] + " stand for?";
        string answer = acronymMeaningsList[randomIdx];

        //Debug.Log(question);
        //Debug.Log("Answer: " + answer);

        return new Question(question, answer);
    }

    private void ReadCSV() {

        string[,] arr = CSVReader.GetCSVGridString(file.text);
        for (int i = 0; i < arr.GetLength(0); i++) {
            string acronym = arr[i,0];
            if (acronym == "" || acronym == null)
                continue;
            string meaning = arr[i,1];
            acronymsList.Add(acronym);
            acronymMeaningsList.Add(meaning);
        }
    }
}
