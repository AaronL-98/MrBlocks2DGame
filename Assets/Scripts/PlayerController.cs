using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private bool spaceBarHit = false;
    public GameObject levelCompleteUI;
    public GameObject levelLostPanel;
    public CameraShake camShaker;
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
        if(other.gameObject.CompareTag("Door"))
        {
            Debug.Log("Door Hit");
            levelCompleteUI.SetActive(true);
            isGameOver = true;
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit");
            levelLostPanel.SetActive(true);
            isGameOver = true;
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall Hit - Cam Shake");
            // Trigger the camera shake
            if (camShaker != null)
            {
                StartCoroutine(camShaker.Shake(0.5f, 1f));
            }
        }
    }

}
