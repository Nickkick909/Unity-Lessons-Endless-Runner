using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI distanceTravelledNumber;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Player player;

    public void RetryGame()
    {
        Debug.Log("Restart game");
        SceneManager.LoadScene("Endless Runner");
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
        float roundedDistance = Mathf.Ceil(player.distanceTravelled);
        distanceTravelledNumber.text = roundedDistance.ToString();
    }
}
