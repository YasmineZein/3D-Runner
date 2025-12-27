using UnityEngine;

public class Spike : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            GameObject btn = GameObject.FindWithTag("RestartButton");
            
            player.SetActive(false);
            btn.transform.localScale = new Vector3(1, 1, 1);
        }
        GameObject.FindAnyObjectByType<GameManager>().CheckHighScore();
    }
}
