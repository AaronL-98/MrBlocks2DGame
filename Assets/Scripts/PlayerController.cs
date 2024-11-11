using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private bool spaceBarHit = false;
    public GameObject levelCompleteUI;
    public GameObject levelLostPanel;
    private bool isGameOver = false;

    // Update is called once per frame
    void Update()
    {
        float moveHori = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            spaceBarHit = !spaceBarHit;
        }

        if (spaceBarHit == false && isGameOver == false)
        {
            if(moveHori != 0)
            {
                rb.AddForceX(speed * moveHori);
            }
            if(moveVert != 0)
            {
                rb.AddForceY(speed * moveVert);
            }
        }

        if (isGameOver == true || (moveHori == 0 && moveVert == 0))
        {
            rb.linearVelocity = new Vector2 (0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Door")
        {
            levelCompleteUI.SetActive(true);
            isGameOver = true;
        }
        else if (other.tag == "Enemy")
        {
            Debug.Log("Enemy Hit");
            levelLostPanel.SetActive(true);
            isGameOver = true;
        }

        return;
    }

}
