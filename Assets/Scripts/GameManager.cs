using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform Ground;
    public Transform Player;
    public GameObject GameOverUI;
    public TextMeshProUGUI NewHighScoreUI;
    float initSound;
    public int scoreincrease = CoinsManager.scoreIncrease;
    Vector3 initPosition;
    Vector3 GinitPosition;
    // private string ObstaclesTag = "Obstacles";
    private void Awake() {
        GinitPosition = Ground.position;
        initPosition = Player.position;
        initSound = PlayerManager.soundVolume;
    }

    private void Update(){
        Ground.position = new Vector3(3.5f, -0.25f, Player.position.z);
        if (Player.position.y <= -25){
            PlayerManager.isDead = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            sceneManager.GoToMainMenu();
        }
        PlayerDead(PlayerManager.isDead);
        increaseSpeed(ref scoreincrease);
    }
    private void GameOver()
    {
        if (CoinsManager.Score > Score.highScore){
            Score.highScore = CoinsManager.Score;
            NewHighScoreUI.text = "New High Score ! " + (Score.highScore).ToString();
            NewHighScoreUI.gameObject.SetActive(true);
        }
        Ground.gameObject.SetActive(false);
        Player.gameObject.SetActive(false);
        GameOverUI.SetActive(true);
        Ground.position = GinitPosition;
        Player.position = initPosition;
        Time.timeScale = 0;
    }

    public void PlayerDead(bool ans=false)
    {
        if (ans){
            GameOver();
            if (Input.anyKeyDown){
                resetState();
            }
        }
    }

    private void resetState()
    {
        CoinsManager.Score = 0;
        CoinsManager.redScore = 0;
        CoinsManager.blueScore = 0;
        CoinsManager.yellowScore = 0;
        scoreincrease = CoinsManager.scoreIncrease;
        PlayerManager.Speed = 4f;
        PlayerManager.isDead = false;
        PlayerManager.soundVolume = initSound;
        Time.timeScale = 1;
        Ground.gameObject.SetActive(true);
        Player.gameObject.SetActive(true);
        GameOverUI.SetActive(false);
        NewHighScoreUI.gameObject.SetActive(false);
    }

    public void increaseSpeed(ref int s)
    {
        if (CoinsManager.Score > s && PlayerManager.Speed <= PlayerManager.maxSpeed){
            s *= 2;
            PlayerManager.Speed += PlayerManager.speedMultiplier;
            Debug.Log(s);
        }
    }
}
