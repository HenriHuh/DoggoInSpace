using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
   


    //Level updates when objects make full circle. More objects will be spawned  with this command
    public float Level = 1f;
    
    //Makes values to choose what object will spawn
    int ObjectSpawn = 0;

    //Calculates how many object get spawned
    int JunkCalc = 0;
    int JunkMax = 0;

    public GameObject hpbone1;
    public GameObject hpmax;
    public GameObject deadguy;
    public GameObject satellite;
    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;



    void Update()
    {



        ObjectSpawn = Random.Range(0, 101);


        //Secret level button - DELETE THIS LATER
        if (Input.GetKeyDown("c"))
            {
            Level += 1f;
        }



        if (Level == 1f)
            {
            JunkMax = 20;
        }

        if (Level == 2f)
        {
            JunkMax = 25;
        }

        if (Level == 3f)
        {
            JunkMax = 30;
        }

        if (Level == 4f)
        {
            JunkMax = 40;
        }

        if (Level == 5f)
        {
            JunkMax = 50;
        }

        if (Level == 6f)
        {
            JunkMax = 60;
        }

        if (Level == 7f)
        {
            JunkMax = 70;
        }

        if (Level == 8f)
        {
            JunkMax = 80;
        }

        if (Level == 9f)
        {
            JunkMax = 90;
        }

        if (Level == 10f)
        {
            JunkMax = 100;
        }


        //HP Bones spawner level 1 (1-6)                                                            
        if (((ObjectSpawn >= 0) && (ObjectSpawn <= 7) && JunkCalc <= JunkMax))
        {
            Instantiate(hpbone1);
            //new GameObject("hpbone1");
            gameObject.layer = LayerMask.NameToLayer("HP");
            JunkCalc += 1;
        }

        //HP Max spawner level 1 (7)
        if (((ObjectSpawn >= 6) && (ObjectSpawn <= 8) && JunkCalc <= JunkMax))
        {
            Instantiate(hpmax);
            //new GameObject("hpmax");
            gameObject.layer = LayerMask.NameToLayer("HP Max");
            JunkCalc += 1;
        }

        //Deadguy spawner level 1 (8-9)
        if (((ObjectSpawn >=7) && (ObjectSpawn <= 10) && JunkCalc <= JunkMax))
        {
            Instantiate(deadguy);
            //new GameObject("deadguy");
            gameObject.layer = LayerMask.NameToLayer("Deadman");
            JunkCalc += 1;
        }


        //Satellite spawner level 1 (10-20)
        if ((ObjectSpawn >= 9) && (ObjectSpawn <= 21) && JunkCalc <= JunkMax)
        {
            Instantiate(satellite);
            //new GameObject("satellite");
            gameObject.layer = LayerMask.NameToLayer("Satellite");
            JunkCalc += 1;
        }


        //Asteroid1 spawner level 1 (20-50)
        if (((ObjectSpawn >= 19) && (ObjectSpawn <= 51) && JunkCalc <= JunkMax))
        {
            Instantiate(asteroid1);
            //new GameObject("asteroid1");
            gameObject.layer = LayerMask.NameToLayer("Asteroids");
            JunkCalc += 1;
        }
        //Asteroid2 spawner level 1 (50-75)
        if (((ObjectSpawn >= 49) && (ObjectSpawn <= 76) && JunkCalc <= JunkMax))
        {
            Instantiate(asteroid2);
            //new GameObject("asteroid2");
            gameObject.layer = LayerMask.NameToLayer("Asteroids");
            JunkCalc += 1;
        }


        //Asteroid3 spawner level 1 (75-100)
        if (((ObjectSpawn >= 74) && (ObjectSpawn <= 101) && JunkCalc <= JunkMax))
        {
            Instantiate(asteroid3);
            //new GameObject("asteroid3");
            gameObject.layer = LayerMask.NameToLayer("Asteroids");
            JunkCalc += 1;
        }


}
}
