using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    [SerializeField] GameObject player;

    Transform posessedStuff;



    //Singleton

    private void Awake()
    {
        int numGameManagers = FindObjectsOfType<GameManager>().Length;

        if (numGameManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start () {

        posessedStuff = player.transform.parent;        		
	}

    public void SetPosessedStuff(Transform posessedStuff)
    {
        this.posessedStuff = posessedStuff;
    }

    public Transform GetPosessedStuff()
    {
        return posessedStuff;
    }

   
}
