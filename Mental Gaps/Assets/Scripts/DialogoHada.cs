using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogoHada : MonoBehaviour
{
 private bool estaEnRango;
    [SerializeField, TextArea(4,6)] private string[] LineasDeDialogos;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;

    private float typingTime = 0.05f;
    private IEnumerator coroutine;
    private bool dialogoActivo;
    private int indexLinea;
    // Update is called once per frame
    void Update()
    {
        if (estaEnRango && Input.GetButtonDown("Fire1"))
        {
            if (!dialogoActivo)
            {
                Debug.Log("Dialogo activado");
                InicioDialogo(); 
            }
        }
    }

    private void InicioDialogo()
    {
        try
        {
            dialogoActivo = true;
            dialoguePanel.SetActive(true);
            dialogueMark.SetActive(false);
            indexLinea = 0;
            dialogueText.text = LineasDeDialogos[indexLinea];
            //coroutine = (IEnumerator)ShowLine();
            //StartCoroutine(coroutine);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private IEnumerable ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach (char line in LineasDeDialogos[indexLinea])
        {
            dialogueText.text += line;
            yield return new WaitForSeconds(typingTime);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            estaEnRango = true;
            dialogueMark.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            estaEnRango = false;
            dialogueMark.SetActive(false);
        }
    }
}
