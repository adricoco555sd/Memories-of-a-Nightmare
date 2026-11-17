using UnityEngine;
using UnityEngine.InputSystem;

public class LightMovement : MonoBehaviour
{
    private Camera camara;
    private float distancia = 20f;
    private float suavizado = 0f;
    
    private void Awake() {
        if (camara == null)
            camara = Camera.main;
    }

    private void Update() {
        Vector2 posRaton = Mouse.current.position.ReadValue();
        
        Ray rayo = camara.ScreenPointToRay(posRaton);
        
        Vector3 objetivo = Physics.Raycast(rayo, out RaycastHit hit, 100f)
            ? hit.point
            : rayo.GetPoint(distancia);

        Quaternion rotacionDeseada = Quaternion.LookRotation(objetivo - transform.position);

        if (suavizado <= 0f)
            transform.rotation = rotacionDeseada;
        else
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, suavizado * Time.deltaTime);
    }
}