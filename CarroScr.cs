
using UnityEngine;
using System.Collections;


public class CarroScr : MonoBehaviour {
	
	public  float       speed    = 5;
	public  float       rotSpeed = 10;
	private Rigidbody   rb;

    public enum Estado {  Andar, Bateu, Parar, WP};
    public Estado estado = Estado.Andar;
    private Estado estadoAnt;

    #region WaypointParametros
    private GameObject pai;
    [HideInInspector]
    public int currentWayPoint;
    [HideInInspector]
    public Transform[] waypoints;
    [HideInInspector]
    public float angulo_Y = 0; //Angulo em Y para não bugar o codigo
    [HideInInspector]
    public float anguloFinal = 0; //Angulo que o carro ficará oa final da curva
    #endregion

    public void Awake()
    {
        currentWayPoint = 0;
        rb = GetComponent<Rigidbody>();
        pai = transform.parent.gameObject;
        print(pai);
    }

	public void FixedUpdate() {
        transform.localEulerAngles = new Vector3(0, 90, 90); //deixar sempre o sprite reto;

        if (estado == Estado.Andar)
        {
            pai.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (estado == Estado.WP)
        {
            Vector3 dir = waypoints[currentWayPoint].position - pai.transform.position;

            pai.transform.rotation = Quaternion.Slerp(pai.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotSpeed);

            pai.transform.eulerAngles = new Vector3(pai.transform.eulerAngles.x, angulo_Y, 0);

            if (dir.sqrMagnitude <= 1)
            {
                currentWayPoint++;
                if (currentWayPoint >= waypoints.Length)
                {
                    estado = Estado.Andar;
                    pai.transform.eulerAngles = new Vector3(anguloFinal, angulo_Y, 0);
                    anguloFinal = 0;
                    currentWayPoint = 0;
                }
            }
            else
                pai.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
	}
    void OnTriggerStay2D(Collider2D hit)
    {
        if ((hit.CompareTag("Carro") || hit.CompareTag("Player")) && !hit.isTrigger) {
            if (estado != Estado.Bateu) { estadoAnt = estado; }
            estado = Estado.Bateu;
        } else if (hit.CompareTag("Semaforo")) {
            estadoAnt = estado;
            estado = Estado.Parar;
        }
    }
    void OnTriggerExit2D(Collider2D hit)
    {
        if ((hit.CompareTag("Carro") || hit.CompareTag("Player")) && !hit.isTrigger)
        {
            estado = estadoAnt;
        }
        else if (hit.CompareTag("Semaforo"))
        {
            estado = estadoAnt;
        }
    }
}
