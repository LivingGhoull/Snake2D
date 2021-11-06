using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Snake : MonoBehaviour
{
    [SerializeField] ScoreSystem scoreSystem;
    [SerializeField] Points points;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] ParticleSystem particle;

    Vector2Int gridPosition;
    Vector2Int gridMoveDirection;
    float gridMoveMaxTimer;
    float gridMoveTime;

    [SerializeField] GameObject gameoverUI;

    int snakeBodySize;
    List<Vector2Int> snakeMovePositionList;
    [SerializeField] GameObject body;

    // Start is called before the first frame update
    void Start() {
        snakeMovePositionList = new List<Vector2Int>();
        snakeBodySize = 0;
        gridMoveMaxTimer = .5f;
        gridMoveTime = gridMoveMaxTimer;
        gridMoveDirection = new Vector2Int(0, 1);
    }

    // Update is called once per frame
    void Update() {
        HandleInput();
        HandleGridmovement();
    }

    void HandleInput() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (gridMoveDirection.y != -1) {
                gridMoveDirection.y = 1;
                gridMoveDirection.x = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (gridMoveDirection.y != 1) {
                gridMoveDirection.y = -1;
                gridMoveDirection.x = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (gridMoveDirection.x != 1) {
                gridMoveDirection.y = 0;
                gridMoveDirection.x = -1;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (gridMoveDirection.x != -1) {
                gridMoveDirection.y = 0;
                gridMoveDirection.x = 1;
            }
        }
    }

    void HandleGridmovement() {
        gridMoveTime += Time.deltaTime;
        if (gridMoveTime >= gridMoveMaxTimer) {
            gridMoveTime -= gridMoveMaxTimer;

            //Reset snakes head position
            snakeMovePositionList.Insert(0, gridPosition);
            gridPosition += gridMoveDirection;

            //Removes the last position of the tail so it looks like the snake moves 
            if (snakeMovePositionList.Count >= snakeBodySize + 1) {
                snakeMovePositionList.RemoveAt(snakeMovePositionList.Count - 1);
            }
            //adds a new tail
            for (int i = 0; i < snakeMovePositionList.Count; i++) {
                Vector2Int snakeMovePosition = snakeMovePositionList[i];
                GameObject newTail = Instantiate(body, new Vector3(snakeMovePosition.x, snakeMovePosition.y), Quaternion.identity);
                StartCoroutine(DeleteTail(newTail));
            }
            transform.position = new Vector2(gridPosition.x, gridPosition.y);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection)-90);
        }
    }

    IEnumerator DeleteTail(GameObject newTail) {
        yield return new WaitForSeconds(gridMoveMaxTimer);
        Destroy(newTail);
    }

    // Rotates the head of the snake
    float GetAngleFromVector(Vector2Int dir) {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    //Add to the body
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Apple") {
            Destroy(collision.gameObject);
            snakeBodySize++;
            score.text = "Score: "+snakeBodySize;
            particle.Play();
            points.SpawnApple();
        }
        else if (collision.tag == "Tail") {
            scoreSystem.Highscore(snakeBodySize);
            gameoverUI.SetActive(true);
            GetComponent<Snake>().enabled = false;
        }
    }
}
