using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneManagerScript : MonoBehaviour
{
    public Text ValueTxt;



    private void Start()
    {
        //Mathf.Round -> deletes decimals
        ValueTxt.text = Mathf.Round(PersistentManagerScript.Instance.Value).ToString();

        //Time + Seconds added
        //ValueTxt.text = (Mathf.Round(PersistentManagerScript.Instance.Value).ToString() + " Seconds");

        //Original -> with all decimals (0.000000)
        //ValueTxt.text = PersistentManagerScript.Instance.Value.ToString();
    }

    public void GoToFirstScene()
    {
        
        SceneManager.LoadScene("Level_1_Scene");
        PersistentManagerScript.Instance.Value++;

    }

    public void GoToSecondScene()
    {
        SceneManager.LoadScene("EndMenuScene");
        PersistentManagerScript.Instance.Value++;

    }


}
