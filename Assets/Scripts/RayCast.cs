using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RayCast : MonoBehaviour
{

    [SerializeField] private Text _countDownText;

    private bool _raycastUsed = false;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Input.GetButtonDown("Fire1") && _raycastUsed == false)
        {
            if(Physics.Raycast(ray, out hit) && hit.transform.tag == "1")
            {
                StartCoroutine(CountDown(0));
                _raycastUsed = true;
            }

            if(Physics.Raycast(ray, out hit) && hit.transform.tag == "2")
            {
                StartCoroutine(CountDown(1));
                _raycastUsed = true;
            }

            if(Physics.Raycast(ray, out hit) && hit.transform.tag == "3")
            {
                StartCoroutine(CountDown(2));
                _raycastUsed = true;
            }
        }
    }

    private IEnumerator CountDown(int scene)
    {
        while(_countDownText.text != "Cargado")
        {
            yield return new WaitForSeconds(1);
            _countDownText.text = "5";
            yield return new WaitForSeconds(1);
            _countDownText.text = "4";
            yield return new WaitForSeconds(1);
            _countDownText.text = "3";
            yield return new WaitForSeconds(1);
            _countDownText.text = "2";
            yield return new WaitForSeconds(1);
            _countDownText.text = "1";
            yield return new WaitForSeconds(1);
            _countDownText.text = "Cargando";
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(scene);
        }
    }
}
