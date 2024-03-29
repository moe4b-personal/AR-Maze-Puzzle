﻿using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Game
{
    [RequireComponent(typeof(Button))]
	public class Puzzle : MonoBehaviour
	{
        [SerializeField]
        protected bool solved;
        public bool Solved
        {
            get
            {
                return solved;
            }
        }

        public event Action OnSolved;
        public void Solve()
        {
            solved = true;

            if (OnSolved != null) OnSolved();
        }

        public int number1 = 1;
        public int number2 = 1;

        public int Solution
        {
            get
            {
                return number1 + number2;
            }
        }

        Button button;
        public bool Interactable
        {
            get
            {
                return button.interactable;
            }
            set
            {
                button.interactable = value;
            }
        }

        void Start()
        {
            button = GetComponent<Button>();

            button.onClick.AddListener(Click);
        }

        void Click()
        {
            Level.Instance.puzzleScreen.Show(this);
        }
	}
}