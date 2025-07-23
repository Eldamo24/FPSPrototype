using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraFollow;
    [SerializeField] private Transform orientation;
    [SerializeField] private InputReader inputReader;

    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    [SerializeField] private float sensitivityX;
    [SerializeField] private float sensitivityY;

    private float xRotation;

    private void LateUpdate()
    {
        transform.position = cameraFollow.position;
        float mouseX = inputReader.LookVector.x * sensitivityX; //Tomo el input del mouse en x y lo suavizo
        float mouseY = inputReader.LookVector.y * sensitivityY; //Tomo el input del mouse en y y lo suavizo
        xRotation -= mouseY; //Acumulo la rotacion del eje y en x ya que la uso para mirar arriba y abajo, es decir, rotar en x
        xRotation = Mathf.Clamp(xRotation, minX, maxX); //Clampeo para evitar pasarme de limites

        transform.rotation = Quaternion.Euler(xRotation, transform.eulerAngles.y + mouseX, 0f); //Aplico rotacion en x y en y (sumo el input de mouse x mas la rotacion actual)
        if(orientation != null)
        {
            orientation.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f); //Roto orientation (lo usare para definir la direccion del player
        }
    }
}
