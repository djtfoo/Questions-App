using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionsList {
	
	public List<Question> questions;

    public QuestionsList()
    {
        questions = new List<Question>();
    }
}