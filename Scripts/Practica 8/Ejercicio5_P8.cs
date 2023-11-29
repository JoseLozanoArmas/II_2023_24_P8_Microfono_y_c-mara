using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Ejercicio5_P8 : MonoBehaviour
{
    private Material tvMaterial;
    private WebCamTexture webcamTexture;
    private string path = Path.Combine(Application.dataPath, "Capturas_camara");
    private int captureCounter = 1;

    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        tvMaterial = renderer.material;
        webcamTexture = new WebCamTexture();
        tvMaterial.mainTexture = webcamTexture;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s")) {
            webcamTexture.Play();
        }
        if (Input.GetKey("p")) {
            webcamTexture.Pause();
        }
        if (Input.GetKey("x")) {
            TakePicture();
        }
    }

    private void TakePicture() {
        // Capturar el fotograma de la cámara
        Texture2D snapshot = new Texture2D(webcamTexture.width, webcamTexture.height);
        snapshot.SetPixels(webcamTexture.GetPixels());
        snapshot.Apply();

        // Convertir la textura a bytes y guardar la imagen en el directorio especificado
        string fileName = "Captura" + captureCounter + ".png";
        string filePath = Path.Combine(path, fileName);
        File.WriteAllBytes(filePath, snapshot.EncodeToPNG());

        // Incrementar el contador de capturas
        captureCounter++;
    }
}
