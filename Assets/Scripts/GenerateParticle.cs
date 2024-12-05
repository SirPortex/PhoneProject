using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateParticle : MonoBehaviour
{

    public GameObject particlePrefab; // prefab de la bola
    private Camera _cam; // Camara 

    private void Start()
    {
        _cam = Camera.main; // La primera camara que esté habilitada con el tag de MainCamera
    }

    void Update()
    {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE //PARA QUE FUNCIONE EN PC

        //PC
        if (Input.GetMouseButtonDown(0)) // cuando pulsemos el click izquierdo
        {
            Vector3 screenCoords = Input.mousePosition; //coordenadas de pantalla
            screenCoords.z = 10; //
            Vector3 gameCoords = _cam.ScreenToWorldPoint(screenCoords); // transformamos las coordenadas de la pantalla a coordenadas de mundo
            Instantiate(particlePrefab, gameCoords, Quaternion.identity); // instanciamos la bola en las coordenadas donde cliqueamos
        }

#elif UNITY_ANDROID

        //ANDROID
        foreach (Touch touch in Input.touches) // por cada toque que demos
        {
            if (touch.phase == TouchPhase.Began) // Began es el primer toque que das en la pantallaS
            {
                Vector3 screenCoords = touch.position; //coordenadas de la pantalla
                screenCoords.z = 10;
                Vector3 gameCoords = _cam.ScreenToWorldPoint(screenCoords); // transformamos las coordenadas de la pantalla a coordenadas de mundo
                Instantiate(particlePrefab, gameCoords, Quaternion.identity); // instanciamos la bola en las coordenadas donde cliqueamos


            }
        }
#endif
    }
}
