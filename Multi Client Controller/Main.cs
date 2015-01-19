/*
Copyright 2015 Yixin Zhang

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace Multi_Client_Controller
{
    public partial class Main : Form
    {
        private bool detecting = false;
        private bool controlling = false;
        private Process process;
        private String path;
        private KeyboardHook sender = new KeyboardHook();
        private Keys[] detected = { Keys.Up, Keys.Down, Keys.Left, Keys.Right };
        private VMessages VM;
        Process[] allClients;

        public Main()
        {
            InitializeComponent();
            VM = new VMessages("QwenameClient//MacromediaFlashPlayerActiveX");
            allClients = sender.getClients("QwenameClient");
            this.KeyDown += new KeyEventHandler(Main_KeyDown);
            this.KeyUp += new KeyEventHandler(Main_KeyUp);
            sender.KeyPressed += new EventHandler<KeyPressedEventArgs>(sender_KeyPressed);
        }

        void Main_KeyUp(object sender, KeyEventArgs e)
        {
            //statusTxt.AppendText(e.KeyCode.ToString() + " Up \n");
            if (controlling)
                VM.sendKeyStroke((IntPtr)e.KeyValue, false);
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            //statusTxt.AppendText(e.KeyCode.ToString() + " Down \n");
            if (controlling)
                VM.sendKeyStroke((IntPtr)e.KeyValue, true);
        }


        override protected bool IsInputKey(Keys keyData)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Up:
                    return true;
                case Keys.Down:
                    return true;
                case Keys.Right:
                    return true;
                case Keys.Left:
                    return true;
                default:
                    return base.IsInputKey(keyData);
            }

        }

        private void registerKeys(Keys[] kArray)
        {
            if (!detecting)
                for (int i = 0; i <= kArray.Length - 1; i++)
                    sender.RegisterHotKey(0, kArray[i]);
            detecting = true;
        }

        private void unregisterKeys(Keys[] kArray)
        {
            if (detecting)
                for (int i = 0; i <= kArray.Length - 1; i++)
                    sender.UnregisterHotKey();
            detecting = false;
        }

        private void sender_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (containsKey(detected, e.Key))
                statusTxt.AppendText(e.Key.ToString() + " button pressed\n");
        }

        private bool containsKey(Keys[] kArray, Keys k)
        {
            for (int i = 0; i <= kArray.Length - 1; i++)
                if (kArray[i] == k)
                    return true;
            return false;
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            process.Start();
            statusTxt.AppendText("Client executed from:\n" + Application.StartupPath + "\n");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            process = new Process();
            path = Application.StartupPath + @"\QwenameClient.exe";
            process.StartInfo.FileName = path;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
           this.sender.CloseAllClients("QwenameClient");
        }

        private void keyBtn_Click(object sender, EventArgs e)
        {
            //VM = new VMessages("Qwename's Client//MacromediaFlashPlayerActiveX");
            if (VM.windowExists())
            {
                VM.refreshProcesses("QwenameClient//MacromediaFlashPlayerActiveX");
            }
            else
            { 
                statusTxt.AppendText("Window not found!\n"); 
            }
        }

        private void stopHook_Click(object sender, EventArgs e)
        {
            if (detecting)
            {
                unregisterKeys(detected);
                stopHook.Text = "Start Detecting";
            }
            else
            {
                registerKeys(detected);
                stopHook.Text = "Stop Detecting";
            }
        }

        private void toggle_Click(object sender, EventArgs e)
        {
            if (controlling)
            {
                controlling = false;
            }
            else
            {
                controlling = true;
            }
        }
    }
}
