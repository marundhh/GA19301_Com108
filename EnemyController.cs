using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float start, end, speed;
    Rigidbody2D rig;
    int isRight = 1; //Check if the character is moving right or left
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Run()
    {
        var x_enemy = transform.position.x; //Get x for enemy
        if (x_enemy < start) // Check enemy if x < start then the enemy will flip
        {
            isRight = 1;
        }
        if (x_enemy > end) //Similar to start
        {
            isRight = -1;
        }
        transform.Translate(new Vector3(isRight * speed * Time.deltaTime, 0, 0));

        var y_enemy = transform.position.y; //Get y for enemy
        var x_player = player.transform.position.x; //Get x for Player
        var y_player = player.transform.position.y; //Get y for Player
        if ((x_player > start && x_player < end) && (y_player < y_enemy + 1 && y_player > y_enemy - 1))
        {
            if (x_player < x_enemy)
            {
                isRight = -1;
            }
            if (x_player > x_enemy)
            {
                isRight = 1;
            }
        }
    }
    void flip()
    {
        transform.localScale = new Vector2(-isRight, 1f);
    }
    // Update is called once per frame
    void Update()
    {
        Run();
        flip();
    }
}