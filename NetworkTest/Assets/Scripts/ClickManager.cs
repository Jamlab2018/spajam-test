using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour {

	public InputField inputField;

	public void Click(){ 
		inputField.text = FileManager.Apply ();
	}
}
