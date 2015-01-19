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

﻿namespace Multi_Client_Controller
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.runBtn = new System.Windows.Forms.Button();
            this.statusTxt = new System.Windows.Forms.RichTextBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.keyBtn = new System.Windows.Forms.Button();
            this.stopHook = new System.Windows.Forms.Button();
            this.toggle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(94, 280);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(108, 23);
            this.runBtn.TabIndex = 0;
            this.runBtn.Text = "Start new client";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // statusTxt
            // 
            this.statusTxt.Location = new System.Drawing.Point(12, 12);
            this.statusTxt.Name = "statusTxt";
            this.statusTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.statusTxt.Size = new System.Drawing.Size(536, 246);
            this.statusTxt.TabIndex = 1;
            this.statusTxt.Text = "";
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(256, 280);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(108, 23);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.Text = "Close All Clients";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // keyBtn
            // 
            this.keyBtn.Location = new System.Drawing.Point(94, 327);
            this.keyBtn.Name = "keyBtn";
            this.keyBtn.Size = new System.Drawing.Size(108, 23);
            this.keyBtn.TabIndex = 4;
            this.keyBtn.Text = "Refresh";
            this.keyBtn.UseVisualStyleBackColor = true;
            this.keyBtn.Click += new System.EventHandler(this.keyBtn_Click);
            // 
            // stopHook
            // 
            this.stopHook.Location = new System.Drawing.Point(256, 327);
            this.stopHook.Name = "stopHook";
            this.stopHook.Size = new System.Drawing.Size(108, 23);
            this.stopHook.TabIndex = 5;
            this.stopHook.Text = "Start Detecting";
            this.stopHook.UseVisualStyleBackColor = true;
            this.stopHook.Click += new System.EventHandler(this.stopHook_Click);
            // 
            // toggle
            // 
            this.toggle.Location = new System.Drawing.Point(382, 327);
            this.toggle.Name = "toggle";
            this.toggle.Size = new System.Drawing.Size(93, 23);
            this.toggle.TabIndex = 6;
            this.toggle.Text = "Toggle Control";
            this.toggle.UseVisualStyleBackColor = true;
            this.toggle.Click += new System.EventHandler(this.toggle_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 375);
            this.Controls.Add(this.toggle);
            this.Controls.Add(this.stopHook);
            this.Controls.Add(this.keyBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.statusTxt);
            this.Controls.Add(this.runBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Main";
            this.Text = "Qwename\'s Multi Client Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.RichTextBox statusTxt;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button keyBtn;
        private System.Windows.Forms.Button stopHook;
        private System.Windows.Forms.Button toggle;
    }
}

