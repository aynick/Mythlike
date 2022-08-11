﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerFlip))]
    public class PlayerBehavior : MonoBehaviour, IStateSwitcher
    {
        private Player _player;
        private BasePlayerMove _playerMove;
        private BasePlayerAttack _playerAttack;
        private PlayerFlip _playerFlip;
        private BaseState _currentState;
        private List<BaseState> _allStates;
        public PlayerApplyDamage PlayerApplyDamage;
        [SerializeField] private PlayerType _playerType;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button attackButton;
        [SerializeField] private float range;

        private void Awake()
        {
            InitPlayer();
            InitStates();
        }

        void InitStates()
        {
            _allStates = new List<BaseState>()
            {
                new MoveAndAttackState(_playerAttack,_playerMove,this,_joystick),
                new IdleState(this,_playerAttack,_joystick)
            };
            _currentState = _allStates[0];
        }

        void InitPlayer()
        {
            switch (_playerType)
            {
                case PlayerType.Warrior : _player = new WarriorPlayer();
                    break;
                case PlayerType.Wizard : _player = new WizardPlayer();
                    break;
                case PlayerType.Elf : _player = new ElfPlayer();
                    break;
            }

            _player.InitStats();
            _playerFlip = gameObject?.GetComponent<PlayerFlip>();
            InitPlayerTools();
        }

        void InitPlayerTools()
        {
            PlayerApplyDamage = new PlayerApplyDamage(_player);
            _playerAttack = new BasePlayerAttack(transform,_player,_playerFlip,GetComponent<Rigidbody2D>(),attackButton,range);
            _playerMove = new BasePlayerMove(GetComponent<Rigidbody2D>(),_player.speed,_joystick);
        }

        private void Update()
        {
            _currentState.Action();
        }

        public void SwitchState<T>() where T : BaseState
        {
            var state = _allStates.FirstOrDefault(s => s is T);
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}