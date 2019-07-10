using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// question format: How many feet do X <animal>, Y <animal>, ... and Z <animal> have?
public class AnimalLegsQuestionGenerator : QuestionGenerator {

    [SerializeField]
    private TextAsset[] objectTextFiles;
    [SerializeField]
    private string[] quantityInQuestion;

    private List<List<string>> itemsList;   // list of item
    private List<List<int>> quantityList;   // quantity corresponding to each item

    void Start () {
        itemsList = new List<List<string>>();
        quantityList = new List<List<int>>();

        // initialised in QuestionBank instead
        //Random.InitState((int)System.DateTime.Now.Ticks);

        foreach (TextAsset asset in objectTextFiles) {
            ReadCSV(asset);
        }
        //GenerateQuestion();
    }

    public override Question GenerateQuestion() {

        int id = Random.Range(0, objectTextFiles.Length);   // determine which items to be used in generated question
        return DefineQuestion(quantityInQuestion[id], itemsList[id], quantityList[id]);
    }

    private Question DefineQuestion(string item, List<string> iList, List<int> qList) {
        
        //int count = Random.Range(2, 3); // 2 to 3
        int count = 2;
        string question = "How many " + item + " do ";
        int answer = 0;
        //List<int> itemsCalledBefore = new List<int>();  // to ensure uniquely generated animals; not using now
        for (int i = 0; i < count; i++) {
            int quantity = Random.Range(2, 21); // 2 to 20
            int itemIdx = Random.Range(0, iList.Count); // which animal to invoke
            // calculate feet
            answer += quantity * qList[itemIdx];
            // add on to question
            question += quantity.ToString() + " " + iList[itemIdx];
            if (i == count - 2) {
                question += " and ";
            } else if (i < count - 1) {
                question += ", ";
            }
        }

        question += " have?";

        //Debug.Log(question);
        //Debug.Log("Answer: " + answer);

        return new Question(question, answer.ToString());
    }

    private void ReadCSV(TextAsset asset) {

        string[,] arr = CSVReader.GetCSVGridString(asset.text);
        List<string> iList = new List<string>();
        List<int> qList = new List<int>();
        for (int i = 0; i < arr.GetLength(0); i++) {
            string item = arr[i,0];
            if (item == "" || item == null)
                continue;
            int quantity = int.Parse(arr[i,1]);
            iList.Add(item);
            qList.Add(quantity);
        }
        itemsList.Add(iList);
        quantityList.Add(qList);
    }
}
