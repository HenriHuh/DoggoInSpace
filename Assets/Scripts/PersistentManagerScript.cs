using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PersistentManagerScript : MonoBehaviour
{
    public static PersistentManagerScript Instance { get; private set; }

    //public int Value;
    public float Value = 0;

    bool Check = false;

    string sceneName;



    
    private void Awake()
    {

        
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        
            Destroy(gameObject);
        

    


    }
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (Check == false)
        {
            Value = Value - Value;
            Check = true;
        }



    }



        void Update()
        {
        if (sceneName == "Level_1_Scene")
        {

            if (Check == true)
            {
                Value += Time.deltaTime;
            }

        }




        //Value += Time.deltaTime;





        /*
            timeLevel += Time.deltaTime;

            if (timeLevel >= 30)
            {

                GameObject.Find("Spawner").GetComponent<Spawner>().Level += 1f;
                timeLevel = 0;
            }
            */


    }





    

}
