using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float jumpForce;
    float score;
    public Text scoreTxt;
    GameObject endPanel;
    Text lastScore;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        endPanel = GameObject.Find("EndPanel");
        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "" + score;
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "point")
        {
            score++;
            Debug.Log(score);
        }
        if(collision.gameObject.tag == "pipa")
        {
            endPanel.SetActive(true);
            lastScore = GameObject.Find("Scorelast").GetComponent<Text>();
            lastScore.text =  "YOUR SCORE IS \n" + score;
            Destroy(gameObject);
            return;
        }
    }
  
}
