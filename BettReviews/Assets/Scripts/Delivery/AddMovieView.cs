using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMovieView : MonoBehaviour
{
    [SerializeField] Button returnButton;
    [SerializeField] GameObject selectActionView;


    //url importante: http://www.omdbapi.com/?apikey=6aaadb49&s= + string to search


    void Start()
    {
        returnButton.onClick.AddListener(Return);
    }

    void Return()
    {
        gameObject.SetActive(false);
        selectActionView.SetActive(true);
    }
    
}
