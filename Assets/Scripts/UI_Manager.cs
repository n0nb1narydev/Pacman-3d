using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{  
    [SerializeField]
    private Text _readyText;
    [SerializeField]
    private Text _winnerText;    
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    public int currentScore;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Image _livesImg;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;
    private GameManager _gameManager;
    private Player _player;
    [SerializeField]
    private Text _yellowText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReadyTextOff());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void UpdateYellowCount(int yellowCount)
    {
        _yellowText.text = "Pellets: " + yellowCount;

        if (yellowCount == 0)
        {
            GameOverWinner();
        }     
    }
    public void UpdateLives(int currentLives)
    {
      //access display image sprite and give it a new one   
      _livesImg.sprite = _liveSprites[currentLives];
    }

    void GameOverWinner()
    {
        _gameManager.GameOver();
        _winnerText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        Destroy(_player.gameObject, 1f);
        // StartCoroutine(FlashingGameOverText());
    }
    IEnumerator ReadyTextOff()
    {
        yield return new WaitForSeconds(4.2f);
        _readyText.gameObject.SetActive(false);
    }
    public void UpdateScore(int currentScore)
    {
        _scoreText.text = "Score: " + currentScore;
    }
}
