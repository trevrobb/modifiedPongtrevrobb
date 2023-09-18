using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;
    public int leftScore;
    public int rightScore;
    [SerializeField] GameObject ballPrefab;
    bool multipleMode;

    float startWaitMM;
    void Start()
    {
        leftScore = 0;
        rightScore = 0;
        instance = this;

        multipleMode = false;
        startWaitMM = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !multipleMode)
        {
            multipleMode = true;
            spawnNewBall(Pongball.instance.startPosition);
            StartCoroutine(multipleSpawnMode());
            
        }
    }

    public void spawnNewBall(Vector3 spawnPos)
    {
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = spawnPos;
    }

    IEnumerator multipleSpawnMode()
    {
        for (int i = 0; i< 50; i++)
        {
            yield return new WaitForSeconds(startWaitMM);
            spawnNewBall(Pongball.instance.startPosition);
            int speedUp = Random.Range(0, 100);
            if (speedUp > 90) { startWaitMM -= .25f; }
        }
        
    }
}
