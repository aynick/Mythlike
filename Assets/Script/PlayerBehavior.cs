﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        private BasePlayerState _currentState;
        private List<BasePlayerState> _allStates;

        [SerializeField] private PlayerType _playerType;

        private void Awake()
        {
            InitPlayer();
            InitStates();
        }

        void InitStates()
        {
            _allStates = new List<BasePlayerState>()
            {
                new PlayerMoveAndAttackState(_playerAttack,_playerMove,this),
                new PlayerIdleState(this,_playerAttack)
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
            _playerAttack = new BasePlayerAttack(transform,_player,_playerFlip);
            _playerMove = new BasePlayerMove(GetComponent<Rigidbody2D>(),_player.speed);
        }

        private void Update()
        {
            _currentState.Action();
        }

        public void SwitchState<T>() where T : BasePlayerState
        {
            var state = _allStates.FirstOrDefault(s => s is T);
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}