using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

    public GameObject explosion;
    public GameObject numbers;
    public float dissappear;

    public float damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    /*
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Targets")
            {

                GameObject popup = Instantiate(numbers, transform.position, transform.rotation);
                float dmg = Mathf.Round(Random.Range(30f, 50f));
                popup.GetComponent<TextMesh>().text = dmg.ToString();
                popup.transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(0, 0, 0), Time.deltaTime * 1 / 2);
                Destroy(popup, dissappear);
             }
            explode();
        }
    */
    
    //*
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("hit");
        Health_Script damagehit = collider.GetComponent<Health_Script>();
        if (damagehit!=null)
        {

            GameObject popup = Instantiate(numbers, transform.position, transform.rotation);
            float dmg = Mathf.Round(Random.Range(0.75f * damage, 1.25f * damage));
            damagehit.takedamage(dmg);
            popup.GetComponent<TextMesh>().text = dmg.ToString();
            popup.transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(0, 0, 0), Time.deltaTime * 1 / 2);
            Destroy(popup, dissappear);
        }
        explode();
    }
    //*/
    void explode()
    {
        if (explosion)
        {
            GameObject boom =Instantiate(explosion, transform.position, transform.rotation);
            Destroy(boom, 2f);
            
        }
        Destroy(gameObject);
    }
}
