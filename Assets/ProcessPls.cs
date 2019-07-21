using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class ProcessPls : MonoBehaviour {

    [SerializeField]
    private TextAsset file;

	// Use this for initialization
	void Start () {
		
        string[] lines = CSVReader.GetCSVLines(file.text);
        //StringBuilder sb = new StringBuilder();

        QuestionsList questionsList = new QuestionsList();

        foreach (string line in lines) {
            Debug.Log("HEY");
            if (line == null || line == "")
                continue;

            string[] retrieved = line.Split(new string[] {","}, System.StringSplitOptions.RemoveEmptyEntries);
            string qn = retrieved[0];

            if (qn == null || qn == "")
                continue;
            string ans = retrieved[1].Replace("\r", "");

            questionsList.questions.Add(new Question(qn, ans));

            //string lowerLine = line.ToLower();
            /*string[] retrieved = line.Split(new string[] {","}, System.StringSplitOptions.RemoveEmptyEntries);
            retrieved[0] = retrieved[0].ToLower();
            retrieved[1] = retrieved[1].Substring(0, retrieved[1].Length - 1);  // remove \n at back
            sb.AppendLine(retrieved[0] + "," + retrieved[1]);*/
        }

        // write to JSON
        string jsonString = JsonUtility.ToJson(questionsList);

        StreamWriter outStream = System.IO.File.CreateText(Application.dataPath + "/TextAssets/Processed.json");
        outStream.WriteLine(jsonString);
        outStream.Close();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
