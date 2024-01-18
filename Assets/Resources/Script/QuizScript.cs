using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;

public class QuizScript : MonoBehaviour
{
    public static int currentSceneID;
    public int sceneID;
    public Image[] feedback;
    void Start()
    {
        GetValue();
        PlayerPrefs.SetInt("Score", 0);
        feedback[0].gameObject.SetActive(false);
        feedback[1].gameObject.SetActive(false);
    }

    void Update()
    {

    }

    void GetValue()
    {
        currentSceneID = PlayerPrefs.GetInt("SceneID", sceneID);
    }

    public void Response(bool answer)
    {
        if (answer)
        {
            int currentScore = PlayerPrefs.GetInt("Score", 0);
            PlayerPrefs.SetInt("Score", currentScore + 10);
            feedback[0].gameObject.SetActive(false);
            feedback[0].gameObject.SetActive(true);
        }else{
            feedback[1].gameObject.SetActive(false);
            feedback[1].gameObject.SetActive(true);
        }
        SequenceManagerScript sequenceManager = FindAnyObjectByType<SequenceManagerScript>();
        if (sequenceManager != null)
        {
            sequenceManager.GetSiblingIndexes();
        }
    }

    public void ChangeSceneButton(string sceneName)
    {
        PlayerPrefs.SetInt("SceneID", sceneID);
        SceneManager.LoadScene(sceneName);
    }
}
