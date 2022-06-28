//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Data Access Application Block
//===============================================================================
// Copyright © 2004 Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

using NCI.EasyObjects;
using EasyObjectsQuickStart.BLL;

namespace EasyObjectsQuickStart
{
    /// <summary>
    /// Enterprise Library Data Access Block Quick Start Sample.
    /// Please run SetupQuickStartsDB.bat to create database objects 
    /// used by this sample.
    /// </summary>
    public class QuickStartForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        private Label label4;
        private GroupBox groupBox1;
        private GroupBox groupBox;

        private Process viewerProcess = null;
        private DataGrid resultsDataGrid;
        private Button transactionalUpdateButton;
        private Button singleItemButton;
        private Label useCaseLabel;
        private Button retrieveUsingXmlReaderButton;
        private Button viewWalkthroughButton;
        private Button quitButton;
        private PictureBox logoPictureBox;
        private TextBox resultsTextBox;

        private const string HelpViewerExecutable = "iexplore.exe";
        private const string HelpTopicNamespace = @"ms-help://MS.EntLib.2005Jun.Da.QS";
		private System.Windows.Forms.Button btnLoadAll;
		private System.Windows.Forms.Button btnSimpleQuery;
		private System.Windows.Forms.Button btnProductsAddDelete;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblQuery;
		private System.Windows.Forms.LinkLabel linkDownload;
		private System.Windows.Forms.CheckBox chkStoredProcedures;
		private System.Windows.Forms.Button btnAggregate;

		public static System.Windows.Forms.Form AppForm;

        public QuickStartForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(QuickStartForm));
			this.resultsTextBox = new System.Windows.Forms.TextBox();
			this.transactionalUpdateButton = new System.Windows.Forms.Button();
			this.singleItemButton = new System.Windows.Forms.Button();
			this.btnLoadAll = new System.Windows.Forms.Button();
			this.btnProductsAddDelete = new System.Windows.Forms.Button();
			this.btnSimpleQuery = new System.Windows.Forms.Button();
			this.useCaseLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.retrieveUsingXmlReaderButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.logoPictureBox = new System.Windows.Forms.PictureBox();
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.linkDownload = new System.Windows.Forms.LinkLabel();
			this.viewWalkthroughButton = new System.Windows.Forms.Button();
			this.quitButton = new System.Windows.Forms.Button();
			this.resultsDataGrid = new System.Windows.Forms.DataGrid();
			this.lblQuery = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.chkStoredProcedures = new System.Windows.Forms.CheckBox();
			this.btnAggregate = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.resultsDataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// resultsTextBox
			// 
			this.resultsTextBox.AccessibleDescription = resources.GetString("resultsTextBox.AccessibleDescription");
			this.resultsTextBox.AccessibleName = resources.GetString("resultsTextBox.AccessibleName");
			this.resultsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resultsTextBox.Anchor")));
			this.resultsTextBox.AutoSize = ((bool)(resources.GetObject("resultsTextBox.AutoSize")));
			this.resultsTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resultsTextBox.BackgroundImage")));
			this.resultsTextBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resultsTextBox.Dock")));
			this.resultsTextBox.Enabled = ((bool)(resources.GetObject("resultsTextBox.Enabled")));
			this.resultsTextBox.Font = ((System.Drawing.Font)(resources.GetObject("resultsTextBox.Font")));
			this.resultsTextBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resultsTextBox.ImeMode")));
			this.resultsTextBox.Location = ((System.Drawing.Point)(resources.GetObject("resultsTextBox.Location")));
			this.resultsTextBox.MaxLength = ((int)(resources.GetObject("resultsTextBox.MaxLength")));
			this.resultsTextBox.Multiline = ((bool)(resources.GetObject("resultsTextBox.Multiline")));
			this.resultsTextBox.Name = "resultsTextBox";
			this.resultsTextBox.PasswordChar = ((char)(resources.GetObject("resultsTextBox.PasswordChar")));
			this.resultsTextBox.ReadOnly = true;
			this.resultsTextBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resultsTextBox.RightToLeft")));
			this.resultsTextBox.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("resultsTextBox.ScrollBars")));
			this.resultsTextBox.Size = ((System.Drawing.Size)(resources.GetObject("resultsTextBox.Size")));
			this.resultsTextBox.TabIndex = ((int)(resources.GetObject("resultsTextBox.TabIndex")));
			this.resultsTextBox.TabStop = false;
			this.resultsTextBox.Text = resources.GetString("resultsTextBox.Text");
			this.resultsTextBox.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("resultsTextBox.TextAlign")));
			this.resultsTextBox.Visible = ((bool)(resources.GetObject("resultsTextBox.Visible")));
			this.resultsTextBox.WordWrap = ((bool)(resources.GetObject("resultsTextBox.WordWrap")));
			// 
			// transactionalUpdateButton
			// 
			this.transactionalUpdateButton.AccessibleDescription = resources.GetString("transactionalUpdateButton.AccessibleDescription");
			this.transactionalUpdateButton.AccessibleName = resources.GetString("transactionalUpdateButton.AccessibleName");
			this.transactionalUpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("transactionalUpdateButton.Anchor")));
			this.transactionalUpdateButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("transactionalUpdateButton.BackgroundImage")));
			this.transactionalUpdateButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("transactionalUpdateButton.Dock")));
			this.transactionalUpdateButton.Enabled = ((bool)(resources.GetObject("transactionalUpdateButton.Enabled")));
			this.transactionalUpdateButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("transactionalUpdateButton.FlatStyle")));
			this.transactionalUpdateButton.Font = ((System.Drawing.Font)(resources.GetObject("transactionalUpdateButton.Font")));
			this.transactionalUpdateButton.Image = ((System.Drawing.Image)(resources.GetObject("transactionalUpdateButton.Image")));
			this.transactionalUpdateButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("transactionalUpdateButton.ImageAlign")));
			this.transactionalUpdateButton.ImageIndex = ((int)(resources.GetObject("transactionalUpdateButton.ImageIndex")));
			this.transactionalUpdateButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("transactionalUpdateButton.ImeMode")));
			this.transactionalUpdateButton.Location = ((System.Drawing.Point)(resources.GetObject("transactionalUpdateButton.Location")));
			this.transactionalUpdateButton.Name = "transactionalUpdateButton";
			this.transactionalUpdateButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("transactionalUpdateButton.RightToLeft")));
			this.transactionalUpdateButton.Size = ((System.Drawing.Size)(resources.GetObject("transactionalUpdateButton.Size")));
			this.transactionalUpdateButton.TabIndex = ((int)(resources.GetObject("transactionalUpdateButton.TabIndex")));
			this.transactionalUpdateButton.Text = resources.GetString("transactionalUpdateButton.Text");
			this.transactionalUpdateButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("transactionalUpdateButton.TextAlign")));
			this.transactionalUpdateButton.Visible = ((bool)(resources.GetObject("transactionalUpdateButton.Visible")));
			this.transactionalUpdateButton.Click += new System.EventHandler(this.transactionalUpdateButton_Click);
			// 
			// singleItemButton
			// 
			this.singleItemButton.AccessibleDescription = resources.GetString("singleItemButton.AccessibleDescription");
			this.singleItemButton.AccessibleName = resources.GetString("singleItemButton.AccessibleName");
			this.singleItemButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("singleItemButton.Anchor")));
			this.singleItemButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("singleItemButton.BackgroundImage")));
			this.singleItemButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("singleItemButton.Dock")));
			this.singleItemButton.Enabled = ((bool)(resources.GetObject("singleItemButton.Enabled")));
			this.singleItemButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("singleItemButton.FlatStyle")));
			this.singleItemButton.Font = ((System.Drawing.Font)(resources.GetObject("singleItemButton.Font")));
			this.singleItemButton.Image = ((System.Drawing.Image)(resources.GetObject("singleItemButton.Image")));
			this.singleItemButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("singleItemButton.ImageAlign")));
			this.singleItemButton.ImageIndex = ((int)(resources.GetObject("singleItemButton.ImageIndex")));
			this.singleItemButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("singleItemButton.ImeMode")));
			this.singleItemButton.Location = ((System.Drawing.Point)(resources.GetObject("singleItemButton.Location")));
			this.singleItemButton.Name = "singleItemButton";
			this.singleItemButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("singleItemButton.RightToLeft")));
			this.singleItemButton.Size = ((System.Drawing.Size)(resources.GetObject("singleItemButton.Size")));
			this.singleItemButton.TabIndex = ((int)(resources.GetObject("singleItemButton.TabIndex")));
			this.singleItemButton.Text = resources.GetString("singleItemButton.Text");
			this.singleItemButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("singleItemButton.TextAlign")));
			this.singleItemButton.Visible = ((bool)(resources.GetObject("singleItemButton.Visible")));
			this.singleItemButton.Click += new System.EventHandler(this.singleItemButton_Click);
			// 
			// btnLoadAll
			// 
			this.btnLoadAll.AccessibleDescription = resources.GetString("btnLoadAll.AccessibleDescription");
			this.btnLoadAll.AccessibleName = resources.GetString("btnLoadAll.AccessibleName");
			this.btnLoadAll.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnLoadAll.Anchor")));
			this.btnLoadAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoadAll.BackgroundImage")));
			this.btnLoadAll.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnLoadAll.Dock")));
			this.btnLoadAll.Enabled = ((bool)(resources.GetObject("btnLoadAll.Enabled")));
			this.btnLoadAll.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnLoadAll.FlatStyle")));
			this.btnLoadAll.Font = ((System.Drawing.Font)(resources.GetObject("btnLoadAll.Font")));
			this.btnLoadAll.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadAll.Image")));
			this.btnLoadAll.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnLoadAll.ImageAlign")));
			this.btnLoadAll.ImageIndex = ((int)(resources.GetObject("btnLoadAll.ImageIndex")));
			this.btnLoadAll.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnLoadAll.ImeMode")));
			this.btnLoadAll.Location = ((System.Drawing.Point)(resources.GetObject("btnLoadAll.Location")));
			this.btnLoadAll.Name = "btnLoadAll";
			this.btnLoadAll.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnLoadAll.RightToLeft")));
			this.btnLoadAll.Size = ((System.Drawing.Size)(resources.GetObject("btnLoadAll.Size")));
			this.btnLoadAll.TabIndex = ((int)(resources.GetObject("btnLoadAll.TabIndex")));
			this.btnLoadAll.Text = resources.GetString("btnLoadAll.Text");
			this.btnLoadAll.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnLoadAll.TextAlign")));
			this.btnLoadAll.Visible = ((bool)(resources.GetObject("btnLoadAll.Visible")));
			this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
			// 
			// btnProductsAddDelete
			// 
			this.btnProductsAddDelete.AccessibleDescription = resources.GetString("btnProductsAddDelete.AccessibleDescription");
			this.btnProductsAddDelete.AccessibleName = resources.GetString("btnProductsAddDelete.AccessibleName");
			this.btnProductsAddDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnProductsAddDelete.Anchor")));
			this.btnProductsAddDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProductsAddDelete.BackgroundImage")));
			this.btnProductsAddDelete.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnProductsAddDelete.Dock")));
			this.btnProductsAddDelete.Enabled = ((bool)(resources.GetObject("btnProductsAddDelete.Enabled")));
			this.btnProductsAddDelete.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnProductsAddDelete.FlatStyle")));
			this.btnProductsAddDelete.Font = ((System.Drawing.Font)(resources.GetObject("btnProductsAddDelete.Font")));
			this.btnProductsAddDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnProductsAddDelete.Image")));
			this.btnProductsAddDelete.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnProductsAddDelete.ImageAlign")));
			this.btnProductsAddDelete.ImageIndex = ((int)(resources.GetObject("btnProductsAddDelete.ImageIndex")));
			this.btnProductsAddDelete.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnProductsAddDelete.ImeMode")));
			this.btnProductsAddDelete.Location = ((System.Drawing.Point)(resources.GetObject("btnProductsAddDelete.Location")));
			this.btnProductsAddDelete.Name = "btnProductsAddDelete";
			this.btnProductsAddDelete.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnProductsAddDelete.RightToLeft")));
			this.btnProductsAddDelete.Size = ((System.Drawing.Size)(resources.GetObject("btnProductsAddDelete.Size")));
			this.btnProductsAddDelete.TabIndex = ((int)(resources.GetObject("btnProductsAddDelete.TabIndex")));
			this.btnProductsAddDelete.Text = resources.GetString("btnProductsAddDelete.Text");
			this.btnProductsAddDelete.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnProductsAddDelete.TextAlign")));
			this.btnProductsAddDelete.Visible = ((bool)(resources.GetObject("btnProductsAddDelete.Visible")));
			this.btnProductsAddDelete.Click += new System.EventHandler(this.btnProductsAddDelete_Click);
			// 
			// btnSimpleQuery
			// 
			this.btnSimpleQuery.AccessibleDescription = resources.GetString("btnSimpleQuery.AccessibleDescription");
			this.btnSimpleQuery.AccessibleName = resources.GetString("btnSimpleQuery.AccessibleName");
			this.btnSimpleQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnSimpleQuery.Anchor")));
			this.btnSimpleQuery.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSimpleQuery.BackgroundImage")));
			this.btnSimpleQuery.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnSimpleQuery.Dock")));
			this.btnSimpleQuery.Enabled = ((bool)(resources.GetObject("btnSimpleQuery.Enabled")));
			this.btnSimpleQuery.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnSimpleQuery.FlatStyle")));
			this.btnSimpleQuery.Font = ((System.Drawing.Font)(resources.GetObject("btnSimpleQuery.Font")));
			this.btnSimpleQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnSimpleQuery.Image")));
			this.btnSimpleQuery.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSimpleQuery.ImageAlign")));
			this.btnSimpleQuery.ImageIndex = ((int)(resources.GetObject("btnSimpleQuery.ImageIndex")));
			this.btnSimpleQuery.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnSimpleQuery.ImeMode")));
			this.btnSimpleQuery.Location = ((System.Drawing.Point)(resources.GetObject("btnSimpleQuery.Location")));
			this.btnSimpleQuery.Name = "btnSimpleQuery";
			this.btnSimpleQuery.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnSimpleQuery.RightToLeft")));
			this.btnSimpleQuery.Size = ((System.Drawing.Size)(resources.GetObject("btnSimpleQuery.Size")));
			this.btnSimpleQuery.TabIndex = ((int)(resources.GetObject("btnSimpleQuery.TabIndex")));
			this.btnSimpleQuery.Text = resources.GetString("btnSimpleQuery.Text");
			this.btnSimpleQuery.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSimpleQuery.TextAlign")));
			this.btnSimpleQuery.Visible = ((bool)(resources.GetObject("btnSimpleQuery.Visible")));
			this.btnSimpleQuery.Click += new System.EventHandler(this.btnSimpleQuery_Click);
			// 
			// useCaseLabel
			// 
			this.useCaseLabel.AccessibleDescription = resources.GetString("useCaseLabel.AccessibleDescription");
			this.useCaseLabel.AccessibleName = resources.GetString("useCaseLabel.AccessibleName");
			this.useCaseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("useCaseLabel.Anchor")));
			this.useCaseLabel.AutoSize = ((bool)(resources.GetObject("useCaseLabel.AutoSize")));
			this.useCaseLabel.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("useCaseLabel.Dock")));
			this.useCaseLabel.Enabled = ((bool)(resources.GetObject("useCaseLabel.Enabled")));
			this.useCaseLabel.Font = ((System.Drawing.Font)(resources.GetObject("useCaseLabel.Font")));
			this.useCaseLabel.Image = ((System.Drawing.Image)(resources.GetObject("useCaseLabel.Image")));
			this.useCaseLabel.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("useCaseLabel.ImageAlign")));
			this.useCaseLabel.ImageIndex = ((int)(resources.GetObject("useCaseLabel.ImageIndex")));
			this.useCaseLabel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("useCaseLabel.ImeMode")));
			this.useCaseLabel.Location = ((System.Drawing.Point)(resources.GetObject("useCaseLabel.Location")));
			this.useCaseLabel.Name = "useCaseLabel";
			this.useCaseLabel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("useCaseLabel.RightToLeft")));
			this.useCaseLabel.Size = ((System.Drawing.Size)(resources.GetObject("useCaseLabel.Size")));
			this.useCaseLabel.TabIndex = ((int)(resources.GetObject("useCaseLabel.TabIndex")));
			this.useCaseLabel.Text = resources.GetString("useCaseLabel.Text");
			this.useCaseLabel.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("useCaseLabel.TextAlign")));
			this.useCaseLabel.Visible = ((bool)(resources.GetObject("useCaseLabel.Visible")));
			// 
			// label4
			// 
			this.label4.AccessibleDescription = resources.GetString("label4.AccessibleDescription");
			this.label4.AccessibleName = resources.GetString("label4.AccessibleName");
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label4.Anchor")));
			this.label4.AutoSize = ((bool)(resources.GetObject("label4.AutoSize")));
			this.label4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label4.Dock")));
			this.label4.Enabled = ((bool)(resources.GetObject("label4.Enabled")));
			this.label4.Font = ((System.Drawing.Font)(resources.GetObject("label4.Font")));
			this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
			this.label4.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label4.ImageAlign")));
			this.label4.ImageIndex = ((int)(resources.GetObject("label4.ImageIndex")));
			this.label4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label4.ImeMode")));
			this.label4.Location = ((System.Drawing.Point)(resources.GetObject("label4.Location")));
			this.label4.Name = "label4";
			this.label4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label4.RightToLeft")));
			this.label4.Size = ((System.Drawing.Size)(resources.GetObject("label4.Size")));
			this.label4.TabIndex = ((int)(resources.GetObject("label4.TabIndex")));
			this.label4.Text = resources.GetString("label4.Text");
			this.label4.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label4.TextAlign")));
			this.label4.Visible = ((bool)(resources.GetObject("label4.Visible")));
			// 
			// retrieveUsingXmlReaderButton
			// 
			this.retrieveUsingXmlReaderButton.AccessibleDescription = resources.GetString("retrieveUsingXmlReaderButton.AccessibleDescription");
			this.retrieveUsingXmlReaderButton.AccessibleName = resources.GetString("retrieveUsingXmlReaderButton.AccessibleName");
			this.retrieveUsingXmlReaderButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("retrieveUsingXmlReaderButton.Anchor")));
			this.retrieveUsingXmlReaderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("retrieveUsingXmlReaderButton.BackgroundImage")));
			this.retrieveUsingXmlReaderButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("retrieveUsingXmlReaderButton.Dock")));
			this.retrieveUsingXmlReaderButton.Enabled = ((bool)(resources.GetObject("retrieveUsingXmlReaderButton.Enabled")));
			this.retrieveUsingXmlReaderButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("retrieveUsingXmlReaderButton.FlatStyle")));
			this.retrieveUsingXmlReaderButton.Font = ((System.Drawing.Font)(resources.GetObject("retrieveUsingXmlReaderButton.Font")));
			this.retrieveUsingXmlReaderButton.Image = ((System.Drawing.Image)(resources.GetObject("retrieveUsingXmlReaderButton.Image")));
			this.retrieveUsingXmlReaderButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("retrieveUsingXmlReaderButton.ImageAlign")));
			this.retrieveUsingXmlReaderButton.ImageIndex = ((int)(resources.GetObject("retrieveUsingXmlReaderButton.ImageIndex")));
			this.retrieveUsingXmlReaderButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("retrieveUsingXmlReaderButton.ImeMode")));
			this.retrieveUsingXmlReaderButton.Location = ((System.Drawing.Point)(resources.GetObject("retrieveUsingXmlReaderButton.Location")));
			this.retrieveUsingXmlReaderButton.Name = "retrieveUsingXmlReaderButton";
			this.retrieveUsingXmlReaderButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("retrieveUsingXmlReaderButton.RightToLeft")));
			this.retrieveUsingXmlReaderButton.Size = ((System.Drawing.Size)(resources.GetObject("retrieveUsingXmlReaderButton.Size")));
			this.retrieveUsingXmlReaderButton.TabIndex = ((int)(resources.GetObject("retrieveUsingXmlReaderButton.TabIndex")));
			this.retrieveUsingXmlReaderButton.Text = resources.GetString("retrieveUsingXmlReaderButton.Text");
			this.retrieveUsingXmlReaderButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("retrieveUsingXmlReaderButton.TextAlign")));
			this.retrieveUsingXmlReaderButton.Visible = ((bool)(resources.GetObject("retrieveUsingXmlReaderButton.Visible")));
			this.retrieveUsingXmlReaderButton.Click += new System.EventHandler(this.retrieveUsingXmlReaderButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.AccessibleDescription = resources.GetString("groupBox1.AccessibleDescription");
			this.groupBox1.AccessibleName = resources.GetString("groupBox1.AccessibleName");
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox1.Anchor")));
			this.groupBox1.BackColor = System.Drawing.Color.White;
			this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
			this.groupBox1.Controls.Add(this.logoPictureBox);
			this.groupBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox1.Dock")));
			this.groupBox1.Enabled = ((bool)(resources.GetObject("groupBox1.Enabled")));
			this.groupBox1.Font = ((System.Drawing.Font)(resources.GetObject("groupBox1.Font")));
			this.groupBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox1.ImeMode")));
			this.groupBox1.Location = ((System.Drawing.Point)(resources.GetObject("groupBox1.Location")));
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox1.RightToLeft")));
			this.groupBox1.Size = ((System.Drawing.Size)(resources.GetObject("groupBox1.Size")));
			this.groupBox1.TabIndex = ((int)(resources.GetObject("groupBox1.TabIndex")));
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = resources.GetString("groupBox1.Text");
			this.groupBox1.Visible = ((bool)(resources.GetObject("groupBox1.Visible")));
			// 
			// logoPictureBox
			// 
			this.logoPictureBox.AccessibleDescription = resources.GetString("logoPictureBox.AccessibleDescription");
			this.logoPictureBox.AccessibleName = resources.GetString("logoPictureBox.AccessibleName");
			this.logoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("logoPictureBox.Anchor")));
			this.logoPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.BackgroundImage")));
			this.logoPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.logoPictureBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("logoPictureBox.Dock")));
			this.logoPictureBox.Enabled = ((bool)(resources.GetObject("logoPictureBox.Enabled")));
			this.logoPictureBox.Font = ((System.Drawing.Font)(resources.GetObject("logoPictureBox.Font")));
			this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
			this.logoPictureBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("logoPictureBox.ImeMode")));
			this.logoPictureBox.Location = ((System.Drawing.Point)(resources.GetObject("logoPictureBox.Location")));
			this.logoPictureBox.Name = "logoPictureBox";
			this.logoPictureBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("logoPictureBox.RightToLeft")));
			this.logoPictureBox.Size = ((System.Drawing.Size)(resources.GetObject("logoPictureBox.Size")));
			this.logoPictureBox.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode)(resources.GetObject("logoPictureBox.SizeMode")));
			this.logoPictureBox.TabIndex = ((int)(resources.GetObject("logoPictureBox.TabIndex")));
			this.logoPictureBox.TabStop = false;
			this.logoPictureBox.Text = resources.GetString("logoPictureBox.Text");
			this.logoPictureBox.Visible = ((bool)(resources.GetObject("logoPictureBox.Visible")));
			this.logoPictureBox.Click += new System.EventHandler(this.logoPictureBox_Click);
			// 
			// groupBox
			// 
			this.groupBox.AccessibleDescription = resources.GetString("groupBox.AccessibleDescription");
			this.groupBox.AccessibleName = resources.GetString("groupBox.AccessibleName");
			this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox.Anchor")));
			this.groupBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox.BackgroundImage")));
			this.groupBox.Controls.Add(this.linkDownload);
			this.groupBox.Controls.Add(this.viewWalkthroughButton);
			this.groupBox.Controls.Add(this.quitButton);
			this.groupBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox.Dock")));
			this.groupBox.Enabled = ((bool)(resources.GetObject("groupBox.Enabled")));
			this.groupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox.Font = ((System.Drawing.Font)(resources.GetObject("groupBox.Font")));
			this.groupBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox.ImeMode")));
			this.groupBox.Location = ((System.Drawing.Point)(resources.GetObject("groupBox.Location")));
			this.groupBox.Name = "groupBox";
			this.groupBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox.RightToLeft")));
			this.groupBox.Size = ((System.Drawing.Size)(resources.GetObject("groupBox.Size")));
			this.groupBox.TabIndex = ((int)(resources.GetObject("groupBox.TabIndex")));
			this.groupBox.TabStop = false;
			this.groupBox.Text = resources.GetString("groupBox.Text");
			this.groupBox.Visible = ((bool)(resources.GetObject("groupBox.Visible")));
			// 
			// linkDownload
			// 
			this.linkDownload.AccessibleDescription = resources.GetString("linkDownload.AccessibleDescription");
			this.linkDownload.AccessibleName = resources.GetString("linkDownload.AccessibleName");
			this.linkDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("linkDownload.Anchor")));
			this.linkDownload.AutoSize = ((bool)(resources.GetObject("linkDownload.AutoSize")));
			this.linkDownload.CausesValidation = false;
			this.linkDownload.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("linkDownload.Dock")));
			this.linkDownload.Enabled = ((bool)(resources.GetObject("linkDownload.Enabled")));
			this.linkDownload.Font = ((System.Drawing.Font)(resources.GetObject("linkDownload.Font")));
			this.linkDownload.Image = ((System.Drawing.Image)(resources.GetObject("linkDownload.Image")));
			this.linkDownload.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("linkDownload.ImageAlign")));
			this.linkDownload.ImageIndex = ((int)(resources.GetObject("linkDownload.ImageIndex")));
			this.linkDownload.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("linkDownload.ImeMode")));
			this.linkDownload.LinkArea = ((System.Windows.Forms.LinkArea)(resources.GetObject("linkDownload.LinkArea")));
			this.linkDownload.Location = ((System.Drawing.Point)(resources.GetObject("linkDownload.Location")));
			this.linkDownload.Name = "linkDownload";
			this.linkDownload.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("linkDownload.RightToLeft")));
			this.linkDownload.Size = ((System.Drawing.Size)(resources.GetObject("linkDownload.Size")));
			this.linkDownload.TabIndex = ((int)(resources.GetObject("linkDownload.TabIndex")));
			this.linkDownload.TabStop = true;
			this.linkDownload.Text = resources.GetString("linkDownload.Text");
			this.linkDownload.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("linkDownload.TextAlign")));
			this.linkDownload.Visible = ((bool)(resources.GetObject("linkDownload.Visible")));
			this.linkDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDownload_LinkClicked);
			// 
			// viewWalkthroughButton
			// 
			this.viewWalkthroughButton.AccessibleDescription = resources.GetString("viewWalkthroughButton.AccessibleDescription");
			this.viewWalkthroughButton.AccessibleName = resources.GetString("viewWalkthroughButton.AccessibleName");
			this.viewWalkthroughButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("viewWalkthroughButton.Anchor")));
			this.viewWalkthroughButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("viewWalkthroughButton.BackgroundImage")));
			this.viewWalkthroughButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("viewWalkthroughButton.Dock")));
			this.viewWalkthroughButton.Enabled = ((bool)(resources.GetObject("viewWalkthroughButton.Enabled")));
			this.viewWalkthroughButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("viewWalkthroughButton.FlatStyle")));
			this.viewWalkthroughButton.Font = ((System.Drawing.Font)(resources.GetObject("viewWalkthroughButton.Font")));
			this.viewWalkthroughButton.Image = ((System.Drawing.Image)(resources.GetObject("viewWalkthroughButton.Image")));
			this.viewWalkthroughButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("viewWalkthroughButton.ImageAlign")));
			this.viewWalkthroughButton.ImageIndex = ((int)(resources.GetObject("viewWalkthroughButton.ImageIndex")));
			this.viewWalkthroughButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("viewWalkthroughButton.ImeMode")));
			this.viewWalkthroughButton.Location = ((System.Drawing.Point)(resources.GetObject("viewWalkthroughButton.Location")));
			this.viewWalkthroughButton.Name = "viewWalkthroughButton";
			this.viewWalkthroughButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("viewWalkthroughButton.RightToLeft")));
			this.viewWalkthroughButton.Size = ((System.Drawing.Size)(resources.GetObject("viewWalkthroughButton.Size")));
			this.viewWalkthroughButton.TabIndex = ((int)(resources.GetObject("viewWalkthroughButton.TabIndex")));
			this.viewWalkthroughButton.Text = resources.GetString("viewWalkthroughButton.Text");
			this.viewWalkthroughButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("viewWalkthroughButton.TextAlign")));
			this.viewWalkthroughButton.Visible = ((bool)(resources.GetObject("viewWalkthroughButton.Visible")));
			this.viewWalkthroughButton.Click += new System.EventHandler(this.viewWalkthroughButton_Click);
			// 
			// quitButton
			// 
			this.quitButton.AccessibleDescription = resources.GetString("quitButton.AccessibleDescription");
			this.quitButton.AccessibleName = resources.GetString("quitButton.AccessibleName");
			this.quitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("quitButton.Anchor")));
			this.quitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("quitButton.BackgroundImage")));
			this.quitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.quitButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("quitButton.Dock")));
			this.quitButton.Enabled = ((bool)(resources.GetObject("quitButton.Enabled")));
			this.quitButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("quitButton.FlatStyle")));
			this.quitButton.Font = ((System.Drawing.Font)(resources.GetObject("quitButton.Font")));
			this.quitButton.Image = ((System.Drawing.Image)(resources.GetObject("quitButton.Image")));
			this.quitButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("quitButton.ImageAlign")));
			this.quitButton.ImageIndex = ((int)(resources.GetObject("quitButton.ImageIndex")));
			this.quitButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("quitButton.ImeMode")));
			this.quitButton.Location = ((System.Drawing.Point)(resources.GetObject("quitButton.Location")));
			this.quitButton.Name = "quitButton";
			this.quitButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("quitButton.RightToLeft")));
			this.quitButton.Size = ((System.Drawing.Size)(resources.GetObject("quitButton.Size")));
			this.quitButton.TabIndex = ((int)(resources.GetObject("quitButton.TabIndex")));
			this.quitButton.Text = resources.GetString("quitButton.Text");
			this.quitButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("quitButton.TextAlign")));
			this.quitButton.Visible = ((bool)(resources.GetObject("quitButton.Visible")));
			this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
			// 
			// resultsDataGrid
			// 
			this.resultsDataGrid.AccessibleDescription = resources.GetString("resultsDataGrid.AccessibleDescription");
			this.resultsDataGrid.AccessibleName = resources.GetString("resultsDataGrid.AccessibleName");
			this.resultsDataGrid.AlternatingBackColor = System.Drawing.Color.FromArgb(((System.Byte)(173)), ((System.Byte)(207)), ((System.Byte)(239)));
			this.resultsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resultsDataGrid.Anchor")));
			this.resultsDataGrid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resultsDataGrid.BackgroundImage")));
			this.resultsDataGrid.CaptionFont = ((System.Drawing.Font)(resources.GetObject("resultsDataGrid.CaptionFont")));
			this.resultsDataGrid.CaptionText = resources.GetString("resultsDataGrid.CaptionText");
			this.resultsDataGrid.DataMember = "";
			this.resultsDataGrid.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resultsDataGrid.Dock")));
			this.resultsDataGrid.Enabled = ((bool)(resources.GetObject("resultsDataGrid.Enabled")));
			this.resultsDataGrid.Font = ((System.Drawing.Font)(resources.GetObject("resultsDataGrid.Font")));
			this.resultsDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.resultsDataGrid.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resultsDataGrid.ImeMode")));
			this.resultsDataGrid.Location = ((System.Drawing.Point)(resources.GetObject("resultsDataGrid.Location")));
			this.resultsDataGrid.Name = "resultsDataGrid";
			this.resultsDataGrid.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resultsDataGrid.RightToLeft")));
			this.resultsDataGrid.Size = ((System.Drawing.Size)(resources.GetObject("resultsDataGrid.Size")));
			this.resultsDataGrid.TabIndex = ((int)(resources.GetObject("resultsDataGrid.TabIndex")));
			this.resultsDataGrid.TabStop = false;
			this.resultsDataGrid.Visible = ((bool)(resources.GetObject("resultsDataGrid.Visible")));
			// 
			// lblQuery
			// 
			this.lblQuery.AccessibleDescription = resources.GetString("lblQuery.AccessibleDescription");
			this.lblQuery.AccessibleName = resources.GetString("lblQuery.AccessibleName");
			this.lblQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblQuery.Anchor")));
			this.lblQuery.AutoSize = ((bool)(resources.GetObject("lblQuery.AutoSize")));
			this.lblQuery.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblQuery.Dock")));
			this.lblQuery.Enabled = ((bool)(resources.GetObject("lblQuery.Enabled")));
			this.lblQuery.Font = ((System.Drawing.Font)(resources.GetObject("lblQuery.Font")));
			this.lblQuery.Image = ((System.Drawing.Image)(resources.GetObject("lblQuery.Image")));
			this.lblQuery.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblQuery.ImageAlign")));
			this.lblQuery.ImageIndex = ((int)(resources.GetObject("lblQuery.ImageIndex")));
			this.lblQuery.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblQuery.ImeMode")));
			this.lblQuery.Location = ((System.Drawing.Point)(resources.GetObject("lblQuery.Location")));
			this.lblQuery.Name = "lblQuery";
			this.lblQuery.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblQuery.RightToLeft")));
			this.lblQuery.Size = ((System.Drawing.Size)(resources.GetObject("lblQuery.Size")));
			this.lblQuery.TabIndex = ((int)(resources.GetObject("lblQuery.TabIndex")));
			this.lblQuery.Text = resources.GetString("lblQuery.Text");
			this.lblQuery.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblQuery.TextAlign")));
			this.lblQuery.Visible = ((bool)(resources.GetObject("lblQuery.Visible")));
			// 
			// label2
			// 
			this.label2.AccessibleDescription = resources.GetString("label2.AccessibleDescription");
			this.label2.AccessibleName = resources.GetString("label2.AccessibleName");
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label2.Anchor")));
			this.label2.AutoSize = ((bool)(resources.GetObject("label2.AutoSize")));
			this.label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label2.Dock")));
			this.label2.Enabled = ((bool)(resources.GetObject("label2.Enabled")));
			this.label2.Font = ((System.Drawing.Font)(resources.GetObject("label2.Font")));
			this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
			this.label2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.ImageAlign")));
			this.label2.ImageIndex = ((int)(resources.GetObject("label2.ImageIndex")));
			this.label2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label2.ImeMode")));
			this.label2.Location = ((System.Drawing.Point)(resources.GetObject("label2.Location")));
			this.label2.Name = "label2";
			this.label2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label2.RightToLeft")));
			this.label2.Size = ((System.Drawing.Size)(resources.GetObject("label2.Size")));
			this.label2.TabIndex = ((int)(resources.GetObject("label2.TabIndex")));
			this.label2.Text = resources.GetString("label2.Text");
			this.label2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.TextAlign")));
			this.label2.Visible = ((bool)(resources.GetObject("label2.Visible")));
			// 
			// chkStoredProcedures
			// 
			this.chkStoredProcedures.AccessibleDescription = resources.GetString("chkStoredProcedures.AccessibleDescription");
			this.chkStoredProcedures.AccessibleName = resources.GetString("chkStoredProcedures.AccessibleName");
			this.chkStoredProcedures.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkStoredProcedures.Anchor")));
			this.chkStoredProcedures.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkStoredProcedures.Appearance")));
			this.chkStoredProcedures.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkStoredProcedures.BackgroundImage")));
			this.chkStoredProcedures.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkStoredProcedures.CheckAlign")));
			this.chkStoredProcedures.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkStoredProcedures.Dock")));
			this.chkStoredProcedures.Enabled = ((bool)(resources.GetObject("chkStoredProcedures.Enabled")));
			this.chkStoredProcedures.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkStoredProcedures.FlatStyle")));
			this.chkStoredProcedures.Font = ((System.Drawing.Font)(resources.GetObject("chkStoredProcedures.Font")));
			this.chkStoredProcedures.Image = ((System.Drawing.Image)(resources.GetObject("chkStoredProcedures.Image")));
			this.chkStoredProcedures.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkStoredProcedures.ImageAlign")));
			this.chkStoredProcedures.ImageIndex = ((int)(resources.GetObject("chkStoredProcedures.ImageIndex")));
			this.chkStoredProcedures.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkStoredProcedures.ImeMode")));
			this.chkStoredProcedures.Location = ((System.Drawing.Point)(resources.GetObject("chkStoredProcedures.Location")));
			this.chkStoredProcedures.Name = "chkStoredProcedures";
			this.chkStoredProcedures.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkStoredProcedures.RightToLeft")));
			this.chkStoredProcedures.Size = ((System.Drawing.Size)(resources.GetObject("chkStoredProcedures.Size")));
			this.chkStoredProcedures.TabIndex = ((int)(resources.GetObject("chkStoredProcedures.TabIndex")));
			this.chkStoredProcedures.Text = resources.GetString("chkStoredProcedures.Text");
			this.chkStoredProcedures.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkStoredProcedures.TextAlign")));
			this.chkStoredProcedures.Visible = ((bool)(resources.GetObject("chkStoredProcedures.Visible")));
			// 
			// btnAggregate
			// 
			this.btnAggregate.AccessibleDescription = resources.GetString("btnAggregate.AccessibleDescription");
			this.btnAggregate.AccessibleName = resources.GetString("btnAggregate.AccessibleName");
			this.btnAggregate.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnAggregate.Anchor")));
			this.btnAggregate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAggregate.BackgroundImage")));
			this.btnAggregate.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnAggregate.Dock")));
			this.btnAggregate.Enabled = ((bool)(resources.GetObject("btnAggregate.Enabled")));
			this.btnAggregate.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnAggregate.FlatStyle")));
			this.btnAggregate.Font = ((System.Drawing.Font)(resources.GetObject("btnAggregate.Font")));
			this.btnAggregate.Image = ((System.Drawing.Image)(resources.GetObject("btnAggregate.Image")));
			this.btnAggregate.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnAggregate.ImageAlign")));
			this.btnAggregate.ImageIndex = ((int)(resources.GetObject("btnAggregate.ImageIndex")));
			this.btnAggregate.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnAggregate.ImeMode")));
			this.btnAggregate.Location = ((System.Drawing.Point)(resources.GetObject("btnAggregate.Location")));
			this.btnAggregate.Name = "btnAggregate";
			this.btnAggregate.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnAggregate.RightToLeft")));
			this.btnAggregate.Size = ((System.Drawing.Size)(resources.GetObject("btnAggregate.Size")));
			this.btnAggregate.TabIndex = ((int)(resources.GetObject("btnAggregate.TabIndex")));
			this.btnAggregate.Text = resources.GetString("btnAggregate.Text");
			this.btnAggregate.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnAggregate.TextAlign")));
			this.btnAggregate.Visible = ((bool)(resources.GetObject("btnAggregate.Visible")));
			this.btnAggregate.Click += new System.EventHandler(this.btnAggregate_Click);
			// 
			// QuickStartForm
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.CancelButton = this.quitButton;
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.btnAggregate);
			this.Controls.Add(this.chkStoredProcedures);
			this.Controls.Add(this.lblQuery);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.retrieveUsingXmlReaderButton);
			this.Controls.Add(this.useCaseLabel);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.transactionalUpdateButton);
			this.Controls.Add(this.singleItemButton);
			this.Controls.Add(this.btnLoadAll);
			this.Controls.Add(this.btnProductsAddDelete);
			this.Controls.Add(this.btnSimpleQuery);
			this.Controls.Add(this.resultsTextBox);
			this.Controls.Add(this.resultsDataGrid);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximizeBox = false;
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "QuickStartForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Load += new System.EventHandler(this.QuickStartForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.resultsDataGrid)).EndInit();
			this.ResumeLayout(false);

		}

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
			AppForm = new QuickStartForm();
            // Unhandled exceptions will be delivered to our ThreadException handler
            Application.ThreadException += new ThreadExceptionEventHandler(AppThreadException);
            Application.Run(AppForm);
        }

		private string _username = string.Empty;
		private string _password = string.Empty;
		private bool _useIntegratedSecurity = true;
		private string _server = string.Empty;

        private void QuickStartForm_Load(object sender, EventArgs e)
        {
            // Initialize image on the form to the embedded logo
            this.logoPictureBox.Image = this.GetEmbeddedImage("EasyObjectsQuickStart.logo.gif");
			this.Show();

			Login dlg = new Login();
			if (dlg.ShowDialog(this) == DialogResult.Cancel)
			{
				this.Close();
			}

			_username = dlg._username;
			_password = dlg._password;
			_useIntegratedSecurity = dlg._useIntegratedSecurity;
			_server = dlg._server;
        }

        /// <summary>
        /// Displays dialog with information about exceptions that occur in the application. 
        /// </summary>
        private static void AppThreadException(object source, ThreadExceptionEventArgs e)
        {
            string errorMsg = SR.GeneralExceptionMessage(e.Exception.Message);
            errorMsg += Environment.NewLine + SR.DbRequirementsMessage;

            DialogResult result = MessageBox.Show(errorMsg, SR.ApplicationErrorMessage, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);

            // Exits the program when the user clicks Abort.
            if (result == DialogResult.Abort)
            {
                Application.Exit();
            }
            QuickStartForm.AppForm.Cursor = System.Windows.Forms.Cursors.Default;
        }

        /// <summary>
        /// Retrieves the specified embedded image resource.
        /// </summary>
        private Image GetEmbeddedImage(string resourceName)
        {
            Stream resourceStream = Assembly.GetEntryAssembly().GetManifestResourceStream(resourceName);

            if (resourceStream == null)
            {
                return null;
            }

            Image img = Image.FromStream(resourceStream);

            return img;
        }

        /// <summary>
        /// Updates the results textbox on the form with the information for a use case.
        /// </summary>
        private void DisplayResults(string useCase, string query, string results)
        {
            this.useCaseLabel.Text = useCase;
			this.lblQuery.Text = query;
            this.resultsTextBox.Text = results;
            this.resultsDataGrid.Hide();
            this.resultsTextBox.Show();
        }

		/// <summary>
		/// Displays the grid showing the results of a use case.
		/// </summary>
//		private void DisplayResults(string useCase)
//		{
//			DisplayResults(useCase, string.Empty);
//		}

        /// <summary>
        /// Displays the grid showing the results of a use case.
        /// </summary>
        private void DisplayResults(string useCase, string query)
        {
            this.useCaseLabel.Text = useCase;
			this.lblQuery.Text = query;
			this.resultsDataGrid.Show();
            this.resultsTextBox.Hide();
        }

        /// <summary>
        /// Demonstrates how to retrieve multiple rows of data using
        /// a DataReader.
        /// </summary>
        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

			Employees emp = new Employees(this._server, this._useIntegratedSecurity, this._username, this._password);
			emp.DefaultCommandType = chkStoredProcedures.Checked ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text;

			if (!emp.LoadAll())
			{
				this.DisplayResults(this.btnLoadAll.Text, emp.ErrorMessage);
				return;
			}

			// Bind the EasyObject's DefaultView to the DataGrid for display
			this.resultsDataGrid.SetDataBinding(emp.DefaultView, null);

			this.DisplayResults(this.btnLoadAll.Text, chkStoredProcedures.Checked ? "Stored Procedure" : emp.Query.LastQuery);

            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Demonstrates how to retrieve multiple rows of data using
        /// a DataSet.
        /// </summary>
        private void btnSimpleQuery_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

			Employees emp = new Employees(this._server, this._useIntegratedSecurity, this._username, this._password);
			// Note: no need to set the DefaultCommmandType, custom queries are always run as inline SQL

			// Limit the columns returned by the SELECT query
			emp.Query.AddResultColumn(EmployeesSchema.LastName);
			emp.Query.AddResultColumn(EmployeesSchema.FirstName);
			emp.Query.AddResultColumn(EmployeesSchema.City);
			emp.Query.AddResultColumn(EmployeesSchema.Region);

			// Add an ORDER BY clause
			emp.Query.AddOrderBy(EmployeesSchema.LastName);

			// Add a WHERE clause
			emp.Where.Region.Value = "WA";

			if (!emp.Query.Load())
			{
				this.DisplayResults(this.btnSimpleQuery.Text, emp.ErrorMessage);
				return;
			}

			// Bind the EasyObject's DefaultView to the DataGrid for display
			this.resultsDataGrid.SetDataBinding(emp.DefaultView, null);

            this.DisplayResults(this.btnSimpleQuery.Text, emp.Query.LastQuery);

            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Demonstrates how to retrieve a single row of data.
        /// </summary>
        private void btnProductsAddDelete_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

			Products prod = new Products(this._server, this._useIntegratedSecurity, this._username, this._password);
			prod.DefaultCommandType = chkStoredProcedures.Checked ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text;

			// Call AddNew() to add a new row to the EasyObject. You must fill in all 
			// required fields or an error will result when you call Save().
			prod.AddNew();

			// Turn IDENTITY insert on, so we can specify a ProductID
			prod.IdentityInsert = true;
			prod.ProductID = 78;

			// Note the use of the 's_' fields, which take strings as arguments. If this object
			// were being loaded from TextBox objects on a WinForm, you don't have to worry about
			// the datatype because this is handled for you in EasyObjects
			prod.s_ProductName = "EasyObjects 1.1";
			prod.s_Discontinued = "True";
			prod.s_QuantityPerUnit = "10";
			prod.s_ReorderLevel = "100";
			prod.s_UnitPrice = "49.95";
			prod.s_UnitsInStock = "200";

			// Save the changes
			prod.Save();

			// Display the XML representation of the EasyObject
            string productDetails = prod.ToXml();

            this.DisplayResults(this.btnProductsAddDelete.Text, chkStoredProcedures.Checked ? "Stored Procedure" : prod.Query.LastQuery, productDetails);

			// Delete the new addition
			prod.MarkAsDeleted();
			prod.Save();

            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Demonstrates how to retrieve a single data item from the database.
        /// </summary>
        private void singleItemButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

			Products prod = new Products(this._server, this._useIntegratedSecurity, this._username, this._password);
			prod.DefaultCommandType = chkStoredProcedures.Checked ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text;

			// Load a single row via the primary key
			prod.LoadByPrimaryKey(4);

            string productName = prod.s_ProductName;

            this.DisplayResults(this.singleItemButton.Text, chkStoredProcedures.Checked ? "Stored Procedure" : prod.Query.LastQuery, productName);

            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Demonstrates how to update the database multiple times in the
        /// context of a transaction. All updates will succeed or all will be 
        /// rolled back.
        /// </summary>
        private void transactionalUpdateButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string results = "";
			Products prod = new Products(this._server, this._useIntegratedSecurity, this._username, this._password);
			prod.DefaultCommandType = chkStoredProcedures.Checked ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text;

			Employees emp = new Employees(this._server, this._useIntegratedSecurity, this._username, this._password);
			emp.DefaultCommandType = chkStoredProcedures.Checked ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text;

			// Update the requested product
			prod.LoadByPrimaryKey(4);
			prod.UnitsInStock += 1;

			// Update the requested employee
			emp.LoadByPrimaryKey(1);
			emp.s_Country = "USA";

			// Retrieve the current transaction manager
			TransactionManager tx = TransactionManager.ThreadTransactionMgr();

			try
			{
				tx.BeginTransaction();

				// Save both objects within the same transaction
				emp.Save();
				prod.Save();

				// Deliberately throw an error, to cause the transaction to rollback
				throw new Exception("Deliberate exception, transaction rolled back.");

				tx.CommitTransaction();

				this.DisplayResults(this.transactionalUpdateButton.Text, chkStoredProcedures.Checked ? "Stored Procedure" : emp.Query.LastQuery, results);
			}
			catch(Exception ex)
			{
				tx.RollbackTransaction();
				TransactionManager.ThreadTransactionMgrReset();
				this.DisplayResults(this.transactionalUpdateButton.Text, ex.Message);
			}

            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Demonstrates how to retrieve XML data from a SQL Server database.
        /// </summary>
        private void retrieveUsingXmlReaderButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

			Products prod = new Products(this._server, this._useIntegratedSecurity, this._username, this._password);
			prod.DefaultCommandType = chkStoredProcedures.Checked ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text;
			prod.LoadAll();

            DisplayResults(this.retrieveUsingXmlReaderButton.Text, chkStoredProcedures.Checked ? "Stored Procedure" : prod.Query.LastQuery, prod.ToXml());

            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Quits the application.
        /// </summary>
        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Displays Quick Start help topics using the Help 2 Viewer.
        /// </summary>
        private void viewWalkthroughButton_Click(object sender, EventArgs e)
        {
			Process process = new Process();

			process.StartInfo.UseShellExecute = true;
			process.StartInfo.FileName = @"..\..\help\index.htm";
			process.Start();
		}

		private void logoPictureBox_Click(object sender, System.EventArgs e)
		{
			Process process = new Process();

			process.StartInfo.UseShellExecute = true;
			process.StartInfo.FileName = "http://www.easyobjects.net";
			process.Start();
		}

		private void linkDownload_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			Process process = new Process();

			process.StartInfo.UseShellExecute = true;
			process.StartInfo.FileName = "http://www.easyobjects.net/Downloads/tabid/125/Default.aspx";
			process.Start();
		}

		private void btnAggregate_Click(object sender, System.EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			Employees emp = new Employees(this._server, this._useIntegratedSecurity, this._username, this._password);
			// Note: no need to set the DefaultCommmandType, custom queries are always run as inline SQL

			// Limit the columns returned by the SELECT query
			emp.Aggregate.EmployeeID.Function = AggregateParameter.Func.Count;
			emp.Aggregate.EmployeeID.Alias = "CustomerCount";

			if (!emp.Query.Load())
			{
				this.DisplayResults(this.btnSimpleQuery.Text, emp.ErrorMessage);
				return;
			}

			// Bind the EasyObject's DefaultView to the DataGrid for display
			this.resultsDataGrid.SetDataBinding(emp.DefaultView, null);

			this.DisplayResults(this.btnSimpleQuery.Text, emp.Query.LastQuery);

			Cursor = Cursors.Arrow;		
		}
    }
}