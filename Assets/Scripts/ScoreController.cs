using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private Scene actualScene;
    public float numOfMovements;

    public Text movementsTxt;

    // Start is called before the first frame update
    void Start()
    {
        //Se obtiene la escena actual en funcionamiento
        actualScene = SceneManager.GetActiveScene();
        
        //Determinar el numero de movimientos dependiendo de la escena actual (Nivel Actual)
        if (actualScene.name == "Level 1")
            numOfMovements = 13f;
    }

    // Update is called once per frame
    void Update()
    {
        //Mostrar el numero de movimientos restantes
        movementsTxt.text = numOfMovements.ToString();
        
        //Si el numero de movimientos es menor a 1, se pierde el juego
        if (numOfMovements < 1)
            Debug.Log("Game Over");

        //Logica para definir el numero de estrellas en funcion de los movimientos
    }
}
