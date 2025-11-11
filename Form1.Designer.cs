namespace AlgoSync
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gbTally = new System.Windows.Forms.GroupBox();
            this.lblTally = new System.Windows.Forms.Label();
            this.btnRefreshTallyComp = new System.Windows.Forms.Button();
            this.lblTallyServer = new System.Windows.Forms.Label();
            this.lblTallyPort = new System.Windows.Forms.Label();
            this.txtTallyPort = new System.Windows.Forms.TextBox();
            this.txtTallyServer = new System.Windows.Forms.TextBox();
            this.gbCRM = new System.Windows.Forms.GroupBox();
            this.chkCRMPass = new System.Windows.Forms.CheckBox();
            this.lblCRM = new System.Windows.Forms.Label();
            this.btnCRMVerify = new System.Windows.Forms.Button();
            this.lblCRMUsername = new System.Windows.Forms.Label();
            this.txtCRMUsername = new System.Windows.Forms.TextBox();
            this.lblCRMCompCode = new System.Windows.Forms.Label();
            this.txtCRMCompCode = new System.Windows.Forms.TextBox();
            this.lblCRMPassword = new System.Windows.Forms.Label();
            this.txtCRMPassword = new System.Windows.Forms.TextBox();
            this.rbBusy = new System.Windows.Forms.RadioButton();
            this.rbTally = new System.Windows.Forms.RadioButton();
            this.gbProduct = new System.Windows.Forms.GroupBox();
            this.gbDatabase = new System.Windows.Forms.GroupBox();
            this.rbSQL = new System.Windows.Forms.RadioButton();
            this.rbAccess = new System.Windows.Forms.RadioButton();
            this.gbBusy = new System.Windows.Forms.GroupBox();
            this.lblFinYrNote = new System.Windows.Forms.Label();
            this.btnLoadCompanies = new System.Windows.Forms.Button();
            this.chkBusyPass = new System.Windows.Forms.CheckBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblServerName = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.cbFinYr = new System.Windows.Forms.ComboBox();
            this.lblFinYr = new System.Windows.Forms.Label();
            this.btnBrowseAppPath = new System.Windows.Forms.Button();
            this.lblAppPath = new System.Windows.Forms.Label();
            this.cbSelectCompany = new System.Windows.Forms.ComboBox();
            this.lblDataPath = new System.Windows.Forms.Label();
            this.lblSelectCompany = new System.Windows.Forms.Label();
            this.btnBrowseDataPath = new System.Windows.Forms.Button();
            this.txtDataPath = new System.Windows.Forms.TextBox();
            this.txtAppPath = new System.Windows.Forms.TextBox();
            this.gbBusyMasters = new System.Windows.Forms.GroupBox();
            this.chkContactDepartment = new System.Windows.Forms.CheckBox();
            this.chkState = new System.Windows.Forms.CheckBox();
            this.chkCountry = new System.Windows.Forms.CheckBox();
            this.chkEnqSource = new System.Windows.Forms.CheckBox();
            this.chkEnqCat = new System.Windows.Forms.CheckBox();
            this.chkSupCat = new System.Windows.Forms.CheckBox();
            this.chkArea = new System.Windows.Forms.CheckBox();
            this.chkUnit = new System.Windows.Forms.CheckBox();
            this.chkItemGroup = new System.Windows.Forms.CheckBox();
            this.chkItem = new System.Windows.Forms.CheckBox();
            this.chkExecutive = new System.Windows.Forms.CheckBox();
            this.chkContactGroup = new System.Windows.Forms.CheckBox();
            this.chkContact = new System.Windows.Forms.CheckBox();
            this.chkAccount = new System.Windows.Forms.CheckBox();
            this.gbDataTransferType = new System.Windows.Forms.GroupBox();
            this.rbIncremental = new System.Windows.Forms.RadioButton();
            this.rbBulk = new System.Windows.Forms.RadioButton();
            this.lblProgress = new System.Windows.Forms.Label();
            this.gbTallyMasters = new System.Windows.Forms.GroupBox();
            this.chkTallyGroup = new System.Windows.Forms.CheckBox();
            this.chkTallyUnit = new System.Windows.Forms.CheckBox();
            this.chkTallyStockGroup = new System.Windows.Forms.CheckBox();
            this.chkTallyStockItem = new System.Windows.Forms.CheckBox();
            this.chkTallyLedger = new System.Windows.Forms.CheckBox();
            this.lblProgress2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.gbTally.SuspendLayout();
            this.gbCRM.SuspendLayout();
            this.gbProduct.SuspendLayout();
            this.gbDatabase.SuspendLayout();
            this.gbBusy.SuspendLayout();
            this.gbBusyMasters.SuspendLayout();
            this.gbDataTransferType.SuspendLayout();
            this.gbTallyMasters.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTally
            // 
            this.gbTally.Controls.Add(this.lblTally);
            this.gbTally.Controls.Add(this.btnRefreshTallyComp);
            this.gbTally.Controls.Add(this.lblTallyServer);
            this.gbTally.Controls.Add(this.lblTallyPort);
            this.gbTally.Controls.Add(this.txtTallyPort);
            this.gbTally.Controls.Add(this.txtTallyServer);
            this.gbTally.Location = new System.Drawing.Point(1216, 146);
            this.gbTally.Name = "gbTally";
            this.gbTally.Size = new System.Drawing.Size(608, 406);
            this.gbTally.TabIndex = 63;
            this.gbTally.TabStop = false;
            this.gbTally.Text = "Specify Tally Details";
            // 
            // lblTally
            // 
            this.lblTally.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTally.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTally.Location = new System.Drawing.Point(16, 208);
            this.lblTally.Name = "lblTally";
            this.lblTally.Size = new System.Drawing.Size(572, 166);
            this.lblTally.TabIndex = 64;
            this.lblTally.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRefreshTallyComp
            // 
            this.btnRefreshTallyComp.Location = new System.Drawing.Point(226, 148);
            this.btnRefreshTallyComp.Name = "btnRefreshTallyComp";
            this.btnRefreshTallyComp.Size = new System.Drawing.Size(146, 42);
            this.btnRefreshTallyComp.TabIndex = 81;
            this.btnRefreshTallyComp.Text = "Refresh";
            this.btnRefreshTallyComp.UseVisualStyleBackColor = true;
            this.btnRefreshTallyComp.Click += new System.EventHandler(this.btnRefreshTallyComp_Click);
            // 
            // lblTallyServer
            // 
            this.lblTallyServer.Location = new System.Drawing.Point(16, 51);
            this.lblTallyServer.Name = "lblTallyServer";
            this.lblTallyServer.Size = new System.Drawing.Size(111, 20);
            this.lblTallyServer.TabIndex = 65;
            this.lblTallyServer.Text = "Tally Server";
            // 
            // lblTallyPort
            // 
            this.lblTallyPort.Location = new System.Drawing.Point(18, 95);
            this.lblTallyPort.Name = "lblTallyPort";
            this.lblTallyPort.Size = new System.Drawing.Size(111, 20);
            this.lblTallyPort.TabIndex = 66;
            this.lblTallyPort.Text = "Tally Port";
            // 
            // txtTallyPort
            // 
            this.txtTallyPort.Location = new System.Drawing.Point(134, 91);
            this.txtTallyPort.Name = "txtTallyPort";
            this.txtTallyPort.Size = new System.Drawing.Size(70, 26);
            this.txtTallyPort.TabIndex = 68;
            // 
            // txtTallyServer
            // 
            this.txtTallyServer.Location = new System.Drawing.Point(134, 46);
            this.txtTallyServer.Name = "txtTallyServer";
            this.txtTallyServer.Size = new System.Drawing.Size(344, 26);
            this.txtTallyServer.TabIndex = 67;
            // 
            // gbCRM
            // 
            this.gbCRM.Controls.Add(this.chkCRMPass);
            this.gbCRM.Controls.Add(this.lblCRM);
            this.gbCRM.Controls.Add(this.btnCRMVerify);
            this.gbCRM.Controls.Add(this.lblCRMUsername);
            this.gbCRM.Controls.Add(this.txtCRMUsername);
            this.gbCRM.Controls.Add(this.lblCRMCompCode);
            this.gbCRM.Controls.Add(this.txtCRMCompCode);
            this.gbCRM.Controls.Add(this.lblCRMPassword);
            this.gbCRM.Controls.Add(this.txtCRMPassword);
            this.gbCRM.Location = new System.Drawing.Point(18, 146);
            this.gbCRM.Name = "gbCRM";
            this.gbCRM.Size = new System.Drawing.Size(578, 406);
            this.gbCRM.TabIndex = 64;
            this.gbCRM.TabStop = false;
            this.gbCRM.Text = "Specify AlgoCRM Details";
            // 
            // chkCRMPass
            // 
            this.chkCRMPass.AutoSize = true;
            this.chkCRMPass.Location = new System.Drawing.Point(524, 92);
            this.chkCRMPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkCRMPass.Name = "chkCRMPass";
            this.chkCRMPass.Size = new System.Drawing.Size(22, 21);
            this.chkCRMPass.TabIndex = 72;
            this.chkCRMPass.UseVisualStyleBackColor = true;
            this.chkCRMPass.CheckedChanged += new System.EventHandler(this.chkCRMPass_CheckedChanged);
            // 
            // lblCRM
            // 
            this.lblCRM.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCRM.Location = new System.Drawing.Point(16, 246);
            this.lblCRM.Name = "lblCRM";
            this.lblCRM.Size = new System.Drawing.Size(538, 144);
            this.lblCRM.TabIndex = 67;
            this.lblCRM.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCRMVerify
            // 
            this.btnCRMVerify.Location = new System.Drawing.Point(195, 189);
            this.btnCRMVerify.Name = "btnCRMVerify";
            this.btnCRMVerify.Size = new System.Drawing.Size(171, 42);
            this.btnCRMVerify.TabIndex = 66;
            this.btnCRMVerify.Text = "Verify Credentials";
            this.btnCRMVerify.UseVisualStyleBackColor = true;
            this.btnCRMVerify.Click += new System.EventHandler(this.btnCRMVerify_Click);
            // 
            // lblCRMUsername
            // 
            this.lblCRMUsername.AutoSize = true;
            this.lblCRMUsername.Location = new System.Drawing.Point(16, 43);
            this.lblCRMUsername.Name = "lblCRMUsername";
            this.lblCRMUsername.Size = new System.Drawing.Size(83, 20);
            this.lblCRMUsername.TabIndex = 63;
            this.lblCRMUsername.Text = "Username";
            // 
            // txtCRMUsername
            // 
            this.txtCRMUsername.Location = new System.Drawing.Point(148, 40);
            this.txtCRMUsername.Name = "txtCRMUsername";
            this.txtCRMUsername.Size = new System.Drawing.Size(366, 26);
            this.txtCRMUsername.TabIndex = 64;
            this.txtCRMUsername.TextChanged += new System.EventHandler(this.txtCRMUsername_TextChanged);
            // 
            // lblCRMCompCode
            // 
            this.lblCRMCompCode.AutoSize = true;
            this.lblCRMCompCode.Location = new System.Drawing.Point(16, 138);
            this.lblCRMCompCode.Name = "lblCRMCompCode";
            this.lblCRMCompCode.Size = new System.Drawing.Size(122, 20);
            this.lblCRMCompCode.TabIndex = 61;
            this.lblCRMCompCode.Text = "Company Name";
            // 
            // txtCRMCompCode
            // 
            this.txtCRMCompCode.Location = new System.Drawing.Point(148, 135);
            this.txtCRMCompCode.Name = "txtCRMCompCode";
            this.txtCRMCompCode.Size = new System.Drawing.Size(366, 26);
            this.txtCRMCompCode.TabIndex = 62;
            this.txtCRMCompCode.TextChanged += new System.EventHandler(this.txtCRMCompCode_TextChanged);
            // 
            // lblCRMPassword
            // 
            this.lblCRMPassword.AutoSize = true;
            this.lblCRMPassword.Location = new System.Drawing.Point(16, 91);
            this.lblCRMPassword.Name = "lblCRMPassword";
            this.lblCRMPassword.Size = new System.Drawing.Size(78, 20);
            this.lblCRMPassword.TabIndex = 59;
            this.lblCRMPassword.Text = "Password";
            // 
            // txtCRMPassword
            // 
            this.txtCRMPassword.Location = new System.Drawing.Point(148, 88);
            this.txtCRMPassword.Name = "txtCRMPassword";
            this.txtCRMPassword.PasswordChar = '*';
            this.txtCRMPassword.Size = new System.Drawing.Size(366, 26);
            this.txtCRMPassword.TabIndex = 60;
            this.txtCRMPassword.TextChanged += new System.EventHandler(this.txtCRMPassword_TextChanged);
            // 
            // rbBusy
            // 
            this.rbBusy.AutoSize = true;
            this.rbBusy.Location = new System.Drawing.Point(20, 34);
            this.rbBusy.Name = "rbBusy";
            this.rbBusy.Size = new System.Drawing.Size(69, 24);
            this.rbBusy.TabIndex = 69;
            this.rbBusy.TabStop = true;
            this.rbBusy.Text = "Busy";
            this.rbBusy.UseVisualStyleBackColor = true;
            this.rbBusy.CheckedChanged += new System.EventHandler(this.rbBusy_CheckedChanged);
            // 
            // rbTally
            // 
            this.rbTally.AutoSize = true;
            this.rbTally.Location = new System.Drawing.Point(20, 64);
            this.rbTally.Name = "rbTally";
            this.rbTally.Size = new System.Drawing.Size(65, 24);
            this.rbTally.TabIndex = 70;
            this.rbTally.TabStop = true;
            this.rbTally.Text = "Tally";
            this.rbTally.UseVisualStyleBackColor = true;
            // 
            // gbProduct
            // 
            this.gbProduct.Controls.Add(this.rbTally);
            this.gbProduct.Controls.Add(this.rbBusy);
            this.gbProduct.Location = new System.Drawing.Point(18, 18);
            this.gbProduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbProduct.Name = "gbProduct";
            this.gbProduct.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbProduct.Size = new System.Drawing.Size(109, 103);
            this.gbProduct.TabIndex = 72;
            this.gbProduct.TabStop = false;
            this.gbProduct.Text = "Product";
            // 
            // gbDatabase
            // 
            this.gbDatabase.Controls.Add(this.rbSQL);
            this.gbDatabase.Controls.Add(this.rbAccess);
            this.gbDatabase.Location = new System.Drawing.Point(135, 17);
            this.gbDatabase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbDatabase.Name = "gbDatabase";
            this.gbDatabase.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbDatabase.Size = new System.Drawing.Size(111, 103);
            this.gbDatabase.TabIndex = 73;
            this.gbDatabase.TabStop = false;
            this.gbDatabase.Text = "Database";
            // 
            // rbSQL
            // 
            this.rbSQL.AutoSize = true;
            this.rbSQL.Location = new System.Drawing.Point(15, 64);
            this.rbSQL.Name = "rbSQL";
            this.rbSQL.Size = new System.Drawing.Size(66, 24);
            this.rbSQL.TabIndex = 70;
            this.rbSQL.TabStop = true;
            this.rbSQL.Text = "SQL";
            this.rbSQL.UseVisualStyleBackColor = true;
            // 
            // rbAccess
            // 
            this.rbAccess.AutoSize = true;
            this.rbAccess.Location = new System.Drawing.Point(15, 34);
            this.rbAccess.Name = "rbAccess";
            this.rbAccess.Size = new System.Drawing.Size(86, 24);
            this.rbAccess.TabIndex = 69;
            this.rbAccess.TabStop = true;
            this.rbAccess.Text = "Access";
            this.rbAccess.UseVisualStyleBackColor = true;
            this.rbAccess.CheckedChanged += new System.EventHandler(this.rbAccess_CheckedChanged);
            // 
            // gbBusy
            // 
            this.gbBusy.Controls.Add(this.lblFinYrNote);
            this.gbBusy.Controls.Add(this.btnLoadCompanies);
            this.gbBusy.Controls.Add(this.chkBusyPass);
            this.gbBusy.Controls.Add(this.lblPassword);
            this.gbBusy.Controls.Add(this.txtPassword);
            this.gbBusy.Controls.Add(this.lblUsername);
            this.gbBusy.Controls.Add(this.txtUsername);
            this.gbBusy.Controls.Add(this.lblServerName);
            this.gbBusy.Controls.Add(this.txtServerName);
            this.gbBusy.Controls.Add(this.cbFinYr);
            this.gbBusy.Controls.Add(this.lblFinYr);
            this.gbBusy.Controls.Add(this.btnBrowseAppPath);
            this.gbBusy.Controls.Add(this.lblAppPath);
            this.gbBusy.Controls.Add(this.cbSelectCompany);
            this.gbBusy.Controls.Add(this.lblDataPath);
            this.gbBusy.Controls.Add(this.lblSelectCompany);
            this.gbBusy.Controls.Add(this.btnBrowseDataPath);
            this.gbBusy.Controls.Add(this.txtDataPath);
            this.gbBusy.Controls.Add(this.txtAppPath);
            this.gbBusy.Location = new System.Drawing.Point(602, 146);
            this.gbBusy.Name = "gbBusy";
            this.gbBusy.Size = new System.Drawing.Size(608, 406);
            this.gbBusy.TabIndex = 62;
            this.gbBusy.TabStop = false;
            this.gbBusy.Text = "Specify Busy Details";
            // 
            // lblFinYrNote
            // 
            this.lblFinYrNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblFinYrNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinYrNote.Location = new System.Drawing.Point(202, 361);
            this.lblFinYrNote.Name = "lblFinYrNote";
            this.lblFinYrNote.Size = new System.Drawing.Size(340, 26);
            this.lblFinYrNote.TabIndex = 88;
            this.lblFinYrNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLoadCompanies
            // 
            this.btnLoadCompanies.Location = new System.Drawing.Point(202, 258);
            this.btnLoadCompanies.Name = "btnLoadCompanies";
            this.btnLoadCompanies.Size = new System.Drawing.Size(186, 40);
            this.btnLoadCompanies.TabIndex = 81;
            this.btnLoadCompanies.Text = "Refresh Companies";
            this.btnLoadCompanies.UseVisualStyleBackColor = true;
            this.btnLoadCompanies.Click += new System.EventHandler(this.btnLoadCompanies_Click);
            // 
            // chkBusyPass
            // 
            this.chkBusyPass.AutoSize = true;
            this.chkBusyPass.Location = new System.Drawing.Point(558, 220);
            this.chkBusyPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkBusyPass.Name = "chkBusyPass";
            this.chkBusyPass.Size = new System.Drawing.Size(22, 21);
            this.chkBusyPass.TabIndex = 71;
            this.chkBusyPass.UseVisualStyleBackColor = true;
            this.chkBusyPass.CheckedChanged += new System.EventHandler(this.chkBusyPass_CheckedChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(21, 225);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(114, 20);
            this.lblPassword.TabIndex = 69;
            this.lblPassword.Text = "SQL Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(202, 215);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(344, 26);
            this.txtPassword.TabIndex = 70;
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(21, 180);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(119, 20);
            this.lblUsername.TabIndex = 67;
            this.lblUsername.Text = "SQL Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(202, 172);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(344, 26);
            this.txtUsername.TabIndex = 68;
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(21, 135);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(137, 20);
            this.lblServerName.TabIndex = 65;
            this.lblServerName.Text = "SQL Server Name";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(202, 129);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(344, 26);
            this.txtServerName.TabIndex = 66;
            this.txtServerName.Leave += new System.EventHandler(this.txtServerName_Leave);
            // 
            // cbFinYr
            // 
            this.cbFinYr.FormattingEnabled = true;
            this.cbFinYr.Location = new System.Drawing.Point(202, 362);
            this.cbFinYr.Name = "cbFinYr";
            this.cbFinYr.Size = new System.Drawing.Size(121, 28);
            this.cbFinYr.TabIndex = 64;
            // 
            // lblFinYr
            // 
            this.lblFinYr.AutoSize = true;
            this.lblFinYr.Location = new System.Drawing.Point(21, 372);
            this.lblFinYr.Name = "lblFinYr";
            this.lblFinYr.Size = new System.Drawing.Size(159, 20);
            this.lblFinYr.TabIndex = 63;
            this.lblFinYr.Text = "Select Financial Year";
            // 
            // btnBrowseAppPath
            // 
            this.btnBrowseAppPath.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowseAppPath.BackgroundImage")));
            this.btnBrowseAppPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrowseAppPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseAppPath.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseAppPath.Location = new System.Drawing.Point(552, 38);
            this.btnBrowseAppPath.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowseAppPath.Name = "btnBrowseAppPath";
            this.btnBrowseAppPath.Size = new System.Drawing.Size(39, 34);
            this.btnBrowseAppPath.TabIndex = 62;
            this.btnBrowseAppPath.Text = "...";
            this.btnBrowseAppPath.UseVisualStyleBackColor = true;
            this.btnBrowseAppPath.Click += new System.EventHandler(this.btnBrowseAppPath_Click);
            // 
            // lblAppPath
            // 
            this.lblAppPath.AutoSize = true;
            this.lblAppPath.Location = new System.Drawing.Point(20, 46);
            this.lblAppPath.Name = "lblAppPath";
            this.lblAppPath.Size = new System.Drawing.Size(124, 20);
            this.lblAppPath.TabIndex = 1;
            this.lblAppPath.Text = "Application Path";
            // 
            // cbSelectCompany
            // 
            this.cbSelectCompany.FormattingEnabled = true;
            this.cbSelectCompany.Location = new System.Drawing.Point(202, 317);
            this.cbSelectCompany.Name = "cbSelectCompany";
            this.cbSelectCompany.Size = new System.Drawing.Size(340, 28);
            this.cbSelectCompany.TabIndex = 61;
            this.cbSelectCompany.SelectedIndexChanged += new System.EventHandler(this.cbSelectCompany_SelectedIndexChanged);
            // 
            // lblDataPath
            // 
            this.lblDataPath.AutoSize = true;
            this.lblDataPath.Location = new System.Drawing.Point(21, 91);
            this.lblDataPath.Name = "lblDataPath";
            this.lblDataPath.Size = new System.Drawing.Size(81, 20);
            this.lblDataPath.TabIndex = 2;
            this.lblDataPath.Text = "Data Path";
            // 
            // lblSelectCompany
            // 
            this.lblSelectCompany.AutoSize = true;
            this.lblSelectCompany.Location = new System.Drawing.Point(21, 328);
            this.lblSelectCompany.Name = "lblSelectCompany";
            this.lblSelectCompany.Size = new System.Drawing.Size(125, 20);
            this.lblSelectCompany.TabIndex = 60;
            this.lblSelectCompany.Text = "Select Company";
            // 
            // btnBrowseDataPath
            // 
            this.btnBrowseDataPath.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowseDataPath.BackgroundImage")));
            this.btnBrowseDataPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrowseDataPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseDataPath.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseDataPath.Location = new System.Drawing.Point(552, 83);
            this.btnBrowseDataPath.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowseDataPath.Name = "btnBrowseDataPath";
            this.btnBrowseDataPath.Size = new System.Drawing.Size(39, 34);
            this.btnBrowseDataPath.TabIndex = 57;
            this.btnBrowseDataPath.Text = "...";
            this.btnBrowseDataPath.UseVisualStyleBackColor = true;
            this.btnBrowseDataPath.Click += new System.EventHandler(this.btnBrowseDataPath_Click);
            // 
            // txtDataPath
            // 
            this.txtDataPath.Location = new System.Drawing.Point(202, 86);
            this.txtDataPath.Name = "txtDataPath";
            this.txtDataPath.Size = new System.Drawing.Size(344, 26);
            this.txtDataPath.TabIndex = 59;
            // 
            // txtAppPath
            // 
            this.txtAppPath.Location = new System.Drawing.Point(202, 43);
            this.txtAppPath.Name = "txtAppPath";
            this.txtAppPath.Size = new System.Drawing.Size(344, 26);
            this.txtAppPath.TabIndex = 58;
            // 
            // gbBusyMasters
            // 
            this.gbBusyMasters.Controls.Add(this.chkContactDepartment);
            this.gbBusyMasters.Controls.Add(this.chkState);
            this.gbBusyMasters.Controls.Add(this.chkCountry);
            this.gbBusyMasters.Controls.Add(this.chkEnqSource);
            this.gbBusyMasters.Controls.Add(this.chkEnqCat);
            this.gbBusyMasters.Controls.Add(this.chkSupCat);
            this.gbBusyMasters.Controls.Add(this.chkArea);
            this.gbBusyMasters.Controls.Add(this.chkUnit);
            this.gbBusyMasters.Controls.Add(this.chkItemGroup);
            this.gbBusyMasters.Controls.Add(this.chkItem);
            this.gbBusyMasters.Controls.Add(this.chkExecutive);
            this.gbBusyMasters.Controls.Add(this.chkContactGroup);
            this.gbBusyMasters.Controls.Add(this.chkContact);
            this.gbBusyMasters.Controls.Add(this.chkAccount);
            this.gbBusyMasters.Location = new System.Drawing.Point(254, 18);
            this.gbBusyMasters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbBusyMasters.Name = "gbBusyMasters";
            this.gbBusyMasters.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbBusyMasters.Size = new System.Drawing.Size(952, 102);
            this.gbBusyMasters.TabIndex = 85;
            this.gbBusyMasters.TabStop = false;
            this.gbBusyMasters.Text = "Select Masters To Export";
            // 
            // chkContactDepartment
            // 
            this.chkContactDepartment.AutoSize = true;
            this.chkContactDepartment.Location = new System.Drawing.Point(137, 29);
            this.chkContactDepartment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkContactDepartment.Name = "chkContactDepartment";
            this.chkContactDepartment.Size = new System.Drawing.Size(180, 24);
            this.chkContactDepartment.TabIndex = 13;
            this.chkContactDepartment.Text = "Contact Department";
            this.chkContactDepartment.UseVisualStyleBackColor = true;
            // 
            // chkState
            // 
            this.chkState.AutoSize = true;
            this.chkState.Location = new System.Drawing.Point(284, 65);
            this.chkState.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkState.Name = "chkState";
            this.chkState.Size = new System.Drawing.Size(74, 24);
            this.chkState.TabIndex = 12;
            this.chkState.Text = "State";
            this.chkState.UseVisualStyleBackColor = true;
            // 
            // chkCountry
            // 
            this.chkCountry.AutoSize = true;
            this.chkCountry.Location = new System.Drawing.Point(568, 65);
            this.chkCountry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkCountry.Name = "chkCountry";
            this.chkCountry.Size = new System.Drawing.Size(90, 24);
            this.chkCountry.TabIndex = 11;
            this.chkCountry.Text = "Country";
            this.chkCountry.UseVisualStyleBackColor = true;
            // 
            // chkEnqSource
            // 
            this.chkEnqSource.AutoSize = true;
            this.chkEnqSource.Location = new System.Drawing.Point(114, 65);
            this.chkEnqSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkEnqSource.Name = "chkEnqSource";
            this.chkEnqSource.Size = new System.Drawing.Size(143, 24);
            this.chkEnqSource.TabIndex = 10;
            this.chkEnqSource.Text = "Enquiry Source";
            this.chkEnqSource.UseVisualStyleBackColor = true;
            // 
            // chkEnqCat
            // 
            this.chkEnqCat.AutoSize = true;
            this.chkEnqCat.Location = new System.Drawing.Point(385, 65);
            this.chkEnqCat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkEnqCat.Name = "chkEnqCat";
            this.chkEnqCat.Size = new System.Drawing.Size(156, 24);
            this.chkEnqCat.TabIndex = 9;
            this.chkEnqCat.Text = "Enquiry Category";
            this.chkEnqCat.UseVisualStyleBackColor = true;
            // 
            // chkSupCat
            // 
            this.chkSupCat.AutoSize = true;
            this.chkSupCat.Location = new System.Drawing.Point(685, 65);
            this.chkSupCat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkSupCat.Name = "chkSupCat";
            this.chkSupCat.Size = new System.Drawing.Size(160, 24);
            this.chkSupCat.TabIndex = 8;
            this.chkSupCat.Text = "Support Category";
            this.chkSupCat.UseVisualStyleBackColor = true;
            // 
            // chkArea
            // 
            this.chkArea.AutoSize = true;
            this.chkArea.Location = new System.Drawing.Point(872, 64);
            this.chkArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkArea.Name = "chkArea";
            this.chkArea.Size = new System.Drawing.Size(69, 24);
            this.chkArea.TabIndex = 7;
            this.chkArea.Text = "Area";
            this.chkArea.UseVisualStyleBackColor = true;
            // 
            // chkUnit
            // 
            this.chkUnit.AutoSize = true;
            this.chkUnit.Location = new System.Drawing.Point(756, 29);
            this.chkUnit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkUnit.Name = "chkUnit";
            this.chkUnit.Size = new System.Drawing.Size(64, 24);
            this.chkUnit.TabIndex = 6;
            this.chkUnit.Text = "Unit";
            this.chkUnit.UseVisualStyleBackColor = true;
            // 
            // chkItemGroup
            // 
            this.chkItemGroup.AutoSize = true;
            this.chkItemGroup.Location = new System.Drawing.Point(454, 29);
            this.chkItemGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkItemGroup.Name = "chkItemGroup";
            this.chkItemGroup.Size = new System.Drawing.Size(116, 24);
            this.chkItemGroup.TabIndex = 5;
            this.chkItemGroup.Text = "Item Group";
            this.chkItemGroup.UseVisualStyleBackColor = true;
            // 
            // chkItem
            // 
            this.chkItem.AutoSize = true;
            this.chkItem.Location = new System.Drawing.Point(20, 65);
            this.chkItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkItem.Name = "chkItem";
            this.chkItem.Size = new System.Drawing.Size(67, 24);
            this.chkItem.TabIndex = 4;
            this.chkItem.Text = "Item";
            this.chkItem.UseVisualStyleBackColor = true;
            // 
            // chkExecutive
            // 
            this.chkExecutive.AutoSize = true;
            this.chkExecutive.Location = new System.Drawing.Point(843, 29);
            this.chkExecutive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkExecutive.Name = "chkExecutive";
            this.chkExecutive.Size = new System.Drawing.Size(103, 24);
            this.chkExecutive.TabIndex = 3;
            this.chkExecutive.Text = "Executive";
            this.chkExecutive.UseVisualStyleBackColor = true;
            // 
            // chkContactGroup
            // 
            this.chkContactGroup.AutoSize = true;
            this.chkContactGroup.Location = new System.Drawing.Point(593, 29);
            this.chkContactGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkContactGroup.Name = "chkContactGroup";
            this.chkContactGroup.Size = new System.Drawing.Size(140, 24);
            this.chkContactGroup.TabIndex = 2;
            this.chkContactGroup.Text = "Contact Group";
            this.chkContactGroup.UseVisualStyleBackColor = true;
            // 
            // chkContact
            // 
            this.chkContact.AutoSize = true;
            this.chkContact.Location = new System.Drawing.Point(340, 29);
            this.chkContact.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkContact.Name = "chkContact";
            this.chkContact.Size = new System.Drawing.Size(91, 24);
            this.chkContact.TabIndex = 1;
            this.chkContact.Text = "Contact";
            this.chkContact.UseVisualStyleBackColor = true;
            // 
            // chkAccount
            // 
            this.chkAccount.AutoSize = true;
            this.chkAccount.Location = new System.Drawing.Point(20, 29);
            this.chkAccount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkAccount.Name = "chkAccount";
            this.chkAccount.Size = new System.Drawing.Size(94, 24);
            this.chkAccount.TabIndex = 0;
            this.chkAccount.Text = "Account";
            this.chkAccount.UseVisualStyleBackColor = true;
            // 
            // gbDataTransferType
            // 
            this.gbDataTransferType.Controls.Add(this.rbIncremental);
            this.gbDataTransferType.Controls.Add(this.rbBulk);
            this.gbDataTransferType.Location = new System.Drawing.Point(18, 568);
            this.gbDataTransferType.Name = "gbDataTransferType";
            this.gbDataTransferType.Size = new System.Drawing.Size(264, 70);
            this.gbDataTransferType.TabIndex = 86;
            this.gbDataTransferType.TabStop = false;
            this.gbDataTransferType.Text = "Data Transfer Type";
            // 
            // rbIncremental
            // 
            this.rbIncremental.AutoSize = true;
            this.rbIncremental.Location = new System.Drawing.Point(130, 30);
            this.rbIncremental.Name = "rbIncremental";
            this.rbIncremental.Size = new System.Drawing.Size(118, 24);
            this.rbIncremental.TabIndex = 72;
            this.rbIncremental.TabStop = true;
            this.rbIncremental.Text = "Incremental";
            this.rbIncremental.UseVisualStyleBackColor = true;
            // 
            // rbBulk
            // 
            this.rbBulk.AutoSize = true;
            this.rbBulk.Location = new System.Drawing.Point(30, 30);
            this.rbBulk.Name = "rbBulk";
            this.rbBulk.Size = new System.Drawing.Size(65, 24);
            this.rbBulk.TabIndex = 71;
            this.rbBulk.TabStop = true;
            this.rbBulk.Text = "Bulk";
            this.rbBulk.UseVisualStyleBackColor = true;
            // 
            // lblProgress
            // 
            this.lblProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(298, 568);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(574, 25);
            this.lblProgress.TabIndex = 87;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbTallyMasters
            // 
            this.gbTallyMasters.Controls.Add(this.chkTallyGroup);
            this.gbTallyMasters.Controls.Add(this.chkTallyUnit);
            this.gbTallyMasters.Controls.Add(this.chkTallyStockGroup);
            this.gbTallyMasters.Controls.Add(this.chkTallyStockItem);
            this.gbTallyMasters.Controls.Add(this.chkTallyLedger);
            this.gbTallyMasters.Location = new System.Drawing.Point(1216, 560);
            this.gbTallyMasters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbTallyMasters.Name = "gbTallyMasters";
            this.gbTallyMasters.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbTallyMasters.Size = new System.Drawing.Size(952, 102);
            this.gbTallyMasters.TabIndex = 88;
            this.gbTallyMasters.TabStop = false;
            this.gbTallyMasters.Text = "Select Masters To Export";
            this.gbTallyMasters.Visible = false;
            // 
            // chkTallyGroup
            // 
            this.chkTallyGroup.AutoSize = true;
            this.chkTallyGroup.Location = new System.Drawing.Point(418, 46);
            this.chkTallyGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTallyGroup.Name = "chkTallyGroup";
            this.chkTallyGroup.Size = new System.Drawing.Size(80, 24);
            this.chkTallyGroup.TabIndex = 14;
            this.chkTallyGroup.Text = "Group";
            this.chkTallyGroup.UseVisualStyleBackColor = true;
            // 
            // chkTallyUnit
            // 
            this.chkTallyUnit.AutoSize = true;
            this.chkTallyUnit.Location = new System.Drawing.Point(803, 46);
            this.chkTallyUnit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTallyUnit.Name = "chkTallyUnit";
            this.chkTallyUnit.Size = new System.Drawing.Size(64, 24);
            this.chkTallyUnit.TabIndex = 6;
            this.chkTallyUnit.Text = "Unit";
            this.chkTallyUnit.UseVisualStyleBackColor = true;
            // 
            // chkTallyStockGroup
            // 
            this.chkTallyStockGroup.AutoSize = true;
            this.chkTallyStockGroup.Location = new System.Drawing.Point(588, 46);
            this.chkTallyStockGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTallyStockGroup.Name = "chkTallyStockGroup";
            this.chkTallyStockGroup.Size = new System.Drawing.Size(125, 24);
            this.chkTallyStockGroup.TabIndex = 5;
            this.chkTallyStockGroup.Text = "Stock Group";
            this.chkTallyStockGroup.UseVisualStyleBackColor = true;
            // 
            // chkTallyStockItem
            // 
            this.chkTallyStockItem.AutoSize = true;
            this.chkTallyStockItem.Location = new System.Drawing.Point(216, 46);
            this.chkTallyStockItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTallyStockItem.Name = "chkTallyStockItem";
            this.chkTallyStockItem.Size = new System.Drawing.Size(112, 24);
            this.chkTallyStockItem.TabIndex = 4;
            this.chkTallyStockItem.Text = "Stock Item";
            this.chkTallyStockItem.UseVisualStyleBackColor = true;
            // 
            // chkTallyLedger
            // 
            this.chkTallyLedger.AutoSize = true;
            this.chkTallyLedger.Location = new System.Drawing.Point(41, 46);
            this.chkTallyLedger.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTallyLedger.Name = "chkTallyLedger";
            this.chkTallyLedger.Size = new System.Drawing.Size(85, 24);
            this.chkTallyLedger.TabIndex = 0;
            this.chkTallyLedger.Text = "Ledger";
            this.chkTallyLedger.UseVisualStyleBackColor = true;
            // 
            // lblProgress2
            // 
            this.lblProgress2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblProgress2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress2.Location = new System.Drawing.Point(298, 606);
            this.lblProgress2.Name = "lblProgress2";
            this.lblProgress2.Size = new System.Drawing.Size(574, 25);
            this.lblProgress2.TabIndex = 89;
            this.lblProgress2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(884, 568);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(160, 54);
            this.btnStart.TabIndex = 92;
            this.btnStart.Text = "Start Data Transfer";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(1050, 568);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(159, 54);
            this.btnStop.TabIndex = 93;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 650);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblProgress2);
            this.Controls.Add(this.gbTallyMasters);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.gbDataTransferType);
            this.Controls.Add(this.gbBusy);
            this.Controls.Add(this.gbTally);
            this.Controls.Add(this.gbBusyMasters);
            this.Controls.Add(this.gbDatabase);
            this.Controls.Add(this.gbProduct);
            this.Controls.Add(this.gbCRM);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AlgoSync";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbTally.ResumeLayout(false);
            this.gbTally.PerformLayout();
            this.gbCRM.ResumeLayout(false);
            this.gbCRM.PerformLayout();
            this.gbProduct.ResumeLayout(false);
            this.gbProduct.PerformLayout();
            this.gbDatabase.ResumeLayout(false);
            this.gbDatabase.PerformLayout();
            this.gbBusy.ResumeLayout(false);
            this.gbBusy.PerformLayout();
            this.gbBusyMasters.ResumeLayout(false);
            this.gbBusyMasters.PerformLayout();
            this.gbDataTransferType.ResumeLayout(false);
            this.gbDataTransferType.PerformLayout();
            this.gbTallyMasters.ResumeLayout(false);
            this.gbTallyMasters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbTally;
        private System.Windows.Forms.GroupBox gbCRM;
        private System.Windows.Forms.RadioButton rbBusy;
        private System.Windows.Forms.RadioButton rbTally;
        private System.Windows.Forms.Label lblCRMUsername;
        private System.Windows.Forms.TextBox txtCRMUsername;
        private System.Windows.Forms.Label lblCRMCompCode;
        private System.Windows.Forms.TextBox txtCRMCompCode;
        private System.Windows.Forms.Label lblCRMPassword;
        private System.Windows.Forms.TextBox txtCRMPassword;
        private System.Windows.Forms.Button btnCRMVerify;
        private System.Windows.Forms.GroupBox gbProduct;
        private System.Windows.Forms.GroupBox gbDatabase;
        private System.Windows.Forms.RadioButton rbSQL;
        private System.Windows.Forms.RadioButton rbAccess;
        private System.Windows.Forms.GroupBox gbBusy;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.ComboBox cbFinYr;
        private System.Windows.Forms.Label lblFinYr;
        private System.Windows.Forms.Button btnBrowseAppPath;
        private System.Windows.Forms.Label lblAppPath;
        private System.Windows.Forms.ComboBox cbSelectCompany;
        private System.Windows.Forms.Label lblDataPath;
        private System.Windows.Forms.Label lblSelectCompany;
        private System.Windows.Forms.Button btnBrowseDataPath;
        private System.Windows.Forms.TextBox txtDataPath;
        private System.Windows.Forms.TextBox txtAppPath;
        private System.Windows.Forms.Label lblTally;
        private System.Windows.Forms.Label lblCRM;
        private System.Windows.Forms.CheckBox chkCRMPass;
        private System.Windows.Forms.CheckBox chkBusyPass;
        private System.Windows.Forms.Button btnLoadCompanies;
        private System.Windows.Forms.Label lblTallyServer;
        private System.Windows.Forms.Label lblTallyPort;
        private System.Windows.Forms.TextBox txtTallyPort;
        private System.Windows.Forms.TextBox txtTallyServer;
        private System.Windows.Forms.Button btnRefreshTallyComp;
        private System.Windows.Forms.GroupBox gbBusyMasters;
        private System.Windows.Forms.CheckBox chkArea;
        private System.Windows.Forms.CheckBox chkUnit;
        private System.Windows.Forms.CheckBox chkItemGroup;
        private System.Windows.Forms.CheckBox chkItem;
        private System.Windows.Forms.CheckBox chkExecutive;
        private System.Windows.Forms.CheckBox chkContactGroup;
        private System.Windows.Forms.CheckBox chkContact;
        private System.Windows.Forms.CheckBox chkAccount;
        private System.Windows.Forms.CheckBox chkEnqSource;
        private System.Windows.Forms.CheckBox chkEnqCat;
        private System.Windows.Forms.CheckBox chkSupCat;
        private System.Windows.Forms.GroupBox gbDataTransferType;
        private System.Windows.Forms.RadioButton rbIncremental;
        private System.Windows.Forms.RadioButton rbBulk;
        private System.Windows.Forms.CheckBox chkState;
        private System.Windows.Forms.CheckBox chkCountry;
        private System.Windows.Forms.CheckBox chkContactDepartment;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.GroupBox gbTallyMasters;
        private System.Windows.Forms.CheckBox chkTallyGroup;
        private System.Windows.Forms.CheckBox chkTallyUnit;
        private System.Windows.Forms.CheckBox chkTallyStockGroup;
        private System.Windows.Forms.CheckBox chkTallyStockItem;
        private System.Windows.Forms.CheckBox chkTallyLedger;
        private System.Windows.Forms.Label lblProgress2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblFinYrNote;
    }
}

