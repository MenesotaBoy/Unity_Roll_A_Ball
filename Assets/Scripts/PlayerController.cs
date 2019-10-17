using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] Text scoreText;
    [SerializeField] Text winText;
    int score;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetCoutText();
        winText.text = "";
    }

	void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hor, 0.0f, ver);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider pickUp)
    {
        if (pickUp.gameObject.CompareTag("Pick Up"))
        {
            pickUp.gameObject.SetActive(false);
            score++;
            SetCoutText();
        }
        //Destroy(pickUp.gameObject);
    }

    void SetCoutText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 12)
            winText.text = "So EZ!";
    }


}
