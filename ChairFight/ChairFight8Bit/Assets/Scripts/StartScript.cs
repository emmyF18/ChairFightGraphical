using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Scenes/Fighting");
    } 
    public void StrixGame()
    {
        PlayerPrefs.SetString("Player","Strix");
        PlayerPrefs.Save();
        LoadGame();
    } 
    public void PaultinGame()
    {
        PlayerPrefs.SetString("Player","Paultin");
        PlayerPrefs.Save();
        LoadGame();
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
