using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentalSumsGenerator : QuestionGenerator {

    // range of possible operands to appear in the equation
    [SerializeField]
    [Tooltip("Minimum possible operand value (inclusive)")]
    private int minOperandValue;
    [SerializeField]
    [Tooltip("Maximum possible operand value (exclusive)")]
    private int maxOperandValue;

    [SerializeField]
    [Tooltip("Maximum possible number of operands to appear in the equation")]
    private int maxOperands;

	// Use this for initialization
	void Start () {
		
	}
	
    public override Question GenerateQuestion() {

        //int numOperands = (2 == maxOperands) ? 2 : Random.Range(2, maxOperands);
        int numOperands = 2;    // temporarily
        string question = "";
        int answer = 0;

        List<int> operandsList = new List<int>();

        int op = Random.Range(0, 3);  // + - *, no divide yet
        switch (op)
        {
            case 0: // +
                {
                    int operand1 = Random.Range(minOperandValue, maxOperandValue);
                    int operand2 = Random.Range(minOperandValue, maxOperandValue);
                    question = operand1.ToString() + " + " + operand2.ToString();
                    answer = operand1 + operand2;
                }break;
            case 1: // -
                {
                    int operand1 = Random.Range(minOperandValue, maxOperandValue);
                    int operand2 = Random.Range(minOperandValue, maxOperandValue);
                    question = operand1.ToString() + " - " + operand2.ToString();
                    answer = operand1 - operand2;
                }break;
            case 2: // *
                {
                    int operand1 = Random.Range(2, 10);
                    int operand2 = Random.Range(5, 100);
                    question = operand1.ToString() + " * " + operand2.ToString();
                    answer = operand1 * operand2;
                }break;
            //case 3: // divide
              //  question = operand1.ToString() + " / " + operand2.ToString();
              //  answer = operand1 / operand2;
            default:
                break;
        }

        return new Question(question, answer.ToString());
	}
}
