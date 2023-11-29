using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio2_P8 : MonoBehaviour
{
    private AudioSource audio; //Declaración de una variable de tipo AudioSource para usar en el código
    
    void Start()
    {
        audio = GetComponent<AudioSource>(); // Recuperar el componente AudioSource que se agrega a los altavoces, se asigna a la variable de este tipo declarada anteriormente.
        if (audio == null) {
            audio = gameObject.AddComponent<AudioSource>();
        }
        StartCapture(); // Iniciar la recogida de audio por el micrófono
    }

    
    void Update()
    {
        // En cada frame verificar si se ha pulsado la teclar R para iniciar la recogida de aduio desde el micrófono
        if (Input.GetKeyDown(KeyCode.R)) {
            audio.Play(); // Reproducir el clip que se ha vinculado al AudioSource
            Debug.Log("Se pulsó R");
        }

        // En cada frame, verificar si el usuario ha decidido parar el micrófono
        if (Input.GetKeyDown(KeyCode.P)) {
            StopCapture(); // Finalizar la captación de audio por el micrófono
            Debug.Log("Se pulsó P");
        }
    }

    private void StartCapture() {
        if (Microphone.devices.Length > 0) {
            string selectedMicrophone = Microphone.devices[0]; // Guardamos el primero disponible
            audio.clip = Microphone.Start(selectedMicrophone, true, 10, AudioSettings.outputSampleRate); // Iniciar la captación de audio desde el micrófono seleccionado
        }
    }

    private void StopCapture() {
        Microphone.End(null);
    }
}
