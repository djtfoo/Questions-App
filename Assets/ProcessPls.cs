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
        StringBuilder sb = new StringBuilder();

        foreach (string line in lines) {
            if (line == null || line == "")
                continue;

            //string lowerLine = line.ToLower();
            string[] retrieved = line.Split(new string[] {","}, System.StringSplitOptions.RemoveEmptyEntries);
            retrieved[0] = retrieved[0].ToLower();
            retrieved[1] = retrieved[1].Substring(0, retrieved[1].Length - 1);  // remove \n at back
            sb.AppendLine(retrieved[0] + "," + retrieved[1]);
        }

        StreamWriter outStream = System.IO.File.CreateText(Application.dataPath + "/TextAssets/Vocabs2.csv");
        outStream.WriteLine(sb);
        outStream.Close();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
