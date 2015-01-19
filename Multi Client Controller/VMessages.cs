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
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace Multi_Client_Controller
{
    class VMessages
    {
        string[] eWindowClassStructure;
        IntPtr[] eClassHandle;

        public VMessages(string pWindowClassStructure)
        {
            refreshProcesses(pWindowClassStructure);

            //Win32.FindWindow(null, "Untitled - Notepad");
            //Win32.FindWindowEx(eClassHandle, IntPtr.Zero, "Edit", null);
        }

        public void refreshProcesses(string pWindowClassStructure)
        {
            if (eClassHandle != null)
            {
                eClassHandle = null;
            }
            eWindowClassStructure = pWindowClassStructure.Split(new string[] { "//" }, StringSplitOptions.None);
            Process[] processes = Process.GetProcessesByName(eWindowClassStructure[0]);
            eClassHandle = new IntPtr[processes.Length];
            int i = 0;
            foreach (Process p in processes)
            {
                eClassHandle[i] = p.MainWindowHandle;
                if (eWindowClassStructure.Length > 1)
                {
                    eClassHandle[i] = (IntPtr)Win32.FindWindowEx(eClassHandle[i].ToInt32(), IntPtr.Zero, eWindowClassStructure[1], null);
                }
                i++;
            }
        }

        public Boolean windowExists()
        {
            if (eClassHandle[0].ToInt32() == 0)
                return false;
            return true;
        }

                
        /*public void sendText(string pText)
        {
            char[] tmpText = pText.ToCharArray();

            foreach (char c in tmpText)
            {
                sendChar(c);
            }
            
        }*/

        public void sendKeyStroke(IntPtr key, bool status)
        {
            foreach (IntPtr handle in eClassHandle)
            {
                sendKey(key, handle, status);
            }
        }

        private void sendKey(IntPtr pKey, IntPtr handle, bool upOrdown)
        {
            bool success;
            if (upOrdown)
            {
                success = Win32.PostMessage(handle, Win32.WM_KEYDOWN, pKey, Win32.DOWN);
                //success = Win32.PostMessage(handle, Win32.WM_CHARR, pKey, IntPtr.Zero);
            }
            else
            {
                //Win32.PostMessage(eClassHandle, Win32.WM_CHAR, 0x00000000 + (Int32)pKey, 0x00140001);
                success = Win32.PostMessage(handle, Win32.WM_KEYUP, pKey, Win32.UP);
            }
            if (!success)
            {
                //fail
            }
        }

        private void sendChar(char pChar, IntPtr handle)
        {
            Win32.PostMessage(handle, Win32.WM_KEYDOWN, (IntPtr)Win32.VkKeyScan(pChar), 0x00140001);
            //Win32.PostMessage(eClassHandle, Win32.WM_CHAR, 0x00000000 + (Int32)pChar, 0x00140001);
            Win32.PostMessage(handle, Win32.WM_KEYUP, (IntPtr)Win32.VkKeyScan(pChar), 0xC0140001);
        }

        public void Wait(float pSeconds)
        { System.Threading.Thread.Sleep((Int32)(pSeconds * 1000)); }



    }
}
