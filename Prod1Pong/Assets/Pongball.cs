using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pongball : MonoBehaviour
{
    private Vector3 PongDirection;
    [SerializeField] float speed;
    private Rigidbody rb;
    public Vector3 startPosition;
    private Vector3 currentDirection;
    private float addedSpeed;

    public static Pongball instance; 
    void Start()
    {
        float RandomX = Random.Range(-1, 2);
        float RandomZ = Random.Range(-1, 2);
        if (RandomZ == 0)
        {
            RandomZ = -1;
        }
        PongDirection = new Vector3(RandomX, 0, RandomZ);

        
        startPosition = this.transform.position;
        startPosition.y = 3.1f;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(PongDirection * speed, ForceMode.Impulse);


        addedSpeed = speed;
        instance = this;
        StartCoroutine(addForceOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        currentDirection = new Vector3(this.transform.position.x, 0, this.transform.position.y).normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("leftScore")){
            Score.instance.leftScore++;
            StartCoroutine(RespawnBall());
            Debug.Log(Score.instance.leftScore);
        }
        if (other.CompareTag("rightScore"))
        {
            Score.instance.rightScore++;
            StartCoroutine(RespawnBall());
            Debug.Log(Score.instance.rightScore);
        }
    }

    IEnumerator RespawnBall()
    {
        this.gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(2f);
        Score.instance.spawnNewBall(startPosition);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
    IEnumerator addForceOverTime()
    {
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(5f);

            addedSpeed += .5f;
        }
        
    }
    
    public void accelerate()
    {
        rb.AddForce(rb.velocity.normalized * addedSpeed, ForceMode.Impulse);
    }
}
