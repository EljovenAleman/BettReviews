using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetMovieView : MonoBehaviour
{    
    [SerializeField] TMP_InputField movieNameField;

    GetMovieViewPresenter getMovieViewPresenter;


    //url importante: http://www.omdbapi.com/?apikey=6aaadb49&s= + string to search


    void Start()
    {
        //returnButton.onClick.AddListener(Return);

        getMovieViewPresenter = new GetMovieViewPresenter(new IMDBSearchMovieService(), UnityMainThreadTaskHandler.GetInstance());
        movieNameField.onSubmit.AddListener(getMovieViewPresenter.OnSubmitMovie);

    }
        
}
