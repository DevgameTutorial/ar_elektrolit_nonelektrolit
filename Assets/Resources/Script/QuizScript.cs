using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizScript : MonoBehaviour
{
    public static int currentSceneID;
    public int sceneID;
    // Start is called before the first frame update
    void Start()
    {
        getValue();
        PlayerPrefs.SetInt("Score",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getValue(){
        currentSceneID=PlayerPrefs.GetInt("SceneID",sceneID);
    }

    public void Response(bool answer){
        if(answer){
            int currentScore=PlayerPrefs.GetInt("Score",0);
            PlayerPrefs.SetInt("Score",currentScore +10);
        }
        SequenceManagerScript sequenceManager=FindAnyObjectByType<SequenceManagerScript>();
        if(sequenceManager!=null){
            sequenceManager.GetSiblingIndexes();
        }
    }

    public void ChangeSceneButton(string sceneName){
        PlayerPrefs.SetInt("SceneID",sceneID);
        SceneManager.LoadScene(sceneName);
    }
}
