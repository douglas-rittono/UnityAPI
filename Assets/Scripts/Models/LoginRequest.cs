using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [System.Serializable]
    public class LoginRequest
    {
        [SerializeField]
        public string username;
        [SerializeField]
        public string password;
    }
}