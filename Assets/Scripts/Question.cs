 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question {

	public string question;
	public string answer;

    public Question(string qn, string ans) {
        question = qn;
        answer = ans;
    }
}