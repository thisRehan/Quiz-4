using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] Tilemap[] levelTile;
    [SerializeField] GameObject levelButton;
    [SerializeField] Text GameNameText;
    [SerializeField] PlayerController player;
    [SerializeField] Button restartButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button playPause;
    [SerializeField] GameObject Enemy;
    private GameObject enemyClone;
    private bool previousLevelComplete;
    private int enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = 0;
        previousLevelComplete = true;
    }

    // Update is called once per frame
    void Update()
    {
        levelComplete();
    }
    public void gameStart()
    {
        levelButton.gameObject.SetActive(false);
        GameNameText.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        playPause.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
        enemyClone = Instantiate(Enemy, Enemy.transform.position, Enemy.transform.rotation);
        StartCoroutine(destroyEnemy());
    }
    IEnumerator destroyEnemy()
    {
        yield return new WaitForSeconds(2);
        Destroy(enemyClone);
    }
    public void setLevel(int level)
    {
        if(level == 0)
        {
            gameStart();
            levelTile[level].gameObject.SetActive(true);
        }
        else if(level !=0 && previousLevelComplete)
        {
            gameStart();
            levelTile[level].gameObject.SetActive(true);
        }
      
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Back()
    {
        levelButton.gameObject.SetActive(true);
        GameNameText.gameObject.SetActive(true);
        playPause.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        for(int level = 0; level <levelTile.Length; level++)
        {
            levelTile[level].gameObject.SetActive(false);
        }
    }
    public void levelComplete()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemy == 0)
            previousLevelComplete = true;
        else
            previousLevelComplete = false;
    }

}
