using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetMovieView : MonoBehaviour
{
    //[SerializeField] Button returnButton;
    [SerializeField] GameObject selectActionView;

    [SerializeField] TMP_InputField movieNameField;

    GetMovieViewPresenter getMovieViewPresenter;


    //url importante: http://www.omdbapi.com/?apikey=6aaadb49&s= + string to search


    void Start()
    {
        //returnButton.onClick.AddListener(Return);
        movieNameField.onSubmit.AddListener(null);
        getMovieViewPresenter = new GetMovieViewPresenter(new IMDBSearchMovieService());

    }

    void Return()
    {
        gameObject.SetActive(false);
        selectActionView.SetActive(true);
    }

    void OnSubmitMovieName(string movieName)
    {

    }
    
}
