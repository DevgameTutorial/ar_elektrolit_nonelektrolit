using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainScript : MonoBehaviour
{
    public GameObject homePanel;
    public GameObject selectPanel;
    public GameObject strongElectrolytePanel;
    public GameObject weakElectrolytePanel;
    public GameObject nonElectrolytePanel;
    public GameObject infoPanel;
    public GameObject guidePanel;

    public static int currentSceneID;
    public int sceneID;
    // Start is called before the first frame update
    void Start()
    {
        getValue();
        if (sceneID == 0)
        {
            sceneID = 0;
            homePanel.SetActive(true);
            selectPanel.SetActive(false);
            strongElectrolytePanel.SetActive(false);
            weakElectrolytePanel.SetActive(false);
            nonElectrolytePanel.SetActive(false);
            infoPanel.SetActive(false);
            guidePanel.SetActive(false);
        }
        else if (sceneID == 1)
        {
            homePanel.SetActive(false);
            selectPanel.SetActive(false);
            strongElectrolytePanel.SetActive(true);
            weakElectrolytePanel.SetActive(false);
            nonElectrolytePanel.SetActive(false);
            infoPanel.SetActive(false);
            guidePanel.SetActive(false);
        }
        else if (sceneID == 2)
        {
            homePanel.SetActive(false);
            selectPanel.SetActive(false);
            strongElectrolytePanel.SetActive(false);
            weakElectrolytePanel.SetActive(true);
            nonElectrolytePanel.SetActive(false);
            infoPanel.SetActive(false);
            guidePanel.SetActive(false);
        }
        else if (sceneID == 3)
        {
            homePanel.SetActive(false);
            selectPanel.SetActive(false);
            strongElectrolytePanel.SetActive(false);
            weakElectrolytePanel.SetActive(false);
            nonElectrolytePanel.SetActive(true);
            infoPanel.SetActive(false);
            guidePanel.SetActive(false);
        }
        else if (sceneID == 4)
        {
            homePanel.SetActive(true);
            selectPanel.SetActive(false);
            strongElectrolytePanel.SetActive(false);
            weakElectrolytePanel.SetActive(false);
            nonElectrolytePanel.SetActive(false);
            infoPanel.SetActive(false);
            guidePanel.SetActive(false);
        }
        PlayerPrefs.SetInt("SceneID", currentSceneID);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("SceneID", currentSceneID);
    }

    void getValue()
    {
        sceneID = PlayerPrefs.GetInt("SceneID", currentSceneID);
    }

    public void StartButton()
    {
        homePanel.SetActive(false);
        selectPanel.SetActive(true);
    }
    public void StrongElectrolyteButton()
    {
        sceneID = 1;
        selectPanel.SetActive(false);
        strongElectrolytePanel.SetActive(true);
    }
    public void WeakElectrolyteButton()
    {
        sceneID = 2;
        selectPanel.SetActive(false);
        weakElectrolytePanel.SetActive(true);
    }
    public void NonElectrolyteButton()
    {
        sceneID = 3;
        selectPanel.SetActive(false);
        nonElectrolytePanel.SetActive(true);
    }
    public void InfoButton()
    {
        homePanel.SetActive(false);
        infoPanel.SetActive(true);
    }
    public void GuideButton()
    {
        homePanel.SetActive(false);
        guidePanel.SetActive(true);
    }
    public void BackButton()
    {
        if (sceneID == 1 || sceneID == 2 || sceneID == 3)
        {
            selectPanel.SetActive(true);
            strongElectrolytePanel.SetActive(false);
            weakElectrolytePanel.SetActive(false);
            nonElectrolytePanel.SetActive(false);
            sceneID = 0;

        }
        else
        {
            homePanel.SetActive(true);
            selectPanel.SetActive(false);
            infoPanel.SetActive(false);
            guidePanel.SetActive(false);
            sceneID=0;
        }
    }
    public void ChangeSceneButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void OpenURLButton(string URL)
    {
        Application.OpenURL(URL);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
