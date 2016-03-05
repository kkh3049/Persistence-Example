using UnityEngine;
using System.Collections;

public class SaveLoad : MonoBehaviour {

    void OnGUI()
    {
        if(GUI.Button(new Rect(10, 100, 50, 30), "Save"))
        {
            GameControl.control.Save();
        }
        if(GUI.Button(new Rect(10, 200, 50, 30), "Load"))
        {
            GameControl.control.Load();
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
