using UnityEngine;

public class Bricks : MonoBehaviour {

    // Use this for initialization
    private Rigidbody2D rb;
    public GameObject brickParticle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    } 

 
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball") {
           GameObject particle =  Instantiate(brickParticle, transform.position, Quaternion.identity);
            Renderer rend = particle.GetComponent<Renderer>();
            rend.material = gameObject.GetComponent<Renderer>().material;

            //Update bricks count and destroy the brick object   
            GameManager.instance.decreaseBricksCount();
            Destroy(gameObject);
            Destroy(particle, 3);

           
        }
    }

}
