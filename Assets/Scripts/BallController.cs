using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private float jumpDistance = 10f;
    private float jumpHeight = 2f; //2f
    private float jumpDuration = 1f; //
   

    private float laneOffset = 6f;
    // x -> -3  (left)   3(right)

    private int currentLane = 1;

    private bool isJumping = false;

    public bool isOnTile = true;

    public bool isGameOver = false;
      
    public int testScore = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextInGameOverSreen;

    public GameObject currentScoreCanvas;
    public GameObject gameOverCanvas;

    public AudioSource jumpSound;
    public AudioSource gameOverSound;
    private bool isGameOverSoundplayed = false;

    // private Vector2 startTouchPos;
    



    // private void FixedUpdate()
    // {


    // }
    void Start()
    {
        gameOverCanvas.SetActive(false);
        currentScoreCanvas.SetActive(true);

        AudioSource[] audioSources = GetComponents<AudioSource>();
        jumpSound = audioSources[0];
        gameOverSound = audioSources[1];
        
    }

    private void Update()
    {
        // HandleDragInput();
        HandleKeyInput();
        HandleTouchInput();
        if (!isJumping && isOnTile)  //isOnTile
        {
            StartCoroutine(PerformJump());
        }

        if (testScore > 20)
        {
            jumpDuration = 0.9f;
            if (testScore > 50)
            {
                jumpDuration = 0.8f;
                if (testScore > 100)
                {
                    jumpDuration = 0.7f;
                    if (testScore > 150)
                    {
                        jumpDuration = 0.65f;
                        if (testScore > 200)
                        {
                            jumpDuration = 0.6f;
                            if (testScore > 250)
                            {
                                jumpDuration = 0.55f;
                                if (testScore > 320)
                                {
                                    jumpDuration = 0.50f;
                                    if(testScore> 450)
                                    {
                                        jumpDuration = 0.45f;
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }

        if(transform.position.y < -10)
        {
            if (!isGameOverSoundplayed)
            {
                gameOverSound.Play();
                isGameOverSoundplayed = true;
            }
            
            // Debug.Log("GameOver.........");
            isGameOver = true;
            scoreTextInGameOverSreen.text = "Your Score : "+testScore.ToString();
            currentScoreCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);
        }


    }

    // void TryJump()
    // {
    //     if(!isJumping && isOnTile)
    //     {
    //         StartCoroutine(PerformJump());
    //     }
    // }

    // void HandleDragInput()
    // {
    //     if (Input.touchCount == 0) return;

    //     Touch t = Input.GetTouch(0);

    //     if (t.phase == TouchPhase.Began)
    //     {
    //         startTouchPos = t.position;
    //     }
    //     else if (t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary)
    //     {
    //         float dx = t.position.x - startTouchPos.x;
    //         float dragSensitivity = 0.02f;

    //         float normalizedX = dx * dragSensitivity;

    //         currentLane = (normalizedX < 0) ? 0 : 1;
    //     }
    // }

    void HandleKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentLane = 0;
            // Debug.Log("leftArrowPressed");
            // TryJump();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentLane = 1;
            // TryJump();
        }
    }

    void HandleTouchInput()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            Vector2 touchPos = Input.GetTouch(0).position;

            if(touchPos.x < Screen.width * 0.5)
            {
                currentLane = 0;
            }
            else
            {
                currentLane = 1;
            }
            // TryJump();
        }
    }




    System.Collections.IEnumerator PerformJump()
    {
        isJumping = true;
        jumpSound.Play();
        isOnTile = false; //tst

        Vector3 start = transform.position;

        float forward = start.z + jumpDistance;

        float targetX = (currentLane == 0) ? -laneOffset * 0.5f : laneOffset * 0.5f;

        Vector3 end = new Vector3(targetX, start.y, forward);

        float t = 0f;
          while (t < 1f)   
        {
            t += Time.deltaTime / jumpDuration;

            // Parabolic jump
            float height = 4f * jumpHeight * t * (1f - t);

            transform.position = Vector3.Lerp(start, end, t) + Vector3.up * height;

            yield return null;
        }

        transform.position = end;
        isJumping = false;
        // isOnTile = true; //tst
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            isOnTile = true;
            // Debug.Log("done");
            testScore += 1; //tst
            scoreText.text = testScore.ToString();
        }
    }
}
