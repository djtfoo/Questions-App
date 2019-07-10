using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeQuestion : QuestionGenerator {

    [SerializeField]
    private TextAsset namesFile; // text file containing list of people names to use

    private List<string> nameList;

	// Use this for initialization
	void Start () {
		
        nameList = new List<string>();
        ReadCSV();

        GenerateQuestion();
	}

    public override Question GenerateQuestion() {

        return new Question("", "");
    }

    private void ReadCSV() {

        string[] names = CSVReader.GetCSVLines(namesFile.text);
        for (int i = 0; i < names.Length; i++) {
            nameList.Add(names[i]);
        }
    }
}
