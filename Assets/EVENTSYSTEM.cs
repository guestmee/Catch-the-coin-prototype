using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EVENTSYSTEM : MonoBehaviour
{
    System.Random r = new System.Random();
    public int timetodrop, timetodrop2;
    public Camera cam;
    public GameObject prefab;
    [SerializeField] private TextMeshProUGUI _scoretext;
    [SerializeField] private TextMeshProUGUI _endgametext;
    bool endgame = false;
    private IEnumerator emulator()
    {
        print("Waiting");
        yield return new WaitForSeconds(r.Next(timetodrop, timetodrop2));
        print("Droping");
        GameObject objectcoin = Instantiate(prefab);
        objectcoin.transform.position = new Vector3(r.Next(-10, 10), 12, -1.5f);
        StartCoroutine(emulator());
    }

    public void SynchronizeScore(int score)
    {
        Debug.Log("Synchronizing Score");
        _scoretext.text = "" + score;
    }

    public void EndGame(string name, GameObject transform)
    {
        Debug.Log(String.Format("End Game EVENT -> END BY TOUCHING {0}", name));
        endgame = true;
        cam.gameObject.transform.LookAt(transform.transform.position);
        Time.timeScale = 0.0f;
        _endgametext.gameObject.SetActive(true);
        _endgametext.text = String.Format("You Lose...By Ball touch {0} your score was {1}. Press Space to play again!", name, _scoretext.text);
       
    }
    void Start()
    {
        StartCoroutine(emulator());
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && endgame)
        {
            SceneManager.LoadScene(0);
        }
    }
}
