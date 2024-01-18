using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class ARScript : MonoBehaviour
{
    [Header("SceneID")]
    public static int currentSceneID;
    public int sceneID;
    [Header("Image Target")]
    public GameObject imageTarget1;
    public GameObject imageTarget2;
    public GameObject imageTarget3;
    [Header("DescriptionText")]
    public GameObject descriptionPanel;
    public TextMeshProUGUI descriptionText;
    public List<AugmentedReality> imageTargetInformation;
    [System.Serializable]
    public class AugmentedReality
    {
        public GameObject models;
        public GameObject emissionLamp;
        public GameObject particleSystem1;
        public GameObject particleSystem2;
        [TextArea]
        public string descriptionText;
    }
    private bool isTargetDetected = false;
    // Start is called before the first frame update
    void Start()
    {
        getValue();
        descriptionPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeSceneButton(string sceneName)
    {
        PlayerPrefs.SetInt("SceneID", sceneID);
        SceneManager.LoadScene(sceneName);
    }
    public void DescriptionButton()
    {
        bool isDescPanelActive = descriptionPanel.activeSelf;
        descriptionPanel.SetActive(!isDescPanelActive);
    }
    public void onTargetFound1()
    {
        isTargetDetected = true;
        showDescription(0);
        playAnimation(0);
        StartCoroutine(startParticleSystemWithDelay(0, 4.0f));
        StartCoroutine(showEmersiveLampWithDelay(0, 6.0f));
    }
    public void onTargetFoundNonElectrolyte1(){
        isTargetDetected=true;
        showDescription(0);
        playAnimation(0);
    }
    public void onTargetFound2()
    {
        isTargetDetected = true;
        showDescription(1);
        playAnimation(1);
        StartCoroutine(startParticleSystemWithDelay(1, 4.0f));
        StartCoroutine(showEmersiveLampWithDelay(1, 6.0f));
    }
    public void onTargetFoundNonElectrolyte2(){
        isTargetDetected=true;
        showDescription(1);
        playAnimation(1);
    }
    public void onTargetFound3()
    {
        isTargetDetected = true;
        showDescription(2);
        playAnimation(2);
        StartCoroutine(startParticleSystemWithDelay(2, 4.0f));
        StartCoroutine(showEmersiveLampWithDelay(2, 6.0f));
    }
    public void onTargetFoundNonElectrolyte3(){
        isTargetDetected=true;
        showDescription(2);
        playAnimation(2);
    }
    public void onTargetLost()
    {
        isTargetDetected = false;
        stopAnimation();
        stopParticleSystem();
        deactiveEmersiveLamp();
        UpdateDescriptionText();
    }
    void getValue()
    {
        currentSceneID = PlayerPrefs.GetInt("SceneID", sceneID);
    }
    void showDescription(int index)
    {
        if (isTargetDetected)
        {
            if (index >= 0 && index < imageTargetInformation.Count)
            {
                if (descriptionText != null)
                {
                    descriptionText.text = imageTargetInformation[index].descriptionText;
                }
                else
                {
                    Debug.LogError("Text Mesh Pro UGUI not found or attaches");
                }
            }
            else
            {
                Debug.LogError("Invalid index on imageTargetInformation");
            }
        }
    }
    void UpdateDescriptionText()
    {
        if (descriptionText != null)
        {
            if (isTargetDetected)
            {
                descriptionText.text = "Scan image target yang sesuai untuk menampilkan deskripsi";
            }
            else
            {
                descriptionText.text = "Scan image target yang sesuai untuk menampilkan deskripsi";
            }
        }
        else
        {
            Debug.LogError("TextMeshProUGUI not found!");
        }
    }
    void playAnimation(int index)
    {
        if (index >= 0 && index < imageTargetInformation.Count)
        {
            Animator animator = imageTargetInformation[index].models.GetComponent<Animator>();
            if (animator != null)
            {
                animator.Play("Electrode Metal");
            }
            else
            {
                Debug.LogError("Animator component not found on models.");
            }
        }
        else
        {
            Debug.LogError("Invalid index on imageTargetInformation.");
        }
    }
    void stopAnimation()
    {
        foreach (var info in imageTargetInformation)
        {
            Animator animator = info.models.GetComponent<Animator>();
            if (animator != null)
            {
                animator.Rebind();
            }
        }
    }
    IEnumerator startParticleSystemWithDelay(int index, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (index >= 0 && index < imageTargetInformation.Count)
        {
            ParticleSystem particleSystem1 = imageTargetInformation[index].particleSystem1.GetComponent<ParticleSystem>();
            if (particleSystem1 != null)
            {
                if (!particleSystem1.isPlaying)
                {
                    particleSystem1.Play();
                }
            }
            ParticleSystem particleSystem2 = imageTargetInformation[index].particleSystem2.GetComponent<ParticleSystem>();
            if (particleSystem2 != null)
            {
                if (!particleSystem2.isPlaying)
                {
                    particleSystem2.Play();
                }
            }
            else
            {
                Debug.LogError("ParticleSystem component not found on models.");
            }
        }
        else
        {
            Debug.LogError("Invalid index for imageTargetInformation.");
        }
    }
    void stopParticleSystem()
    {
        foreach (var info in imageTargetInformation)
        {
            ParticleSystem particleSystem1 = info.particleSystem1.GetComponent<ParticleSystem>();
            if (particleSystem1 != null)
            {
                particleSystem1.Stop();
            }
            ParticleSystem particleSystem2 = info.particleSystem2.GetComponent<ParticleSystem>();
            if (particleSystem2 != null)
            {
                particleSystem2.Stop();
            }
        }
    }
    IEnumerator showEmersiveLampWithDelay(int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (index >= 0 && index < imageTargetInformation.Count)
        {
            GameObject emissionLamp = imageTargetInformation[index].emissionLamp;
            if (emissionLamp != null)
            {
                emissionLamp.SetActive(true);
            }
            else
            {
                Debug.LogError("Emission gameobject not found or attaches");
            }
        }
        else
        {
            Debug.LogError("Invalid index on imageTargetInformation");
        }
    }
    void deactiveEmersiveLamp()
    {
        foreach (var info in imageTargetInformation)
        {
            GameObject emissionLamp = info.emissionLamp;
            if (emissionLamp != null)
            {
                // Menonaktifkan game object emissionLamp
                emissionLamp.SetActive(false);
            }
        }
    }
}