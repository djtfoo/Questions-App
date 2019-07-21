using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestionGenerator : MonoBehaviour {

    protected List<int> availableInt;

    protected void InitAvailableInt(int listSize) {
        availableInt = new List<int>();
        for (int i = 0; i < listSize; i++)
            availableInt.Add(i);
    }

    protected int GetRandomIdx() {

        if (availableInt.Count == 0)
            return -1;  // no more indexes available

        // get random index
        int randomIdx = availableInt[Random.Range(0, availableInt.Count)];
        // remove from List
        availableInt.Remove(randomIdx);

        return randomIdx;
    }

    public abstract Question GenerateQuestion();
}
