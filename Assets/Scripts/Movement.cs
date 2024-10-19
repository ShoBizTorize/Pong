using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 direction = Vector2.right;
    float speed = 4.0f;
    float time = 0.0f;

    public GameObject Player1;
    public GameObject Player2;
    private float NoBounce=0f;
    
    int Player_Score_1 = 0;
    int Player_Score_2 = 0;
    int Scoring_Point = 1;
    void Start()
    {
 
        float angle = 38.0f * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        transform.position = Vector3.zero;

        Debug.Log("Start!");
        Debug.Log( Player_Score_1 + " = " + Player_Score_2 );
    }


    // Update is called once per frame
    void Update()
    {

        if (transform.position.x != Mathf.Clamp(transform.position.x,-9f,9f) )
        {
            transform.position = new Vector2(0,0);
            speed = 4.0f;
        }

        if (NoBounce>0)
        NoBounce-=Time.deltaTime;
        else{
        if (transform.position.x > 9.1f) // Origionaly 7.5
        {
            direction.x = -direction.x;
        }
         if (transform.position.y > 3.5f)
        {
            speed = speed*1.02f;
            direction.y = -direction.y;
        }
        if (transform.position.x < -9.1f)
        {
            direction.x = -direction.x;
        }
         if (transform.position.y < -3.5f)
        {
            speed = speed*1.02f;
            direction.y = -direction.y;
        }
        if (IsBounded(Player1)||IsBounded(Player2)){
            direction.x = -direction.x;
        }
        NoBounce=0.03f;
        }
        float dt = Time.deltaTime;
        Vector3 change = direction * speed * dt;
        transform.position += change;


    /// <summary>
    /// Checks to see if the ball is "touching the paddle"
    /// </summary>
    /// <param name="Paddle">The paddle object</param>
    /// <returns></returns>
    bool IsBounded(GameObject Paddle)
    {
        Vector3 Average = (transform.position+Paddle.GetComponent<Transform>().transform.position)/2;
           Vector3 BallAverage = new Vector3(Mathf.Clamp(Average.x,transform.position.x-0.5f,transform.position.x+0.5f),
        Mathf.Clamp(Average.y,transform.position.y-0.5f,transform.position.y+0.5f),
        Mathf.Clamp(Average.z,transform.position.z-0.5f,transform.position.z+0.5f));

        Vector3 PaddleAverage = new Vector3(Mathf.Clamp(Average.x,Paddle.GetComponent<Transform>().transform.position.x-Paddle.GetComponent<Transform>().transform.localScale.x/2,Paddle.GetComponent<Transform>().transform.position.x+Paddle.GetComponent<Transform>().transform.localScale.x/2),
        Mathf.Clamp(Average.y,Paddle.GetComponent<Transform>().transform.position.y-Paddle.GetComponent<Transform>().transform.localScale.y/2,Paddle.GetComponent<Transform>().transform.position.y+Paddle.GetComponent<Transform>().transform.localScale.y/2),
        Mathf.Clamp(Average.z,Paddle.GetComponent<Transform>().transform.position.z-Paddle.GetComponent<Transform>().transform.localScale.z/2,Paddle.GetComponent<Transform>().transform.position.z+Paddle.GetComponent<Transform>().transform.localScale.z/2));

        return PaddleAverage==BallAverage;
    }

        if (transform.position.x > 9f)
    {//The ball gets reset from the right 
        Player_Score_1++;
        Debug.Log( Player_Score_1 + " = " + Player_Score_2 );
    }

            if (transform.position.x < -9f)
    {//The ball gets reset from the right 
        Player_Score_2++;
        Debug.Log( Player_Score_1 + " = " + Player_Score_2 );
    }


}}
