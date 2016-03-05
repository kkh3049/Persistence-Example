using UnityEngine;
using System.Collections;

public class PickupPic : MonoBehaviour {
    public static readonly int NUM_PICS = 6;
    public static int curId;
    public int id = -1;

    //Will this always assign the pictures the same id between different instances of the game?
    public void assignId()
    {
        if (id == -1)
        {
            id = curId;
            ++curId;
        }
    }

    void Awake()
    {
        assignId();
    }
   

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Doesn't allow for loading a state with more pictures while in game. 
        if (!GameControl.control.remainingPics[id])
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameControl.control.remainingPics[id] = false;
        }
    }
}
