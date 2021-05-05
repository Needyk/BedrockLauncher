﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BedrockLauncher.Events;
using BedrockLauncher.Classes;

namespace BedrockLauncher.ViewModels
{
    public class LauncherModel : NotifyPropertyChangedBase
    {
        #region Events

        public event EventHandler ProgressBarStateChanged;
        public event EventHandler GameRunningStateChanged;

        protected virtual void OnProgressBarStateChanged(ProgressBarState e)
        {
            EventHandler handler = ProgressBarStateChanged;
            if (handler != null) handler(this, e);
        }
        protected virtual void OnGameRunningStateChanged(GameRunningState e)
        {
            EventHandler handler = ProgressBarStateChanged;
            if (handler != null) handler(this, e);
        }

        #endregion

        #region One Way Bindings

        public bool IsStateChanging => StateChangeInfo != null;
        public string PlayButtonString
        {
            get
            {         
                if (IsGameRunning) return App.Current.FindResource("GameTab_PlayButton_Kill_Text").ToString();
                else return App.Current.FindResource("GameTab_PlayButton_Text").ToString();
            }
        }

        #endregion

        #region Bindings

        private bool _IsGameRunning = false;
        private VersionStateChangeInfo _stateChangeInfo;
        private bool _ShowProgressBar = false;
        private bool _EnableVariousControls = true;
        public bool EnableVariousControls
        {
            get
            {
                return _EnableVariousControls;
            }
            set
            {
                _EnableVariousControls = value;
                OnPropertyChanged(nameof(EnableVariousControls));
            }
        }
        public bool IsGameRunning
        {
            get
            {
                return _IsGameRunning;
            }
            set
            {
                _IsGameRunning = value;
                EnableVariousControls = !value;
                OnPropertyChanged(nameof(PlayButtonString));
                OnPropertyChanged(nameof(IsGameRunning));
            }
        }
        public VersionStateChangeInfo StateChangeInfo
        {
            get { return _stateChangeInfo; }
            set { _stateChangeInfo = value; OnPropertyChanged("StateChangeInfo"); OnPropertyChanged("IsStateChanging"); }
        }
        public bool ShowProgressBar
        {
            get
            {
                return _ShowProgressBar;
            }
            set
            {
                _ShowProgressBar = value;
                OnProgressBarStateChanged(new ProgressBarState(value));
                OnPropertyChanged(nameof(ShowProgressBar));
            }
        }

        #endregion
    }
}
