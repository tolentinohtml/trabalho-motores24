using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{  
    public TextMeshProUGUI hud, msgwinner;
    public int restantes;
    public AudioClip clipMoeda, clipVitoria, clipCair;
    private AudioSource source;



    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out source);
        restantes = FindObjectsOfType<Moedas>().Length;
        hud.text=$"Moedas restantes: {restantes}";
      
    }

    public void SubtrairMoedas(int valor){
        restantes = restantes -  valor;
        hud.text=$"Moedas restantes: {restantes}";
        source.PlayOneShot(clipMoeda);
        if (restantes <=0){
            msgwinner.text = "Game Winner!";
            source.Stop();
            source.PlayOneShot(clipVitoria);    
        }
    }
    public void GameOver()
    {
        source.Stop();
        source.PlayOneShot(clipCair);
    }
        

}

       

