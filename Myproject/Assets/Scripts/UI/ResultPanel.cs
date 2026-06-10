using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private GameObject panelRoot;
    [SerializeField] private TMP_Text finalScoreText;

    private void Start()
    {
        Hide();
    }

    public void Show(int score)
    {
        panelRoot.SetActive(true);
        finalScoreText.text = $"Final Score : {score}";
    }

    public void Hide()
    {
        panelRoot.SetActive(false);
    }

    public void OnRestartClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
