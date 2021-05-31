using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
public class Play : MonoBehaviour
{
   public void PlayGame() {
        SceneManager.LoadScene(1);
    } 
    public void PlayOne() {
        SceneManager.LoadScene(1);
    }
    public void PlayTwo() {
        SceneManager.LoadScene(2);
    }
    public void PlayThree() {
        SceneManager.LoadScene(3);
    } 
}
