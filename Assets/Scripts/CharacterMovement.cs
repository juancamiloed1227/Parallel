using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private GameObject mainCamera;
    public ScoreController scriptScore;
    
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        if (mainCamera != null)
            scriptScore = mainCamera.GetComponent<ScoreController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //Mover el personaje
        if (Input.GetKey(KeyCode.W) && !isMoving)
            StartCoroutine(movePlayer(Vector3.up));

        if (Input.GetKey(KeyCode.A) && !isMoving)
            StartCoroutine(movePlayer(Vector3.left));

        if (Input.GetKey(KeyCode.S) && !isMoving)
            StartCoroutine(movePlayer(Vector3.down));

        if (Input.GetKey(KeyCode.D) && !isMoving)
            StartCoroutine(movePlayer(Vector3.right));
    }

    private IEnumerator movePlayer(Vector3 direction)
    {
        isMoving = true;
        
        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + (direction * 0.49f);

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        scriptScore.numOfMovements -= 0.5f;

        isMoving = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemigo")
            {/*Logica cuando toque un enemigo*/}

        if (other.tag == "Estrella")
            {/*Logica cuando llegue a la meta*/}
    }
}
