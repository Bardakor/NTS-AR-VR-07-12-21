using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class KillingCam : MonoBehaviour
{
    public GameObject particleEffect;

    public AudioSource hitSound;

    private Vector2 touchpos;

    private RaycastHit hit;

    private Camera cam;
    [SerializeField] private Text countText;
    public int _cubeCount;
    // Start is called before the first frame update
    
    
    
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount <= 0)
            return;

        touchpos = Input.GetTouch(0).position;
        Ray ray = cam.ScreenPointToRay(touchpos);

        if(Physics.Raycast(ray, out hit))
        {
            GameObject hitObj = hit.collider.gameObject;

            if (hitObj.tag == "Enemy")
            {
                hitSound.Play();
                var clone = Instantiate(particleEffect, hitObj.transform.position, Quaternion.identity);
                clone.transform.localScale = hitObj.transform.localScale;
                Destroy(hitObj);
                _cubeCount += 1;
                countText.text = "SCORE: " + _cubeCount;
                if (_cubeCount == 7)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            if (hitObj.tag == "notnice")
            {
                hitSound.Play();
                var clone = Instantiate(particleEffect, hitObj.transform.position, Quaternion.identity);
                clone.transform.localScale = hitObj.transform.localScale;
                Destroy(hitObj);
                _cubeCount -= 1;
                countText.text = "SCORE: " + _cubeCount;
            }
        }
    }
}
