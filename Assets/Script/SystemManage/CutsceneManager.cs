using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CutsceneManager : MonoBehaviour
{
    DataCutscene dataCutscene;
    public List<DataCutscene> DCutscene;
    public float timebetweenCutscene = 1f;
    public Image imageCutsceneTemplate;
    public TextMeshProUGUI textCutsceneTemplate;
    public GameObject UI_Cutscene;
    public GameObject UI_Loading;
    
    
    [Space(20)]
    [Header("Animation Text")]
    [SerializeField] private float typingSpeed = 0.1f;
    private string targetText;
    private float charactersPerSecond = 0f;
    private float elapsedTime = 0.0f;
    private int charactersToShow = 0;

    [Space(20)]
    [Header("Animation Image")]
    [SerializeField] private bool fadeIn = false;

    // [SerializeField] private MusicManager musicManager;


    private void Start()
    {
        targetText = textCutsceneTemplate.text;
        textCutsceneTemplate.text = "";
        StartTypingAnimation();
    }



    private void Update()
    {
        Cutscene();
    }

    public void Cutscene()
    {
            // Increase the elapsed time
            elapsedTime += Time.deltaTime;

            // FadeOut();

            // Check if it's time to show the next character
            if (elapsedTime >= typingSpeed)
            {
                // Reset the elapsed time
                elapsedTime = 0.0f;

                // Show the next character
                charactersToShow++;

                // Check if text in the list number1 in DataCutscene is finished next text in the list number2 and so on

                
                if(charactersToShow >= targetText.Length)
                {                    
                    
                    
                    // Check if the list number1 in DataCutscene is finished
                    if (DCutscene.IndexOf(dataCutscene) >= DCutscene.Count - 1)
                    {
                        // Reset the animation parameters
                        elapsedTime = 0.0f;
                        charactersToShow = 0;

                        // Clear the text initially
                        textCutsceneTemplate.text = "";
                        // var butt = buttonExit.GetComponent<Button>();
                        // buttonExit.SetActive(true);
                        // butt.onClick.RemoveAllListeners();
                        // butt.onClick.AddListener(ExitCutscene);
                        // musicManager.PlayMusic();
                        UI_Loading.SetActive(true);
                        UI_Cutscene.SetActive(false);
                        CutsceneManager cutsceneManager = GetComponent<CutsceneManager>();
                        cutsceneManager.enabled = false;
                        Debug.Log("Cutscene Selesai");
                        return;

                        
                    }
                    else
                    {
                    
                        // Reset the animation parameters
                        elapsedTime = 0.0f;
                        charactersToShow = 0;
                        
                        
                        // FadeIn();
                        textCutsceneTemplate.text = "";
                        dataCutscene = DCutscene[DCutscene.IndexOf(dataCutscene) + 1];
                        imageCutsceneTemplate.sprite = dataCutscene.imageCutscene;

                        targetText = dataCutscene.textCutscene;
                    }
                    

                }

                // Update the displayed text with the characters to show
                textCutsceneTemplate.text = targetText.Substring(0, charactersToShow);

            }

        
    }

    public void ExitCutscene()
    {
        UI_Cutscene.SetActive(false);
    }
    

    public void StartTypingAnimation()
    {
        // Reset the animation parameters
        elapsedTime = 0.0f;
        charactersToShow = 0;

        // Clear the text initially
        textCutsceneTemplate.text = "";
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInE());
    }

    IEnumerator FadeInE()
    {
        
        yield return new WaitForSeconds(1);
        imageCutsceneTemplate.CrossFadeAlpha(0, 1, true);
        // Clear the text initially
        
        
        Debug.Log("Fade In");
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutE());
    }

    IEnumerator FadeOutE()
    {
        
        yield return new WaitForSeconds(2);
        imageCutsceneTemplate.CrossFadeAlpha(1, 1, true);
        Debug.Log("Fade Out");
    }
}