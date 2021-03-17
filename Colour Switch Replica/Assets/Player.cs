using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public float jumpForce = 10f;

    public Rigidbody2D rb;

    public string currentColour;

    public SpriteRenderer sr;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPurple;

    void Start()
    {
        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
            
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        // Called everytime we collide with something
        // Gather information on what we collided with
        
        if(col.tag == "ColourChanger")
        {
            // We messed up
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }

        if(col.tag != currentColour)
        {
            // We messed up
            Debug.Log("Game Over!");
            // Load reset if we failed
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0,4);

        switch(index)
        {
            case 0:
                currentColour = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColour = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColour = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColour = "Purple";
                sr.color = colorPurple;
                break;
        }
    }
}
