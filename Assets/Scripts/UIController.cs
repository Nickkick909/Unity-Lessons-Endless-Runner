using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI distanceTravelledNumber;
    [SerializeField] TextMeshProUGUI coinsCollectedNumber;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Player player;
    [SerializeField] GameObject gameMusic;
    [SerializeField] GameObject sky;

    public void RetryGame()
    {
        SceneManager.LoadScene("Endless Runner");
    }

    public void ShowGameOver()
    {
        sky.SetActive(false);
        gameMusic.SetActive(false);
        gameOverScreen.SetActive(true);
        float roundedDistance = Mathf.Ceil(player.distanceTravelled);
        distanceTravelledNumber.text = roundedDistance.ToString();
        coinsCollectedNumber.text = player.coinsCollected.ToString();
    }
}
