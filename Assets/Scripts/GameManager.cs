using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject player;
    public GameObject spawner;
    public GameObject gameOver;
    public GameObject gameTitle;
    public GameObject scoreUI;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver
    }

    GameManagerState GMState;

    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    void UpdateGMState()
    {
        switch (GMState) 
        {
            case GameManagerState.Opening:

                gameOver.SetActive(false);

                gameTitle.SetActive(true);

                playButton.SetActive(true);

                break;
            case GameManagerState.Gameplay:

                scoreUI.GetComponent<GameScore>().Score = 0;

                playButton.SetActive(false);

                gameTitle.SetActive(false);

                player.GetComponent<Player>().Init();

                spawner.GetComponent<Spawner>().ScheduleEnemySpawn();

                break;
            case GameManagerState.GameOver:

                spawner.GetComponent<Spawner>().UnScheduleEnemySpawn();

                gameOver.SetActive(true);

                Invoke("ChangeToOpeningState", 3f);

                break;
        }
    }

    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGMState();
    }

    public void SetGMState(GameManagerState state)
    {
        GMState = state;
        UpdateGMState();
    }

    public void ChangeToOpeningState()
    {
        SetGMState(GameManagerState.Opening); 
    }
}
