using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public ShipScript ship;
    public LogicScript logic;

    public GameObject GameOverScreen;
    public GameObject StartMenuScreen;
    public GameObject OptionsButton;
    public GameObject OptionsMenu;
    public GameObject ExitButton;

    public bool GameIsInStartMenu;
    public bool GameIsRestarted;

    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipScript>();
        StartMenu();
        Debug.Log("Logic Script has finished initializing...");
        Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsRestarted) StartGame(); 
        if (Input.GetKeyDown(KeyCode.F1)) ToggleFullScreen();
        if (Input.GetKeyDown(KeyCode.F12)) ExitGame();
    }

    public void ToggleFullScreen()
    {
        if (Screen.fullScreenMode == FullScreenMode.Windowed)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            Debug.Log("Full Screen Mode Entered");
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            Debug.Log("Windowed Mode Entered");
        }
    }

    public void StartMenu()
    {
        GameIsInStartMenu = true;
        ship.FlightPersistance = true;
        StartMenuScreen.SetActive(true);
        OptionsButton.SetActive(true);
        ExitButton.SetActive(true);
        Debug.Log("Start Menu is up...");
    }

    // Options Menu Stuff

    public void ToggleOptions() {
        Debug.Log("Options button clicked.");
        if (OptionsMenu.activeInHierarchy == false) OptionsMenu.SetActive(true);
        else OptionsMenu.SetActive(false);
    }

    // Start, Restart, Exit

    public void StartGame()
    {
        
        logic.GameIsRunning = true;
        GameIsInStartMenu = false;
        ship.FlightPersistance = false;
        StartMenuScreen.SetActive(false);
        ExitButton.SetActive(false);
        if (GameIsRestarted)
        {
            GameIsRestarted = false;
            Debug.Log("Game has been restarted.");
        }
        else Debug.Log("Game has been started.");

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainGame")); // This makes newly spawned objects appear in the MainGame Scene (instead of another active scene)
        Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);

        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        GameIsRestarted = true;
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOverMenu()
    {
        GameOverScreen.SetActive(true);
        ExitButton.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false; // Comment out this line for export.
        Debug.Log("Orbiteer Application Ending...");
    }
}
