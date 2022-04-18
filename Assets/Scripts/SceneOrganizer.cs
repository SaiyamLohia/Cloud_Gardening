using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneOrganizer : MonoBehaviour
{
    GameObject[] flowers;
    int flowerCount;
    int flowerDoneCount = 0;

    [SerializeField] Text levelNumber;
    [SerializeField] GameObject instructions;
    [SerializeField] GameObject options;

    GameObject cloudShooter;
    private void Start()
    {
        flowers = GameObject.FindGameObjectsWithTag("Flower");
        flowerCount = flowers.Length;

        try { levelNumber = GameObject.Find("LevelText").GetComponent<Text>();  }
        catch (NullReferenceException) { }


        if(levelNumber != null)
        {
            levelNumber.text = SceneManager.GetActiveScene().name;
        }

        cloudShooter = GameObject.FindGameObjectWithTag("Shooter");
    }
    void Update()
    {
        if(flowerDoneCount == flowerCount)
        {
            StartCoroutine(LoadNextLevel());
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(instructions != null) instructions.SetActive(false);
            if (options != null)
            {
                options.SetActive(!options.activeSelf);
                cloudShooter.SetActive(!options.activeSelf);
            }
        }
    }

    public void UpdateFlowerDoneCount()
    {
        flowerDoneCount++;
    }

    IEnumerator LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) yield break;
        yield return new WaitForSeconds(1);
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
            if (levelNumber != null)
            {
                levelNumber.text = SceneManager.GetActiveScene().name;
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void SkipLevel()
    {
        options.SetActive(false);
        StartCoroutine(LoadNextLevel());
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenInfo()
    {
        if(instructions != null)
        {
            instructions.SetActive(true);
        }
    }
}
