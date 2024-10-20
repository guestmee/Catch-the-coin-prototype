using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PLAYER : MonoBehaviour
{
    public float playerspeed;
    public GameObject particlecoin;
    public int score;
    [SerializeField] EVENTSYSTEM _eventsystem;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }
    private void PositionChecker()
    {
        if (this.transform.position.x > 10.8f || transform.transform.position.x < -10.8f)
        {
            if (this.transform.position.x > 10.8f)
            {
                this.transform.position = new Vector3(this.transform.position.x - 21.5f, this.transform.position.y, this.transform.position.z);
            }
            else if (this.transform.position.x < -10.8f)
            {
                this.transform.position = new Vector3(this.transform.position.x + 21.5f, this.transform.position.y, this.transform.position.z);
            }
        }
    }
    private void UpdateMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.position = new Vector3(this.transform.position.x - playerspeed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.position = new Vector3(this.transform.position.x + playerspeed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        PositionChecker();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "coin") { return; }
        Debug.Log("Touch Event");
        GameObject Particle = Instantiate(particlecoin);
        Particle.transform.position = collision.transform.position;
        Destroy(Particle, 2.0f);
        Destroy(collision.gameObject);
        score += 1;
        _eventsystem.SynchronizeScore(score);
    }
}
