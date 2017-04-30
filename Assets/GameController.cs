using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KinectBox.Global
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;
        private static Vector3 _Direction = new Vector3(0f, 0f, -1f);

        public Vector3 HeadPosition
        {
            get { return _headPosition; }
        }

        private Vector3 _headPosition;

        void Awake()
        {
            if (Instance != null)
            {
                GameObject.Destroy(gameObject);
            }
            else
            {
                GameObject.DontDestroyOnLoad(gameObject);
                Instance = this;
            }
        }

        void Start()
        {
            _headPosition = new Vector3(0f, 0f, 0f);
        }

        void Update()
        {
            _headPosition += _Direction * Time.deltaTime;
        }
    }
}