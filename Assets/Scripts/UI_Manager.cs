using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{  
    [SerializeField]
    private Text _readyText;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    public int currentScore;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Image _livesImg;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReadyTextOff());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLives(int currentLives)
    {
      //access display image sprite and give it a new one   
      _livesImg.sprite = _liveSprites[currentLives];
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
