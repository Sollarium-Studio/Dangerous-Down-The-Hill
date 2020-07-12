using System;
using Proyecto26;
using UnityEditor.Rendering;
using UnityEngine;

namespace Firebase
{
    public class Firebase : Singleton<Firebase>
    {
        public const string api = "AIzaSyAYwckI3hTaeMJuRGL5dDNrDccsQi-42O0";
        public const string firebaseUrl = "https://ddth-game.firebaseio.com/";
        
        private string FirebaseUrl { get; set; }

        private void Awake()
        {
            FirebaseUrl = firebaseUrl;
        }

        public string GenerateID()
        {
            return Guid.NewGuid().ToString("N");
        }

        public void RegisterNewUser(UserScore userScore, Action onSuccess, Action onError)
        {
            var id = GenerateID();
            userScore.userId = id;
            Debug.Log(userScore);
            RestClient.Put<UserScore>($"${Instance.FirebaseUrl}scores/{id}.json", userScore).Then(postUser =>
            {
                Debug.Log($"Score Resgistered!!!");
                onSuccess();
            }, error =>
            {
                Debug.Log($"Error: {error}");
                onError();
            });
        }
    }
}