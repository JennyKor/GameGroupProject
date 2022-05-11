using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    public int PlayerHealth = 1000;
    public int currentHealth;
    public HealthBar healthbar;
    public GameObject gameOver;
    public Button playagain;
    public Button backToMenu;
    KillCounter counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = GameObject.FindGameObjectWithTag("GameManager").GetComponent<KillCounter>();
        counter.ResetScore();
        gameOver.SetActive(false);
        healthbar.SetMaxHealth(PlayerHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth = PlayerHealth - damage;
        PlayerHealth -= damage;
        if (PlayerHealth <= 0)
        {
            Debug.Log("Dead");
            gameOver.SetActive(true);
            Time.timeScale = 0;
            PlayerHealth = 1000;
            playagain.onClick.AddListener(RestartGame);
            backToMenu.onClick.AddListener(BackToMenu);

        }

        healthbar.SetHealth(currentHealth);
    }

      void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    void BackToMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
