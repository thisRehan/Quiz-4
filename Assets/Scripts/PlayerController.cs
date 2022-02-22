using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    private GameObject bombClone;
    int speed = 5;
    bool play;
    // Start is called before the first frame update
    void Start()
    {
        play = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    public void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * speed * Time.deltaTime * verticalInput);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            bombClone = Instantiate(bomb, transform.position, transform.rotation);
            StartCoroutine(bombExplode());
        }
    }
    IEnumerator bombExplode()
    {
        yield return new WaitForSeconds(2);
        Destroy(bombClone);
    }
    public void PlayPause()
    {
        if(play)
        {
            Time.timeScale = 0;
            play = false;
        } 
        else if(!play)
        {
            Time.timeScale = 1;
            play = true;
        }
    }
    
}
