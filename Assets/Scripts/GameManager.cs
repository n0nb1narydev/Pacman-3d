using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    private bool _isGameOver;
        // Update is called once per frame
    
    private void Update() 
    {
#if UNITY_IOS
    if (Input.touchCount >= 2  && _isGameOver == true)
     {
          SceneManager.LoadScene(0); 
     }

#elif UNITY_ANDROID
    if (Input.touchCount >= 2  && _isGameOver == true)
     {
          SceneManager.LoadScene(0); 
     }
#else
    if(Input.GetKeyDown(KeyCode.Return) && _isGameOver == true)
        {
            SceneManager.LoadScene(0); //Current Game Scene
        }
#endif
    }
        public void GameOver()
        {
            _isGameOver = true;
            
        }
    

}
