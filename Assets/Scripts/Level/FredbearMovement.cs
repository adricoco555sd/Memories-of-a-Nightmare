using UnityEngine;

public class FredbearMovement : MonoBehaviour
{
    private Animator animator;
    private string idle1 = "Animation1";
    private string idle2 = "Animation2";
    private string idle3 = "Animation3";
    
    private float intervalo = 5f;
    private float temporizador;

    private void Awake() {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    private void Update()
    {
        temporizador += Time.deltaTime;

        if (temporizador >= intervalo)
        {
            temporizador = 0f;
            ElegirIdleAleatorio();
        }
    }

    private void ElegirIdleAleatorio()
    {
        int numero = Random.Range(1, 5);
        
        animator.SetBool(idle1, false);
        animator.SetBool(idle2, false);
        animator.SetBool(idle3, false);
        
        Vector3 posicio1 = new Vector3(2.553f, 0.142f, -2.556f);
        Vector3 posicio2 = new Vector3(2.54f, 0.195f, -1.64f);
        Vector3 posicio3 = new Vector3(2.119f, 0.081f, -2.828f);
        
        Vector3 rotacio1 = new Vector3(0, 116.128f, 0);
        Vector3 rotacio2 = new Vector3(0, 115.432f, 0);
        Vector3 rotacio3 = new Vector3(0, 101.677f, 0);

        switch (numero)
        {
            case 1:
                animator.SetBool(idle1, true);
                gameObject.transform.position = posicio1;
                gameObject.transform.rotation = Quaternion.Euler(rotacio1);
                break;
            case 2:
                animator.SetBool(idle2, true);
                gameObject.transform.position = posicio2;
                gameObject.transform.rotation = Quaternion.Euler(rotacio2);
                break;
            case 3:
                animator.SetBool(idle3, true);
                gameObject.transform.position = posicio3;
                gameObject.transform.rotation = Quaternion.Euler(rotacio3);
                break;
            case 4:
                animator.SetBool("isWalking", true);
                gameObject.transform.position = new Vector3(2f, 0.5f, 0.5f);
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                break;
        }
    }
}
