using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetRequestWWW : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(GetText());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator GetText() {
        	UnityWebRequest www = UnityWebRequest.Get("https://www.alexneo.net/questions.json");
        	yield return www.SendWebRequest();
 
        	if(www.isNetworkError || www.isHttpError) {
            		Debug.Log(www.error);
        	}
        	else {
            		// Show results as text
            		Debug.Log(www.downloadHandler.text);
        	}
	}
}
