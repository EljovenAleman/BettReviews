using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectActionView : MonoBehaviour
{
    [SerializeField] Button goToAddMovieViewButton;
    [SerializeField] Button goToAddReviewViewButton;

    [SerializeField] GameObject addMovieView;
    [SerializeField] GameObject addReviewView;



    void Start()
    {
        goToAddMovieViewButton.onClick.AddListener(GoToAddMovieView);
        goToAddReviewViewButton.onClick.AddListener(GoToAddReviewView);
    }
    
    void GoToAddMovieView()
    {
        gameObject.SetActive(false);
        addMovieView.SetActive(true);
    }

    void GoToAddReviewView()
    {
        gameObject.SetActive(false);
        addReviewView.SetActive(true);
    }

}
