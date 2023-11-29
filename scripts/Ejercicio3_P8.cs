using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Ejercicio3_P8 : MonoBehaviour
{
    // Declaración de variables: Material, WebCamTexture y String para almacenar el path del directorio donde almacenar las imágenes.
    private Material tvMaterial;
    private WebCamTexture webcamTexture;
    private string path = Path.Combine(Application.dataPath, "Capturas_camara");
    private int captureCounter = 1;


    // Start is called before the first frame update
    void Start()
    {
        // Inicializar el materal al que posteriormente se asignará cada imagen-frame de la cámara. Es necesario obtener el Renderer del objeto sobre el que se pinta, y acceder a su material.
        Renderer renderer = GetComponent<Renderer>();
        tvMaterial = renderer.material;
        // Usar el constructor de WebCamTexture para inicializar una variable de ese tipo.
        webcamTexture = new WebCamTexture();
        tvMaterial.mainTexture = webcamTexture;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s")) {
            // Asignar a la mainTexture del material lo que capta la cámara. La captura se inicia con nombrevarible_webcamtexture.Start()
            webcamTexture.Play();
            Debug.Log("Se pulsó S para encender la cámara");
        }
        if (Input.GetKey("p")) {
            // Parar la captura de video
            webcamTexture.Pause();
            Debug.Log("Se pausó el video con P");
        }
        if (Input.GetKey("x")) {
            // Tomar fotogramas
            TakePicture();
        }
    }

    private void TakePicture() {
        Texture2D texture_capture = new Texture2D(webcamTexture.width, webcamTexture.height);
        texture_capture.SetPixels(webcamTexture.GetPixels());
        texture_capture.Apply();

        // Convertir la textura a bytes
        byte[] bytes = texture_capture.EncodeToPNG();

        // Guardar la imagen en el directorio especificado
        string file = "Captura" + captureCounter + ".png";
        string final_path = Path.Combine(path, file);
        File.WriteAllBytes(final_path, bytes);

        // Incrementar el contador de capturas
        captureCounter++;
    }
}
