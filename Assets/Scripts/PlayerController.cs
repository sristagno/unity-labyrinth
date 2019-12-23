using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject ImgGameOver;
    private float speed = 4f, currentSpeed, rotationSpeed = 80f;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            currentSpeed = speed * 2;
        }
        else
        {
            currentSpeed = speed;
        }
        
        transform.Rotate(Time.fixedDeltaTime * Input.GetAxis("Horizontal") * rotationSpeed * Vector3.up);
        transform.Translate(Time.fixedDeltaTime * Input.GetAxis("Vertical") * currentSpeed * Vector3.forward);
    }

    public void GameOver()
    {
        Debug.Log("game over");
        
        ImgGameOver.SetActive(true);
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Scenes/Menu");
    }
}
