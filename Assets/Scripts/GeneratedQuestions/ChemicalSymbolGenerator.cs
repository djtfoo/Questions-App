using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalSymbolGenerator : QuestionGenerator {

    [SerializeField]
    private TextAsset elementsListFile;

    private List<string> elementNamesList;      // list of elements
    private List<string> elementSymbolsList;    // element symbols corresponding to element (via index)

	// Use this for initialization
	void Start () {
		
        elementNamesList = new List<string>();
        elementSymbolsList = new List<string>();

        ReadCSV();
        InitAvailableInt(elementNamesList.Count);
	}
	
    public override Question GenerateQuestion() {
		
        //int randomIdx = Random.Range(0, elementNamesList.Count);
        int randomIdx = GetRandomIdx();
        if (randomIdx == -1)    // no more available questions
        {
            InitAvailableInt(elementNamesList.Count);
            randomIdx = GetRandomIdx();
        }

        string question = "What is the chemical symbol of ";
        question += elementNamesList[randomIdx] + "?";
        string answer = elementSymbolsList[randomIdx];

        //Debug.Log(question);
        //Debug.Log("Answer: " + answer);

        return new Question(question, answer);
	}

    private void ReadCSV() {

        string[,] arr = CSVReader.GetCSVGridString(elementsListFile.text);
        for (int i = 0; i < arr.GetLength(0); i++) {
            string element = arr[i,0];
            if (element == "")
                continue;
            string symbol = arr[i,1];
            elementNamesList.Add(element);
            elementSymbolsList.Add(symbol);
        }
    }
}
