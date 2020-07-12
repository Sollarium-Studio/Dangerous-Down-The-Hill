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
            GetUsers();
        }

        public string GenerateID()
        {
            return Guid.NewGuid().ToString("N");
        }

        public void RegisterNewUser(User user, Action onSuccess, Action onError)
        {
            user.userId = GenerateID();
            Debug.Log(user);
            RestClient.Put<User>($"${Instance.FirebaseUrl}Teste/{user.userId}.json", user).Then(postUser =>
            {
                Debug.Log($"Score Resgistered!!!");
                onSuccess();
            }, error =>
            {
                Debug.Log($"Error: {error}");
                onError();
            });
        }

        public void GetUsers()
        {
            RestClient.Get($"{FirebaseUrl}users").Then(obj =>
            {
                Debug.Log(obj.ToString());
            });
        }
    }
}