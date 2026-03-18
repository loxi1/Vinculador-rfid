namespace Scanner_SDK_Sample_Application
{
    partial class frmScannerApp
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScannerApp));
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabConectar = new System.Windows.Forms.TabPage();
            this.btnGetScanners = new System.Windows.Forms.Button();
            this.grpScanners = new System.Windows.Forms.GroupBox();
            this.lstvScanners = new System.Windows.Forms.ListView();
            this.clmId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFrmwr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCnfig = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmMnftrd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSerial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmGuid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSlctScnnr = new System.Windows.Forms.Label();
            this.cmbSlcrScnr = new System.Windows.Forms.ComboBox();
            this.tabVinculador = new System.Windows.Forms.TabPage();
            this.gbxInventoryEx = new System.Windows.Forms.GroupBox();
            this.tablaContenedorTimbrado = new System.Windows.Forms.TableLayoutPanel();
            this.tabaLadoTimbrado = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLimpiarRFID = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cantidadRFID = new System.Windows.Forms.Label();
            this.MsnVincular = new System.Windows.Forms.Label();
            this.CodBarras = new System.Windows.Forms.TextBox();
            this.TableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvTagList = new System.Windows.Forms.DataGridView();
            this.clnEPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroOP = new System.Windows.Forms.TextBox();
            this.nroHM = new System.Windows.Forms.TextBox();
            this.btnLimpiarOPHM = new System.Windows.Forms.Button();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnVerConsolidado = new System.Windows.Forms.Button();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbContEspacioVertical = new System.Windows.Forms.TableLayoutPanel();
            this.btnStopInventoryEx = new System.Windows.Forms.Button();
            this.cbxInventory = new System.Windows.Forms.ComboBox();
            this.btnStartInventoryEx = new System.Windows.Forms.Button();
            this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.op = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoja_marcacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.corte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subcorte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.talla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_talla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_talla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_rfid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tbConsolidado = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotalDetalle = new System.Windows.Forms.Label();
            this.panelScroll = new System.Windows.Forms.Panel();
            this.tbDetalleTimbrado = new System.Windows.Forms.TableLayoutPanel();
            this.tabBarcode = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnScriptEditor = new System.Windows.Forms.Button();
            this.btnBrowseScript = new System.Windows.Forms.Button();
            this.chkBoxAppADF = new System.Windows.Forms.CheckBox();
            this.grpBoxLanguage = new System.Windows.Forms.GroupBox();
            this.chkBoxEmulation = new System.Windows.Forms.CheckBox();
            this.cmbEmulation = new System.Windows.Forms.ComboBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.grpboxBarcodeLbl = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbEncoding = new System.Windows.Forms.ComboBox();
            this.lblSyblogy = new System.Windows.Forms.Label();
            this.txtSyblogy = new System.Windows.Forms.TextBox();
            this.lblDecdBarCde = new System.Windows.Forms.Label();
            this.txtBarcodeLbl = new System.Windows.Forms.TextBox();
            this.btnAbortMacroPdf = new System.Windows.Forms.Button();
            this.btnBarcodeClear = new System.Windows.Forms.Button();
            this.btnFlushMacroPdf = new System.Windows.Forms.Button();
            this.tabImgVdo = new System.Windows.Forms.TabPage();
            this.grpImageVideo = new System.Windows.Forms.GroupBox();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.chkVideoViewFinderEnable = new System.Windows.Forms.CheckBox();
            this.btnSveImge = new System.Windows.Forms.Button();
            this.btnVideo = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.btnAbortImageXfer = new System.Windows.Forms.Button();
            this.grpBoxImgType = new System.Windows.Forms.GroupBox();
            this.rdoJPG = new System.Windows.Forms.RadioButton();
            this.rdoTIFF = new System.Windows.Forms.RadioButton();
            this.rdoBMP = new System.Windows.Forms.RadioButton();
            this.pbxImageVideo = new System.Windows.Forms.PictureBox();
            this.tabISO15434 = new System.Windows.Forms.TabPage();
            this.grpIDC = new System.Windows.Forms.GroupBox();
            this.btnSaveIdc = new System.Windows.Forms.Button();
            this.pbxISO15434Image = new System.Windows.Forms.PictureBox();
            this.btnClearpbx = new System.Windows.Forms.Button();
            this.checkUseHID = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSnapiStore = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSnapiParamValue = new System.Windows.Forms.ComboBox();
            this.btnSnapiSet = new System.Windows.Forms.Button();
            this.btnSnapiGet = new System.Windows.Forms.Button();
            this.cmbSnapiParams = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDocCapDecodeDataSymbol = new System.Windows.Forms.TextBox();
            this.txtDocCapDecodeData = new System.Windows.Forms.TextBox();
            this.tabScnAction = new System.Windows.Forms.TabPage();
            this.grpScnActions = new System.Windows.Forms.GroupBox();
            this.grpPagerMotor = new System.Windows.Forms.GroupBox();
            this.lblPagerMotorTimeout = new System.Windows.Forms.Label();
            this.txtPagerMotorDuration = new System.Windows.Forms.TextBox();
            this.btnEnablePagerMotor = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.grpHVS = new System.Windows.Forms.GroupBox();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.chkShmPermChange = new System.Windows.Forms.CheckBox();
            this.chkShmSilentSwitch = new System.Windows.Forms.CheckBox();
            this.btnSwitchHostMode = new System.Windows.Forms.Button();
            this.grpReboot = new System.Windows.Forms.GroupBox();
            this.btnRebootScanner = new System.Windows.Forms.Button();
            this.grpEnbDisScanner = new System.Windows.Forms.GroupBox();
            this.btnScannerDisable = new System.Windows.Forms.Button();
            this.btnScannerEnable = new System.Windows.Forms.Button();
            this.grpBeeper = new System.Windows.Forms.GroupBox();
            this.cmbBeep = new System.Windows.Forms.ComboBox();
            this.btnSoundBeeper = new System.Windows.Forms.Button();
            this.grpLed = new System.Windows.Forms.GroupBox();
            this.cmbLed = new System.Windows.Forms.ComboBox();
            this.btnLedOff = new System.Windows.Forms.Button();
            this.btnLedOn = new System.Windows.Forms.Button();
            this.grpAim = new System.Windows.Forms.GroupBox();
            this.btnAimOn = new System.Windows.Forms.Button();
            this.btnAimOff = new System.Windows.Forms.Button();
            this.tabRsm = new System.Windows.Forms.TabPage();
            this.grpRSM = new System.Windows.Forms.GroupBox();
            this.grpBoxClrSlect = new System.Windows.Forms.GroupBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.grpBoxSetRset = new System.Windows.Forms.GroupBox();
            this.btnGetAll = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnGetNext = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnStore = new System.Windows.Forms.Button();
            this.dgvAttributes = new System.Windows.Forms.DataGridView();
            this.attrNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attrType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.grpCustomDecodeTone = new System.Windows.Forms.GroupBox();
            this.btnEraseTone = new System.Windows.Forms.Button();
            this.buttonWavFileUpload = new System.Windows.Forms.Button();
            this.txtWavFile = new System.Windows.Forms.TextBox();
            this.buttonWavFileBrowse = new System.Windows.Forms.Button();
            this.filterScnrs = new System.Windows.Forms.GroupBox();
            this.cmbFilterScnrs = new System.Windows.Forms.ComboBox();
            this.grpFrmWrUpdate = new System.Windows.Forms.GroupBox();
            this.grpFWoptns = new System.Windows.Forms.GroupBox();
            this.chkBulk = new System.Windows.Forms.CheckBox();
            this.btnAbortFWUpdate = new System.Windows.Forms.Button();
            this.btnFWUpdate = new System.Windows.Forms.Button();
            this.btnLaunchNewFW = new System.Windows.Forms.Button();
            this.progressBarFWUpdate = new System.Windows.Forms.ProgressBar();
            this.buttonFWBrowse = new System.Windows.Forms.Button();
            this.txtFWFile = new System.Windows.Forms.TextBox();
            this.grpScannerProp = new System.Windows.Forms.GroupBox();
            this.chkClaim = new System.Windows.Forms.CheckBox();
            this.grpElectricFenceCustomTone = new System.Windows.Forms.GroupBox();
            this.btnElectricFenceEraseTone = new System.Windows.Forms.Button();
            this.buttonElectricFenceWavFileUpload = new System.Windows.Forms.Button();
            this.txtElectricFenceWaveFile = new System.Windows.Forms.TextBox();
            this.buttonElectricFenceWavFileBrowse = new System.Windows.Forms.Button();
            this.tabRta = new System.Windows.Forms.TabPage();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnGetRTAEventStatus = new System.Windows.Forms.Button();
            this.btnSetRTAEventStatus = new System.Windows.Forms.Button();
            this.btnRegisterRTAEvents = new System.Windows.Forms.Button();
            this.btnGetRegRTAEvents = new System.Windows.Forms.Button();
            this.btnGetSuppRTAEvents = new System.Windows.Forms.Button();
            this.grpRTAEventLog = new System.Windows.Forms.GroupBox();
            this.lblRTAState = new System.Windows.Forms.Label();
            this.btnGetRTAState = new System.Windows.Forms.Button();
            this.btnCleanEvents = new System.Windows.Forms.Button();
            this.dgRtaEventResponse = new System.Windows.Forms.DataGridView();
            this.grpRTAConfig = new System.Windows.Forms.GroupBox();
            this.cbSuspend = new System.Windows.Forms.CheckBox();
            this.dgRtaView = new System.Windows.Forms.DataGridView();
            this.tabScan2Connect = new System.Windows.Forms.TabPage();
            this.grpScan2Connect = new System.Windows.Forms.GroupBox();
            this.btnSaveBarcode = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbHostName = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbScannerType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.picBBarcode = new System.Windows.Forms.PictureBox();
            this.cmbImageSize = new System.Windows.Forms.ComboBox();
            this.cmbDefaultOption = new System.Windows.Forms.ComboBox();
            this.cmbProtocol = new System.Windows.Forms.ComboBox();
            this.tabMisc = new System.Windows.Forms.TabPage();
            this.grpMiscOther = new System.Windows.Forms.GroupBox();
            this.grpSCdcSwitch = new System.Windows.Forms.GroupBox();
            this.btnSCdcSwitchDevices = new System.Windows.Forms.Button();
            this.chkSCdcSIsPermanent = new System.Windows.Forms.CheckBox();
            this.chkSCdcSIsSilent = new System.Windows.Forms.CheckBox();
            this.cmbSCdcSHostMode = new System.Windows.Forms.ComboBox();
            this.lblSCdcSHostMode = new System.Windows.Forms.Label();
            this.grpMiscCmd = new System.Windows.Forms.GroupBox();
            this.btnGetDevTopology = new System.Windows.Forms.Button();
            this.btnSdkVersion = new System.Windows.Forms.Button();
            this.grpAsync = new System.Windows.Forms.GroupBox();
            this.chkAsync = new System.Windows.Forms.CheckBox();
            this.tabScale = new System.Windows.Forms.TabPage();
            this.grpScale = new System.Windows.Forms.GroupBox();
            this.lblScalStatusDesc = new System.Windows.Forms.Label();
            this.txtWeightUnit = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSystemRest = new System.Windows.Forms.Button();
            this.btnZeroScale = new System.Windows.Forms.Button();
            this.btnReadWeight = new System.Windows.Forms.Button();
            this.tabSSW = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtEpcId = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.rdoHex = new System.Windows.Forms.RadioButton();
            this.rdoASCII = new System.Windows.Forms.RadioButton();
            this.btnVerifyTag = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnWriteTag = new System.Windows.Forms.Button();
            this.cmbPartition = new System.Windows.Forms.ComboBox();
            this.cmbFilterValue = new System.Windows.Forms.ComboBox();
            this.statusIcon = new System.Windows.Forms.PictureBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.chkAutoIncrement = new System.Windows.Forms.CheckBox();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.txtUserBank = new System.Windows.Forms.TextBox();
            this.txtNewEpcId = new System.Windows.Forms.TextBox();
            this.lblUserBank = new System.Windows.Forms.Label();
            this.txtUpcaBarcode = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tabXml = new System.Windows.Forms.TabPage();
            this.btnClearXmlArea = new System.Windows.Forms.Button();
            this.btnClearLogsArea = new System.Windows.Forms.Button();
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.grpOutXml = new System.Windows.Forms.GroupBox();
            this.txtOutXml = new System.Windows.Forms.TextBox();
            this.grpTrigger = new System.Windows.Forms.GroupBox();
            this.btnReleaseTrigger = new System.Windows.Forms.Button();
            this.btnPullTrigger = new System.Windows.Forms.Button();
            this.gbAdvanced = new System.Windows.Forms.GroupBox();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.openFileDialogFW = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialogAttr = new System.Windows.Forms.OpenFileDialog();
            this.stStripResult = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLblIbmhid = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLblSnapi = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusIBMTT = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLblHidkb = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLblSsi = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLblNxmdb = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveImgFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogWavFile = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogDADF = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogBarcodePath = new System.Windows.Forms.FolderBrowserDialog();
            this.tabCtrl.SuspendLayout();
            this.tabConectar.SuspendLayout();
            this.grpScanners.SuspendLayout();
            this.tabVinculador.SuspendLayout();
            this.gbxInventoryEx.SuspendLayout();
            this.tablaContenedorTimbrado.SuspendLayout();
            this.tabaLadoTimbrado.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.TableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTagList)).BeginInit();
            this.TableLayoutPanel2.SuspendLayout();
            this.tbContEspacioVertical.SuspendLayout();
            this.TableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.TableLayoutPanel7.SuspendLayout();
            this.tbConsolidado.SuspendLayout();
            this.panelScroll.SuspendLayout();
            this.tabBarcode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpBoxLanguage.SuspendLayout();
            this.grpboxBarcodeLbl.SuspendLayout();
            this.tabImgVdo.SuspendLayout();
            this.grpImageVideo.SuspendLayout();
            this.grpBoxImgType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImageVideo)).BeginInit();
            this.tabISO15434.SuspendLayout();
            this.grpIDC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxISO15434Image)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabScnAction.SuspendLayout();
            this.grpScnActions.SuspendLayout();
            this.grpPagerMotor.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grpHVS.SuspendLayout();
            this.grpReboot.SuspendLayout();
            this.grpEnbDisScanner.SuspendLayout();
            this.grpBeeper.SuspendLayout();
            this.grpLed.SuspendLayout();
            this.grpAim.SuspendLayout();
            this.tabRsm.SuspendLayout();
            this.grpRSM.SuspendLayout();
            this.grpBoxClrSlect.SuspendLayout();
            this.grpBoxSetRset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).BeginInit();
            this.tabConfig.SuspendLayout();
            this.grpCustomDecodeTone.SuspendLayout();
            this.filterScnrs.SuspendLayout();
            this.grpFrmWrUpdate.SuspendLayout();
            this.grpFWoptns.SuspendLayout();
            this.grpScannerProp.SuspendLayout();
            this.grpElectricFenceCustomTone.SuspendLayout();
            this.tabRta.SuspendLayout();
            this.grpRTAEventLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRtaEventResponse)).BeginInit();
            this.grpRTAConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRtaView)).BeginInit();
            this.tabScan2Connect.SuspendLayout();
            this.grpScan2Connect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBBarcode)).BeginInit();
            this.tabMisc.SuspendLayout();
            this.grpMiscOther.SuspendLayout();
            this.grpSCdcSwitch.SuspendLayout();
            this.grpMiscCmd.SuspendLayout();
            this.grpAsync.SuspendLayout();
            this.tabScale.SuspendLayout();
            this.grpScale.SuspendLayout();
            this.tabSSW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusIcon)).BeginInit();
            this.tabXml.SuspendLayout();
            this.grpResult.SuspendLayout();
            this.grpOutXml.SuspendLayout();
            this.grpTrigger.SuspendLayout();
            this.stStripResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtrl
            // 
            this.tabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrl.Controls.Add(this.tabConectar);
            this.tabCtrl.Controls.Add(this.tabVinculador);
            this.tabCtrl.Controls.Add(this.tabBarcode);
            this.tabCtrl.Controls.Add(this.tabImgVdo);
            this.tabCtrl.Controls.Add(this.tabISO15434);
            this.tabCtrl.Controls.Add(this.tabScnAction);
            this.tabCtrl.Controls.Add(this.tabRsm);
            this.tabCtrl.Controls.Add(this.tabConfig);
            this.tabCtrl.Controls.Add(this.tabRta);
            this.tabCtrl.Controls.Add(this.tabScan2Connect);
            this.tabCtrl.Controls.Add(this.tabMisc);
            this.tabCtrl.Controls.Add(this.tabScale);
            this.tabCtrl.Controls.Add(this.tabSSW);
            this.tabCtrl.Controls.Add(this.tabXml);
            this.tabCtrl.Location = new System.Drawing.Point(12, 12);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(1179, 712);
            this.tabCtrl.TabIndex = 1;
            this.tabCtrl.SelectedIndexChanged += new System.EventHandler(this.tabCtrl_SelectedIndexChanged);
            // 
            // tabConectar
            // 
            this.tabConectar.AutoScroll = true;
            this.tabConectar.BackColor = System.Drawing.Color.AliceBlue;
            this.tabConectar.Controls.Add(this.btnGetScanners);
            this.tabConectar.Controls.Add(this.grpScanners);
            this.tabConectar.Controls.Add(this.lblSlctScnnr);
            this.tabConectar.Controls.Add(this.cmbSlcrScnr);
            this.tabConectar.Location = new System.Drawing.Point(4, 22);
            this.tabConectar.Name = "tabConectar";
            this.tabConectar.Padding = new System.Windows.Forms.Padding(12);
            this.tabConectar.Size = new System.Drawing.Size(1171, 686);
            this.tabConectar.TabIndex = 13;
            this.tabConectar.Text = "Conexión";
            this.tabConectar.UseVisualStyleBackColor = true;
            this.tabConectar.Click += new System.EventHandler(this.tabConectar_Click);
            // 
            // btnGetScanners
            // 
            this.btnGetScanners.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGetScanners.Location = new System.Drawing.Point(20, 20);
            this.btnGetScanners.Name = "btnGetScanners";
            this.btnGetScanners.Size = new System.Drawing.Size(170, 32);
            this.btnGetScanners.TabIndex = 0;
            this.btnGetScanners.Text = "Discover Scanners";
            this.btnGetScanners.UseVisualStyleBackColor = false;
            this.btnGetScanners.Click += new System.EventHandler(this.btnGetScanners_Click);
            // 
            // grpScanners
            // 
            this.grpScanners.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpScanners.Controls.Add(this.lstvScanners);
            this.grpScanners.Location = new System.Drawing.Point(20, 70);
            this.grpScanners.Name = "grpScanners";
            this.grpScanners.Size = new System.Drawing.Size(1115, 520);
            this.grpScanners.TabIndex = 2;
            this.grpScanners.TabStop = false;
            this.grpScanners.Text = "Scanners conectados";
            this.grpScanners.Enter += new System.EventHandler(this.grpScanners_Enter);
            // 
            // lstvScanners
            // 
            this.lstvScanners.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstvScanners.BackColor = System.Drawing.Color.White;
            this.lstvScanners.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmId,
            this.clmType,
            this.clmModel,
            this.clmFrmwr,
            this.clmCnfig,
            this.clmMnftrd,
            this.clmSerial,
            this.clmGuid});
            this.lstvScanners.FullRowSelect = true;
            this.lstvScanners.GridLines = true;
            this.lstvScanners.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstvScanners.HideSelection = false;
            this.lstvScanners.Location = new System.Drawing.Point(10, 22);
            this.lstvScanners.MultiSelect = false;
            this.lstvScanners.Name = "lstvScanners";
            this.lstvScanners.ShowItemToolTips = true;
            this.lstvScanners.Size = new System.Drawing.Size(1095, 485);
            this.lstvScanners.TabIndex = 0;
            this.lstvScanners.UseCompatibleStateImageBehavior = false;
            this.lstvScanners.View = System.Windows.Forms.View.Details;
            this.lstvScanners.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstvScanners_ItemSelectionChanged);
            this.lstvScanners.SelectedIndexChanged += new System.EventHandler(this.lstvScanners_SelectedIndexChanged);
            // 
            // clmId
            // 
            this.clmId.Text = "#";
            this.clmId.Width = 30;
            // 
            // clmType
            // 
            this.clmType.Text = "Com Interface";
            this.clmType.Width = 94;
            // 
            // clmModel
            // 
            this.clmModel.Text = "Model #";
            this.clmModel.Width = 132;
            // 
            // clmFrmwr
            // 
            this.clmFrmwr.Text = "Firmware";
            this.clmFrmwr.Width = 119;
            // 
            // clmCnfig
            // 
            this.clmCnfig.Text = "Config Name";
            this.clmCnfig.Width = 119;
            // 
            // clmMnftrd
            // 
            this.clmMnftrd.Text = "Built";
            // 
            // clmSerial
            // 
            this.clmSerial.Text = "Serial # or Port #";
            this.clmSerial.Width = 120;
            // 
            // clmGuid
            // 
            this.clmGuid.Text = "GUID";
            this.clmGuid.Width = 110;
            // 
            // lblSlctScnnr
            // 
            this.lblSlctScnnr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSlctScnnr.AutoSize = true;
            this.lblSlctScnnr.Location = new System.Drawing.Point(20, 610);
            this.lblSlctScnnr.Name = "lblSlctScnnr";
            this.lblSlctScnnr.Size = new System.Drawing.Size(82, 13);
            this.lblSlctScnnr.TabIndex = 66;
            this.lblSlctScnnr.Text = "Scanner activo:";
            this.lblSlctScnnr.Click += new System.EventHandler(this.lblSlctScnnr_Click);
            // 
            // cmbSlcrScnr
            // 
            this.cmbSlcrScnr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbSlcrScnr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSlcrScnr.FormattingEnabled = true;
            this.cmbSlcrScnr.Location = new System.Drawing.Point(120, 607);
            this.cmbSlcrScnr.Name = "cmbSlcrScnr";
            this.cmbSlcrScnr.Size = new System.Drawing.Size(420, 21);
            this.cmbSlcrScnr.TabIndex = 1;
            this.cmbSlcrScnr.SelectedIndexChanged += new System.EventHandler(this.cmbSlcrScnr_SelectedIndexChanged);
            // 
            // tabVinculador
            // 
            this.tabVinculador.Controls.Add(this.gbxInventoryEx);
            this.tabVinculador.Location = new System.Drawing.Point(4, 22);
            this.tabVinculador.Name = "tabVinculador";
            this.tabVinculador.Size = new System.Drawing.Size(1171, 686);
            this.tabVinculador.TabIndex = 14;
            this.tabVinculador.Text = "Vinculador";
            this.tabVinculador.UseVisualStyleBackColor = true;
            // 
            // gbxInventoryEx
            // 
            this.gbxInventoryEx.Controls.Add(this.tablaContenedorTimbrado);
            this.gbxInventoryEx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxInventoryEx.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.gbxInventoryEx.Location = new System.Drawing.Point(0, 0);
            this.gbxInventoryEx.Margin = new System.Windows.Forms.Padding(0);
            this.gbxInventoryEx.Name = "gbxInventoryEx";
            this.gbxInventoryEx.Size = new System.Drawing.Size(1171, 686);
            this.gbxInventoryEx.TabIndex = 9;
            this.gbxInventoryEx.TabStop = false;
            // 
            // tablaContenedorTimbrado
            // 
            this.tablaContenedorTimbrado.ColumnCount = 1;
            this.tablaContenedorTimbrado.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablaContenedorTimbrado.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablaContenedorTimbrado.Controls.Add(this.tabaLadoTimbrado, 0, 0);
            this.tablaContenedorTimbrado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablaContenedorTimbrado.Location = new System.Drawing.Point(3, 16);
            this.tablaContenedorTimbrado.Margin = new System.Windows.Forms.Padding(0);
            this.tablaContenedorTimbrado.Name = "tablaContenedorTimbrado";
            this.tablaContenedorTimbrado.RowCount = 1;
            this.tablaContenedorTimbrado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablaContenedorTimbrado.Size = new System.Drawing.Size(1165, 667);
            this.tablaContenedorTimbrado.TabIndex = 30;
            // 
            // tabaLadoTimbrado
            // 
            this.tabaLadoTimbrado.ColumnCount = 1;
            this.tabaLadoTimbrado.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabaLadoTimbrado.Controls.Add(this.TableLayoutPanel1, 0, 0);
            this.tabaLadoTimbrado.Controls.Add(this.TableLayoutPanel2, 0, 1);
            this.tabaLadoTimbrado.Controls.Add(this.tbContEspacioVertical, 0, 2);
            this.tabaLadoTimbrado.Controls.Add(this.TableLayoutPanel3, 0, 3);
            this.tabaLadoTimbrado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabaLadoTimbrado.Location = new System.Drawing.Point(0, 0);
            this.tabaLadoTimbrado.Margin = new System.Windows.Forms.Padding(0);
            this.tabaLadoTimbrado.Name = "tabaLadoTimbrado";
            this.tabaLadoTimbrado.RowCount = 4;
            this.tabaLadoTimbrado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.tabaLadoTimbrado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tabaLadoTimbrado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tabaLadoTimbrado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.tabaLadoTimbrado.Size = new System.Drawing.Size(1165, 667);
            this.tabaLadoTimbrado.TabIndex = 0;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 4;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.TableLayoutPanel1.Controls.Add(this.btnLimpiarRFID, 1, 1);
            this.TableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.cantidadRFID, 2, 0);
            this.TableLayoutPanel1.Controls.Add(this.MsnVincular, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.CodBarras, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel6, 3, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 3;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1165, 140);
            this.TableLayoutPanel1.TabIndex = 44;
            // 
            // btnLimpiarRFID
            // 
            this.btnLimpiarRFID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLimpiarRFID.Location = new System.Drawing.Point(469, 56);
            this.btnLimpiarRFID.Name = "btnLimpiarRFID";
            this.btnLimpiarRFID.Size = new System.Drawing.Size(168, 47);
            this.btnLimpiarRFID.TabIndex = 51;
            this.btnLimpiarRFID.Text = "Limpiar";
            this.btnLimpiarRFID.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(168)))), ((int)(((byte)(115)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(469, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 47);
            this.button1.TabIndex = 50;
            this.button1.Text = "Nuevo Timbrado";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // cantidadRFID
            // 
            this.cantidadRFID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cantidadRFID.AutoSize = true;
            this.cantidadRFID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cantidadRFID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantidadRFID.ForeColor = System.Drawing.Color.Red;
            this.cantidadRFID.Location = new System.Drawing.Point(643, 3);
            this.cantidadRFID.Margin = new System.Windows.Forms.Padding(3);
            this.cantidadRFID.Name = "cantidadRFID";
            this.TableLayoutPanel1.SetRowSpan(this.cantidadRFID, 2);
            this.cantidadRFID.Size = new System.Drawing.Size(110, 100);
            this.cantidadRFID.TabIndex = 48;
            this.cantidadRFID.Text = "0";
            this.cantidadRFID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MsnVincular
            // 
            this.MsnVincular.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MsnVincular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.MsnVincular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TableLayoutPanel1.SetColumnSpan(this.MsnVincular, 3);
            this.MsnVincular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MsnVincular.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.MsnVincular.Location = new System.Drawing.Point(3, 109);
            this.MsnVincular.Margin = new System.Windows.Forms.Padding(3);
            this.MsnVincular.Name = "MsnVincular";
            this.MsnVincular.Size = new System.Drawing.Size(750, 28);
            this.MsnVincular.TabIndex = 28;
            this.MsnVincular.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CodBarras
            // 
            this.CodBarras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CodBarras.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodBarras.ForeColor = System.Drawing.Color.Gray;
            this.CodBarras.Location = new System.Drawing.Point(3, 38);
            this.CodBarras.Name = "CodBarras";
            this.TableLayoutPanel1.SetRowSpan(this.CodBarras, 2);
            this.CodBarras.Size = new System.Drawing.Size(460, 30);
            this.CodBarras.TabIndex = 25;
            this.CodBarras.Text = "Codigo de Barras...";
            this.CodBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TableLayoutPanel6
            // 
            this.TableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel6.ColumnCount = 3;
            this.TableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.TableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.TableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.TableLayoutPanel6.Controls.Add(this.dgvTagList, 0, 0);
            this.TableLayoutPanel6.Controls.Add(this.nroOP, 0, 1);
            this.TableLayoutPanel6.Controls.Add(this.nroHM, 1, 1);
            this.TableLayoutPanel6.Controls.Add(this.btnLimpiarOPHM, 2, 1);
            this.TableLayoutPanel6.Location = new System.Drawing.Point(756, 0);
            this.TableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel6.Name = "TableLayoutPanel6";
            this.TableLayoutPanel6.RowCount = 2;
            this.TableLayoutPanel1.SetRowSpan(this.TableLayoutPanel6, 3);
            this.TableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.TableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TableLayoutPanel6.Size = new System.Drawing.Size(409, 140);
            this.TableLayoutPanel6.TabIndex = 52;
            // 
            // dgvTagList
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvTagList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTagList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTagList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTagList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTagList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTagList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTagList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTagList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnEPC,
            this.clnTID,
            this.clnCount});
            this.TableLayoutPanel6.SetColumnSpan(this.dgvTagList, 3);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTagList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTagList.EnableHeadersVisualStyles = false;
            this.dgvTagList.GridColor = System.Drawing.Color.LightGray;
            this.dgvTagList.Location = new System.Drawing.Point(3, 3);
            this.dgvTagList.Name = "dgvTagList";
            this.dgvTagList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTagList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTagList.RowHeadersVisible = false;
            this.dgvTagList.RowTemplate.Height = 24;
            this.dgvTagList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTagList.Size = new System.Drawing.Size(403, 78);
            this.dgvTagList.TabIndex = 47;
            // 
            // clnEPC
            // 
            this.clnEPC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnEPC.FillWeight = 40F;
            this.clnEPC.HeaderText = "RFID";
            this.clnEPC.Name = "clnEPC";
            this.clnEPC.ReadOnly = true;
            // 
            // clnTID
            // 
            this.clnTID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnTID.FillWeight = 40F;
            this.clnTID.HeaderText = "TID";
            this.clnTID.Name = "clnTID";
            this.clnTID.ReadOnly = true;
            // 
            // clnCount
            // 
            this.clnCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnCount.FillWeight = 20F;
            this.clnCount.HeaderText = "CANTIDAD";
            this.clnCount.Name = "clnCount";
            this.clnCount.ReadOnly = true;
            // 
            // nroOP
            // 
            this.nroOP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nroOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nroOP.ForeColor = System.Drawing.Color.Gray;
            this.nroOP.Location = new System.Drawing.Point(3, 100);
            this.nroOP.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.nroOP.Name = "nroOP";
            this.nroOP.Size = new System.Drawing.Size(266, 20);
            this.nroOP.TabIndex = 48;
            this.nroOP.Text = "Nro OP...";
            // 
            // nroHM
            // 
            this.nroHM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nroHM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nroHM.ForeColor = System.Drawing.Color.Gray;
            this.nroHM.Location = new System.Drawing.Point(275, 102);
            this.nroHM.Name = "nroHM";
            this.nroHM.Size = new System.Drawing.Size(84, 20);
            this.nroHM.TabIndex = 49;
            this.nroHM.Text = "H. M....";
            // 
            // btnLimpiarOPHM
            // 
            this.btnLimpiarOPHM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiarOPHM.BackColor = System.Drawing.Color.Transparent;
            this.btnLimpiarOPHM.FlatAppearance.BorderSize = 0;
            this.btnLimpiarOPHM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLimpiarOPHM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLimpiarOPHM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarOPHM.ForeColor = System.Drawing.Color.Transparent;
            this.btnLimpiarOPHM.Location = new System.Drawing.Point(365, 87);
            this.btnLimpiarOPHM.Name = "btnLimpiarOPHM";
            this.btnLimpiarOPHM.Size = new System.Drawing.Size(41, 50);
            this.btnLimpiarOPHM.TabIndex = 50;
            this.btnLimpiarOPHM.UseVisualStyleBackColor = false;
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 6;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TableLayoutPanel2.Controls.Add(this.btnVerConsolidado, 4, 0);
            this.TableLayoutPanel2.Controls.Add(this.lblTotalCount, 0, 0);
            this.TableLayoutPanel2.Controls.Add(this.label16, 0, 0);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(0, 140);
            this.TableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 1;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(1165, 40);
            this.TableLayoutPanel2.TabIndex = 46;
            // 
            // btnVerConsolidado
            // 
            this.btnVerConsolidado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnVerConsolidado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerConsolidado.Location = new System.Drawing.Point(910, 14);
            this.btnVerConsolidado.Name = "btnVerConsolidado";
            this.btnVerConsolidado.Size = new System.Drawing.Size(99, 23);
            this.btnVerConsolidado.TabIndex = 0;
            this.btnVerConsolidado.Text = "Detalle Timbrado";
            this.btnVerConsolidado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVerConsolidado.UseVisualStyleBackColor = true;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTotalCount.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCount.Location = new System.Drawing.Point(352, 20);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(52, 20);
            this.lblTotalCount.TabIndex = 48;
            this.lblTotalCount.Text = "0";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label16.Location = new System.Drawing.Point(3, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(343, 20);
            this.label16.TabIndex = 47;
            this.label16.Text = "La Cantidad De Prendas Timbradas Es:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // tbContEspacioVertical
            // 
            this.tbContEspacioVertical.ColumnCount = 3;
            this.tbContEspacioVertical.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tbContEspacioVertical.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tbContEspacioVertical.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tbContEspacioVertical.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbContEspacioVertical.Controls.Add(this.btnStopInventoryEx, 0, 0);
            this.tbContEspacioVertical.Controls.Add(this.cbxInventory, 2, 0);
            this.tbContEspacioVertical.Controls.Add(this.btnStartInventoryEx, 1, 0);
            this.tbContEspacioVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContEspacioVertical.Location = new System.Drawing.Point(0, 180);
            this.tbContEspacioVertical.Margin = new System.Windows.Forms.Padding(0);
            this.tbContEspacioVertical.Name = "tbContEspacioVertical";
            this.tbContEspacioVertical.RowCount = 1;
            this.tbContEspacioVertical.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbContEspacioVertical.Size = new System.Drawing.Size(1165, 6);
            this.tbContEspacioVertical.TabIndex = 47;
            // 
            // btnStopInventoryEx
            // 
            this.btnStopInventoryEx.Location = new System.Drawing.Point(3, 3);
            this.btnStopInventoryEx.Name = "btnStopInventoryEx";
            this.btnStopInventoryEx.Size = new System.Drawing.Size(65, 1);
            this.btnStopInventoryEx.TabIndex = 30;
            this.btnStopInventoryEx.TabStop = false;
            this.btnStopInventoryEx.Text = "Stop";
            this.btnStopInventoryEx.UseVisualStyleBackColor = true;
            this.btnStopInventoryEx.Visible = false;
            // 
            // cbxInventory
            // 
            this.cbxInventory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInventory.FormattingEnabled = true;
            this.cbxInventory.Location = new System.Drawing.Point(770, 2);
            this.cbxInventory.Margin = new System.Windows.Forms.Padding(2);
            this.cbxInventory.Name = "cbxInventory";
            this.cbxInventory.Size = new System.Drawing.Size(93, 21);
            this.cbxInventory.TabIndex = 34;
            this.cbxInventory.Visible = false;
            // 
            // btnStartInventoryEx
            // 
            this.btnStartInventoryEx.Location = new System.Drawing.Point(387, 3);
            this.btnStartInventoryEx.Name = "btnStartInventoryEx";
            this.btnStartInventoryEx.Size = new System.Drawing.Size(65, 1);
            this.btnStartInventoryEx.TabIndex = 29;
            this.btnStartInventoryEx.TabStop = false;
            this.btnStartInventoryEx.Text = "Start";
            this.btnStartInventoryEx.UseVisualStyleBackColor = true;
            this.btnStartInventoryEx.Visible = false;
            // 
            // TableLayoutPanel3
            // 
            this.TableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel3.ColumnCount = 2;
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TableLayoutPanel3.Controls.Add(this.DataGridView1, 0, 0);
            this.TableLayoutPanel3.Controls.Add(this.TableLayoutPanel7, 1, 0);
            this.TableLayoutPanel3.Location = new System.Drawing.Point(3, 189);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.RowCount = 1;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel3.Size = new System.Drawing.Size(1159, 475);
            this.TableLayoutPanel3.TabIndex = 48;
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.linea,
            this.op,
            this.hoja_marcacion,
            this.corte,
            this.subcorte,
            this.color,
            this.talla,
            this.cod_talla,
            this.id_talla,
            this.fecha,
            this.id_rfid});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.DataGridView1.Location = new System.Drawing.Point(3, 3);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView1.Size = new System.Drawing.Size(805, 469);
            this.DataGridView1.TabIndex = 54;
            // 
            // linea
            // 
            this.linea.HeaderText = "Linea";
            this.linea.Name = "linea";
            this.linea.ReadOnly = true;
            // 
            // op
            // 
            this.op.HeaderText = "OP";
            this.op.Name = "op";
            this.op.ReadOnly = true;
            // 
            // hoja_marcacion
            // 
            this.hoja_marcacion.HeaderText = "HM";
            this.hoja_marcacion.Name = "hoja_marcacion";
            this.hoja_marcacion.ReadOnly = true;
            // 
            // corte
            // 
            this.corte.HeaderText = "corte";
            this.corte.Name = "corte";
            this.corte.ReadOnly = true;
            this.corte.Visible = false;
            // 
            // subcorte
            // 
            this.subcorte.HeaderText = "subcorte";
            this.subcorte.Name = "subcorte";
            this.subcorte.ReadOnly = true;
            this.subcorte.Visible = false;
            // 
            // color
            // 
            this.color.HeaderText = "Color";
            this.color.Name = "color";
            this.color.ReadOnly = true;
            // 
            // talla
            // 
            this.talla.HeaderText = "Talla";
            this.talla.Name = "talla";
            this.talla.ReadOnly = true;
            // 
            // cod_talla
            // 
            this.cod_talla.HeaderText = "cod_talla";
            this.cod_talla.Name = "cod_talla";
            this.cod_talla.ReadOnly = true;
            this.cod_talla.Visible = false;
            // 
            // id_talla
            // 
            this.id_talla.HeaderText = "id_talla";
            this.id_talla.Name = "id_talla";
            this.id_talla.ReadOnly = true;
            this.id_talla.Visible = false;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // id_rfid
            // 
            this.id_rfid.HeaderText = "RFID";
            this.id_rfid.Name = "id_rfid";
            this.id_rfid.ReadOnly = true;
            // 
            // TableLayoutPanel7
            // 
            this.TableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel7.ColumnCount = 1;
            this.TableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel7.Controls.Add(this.tbConsolidado, 0, 0);
            this.TableLayoutPanel7.Location = new System.Drawing.Point(811, 0);
            this.TableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel7.Name = "TableLayoutPanel7";
            this.TableLayoutPanel7.RowCount = 1;
            this.TableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 475F));
            this.TableLayoutPanel7.Size = new System.Drawing.Size(348, 475);
            this.TableLayoutPanel7.TabIndex = 55;
            // 
            // tbConsolidado
            // 
            this.tbConsolidado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConsolidado.AutoSize = true;
            this.tbConsolidado.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbConsolidado.ColumnCount = 1;
            this.tbConsolidado.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbConsolidado.Controls.Add(this.lblTotalDetalle, 0, 1);
            this.tbConsolidado.Controls.Add(this.panelScroll, 0, 0);
            this.tbConsolidado.Location = new System.Drawing.Point(0, 0);
            this.tbConsolidado.Margin = new System.Windows.Forms.Padding(0);
            this.tbConsolidado.Name = "tbConsolidado";
            this.tbConsolidado.RowCount = 2;
            this.tbConsolidado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tbConsolidado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tbConsolidado.Size = new System.Drawing.Size(348, 475);
            this.tbConsolidado.TabIndex = 2;
            // 
            // lblTotalDetalle
            // 
            this.lblTotalDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDetalle.AutoSize = true;
            this.lblTotalDetalle.BackColor = System.Drawing.Color.LightGray;
            this.lblTotalDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDetalle.ForeColor = System.Drawing.Color.Black;
            this.lblTotalDetalle.Location = new System.Drawing.Point(3, 430);
            this.lblTotalDetalle.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalDetalle.Name = "lblTotalDetalle";
            this.lblTotalDetalle.Size = new System.Drawing.Size(342, 42);
            this.lblTotalDetalle.TabIndex = 1;
            this.lblTotalDetalle.Text = "TOTAL TIMBRADO";
            this.lblTotalDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelScroll
            // 
            this.panelScroll.AutoScroll = true;
            this.panelScroll.Controls.Add(this.tbDetalleTimbrado);
            this.panelScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScroll.Location = new System.Drawing.Point(3, 3);
            this.panelScroll.Name = "panelScroll";
            this.panelScroll.Size = new System.Drawing.Size(342, 421);
            this.panelScroll.TabIndex = 2;
            // 
            // tbDetalleTimbrado
            // 
            this.tbDetalleTimbrado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDetalleTimbrado.ColumnCount = 1;
            this.tbDetalleTimbrado.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbDetalleTimbrado.Location = new System.Drawing.Point(8, 8);
            this.tbDetalleTimbrado.Name = "tbDetalleTimbrado";
            this.tbDetalleTimbrado.RowCount = 1;
            this.tbDetalleTimbrado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbDetalleTimbrado.Size = new System.Drawing.Size(342, 421);
            this.tbDetalleTimbrado.TabIndex = 1;
            // 
            // tabBarcode
            // 
            this.tabBarcode.AutoScroll = true;
            this.tabBarcode.BackColor = System.Drawing.Color.AliceBlue;
            this.tabBarcode.Controls.Add(this.groupBox1);
            this.tabBarcode.Controls.Add(this.grpBoxLanguage);
            this.tabBarcode.Controls.Add(this.txtBarcode);
            this.tabBarcode.Controls.Add(this.grpboxBarcodeLbl);
            this.tabBarcode.Location = new System.Drawing.Point(4, 22);
            this.tabBarcode.Name = "tabBarcode";
            this.tabBarcode.Padding = new System.Windows.Forms.Padding(3);
            this.tabBarcode.Size = new System.Drawing.Size(1171, 686);
            this.tabBarcode.TabIndex = 0;
            this.tabBarcode.Text = "Barcode";
            this.tabBarcode.UseVisualStyleBackColor = true;
            this.tabBarcode.Click += new System.EventHandler(this.tabBarcode_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.btnScriptEditor);
            this.groupBox1.Controls.Add(this.btnBrowseScript);
            this.groupBox1.Controls.Add(this.chkBoxAppADF);
            this.groupBox1.Location = new System.Drawing.Point(19, 416);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 46);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application ADF";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnScriptEditor
            // 
            this.btnScriptEditor.Location = new System.Drawing.Point(283, 16);
            this.btnScriptEditor.Name = "btnScriptEditor";
            this.btnScriptEditor.Size = new System.Drawing.Size(103, 23);
            this.btnScriptEditor.TabIndex = 2;
            this.btnScriptEditor.Text = "Script Editor ...";
            this.btnScriptEditor.UseVisualStyleBackColor = true;
            this.btnScriptEditor.Click += new System.EventHandler(this.btnScriptEditor_Click);
            // 
            // btnBrowseScript
            // 
            this.btnBrowseScript.Location = new System.Drawing.Point(163, 16);
            this.btnBrowseScript.Name = "btnBrowseScript";
            this.btnBrowseScript.Size = new System.Drawing.Size(103, 23);
            this.btnBrowseScript.TabIndex = 1;
            this.btnBrowseScript.Text = "Browse Script ...";
            this.btnBrowseScript.UseVisualStyleBackColor = true;
            this.btnBrowseScript.Click += new System.EventHandler(this.btnBrowseScript_Click);
            // 
            // chkBoxAppADF
            // 
            this.chkBoxAppADF.AutoSize = true;
            this.chkBoxAppADF.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkBoxAppADF.Enabled = false;
            this.chkBoxAppADF.Location = new System.Drawing.Point(18, 22);
            this.chkBoxAppADF.Name = "chkBoxAppADF";
            this.chkBoxAppADF.Size = new System.Drawing.Size(62, 17);
            this.chkBoxAppADF.TabIndex = 0;
            this.chkBoxAppADF.Text = "Not Set";
            this.chkBoxAppADF.UseVisualStyleBackColor = false;
            this.chkBoxAppADF.CheckedChanged += new System.EventHandler(this.OnChkChangedDADF);
            // 
            // grpBoxLanguage
            // 
            this.grpBoxLanguage.BackColor = System.Drawing.SystemColors.Window;
            this.grpBoxLanguage.Controls.Add(this.chkBoxEmulation);
            this.grpBoxLanguage.Controls.Add(this.cmbEmulation);
            this.grpBoxLanguage.Location = new System.Drawing.Point(19, 365);
            this.grpBoxLanguage.Name = "grpBoxLanguage";
            this.grpBoxLanguage.Size = new System.Drawing.Size(468, 50);
            this.grpBoxLanguage.TabIndex = 2;
            this.grpBoxLanguage.TabStop = false;
            this.grpBoxLanguage.Text = "Keyboard Emulation and Language/Locale Details";
            this.grpBoxLanguage.Enter += new System.EventHandler(this.grpBoxLanguage_Enter);
            // 
            // chkBoxEmulation
            // 
            this.chkBoxEmulation.AutoSize = true;
            this.chkBoxEmulation.Location = new System.Drawing.Point(18, 22);
            this.chkBoxEmulation.Name = "chkBoxEmulation";
            this.chkBoxEmulation.Size = new System.Drawing.Size(108, 17);
            this.chkBoxEmulation.TabIndex = 0;
            this.chkBoxEmulation.Text = "Enable Emulation";
            this.chkBoxEmulation.UseVisualStyleBackColor = true;
            this.chkBoxEmulation.CheckedChanged += new System.EventHandler(this.chkBoxEmulation_CheckedChanged);
            // 
            // cmbEmulation
            // 
            this.cmbEmulation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmulation.FormattingEnabled = true;
            this.cmbEmulation.Items.AddRange(new object[] {
            "DEFAULT",
            "FRENCH",
            "ENGLISH"});
            this.cmbEmulation.Location = new System.Drawing.Point(163, 20);
            this.cmbEmulation.Name = "cmbEmulation";
            this.cmbEmulation.Size = new System.Drawing.Size(151, 21);
            this.cmbEmulation.TabIndex = 1;
            this.cmbEmulation.SelectedIndexChanged += new System.EventHandler(this.cmbEmulation_SelectedIndexChanged);
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.White;
            this.txtBarcode.Location = new System.Drawing.Point(19, 15);
            this.txtBarcode.Multiline = true;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.ReadOnly = true;
            this.txtBarcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBarcode.Size = new System.Drawing.Size(468, 217);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            // 
            // grpboxBarcodeLbl
            // 
            this.grpboxBarcodeLbl.BackColor = System.Drawing.SystemColors.Window;
            this.grpboxBarcodeLbl.Controls.Add(this.label15);
            this.grpboxBarcodeLbl.Controls.Add(this.cmbEncoding);
            this.grpboxBarcodeLbl.Controls.Add(this.lblSyblogy);
            this.grpboxBarcodeLbl.Controls.Add(this.txtSyblogy);
            this.grpboxBarcodeLbl.Controls.Add(this.lblDecdBarCde);
            this.grpboxBarcodeLbl.Controls.Add(this.txtBarcodeLbl);
            this.grpboxBarcodeLbl.Controls.Add(this.btnAbortMacroPdf);
            this.grpboxBarcodeLbl.Controls.Add(this.btnBarcodeClear);
            this.grpboxBarcodeLbl.Controls.Add(this.btnFlushMacroPdf);
            this.grpboxBarcodeLbl.Location = new System.Drawing.Point(19, 238);
            this.grpboxBarcodeLbl.Name = "grpboxBarcodeLbl";
            this.grpboxBarcodeLbl.Size = new System.Drawing.Size(468, 124);
            this.grpboxBarcodeLbl.TabIndex = 1;
            this.grpboxBarcodeLbl.TabStop = false;
            this.grpboxBarcodeLbl.Text = "Barcode Scanning";
            this.grpboxBarcodeLbl.Enter += new System.EventHandler(this.grpboxBarcodeLbl_Enter);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(53, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 41;
            this.label15.Text = "Encoding";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // cmbEncoding
            // 
            this.cmbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncoding.FormattingEnabled = true;
            this.cmbEncoding.Items.AddRange(new object[] {
            "ASCII",
            "UTF-8",
            "UTF-16",
            "UTF-32"});
            this.cmbEncoding.Location = new System.Drawing.Point(121, 17);
            this.cmbEncoding.Name = "cmbEncoding";
            this.cmbEncoding.Size = new System.Drawing.Size(121, 21);
            this.cmbEncoding.TabIndex = 40;
            this.cmbEncoding.SelectedIndexChanged += new System.EventHandler(this.cmbEncoding_SelectedIndexChanged);
            // 
            // lblSyblogy
            // 
            this.lblSyblogy.AutoSize = true;
            this.lblSyblogy.Location = new System.Drawing.Point(47, 72);
            this.lblSyblogy.Name = "lblSyblogy";
            this.lblSyblogy.Size = new System.Drawing.Size(58, 13);
            this.lblSyblogy.TabIndex = 39;
            this.lblSyblogy.Text = "Symbology";
            this.lblSyblogy.Click += new System.EventHandler(this.lblSyblogy_Click);
            // 
            // txtSyblogy
            // 
            this.txtSyblogy.BackColor = System.Drawing.Color.White;
            this.txtSyblogy.Location = new System.Drawing.Point(121, 69);
            this.txtSyblogy.Name = "txtSyblogy";
            this.txtSyblogy.ReadOnly = true;
            this.txtSyblogy.Size = new System.Drawing.Size(332, 20);
            this.txtSyblogy.TabIndex = 1;
            this.txtSyblogy.TextChanged += new System.EventHandler(this.txtSyblogy_TextChanged);
            // 
            // lblDecdBarCde
            // 
            this.lblDecdBarCde.AutoSize = true;
            this.lblDecdBarCde.Location = new System.Drawing.Point(11, 46);
            this.lblDecdBarCde.Name = "lblDecdBarCde";
            this.lblDecdBarCde.Size = new System.Drawing.Size(94, 13);
            this.lblDecdBarCde.TabIndex = 0;
            this.lblDecdBarCde.Text = "Decoded Barcode";
            this.lblDecdBarCde.Click += new System.EventHandler(this.lblDecdBarCde_Click);
            // 
            // txtBarcodeLbl
            // 
            this.txtBarcodeLbl.BackColor = System.Drawing.Color.White;
            this.txtBarcodeLbl.Location = new System.Drawing.Point(121, 44);
            this.txtBarcodeLbl.Multiline = true;
            this.txtBarcodeLbl.Name = "txtBarcodeLbl";
            this.txtBarcodeLbl.Size = new System.Drawing.Size(331, 20);
            this.txtBarcodeLbl.TabIndex = 0;
            this.txtBarcodeLbl.TextChanged += new System.EventHandler(this.txtBarcodeLbl_TextChanged);
            // 
            // btnAbortMacroPdf
            // 
            this.btnAbortMacroPdf.Location = new System.Drawing.Point(224, 96);
            this.btnAbortMacroPdf.Name = "btnAbortMacroPdf";
            this.btnAbortMacroPdf.Size = new System.Drawing.Size(104, 23);
            this.btnAbortMacroPdf.TabIndex = 3;
            this.btnAbortMacroPdf.Text = "Abort Macro PDF";
            this.btnAbortMacroPdf.UseVisualStyleBackColor = true;
            this.btnAbortMacroPdf.Click += new System.EventHandler(this.btnAbortMacroPdf_Click);
            // 
            // btnBarcodeClear
            // 
            this.btnBarcodeClear.Location = new System.Drawing.Point(349, 96);
            this.btnBarcodeClear.Name = "btnBarcodeClear";
            this.btnBarcodeClear.Size = new System.Drawing.Size(103, 23);
            this.btnBarcodeClear.TabIndex = 4;
            this.btnBarcodeClear.Text = "Clear";
            this.btnBarcodeClear.UseVisualStyleBackColor = true;
            this.btnBarcodeClear.Click += new System.EventHandler(this.btnBarcodeClear_Click);
            // 
            // btnFlushMacroPdf
            // 
            this.btnFlushMacroPdf.Location = new System.Drawing.Point(95, 96);
            this.btnFlushMacroPdf.Name = "btnFlushMacroPdf";
            this.btnFlushMacroPdf.Size = new System.Drawing.Size(104, 23);
            this.btnFlushMacroPdf.TabIndex = 2;
            this.btnFlushMacroPdf.Text = "Flush Macro PDF";
            this.btnFlushMacroPdf.UseVisualStyleBackColor = true;
            this.btnFlushMacroPdf.Click += new System.EventHandler(this.btnFlushMacroPdf_Click);
            // 
            // tabImgVdo
            // 
            this.tabImgVdo.Controls.Add(this.grpImageVideo);
            this.tabImgVdo.Location = new System.Drawing.Point(4, 22);
            this.tabImgVdo.Name = "tabImgVdo";
            this.tabImgVdo.Padding = new System.Windows.Forms.Padding(3);
            this.tabImgVdo.Size = new System.Drawing.Size(1171, 686);
            this.tabImgVdo.TabIndex = 1;
            this.tabImgVdo.Text = "Image & Video";
            this.tabImgVdo.UseVisualStyleBackColor = true;
            this.tabImgVdo.Click += new System.EventHandler(this.tabImgVdo_Click);
            // 
            // grpImageVideo
            // 
            this.grpImageVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpImageVideo.BackColor = System.Drawing.SystemColors.Window;
            this.grpImageVideo.Controls.Add(this.btnBarcode);
            this.grpImageVideo.Controls.Add(this.chkVideoViewFinderEnable);
            this.grpImageVideo.Controls.Add(this.btnSveImge);
            this.grpImageVideo.Controls.Add(this.btnVideo);
            this.grpImageVideo.Controls.Add(this.btnImage);
            this.grpImageVideo.Controls.Add(this.btnAbortImageXfer);
            this.grpImageVideo.Controls.Add(this.grpBoxImgType);
            this.grpImageVideo.Controls.Add(this.pbxImageVideo);
            this.grpImageVideo.Location = new System.Drawing.Point(6, 6);
            this.grpImageVideo.Name = "grpImageVideo";
            this.grpImageVideo.Size = new System.Drawing.Size(493, 456);
            this.grpImageVideo.TabIndex = 32;
            this.grpImageVideo.TabStop = false;
            this.grpImageVideo.Text = "Imaging and Video";
            this.grpImageVideo.Enter += new System.EventHandler(this.grpImageVideo_Enter);
            // 
            // btnBarcode
            // 
            this.btnBarcode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBarcode.Location = new System.Drawing.Point(325, 296);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(75, 23);
            this.btnBarcode.TabIndex = 2;
            this.btnBarcode.Text = "Barcode";
            this.btnBarcode.UseVisualStyleBackColor = false;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // chkVideoViewFinderEnable
            // 
            this.chkVideoViewFinderEnable.AutoSize = true;
            this.chkVideoViewFinderEnable.Location = new System.Drawing.Point(183, 355);
            this.chkVideoViewFinderEnable.Name = "chkVideoViewFinderEnable";
            this.chkVideoViewFinderEnable.Size = new System.Drawing.Size(147, 17);
            this.chkVideoViewFinderEnable.TabIndex = 3;
            this.chkVideoViewFinderEnable.Text = "Enable Video View Finder";
            this.chkVideoViewFinderEnable.UseVisualStyleBackColor = true;
            this.chkVideoViewFinderEnable.CheckedChanged += new System.EventHandler(this.OnVideoViewFinderEnable);
            // 
            // btnSveImge
            // 
            this.btnSveImge.Location = new System.Drawing.Point(183, 415);
            this.btnSveImge.Name = "btnSveImge";
            this.btnSveImge.Size = new System.Drawing.Size(105, 23);
            this.btnSveImge.TabIndex = 6;
            this.btnSveImge.Text = "Save Image";
            this.btnSveImge.UseVisualStyleBackColor = true;
            this.btnSveImge.Click += new System.EventHandler(this.btnSveImge_Click);
            // 
            // btnVideo
            // 
            this.btnVideo.Location = new System.Drawing.Point(199, 296);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(80, 23);
            this.btnVideo.TabIndex = 1;
            this.btnVideo.Text = "Video";
            this.btnVideo.UseVisualStyleBackColor = true;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // btnImage
            // 
            this.btnImage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnImage.Location = new System.Drawing.Point(74, 296);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(81, 23);
            this.btnImage.TabIndex = 0;
            this.btnImage.Text = "Image";
            this.btnImage.UseVisualStyleBackColor = false;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // btnAbortImageXfer
            // 
            this.btnAbortImageXfer.Location = new System.Drawing.Point(183, 386);
            this.btnAbortImageXfer.Name = "btnAbortImageXfer";
            this.btnAbortImageXfer.Size = new System.Drawing.Size(105, 23);
            this.btnAbortImageXfer.TabIndex = 5;
            this.btnAbortImageXfer.Text = "Abort Transfer";
            this.btnAbortImageXfer.UseVisualStyleBackColor = true;
            this.btnAbortImageXfer.Click += new System.EventHandler(this.btnAbortImageXfer_Click);
            // 
            // grpBoxImgType
            // 
            this.grpBoxImgType.Controls.Add(this.rdoJPG);
            this.grpBoxImgType.Controls.Add(this.rdoTIFF);
            this.grpBoxImgType.Controls.Add(this.rdoBMP);
            this.grpBoxImgType.Location = new System.Drawing.Point(32, 336);
            this.grpBoxImgType.Name = "grpBoxImgType";
            this.grpBoxImgType.Size = new System.Drawing.Size(123, 113);
            this.grpBoxImgType.TabIndex = 4;
            this.grpBoxImgType.TabStop = false;
            this.grpBoxImgType.Text = "Set Image Type";
            this.grpBoxImgType.Enter += new System.EventHandler(this.grpBoxImgType_Enter);
            // 
            // rdoJPG
            // 
            this.rdoJPG.AutoSize = true;
            this.rdoJPG.Location = new System.Drawing.Point(25, 19);
            this.rdoJPG.Name = "rdoJPG";
            this.rdoJPG.Size = new System.Drawing.Size(45, 17);
            this.rdoJPG.TabIndex = 0;
            this.rdoJPG.TabStop = true;
            this.rdoJPG.Text = "JPG";
            this.rdoJPG.UseVisualStyleBackColor = true;
            this.rdoJPG.CheckedChanged += new System.EventHandler(this.OnJpg);
            // 
            // rdoTIFF
            // 
            this.rdoTIFF.AutoSize = true;
            this.rdoTIFF.ForeColor = System.Drawing.Color.Black;
            this.rdoTIFF.Location = new System.Drawing.Point(26, 50);
            this.rdoTIFF.Name = "rdoTIFF";
            this.rdoTIFF.Size = new System.Drawing.Size(47, 17);
            this.rdoTIFF.TabIndex = 1;
            this.rdoTIFF.Text = "TIFF";
            this.rdoTIFF.UseVisualStyleBackColor = true;
            this.rdoTIFF.CheckedChanged += new System.EventHandler(this.OnTiff);
            // 
            // rdoBMP
            // 
            this.rdoBMP.AutoSize = true;
            this.rdoBMP.ForeColor = System.Drawing.Color.Black;
            this.rdoBMP.Location = new System.Drawing.Point(25, 79);
            this.rdoBMP.Name = "rdoBMP";
            this.rdoBMP.Size = new System.Drawing.Size(48, 17);
            this.rdoBMP.TabIndex = 2;
            this.rdoBMP.Text = "BMP";
            this.rdoBMP.UseVisualStyleBackColor = true;
            this.rdoBMP.CheckedChanged += new System.EventHandler(this.OnBmp);
            // 
            // pbxImageVideo
            // 
            this.pbxImageVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxImageVideo.BackColor = System.Drawing.Color.White;
            this.pbxImageVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxImageVideo.Enabled = false;
            this.pbxImageVideo.Location = new System.Drawing.Point(74, 19);
            this.pbxImageVideo.Name = "pbxImageVideo";
            this.pbxImageVideo.Size = new System.Drawing.Size(326, 262);
            this.pbxImageVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxImageVideo.TabIndex = 10;
            this.pbxImageVideo.TabStop = false;
            this.pbxImageVideo.Click += new System.EventHandler(this.pbxImageVideo_Click);
            // 
            // tabISO15434
            // 
            this.tabISO15434.Controls.Add(this.grpIDC);
            this.tabISO15434.Location = new System.Drawing.Point(4, 22);
            this.tabISO15434.Name = "tabISO15434";
            this.tabISO15434.Padding = new System.Windows.Forms.Padding(3);
            this.tabISO15434.Size = new System.Drawing.Size(1171, 686);
            this.tabISO15434.TabIndex = 9;
            this.tabISO15434.Text = "IDC";
            this.toolTip1.SetToolTip(this.tabISO15434, "Intelligent Document Capture");
            this.tabISO15434.ToolTipText = "Intelligent Document Capture";
            this.tabISO15434.UseVisualStyleBackColor = true;
            this.tabISO15434.Click += new System.EventHandler(this.tabISO15434_Click);
            // 
            // grpIDC
            // 
            this.grpIDC.Controls.Add(this.btnSaveIdc);
            this.grpIDC.Controls.Add(this.pbxISO15434Image);
            this.grpIDC.Controls.Add(this.btnClearpbx);
            this.grpIDC.Controls.Add(this.checkUseHID);
            this.grpIDC.Controls.Add(this.groupBox3);
            this.grpIDC.Controls.Add(this.groupBox2);
            this.grpIDC.Enabled = false;
            this.grpIDC.Location = new System.Drawing.Point(6, 6);
            this.grpIDC.Name = "grpIDC";
            this.grpIDC.Size = new System.Drawing.Size(493, 456);
            this.grpIDC.TabIndex = 0;
            this.grpIDC.TabStop = false;
            this.grpIDC.Enter += new System.EventHandler(this.grpIDC_Enter);
            // 
            // btnSaveIdc
            // 
            this.btnSaveIdc.Location = new System.Drawing.Point(336, 423);
            this.btnSaveIdc.Name = "btnSaveIdc";
            this.btnSaveIdc.Size = new System.Drawing.Size(67, 23);
            this.btnSaveIdc.TabIndex = 4;
            this.btnSaveIdc.Text = "Save";
            this.btnSaveIdc.UseVisualStyleBackColor = true;
            this.btnSaveIdc.Click += new System.EventHandler(this.btnSaveIdc_Click);
            // 
            // pbxISO15434Image
            // 
            this.pbxISO15434Image.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pbxISO15434Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxISO15434Image.Location = new System.Drawing.Point(6, 19);
            this.pbxISO15434Image.MaximumSize = new System.Drawing.Size(481, 299);
            this.pbxISO15434Image.Name = "pbxISO15434Image";
            this.pbxISO15434Image.Size = new System.Drawing.Size(481, 299);
            this.pbxISO15434Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxISO15434Image.TabIndex = 0;
            this.pbxISO15434Image.TabStop = false;
            this.pbxISO15434Image.Click += new System.EventHandler(this.pbxISO15434Image_Click);
            // 
            // btnClearpbx
            // 
            this.btnClearpbx.Location = new System.Drawing.Point(424, 423);
            this.btnClearpbx.Name = "btnClearpbx";
            this.btnClearpbx.Size = new System.Drawing.Size(63, 23);
            this.btnClearpbx.TabIndex = 3;
            this.btnClearpbx.Text = "Clear";
            this.btnClearpbx.UseVisualStyleBackColor = true;
            this.btnClearpbx.Click += new System.EventHandler(this.btnClearpbx_Click);
            // 
            // checkUseHID
            // 
            this.checkUseHID.AutoSize = true;
            this.checkUseHID.Location = new System.Drawing.Point(205, 426);
            this.checkUseHID.Name = "checkUseHID";
            this.checkUseHID.Size = new System.Drawing.Size(67, 17);
            this.checkUseHID.TabIndex = 2;
            this.checkUseHID.Text = "Use HID";
            this.checkUseHID.UseVisualStyleBackColor = true;
            this.checkUseHID.CheckedChanged += new System.EventHandler(this.checkUseHID_CheckedChanged_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSnapiStore);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cmbSnapiParamValue);
            this.groupBox3.Controls.Add(this.btnSnapiSet);
            this.groupBox3.Controls.Add(this.btnSnapiGet);
            this.groupBox3.Controls.Add(this.cmbSnapiParams);
            this.groupBox3.Location = new System.Drawing.Point(6, 330);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(193, 119);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parameters";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // btnSnapiStore
            // 
            this.btnSnapiStore.Location = new System.Drawing.Point(135, 55);
            this.btnSnapiStore.Name = "btnSnapiStore";
            this.btnSnapiStore.Size = new System.Drawing.Size(52, 21);
            this.btnSnapiStore.TabIndex = 4;
            this.btnSnapiStore.Text = "Store";
            this.btnSnapiStore.UseVisualStyleBackColor = true;
            this.btnSnapiStore.Click += new System.EventHandler(this.btnSnapiStore_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Value";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "ID";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cmbSnapiParamValue
            // 
            this.cmbSnapiParamValue.FormattingEnabled = true;
            this.cmbSnapiParamValue.Location = new System.Drawing.Point(46, 87);
            this.cmbSnapiParamValue.Name = "cmbSnapiParamValue";
            this.cmbSnapiParamValue.Size = new System.Drawing.Size(141, 21);
            this.cmbSnapiParamValue.TabIndex = 2;
            this.cmbSnapiParamValue.SelectedIndexChanged += new System.EventHandler(this.cmbSnapiParamValue_SelectedIndexChanged);
            // 
            // btnSnapiSet
            // 
            this.btnSnapiSet.Location = new System.Drawing.Point(77, 55);
            this.btnSnapiSet.Name = "btnSnapiSet";
            this.btnSnapiSet.Size = new System.Drawing.Size(52, 21);
            this.btnSnapiSet.TabIndex = 3;
            this.btnSnapiSet.Text = "Set";
            this.btnSnapiSet.UseVisualStyleBackColor = true;
            this.btnSnapiSet.Click += new System.EventHandler(this.btnSnapiSet_Click);
            // 
            // btnSnapiGet
            // 
            this.btnSnapiGet.Location = new System.Drawing.Point(16, 55);
            this.btnSnapiGet.Name = "btnSnapiGet";
            this.btnSnapiGet.Size = new System.Drawing.Size(52, 21);
            this.btnSnapiGet.TabIndex = 1;
            this.btnSnapiGet.Text = "Get";
            this.btnSnapiGet.UseVisualStyleBackColor = true;
            this.btnSnapiGet.Click += new System.EventHandler(this.btnSnapiGet_Click);
            // 
            // cmbSnapiParams
            // 
            this.cmbSnapiParams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSnapiParams.FormattingEnabled = true;
            this.cmbSnapiParams.Location = new System.Drawing.Point(46, 26);
            this.cmbSnapiParams.Name = "cmbSnapiParams";
            this.cmbSnapiParams.Size = new System.Drawing.Size(141, 21);
            this.cmbSnapiParams.TabIndex = 0;
            this.cmbSnapiParams.SelectedIndexChanged += new System.EventHandler(this.cmbSnapiParams_SelectedIndexChanged_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtDocCapDecodeDataSymbol);
            this.groupBox2.Controls.Add(this.txtDocCapDecodeData);
            this.groupBox2.Location = new System.Drawing.Point(205, 330);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 83);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Barcode Data";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Symbology";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Decode Data";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtDocCapDecodeDataSymbol
            // 
            this.txtDocCapDecodeDataSymbol.Location = new System.Drawing.Point(89, 45);
            this.txtDocCapDecodeDataSymbol.Name = "txtDocCapDecodeDataSymbol";
            this.txtDocCapDecodeDataSymbol.ReadOnly = true;
            this.txtDocCapDecodeDataSymbol.Size = new System.Drawing.Size(187, 20);
            this.txtDocCapDecodeDataSymbol.TabIndex = 1;
            this.txtDocCapDecodeDataSymbol.TextChanged += new System.EventHandler(this.txtDocCapDecodeDataSymbol_TextChanged);
            // 
            // txtDocCapDecodeData
            // 
            this.txtDocCapDecodeData.Location = new System.Drawing.Point(89, 19);
            this.txtDocCapDecodeData.Name = "txtDocCapDecodeData";
            this.txtDocCapDecodeData.ReadOnly = true;
            this.txtDocCapDecodeData.Size = new System.Drawing.Size(187, 20);
            this.txtDocCapDecodeData.TabIndex = 0;
            this.txtDocCapDecodeData.TextChanged += new System.EventHandler(this.txtDocCapDecodeData_TextChanged);
            // 
            // tabScnAction
            // 
            this.tabScnAction.Controls.Add(this.grpScnActions);
            this.tabScnAction.Location = new System.Drawing.Point(4, 22);
            this.tabScnAction.Name = "tabScnAction";
            this.tabScnAction.Size = new System.Drawing.Size(1171, 686);
            this.tabScnAction.TabIndex = 5;
            this.tabScnAction.Text = "Actions";
            this.tabScnAction.UseVisualStyleBackColor = true;
            this.tabScnAction.Click += new System.EventHandler(this.tabScnAction_Click);
            // 
            // grpScnActions
            // 
            this.grpScnActions.Controls.Add(this.grpPagerMotor);
            this.grpScnActions.Controls.Add(this.groupBox4);
            this.grpScnActions.Controls.Add(this.grpHVS);
            this.grpScnActions.Controls.Add(this.grpReboot);
            this.grpScnActions.Controls.Add(this.grpEnbDisScanner);
            this.grpScnActions.Controls.Add(this.grpBeeper);
            this.grpScnActions.Controls.Add(this.grpLed);
            this.grpScnActions.Controls.Add(this.grpAim);
            this.grpScnActions.Location = new System.Drawing.Point(3, 3);
            this.grpScnActions.Name = "grpScnActions";
            this.grpScnActions.Size = new System.Drawing.Size(500, 455);
            this.grpScnActions.TabIndex = 41;
            this.grpScnActions.TabStop = false;
            this.grpScnActions.Enter += new System.EventHandler(this.grpScnActions_Enter);
            // 
            // grpPagerMotor
            // 
            this.grpPagerMotor.Controls.Add(this.lblPagerMotorTimeout);
            this.grpPagerMotor.Controls.Add(this.txtPagerMotorDuration);
            this.grpPagerMotor.Controls.Add(this.btnEnablePagerMotor);
            this.grpPagerMotor.Location = new System.Drawing.Point(306, 267);
            this.grpPagerMotor.Name = "grpPagerMotor";
            this.grpPagerMotor.Size = new System.Drawing.Size(177, 175);
            this.grpPagerMotor.TabIndex = 7;
            this.grpPagerMotor.TabStop = false;
            this.grpPagerMotor.Text = "Pager Motor";
            this.grpPagerMotor.Enter += new System.EventHandler(this.grpPagerMotor_Enter);
            // 
            // lblPagerMotorTimeout
            // 
            this.lblPagerMotorTimeout.AutoSize = true;
            this.lblPagerMotorTimeout.Location = new System.Drawing.Point(20, 76);
            this.lblPagerMotorTimeout.Name = "lblPagerMotorTimeout";
            this.lblPagerMotorTimeout.Size = new System.Drawing.Size(84, 13);
            this.lblPagerMotorTimeout.TabIndex = 2;
            this.lblPagerMotorTimeout.Text = "Duration (10 ms)";
            this.lblPagerMotorTimeout.Click += new System.EventHandler(this.lblPagerMotorTimeout_Click);
            // 
            // txtPagerMotorDuration
            // 
            this.txtPagerMotorDuration.Location = new System.Drawing.Point(20, 95);
            this.txtPagerMotorDuration.Name = "txtPagerMotorDuration";
            this.txtPagerMotorDuration.Size = new System.Drawing.Size(127, 20);
            this.txtPagerMotorDuration.TabIndex = 1;
            this.txtPagerMotorDuration.Text = "10";
            this.txtPagerMotorDuration.TextChanged += new System.EventHandler(this.txtPagerMotorDuration_TextChanged);
            // 
            // btnEnablePagerMotor
            // 
            this.btnEnablePagerMotor.Location = new System.Drawing.Point(20, 33);
            this.btnEnablePagerMotor.Name = "btnEnablePagerMotor";
            this.btnEnablePagerMotor.Size = new System.Drawing.Size(127, 23);
            this.btnEnablePagerMotor.TabIndex = 0;
            this.btnEnablePagerMotor.Text = "Start";
            this.btnEnablePagerMotor.UseVisualStyleBackColor = true;
            this.btnEnablePagerMotor.Click += new System.EventHandler(this.btnEnablePageMotor_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDisconnect);
            this.groupBox4.Location = new System.Drawing.Point(306, 85);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(177, 58);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Disconnect BT Scanner";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(41, 22);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 0;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // grpHVS
            // 
            this.grpHVS.BackColor = System.Drawing.SystemColors.Window;
            this.grpHVS.Controls.Add(this.cmbMode);
            this.grpHVS.Controls.Add(this.chkShmPermChange);
            this.grpHVS.Controls.Add(this.chkShmSilentSwitch);
            this.grpHVS.Controls.Add(this.btnSwitchHostMode);
            this.grpHVS.Location = new System.Drawing.Point(31, 267);
            this.grpHVS.Name = "grpHVS";
            this.grpHVS.Size = new System.Drawing.Size(261, 175);
            this.grpHVS.TabIndex = 5;
            this.grpHVS.TabStop = false;
            this.grpHVS.Text = "Switch Host Variant";
            this.grpHVS.Enter += new System.EventHandler(this.grpHVS_Enter);
            // 
            // cmbMode
            // 
            this.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Location = new System.Drawing.Point(33, 35);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(204, 21);
            this.cmbMode.TabIndex = 0;
            this.cmbMode.SelectedIndexChanged += new System.EventHandler(this.cmbMode_SelectedIndexChanged);
            // 
            // chkShmPermChange
            // 
            this.chkShmPermChange.AutoSize = true;
            this.chkShmPermChange.Location = new System.Drawing.Point(36, 95);
            this.chkShmPermChange.Name = "chkShmPermChange";
            this.chkShmPermChange.Size = new System.Drawing.Size(117, 17);
            this.chkShmPermChange.TabIndex = 2;
            this.chkShmPermChange.Text = "Permanent Change";
            this.chkShmPermChange.UseVisualStyleBackColor = true;
            this.chkShmPermChange.CheckedChanged += new System.EventHandler(this.chkShmPermChange_CheckedChanged);
            // 
            // chkShmSilentSwitch
            // 
            this.chkShmSilentSwitch.AutoSize = true;
            this.chkShmSilentSwitch.Location = new System.Drawing.Point(35, 72);
            this.chkShmSilentSwitch.Name = "chkShmSilentSwitch";
            this.chkShmSilentSwitch.Size = new System.Drawing.Size(112, 17);
            this.chkShmSilentSwitch.TabIndex = 1;
            this.chkShmSilentSwitch.Text = "Silent Switch Host";
            this.chkShmSilentSwitch.UseVisualStyleBackColor = true;
            this.chkShmSilentSwitch.CheckedChanged += new System.EventHandler(this.chkShmSilentSwitch_CheckedChanged);
            // 
            // btnSwitchHostMode
            // 
            this.btnSwitchHostMode.Location = new System.Drawing.Point(33, 133);
            this.btnSwitchHostMode.Name = "btnSwitchHostMode";
            this.btnSwitchHostMode.Size = new System.Drawing.Size(117, 23);
            this.btnSwitchHostMode.TabIndex = 3;
            this.btnSwitchHostMode.Text = "Switch Host Mode";
            this.btnSwitchHostMode.UseVisualStyleBackColor = true;
            this.btnSwitchHostMode.Click += new System.EventHandler(this.btnSetReport_Click);
            // 
            // grpReboot
            // 
            this.grpReboot.BackColor = System.Drawing.SystemColors.Window;
            this.grpReboot.Controls.Add(this.btnRebootScanner);
            this.grpReboot.Location = new System.Drawing.Point(305, 19);
            this.grpReboot.Name = "grpReboot";
            this.grpReboot.Size = new System.Drawing.Size(178, 58);
            this.grpReboot.TabIndex = 2;
            this.grpReboot.TabStop = false;
            this.grpReboot.Text = "Reboot Scanner";
            this.grpReboot.Enter += new System.EventHandler(this.grpReboot_Enter);
            // 
            // btnRebootScanner
            // 
            this.btnRebootScanner.Location = new System.Drawing.Point(41, 21);
            this.btnRebootScanner.Name = "btnRebootScanner";
            this.btnRebootScanner.Size = new System.Drawing.Size(75, 23);
            this.btnRebootScanner.TabIndex = 0;
            this.btnRebootScanner.Text = "Reboot Scanner";
            this.btnRebootScanner.UseVisualStyleBackColor = true;
            this.btnRebootScanner.Click += new System.EventHandler(this.btnRebootScanner_Click);
            // 
            // grpEnbDisScanner
            // 
            this.grpEnbDisScanner.BackColor = System.Drawing.SystemColors.Window;
            this.grpEnbDisScanner.Controls.Add(this.btnScannerDisable);
            this.grpEnbDisScanner.Controls.Add(this.btnScannerEnable);
            this.grpEnbDisScanner.Location = new System.Drawing.Point(31, 19);
            this.grpEnbDisScanner.Name = "grpEnbDisScanner";
            this.grpEnbDisScanner.Size = new System.Drawing.Size(261, 58);
            this.grpEnbDisScanner.TabIndex = 0;
            this.grpEnbDisScanner.TabStop = false;
            this.grpEnbDisScanner.Text = "Enable/Disable Scanner";
            this.grpEnbDisScanner.Enter += new System.EventHandler(this.grpEnbDisScanner_Enter);
            // 
            // btnScannerDisable
            // 
            this.btnScannerDisable.Location = new System.Drawing.Point(138, 21);
            this.btnScannerDisable.Name = "btnScannerDisable";
            this.btnScannerDisable.Size = new System.Drawing.Size(75, 23);
            this.btnScannerDisable.TabIndex = 2;
            this.btnScannerDisable.Text = "Disable";
            this.btnScannerDisable.UseVisualStyleBackColor = true;
            this.btnScannerDisable.Click += new System.EventHandler(this.btnScannerDisable_Click);
            // 
            // btnScannerEnable
            // 
            this.btnScannerEnable.Location = new System.Drawing.Point(51, 21);
            this.btnScannerEnable.Name = "btnScannerEnable";
            this.btnScannerEnable.Size = new System.Drawing.Size(75, 23);
            this.btnScannerEnable.TabIndex = 1;
            this.btnScannerEnable.Text = "Enable";
            this.btnScannerEnable.UseVisualStyleBackColor = true;
            this.btnScannerEnable.Click += new System.EventHandler(this.btnScannerEnable_Click);
            // 
            // grpBeeper
            // 
            this.grpBeeper.BackColor = System.Drawing.SystemColors.Window;
            this.grpBeeper.Controls.Add(this.cmbBeep);
            this.grpBeeper.Controls.Add(this.btnSoundBeeper);
            this.grpBeeper.Location = new System.Drawing.Point(31, 149);
            this.grpBeeper.Name = "grpBeeper";
            this.grpBeeper.Size = new System.Drawing.Size(261, 111);
            this.grpBeeper.TabIndex = 3;
            this.grpBeeper.TabStop = false;
            this.grpBeeper.Text = "Beeper";
            this.grpBeeper.Enter += new System.EventHandler(this.grpBeeper_Enter);
            // 
            // cmbBeep
            // 
            this.cmbBeep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBeep.FormattingEnabled = true;
            this.cmbBeep.Items.AddRange(new object[] {
            "ONE SHORT HIGH",
            "TWO SHORT HIGH",
            "THREE SHORT HIGH",
            "FOUR SHORT HIGH",
            "FIVE SHORT HIGH",
            "ONE SHORT LOW",
            "TWO SHORT LOW",
            "THREE SHORT LOW",
            "FOUR SHORT LOW",
            "FIVE SHORT LOW",
            "ONE LONG HIGH",
            "TWO LONG HIGH",
            "THREE LONG HIGH",
            "FOUR LONG HIGH",
            "FIVE LONG HIGH",
            "ONE LONG LOW",
            "TWO LONG LOW",
            "THREE LONG LOW",
            "FOUR LONG LOW",
            "FIVE LONG LOW",
            "FAST HIGH LOW HIGH LOW",
            "SLOW HIGH LOW HIGH LOW",
            "HIGH LOW",
            "LOW HIGH",
            "HIGH LOW HIGH",
            "LOW HIGH LOW",
            "HIGH HIGH LOW LOW"});
            this.cmbBeep.Location = new System.Drawing.Point(87, 43);
            this.cmbBeep.Name = "cmbBeep";
            this.cmbBeep.Size = new System.Drawing.Size(168, 21);
            this.cmbBeep.TabIndex = 0;
            this.cmbBeep.SelectedIndexChanged += new System.EventHandler(this.cmbBeep_SelectedIndexChanged);
            // 
            // btnSoundBeeper
            // 
            this.btnSoundBeeper.Location = new System.Drawing.Point(6, 41);
            this.btnSoundBeeper.Name = "btnSoundBeeper";
            this.btnSoundBeeper.Size = new System.Drawing.Size(70, 23);
            this.btnSoundBeeper.TabIndex = 1;
            this.btnSoundBeeper.Text = "Beep";
            this.btnSoundBeeper.UseVisualStyleBackColor = true;
            this.btnSoundBeeper.Click += new System.EventHandler(this.btnSoundBeeper_Click);
            // 
            // grpLed
            // 
            this.grpLed.BackColor = System.Drawing.SystemColors.Window;
            this.grpLed.Controls.Add(this.cmbLed);
            this.grpLed.Controls.Add(this.btnLedOff);
            this.grpLed.Controls.Add(this.btnLedOn);
            this.grpLed.Location = new System.Drawing.Point(306, 149);
            this.grpLed.Name = "grpLed";
            this.grpLed.Size = new System.Drawing.Size(177, 111);
            this.grpLed.TabIndex = 4;
            this.grpLed.TabStop = false;
            this.grpLed.Text = "LED";
            this.grpLed.Enter += new System.EventHandler(this.grpLed_Enter);
            // 
            // cmbLed
            // 
            this.cmbLed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLed.FormattingEnabled = true;
            this.cmbLed.Items.AddRange(new object[] {
            "GREEN",
            "YELLOW",
            "RED"});
            this.cmbLed.Location = new System.Drawing.Point(20, 30);
            this.cmbLed.Name = "cmbLed";
            this.cmbLed.Size = new System.Drawing.Size(127, 21);
            this.cmbLed.TabIndex = 0;
            this.cmbLed.SelectedIndexChanged += new System.EventHandler(this.cmbLed_SelectedIndexChanged);
            // 
            // btnLedOff
            // 
            this.btnLedOff.Location = new System.Drawing.Point(93, 70);
            this.btnLedOff.Name = "btnLedOff";
            this.btnLedOff.Size = new System.Drawing.Size(54, 23);
            this.btnLedOff.TabIndex = 2;
            this.btnLedOff.Text = "Off";
            this.btnLedOff.UseVisualStyleBackColor = true;
            this.btnLedOff.Click += new System.EventHandler(this.btnLedOff_Click);
            // 
            // btnLedOn
            // 
            this.btnLedOn.Location = new System.Drawing.Point(20, 70);
            this.btnLedOn.Name = "btnLedOn";
            this.btnLedOn.Size = new System.Drawing.Size(54, 23);
            this.btnLedOn.TabIndex = 1;
            this.btnLedOn.Text = "On";
            this.btnLedOn.UseVisualStyleBackColor = true;
            this.btnLedOn.Click += new System.EventHandler(this.btnLedOn_Click);
            // 
            // grpAim
            // 
            this.grpAim.BackColor = System.Drawing.SystemColors.Window;
            this.grpAim.Controls.Add(this.btnAimOn);
            this.grpAim.Controls.Add(this.btnAimOff);
            this.grpAim.Location = new System.Drawing.Point(31, 85);
            this.grpAim.Name = "grpAim";
            this.grpAim.Size = new System.Drawing.Size(261, 58);
            this.grpAim.TabIndex = 1;
            this.grpAim.TabStop = false;
            this.grpAim.Text = "Aim";
            this.grpAim.Enter += new System.EventHandler(this.grpAim_Enter);
            // 
            // btnAimOn
            // 
            this.btnAimOn.Location = new System.Drawing.Point(51, 22);
            this.btnAimOn.Name = "btnAimOn";
            this.btnAimOn.Size = new System.Drawing.Size(75, 23);
            this.btnAimOn.TabIndex = 0;
            this.btnAimOn.Text = "Aim On";
            this.btnAimOn.UseVisualStyleBackColor = true;
            this.btnAimOn.Click += new System.EventHandler(this.btnAimOn_Click);
            // 
            // btnAimOff
            // 
            this.btnAimOff.Location = new System.Drawing.Point(138, 22);
            this.btnAimOff.Name = "btnAimOff";
            this.btnAimOff.Size = new System.Drawing.Size(75, 23);
            this.btnAimOff.TabIndex = 1;
            this.btnAimOff.Text = "Aim Off";
            this.btnAimOff.UseVisualStyleBackColor = true;
            this.btnAimOff.Click += new System.EventHandler(this.btnAimOff_Click);
            // 
            // tabRsm
            // 
            this.tabRsm.Controls.Add(this.grpRSM);
            this.tabRsm.Location = new System.Drawing.Point(4, 22);
            this.tabRsm.Name = "tabRsm";
            this.tabRsm.Size = new System.Drawing.Size(1171, 686);
            this.tabRsm.TabIndex = 2;
            this.tabRsm.Text = "RSM";
            this.tabRsm.ToolTipText = "Remote Scanner Management";
            this.tabRsm.UseVisualStyleBackColor = true;
            this.tabRsm.Click += new System.EventHandler(this.tabRsm_Click);
            // 
            // grpRSM
            // 
            this.grpRSM.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpRSM.Controls.Add(this.grpBoxClrSlect);
            this.grpRSM.Controls.Add(this.grpBoxSetRset);
            this.grpRSM.Controls.Add(this.dgvAttributes);
            this.grpRSM.Location = new System.Drawing.Point(10, 3);
            this.grpRSM.Name = "grpRSM";
            this.grpRSM.Size = new System.Drawing.Size(486, 457);
            this.grpRSM.TabIndex = 0;
            this.grpRSM.TabStop = false;
            this.grpRSM.Text = "RSM";
            this.grpRSM.Enter += new System.EventHandler(this.grpRSM_Enter);
            // 
            // grpBoxClrSlect
            // 
            this.grpBoxClrSlect.Controls.Add(this.btnClearAll);
            this.grpBoxClrSlect.Controls.Add(this.btnSelectAll);
            this.grpBoxClrSlect.Location = new System.Drawing.Point(358, 365);
            this.grpBoxClrSlect.Name = "grpBoxClrSlect";
            this.grpBoxClrSlect.Size = new System.Drawing.Size(122, 87);
            this.grpBoxClrSlect.TabIndex = 1;
            this.grpBoxClrSlect.TabStop = false;
            this.grpBoxClrSlect.Text = "Select/Clear";
            this.grpBoxClrSlect.Enter += new System.EventHandler(this.grpBoxClrSlect_Enter);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(24, 50);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 1;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(24, 19);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // grpBoxSetRset
            // 
            this.grpBoxSetRset.Controls.Add(this.btnGetAll);
            this.grpBoxSetRset.Controls.Add(this.btnGet);
            this.grpBoxSetRset.Controls.Add(this.btnGetNext);
            this.grpBoxSetRset.Controls.Add(this.btnSet);
            this.grpBoxSetRset.Controls.Add(this.btnStore);
            this.grpBoxSetRset.Location = new System.Drawing.Point(6, 365);
            this.grpBoxSetRset.Name = "grpBoxSetRset";
            this.grpBoxSetRset.Size = new System.Drawing.Size(272, 86);
            this.grpBoxSetRset.TabIndex = 0;
            this.grpBoxSetRset.TabStop = false;
            this.grpBoxSetRset.Text = "Attribute Get/Set";
            this.grpBoxSetRset.Enter += new System.EventHandler(this.grpBoxSetRset_Enter);
            // 
            // btnGetAll
            // 
            this.btnGetAll.Location = new System.Drawing.Point(4, 19);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(77, 23);
            this.btnGetAll.TabIndex = 0;
            this.btnGetAll.Text = "Get All IDs";
            this.btnGetAll.UseVisualStyleBackColor = true;
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(4, 50);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(77, 23);
            this.btnGet.TabIndex = 1;
            this.btnGet.Text = "Get Value";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnGetNext
            // 
            this.btnGetNext.Location = new System.Drawing.Point(91, 19);
            this.btnGetNext.Name = "btnGetNext";
            this.btnGetNext.Size = new System.Drawing.Size(77, 23);
            this.btnGetNext.TabIndex = 2;
            this.btnGetNext.Text = "Next Value";
            this.btnGetNext.UseVisualStyleBackColor = true;
            this.btnGetNext.Click += new System.EventHandler(this.btnGetNext_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(91, 50);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(77, 23);
            this.btnSet.TabIndex = 3;
            this.btnSet.Text = "Set Value";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnStore
            // 
            this.btnStore.Location = new System.Drawing.Point(181, 19);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(77, 23);
            this.btnStore.TabIndex = 4;
            this.btnStore.Text = "Store Value";
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // dgvAttributes
            // 
            this.dgvAttributes.AllowUserToAddRows = false;
            this.dgvAttributes.AllowUserToDeleteRows = false;
            this.dgvAttributes.AllowUserToResizeColumns = false;
            this.dgvAttributes.AllowUserToResizeRows = false;
            this.dgvAttributes.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAttributes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvAttributes.ColumnHeadersHeight = 29;
            this.dgvAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.attrNum,
            this.attrType,
            this.property,
            this.value});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAttributes.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvAttributes.GridColor = System.Drawing.SystemColors.Control;
            this.dgvAttributes.Location = new System.Drawing.Point(6, 19);
            this.dgvAttributes.Name = "dgvAttributes";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAttributes.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvAttributes.RowHeadersWidth = 51;
            this.dgvAttributes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttributes.Size = new System.Drawing.Size(474, 340);
            this.dgvAttributes.TabIndex = 2;
            this.dgvAttributes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttributes_CellContentClick);
            // 
            // attrNum
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            this.attrNum.DefaultCellStyle = dataGridViewCellStyle10;
            this.attrNum.HeaderText = "ID";
            this.attrNum.MinimumWidth = 6;
            this.attrNum.Name = "attrNum";
            this.attrNum.ReadOnly = true;
            this.attrNum.Width = 50;
            // 
            // attrType
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            this.attrType.DefaultCellStyle = dataGridViewCellStyle11;
            this.attrType.HeaderText = "Type";
            this.attrType.MinimumWidth = 6;
            this.attrType.Name = "attrType";
            this.attrType.ReadOnly = true;
            this.attrType.Width = 80;
            // 
            // property
            // 
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            this.property.DefaultCellStyle = dataGridViewCellStyle12;
            this.property.HeaderText = "Property";
            this.property.MinimumWidth = 6;
            this.property.Name = "property";
            this.property.ReadOnly = true;
            this.property.Width = 125;
            // 
            // value
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            this.value.DefaultCellStyle = dataGridViewCellStyle13;
            this.value.HeaderText = "Value";
            this.value.MinimumWidth = 6;
            this.value.Name = "value";
            this.value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.value.Width = 320;
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.grpCustomDecodeTone);
            this.tabConfig.Controls.Add(this.filterScnrs);
            this.tabConfig.Controls.Add(this.grpFrmWrUpdate);
            this.tabConfig.Controls.Add(this.grpScannerProp);
            this.tabConfig.Controls.Add(this.grpElectricFenceCustomTone);
            this.tabConfig.Location = new System.Drawing.Point(4, 22);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Size = new System.Drawing.Size(1171, 686);
            this.tabConfig.TabIndex = 3;
            this.tabConfig.Text = "Advanced";
            this.tabConfig.UseVisualStyleBackColor = true;
            this.tabConfig.Click += new System.EventHandler(this.tabConfig_Click);
            // 
            // grpCustomDecodeTone
            // 
            this.grpCustomDecodeTone.BackColor = System.Drawing.SystemColors.Window;
            this.grpCustomDecodeTone.Controls.Add(this.btnEraseTone);
            this.grpCustomDecodeTone.Controls.Add(this.buttonWavFileUpload);
            this.grpCustomDecodeTone.Controls.Add(this.txtWavFile);
            this.grpCustomDecodeTone.Controls.Add(this.buttonWavFileBrowse);
            this.grpCustomDecodeTone.Location = new System.Drawing.Point(16, 208);
            this.grpCustomDecodeTone.Margin = new System.Windows.Forms.Padding(2);
            this.grpCustomDecodeTone.Name = "grpCustomDecodeTone";
            this.grpCustomDecodeTone.Padding = new System.Windows.Forms.Padding(2);
            this.grpCustomDecodeTone.Size = new System.Drawing.Size(468, 89);
            this.grpCustomDecodeTone.TabIndex = 3;
            this.grpCustomDecodeTone.TabStop = false;
            this.grpCustomDecodeTone.Text = "Custom Good Decode Tone";
            this.grpCustomDecodeTone.Enter += new System.EventHandler(this.grpCustomDecodeTone_Enter);
            // 
            // btnEraseTone
            // 
            this.btnEraseTone.Location = new System.Drawing.Point(339, 51);
            this.btnEraseTone.Name = "btnEraseTone";
            this.btnEraseTone.Size = new System.Drawing.Size(113, 25);
            this.btnEraseTone.TabIndex = 3;
            this.btnEraseTone.Text = "Erase Tone";
            this.btnEraseTone.UseVisualStyleBackColor = true;
            this.btnEraseTone.Click += new System.EventHandler(this.btnEraseTone_Click);
            // 
            // buttonWavFileUpload
            // 
            this.buttonWavFileUpload.Location = new System.Drawing.Point(209, 51);
            this.buttonWavFileUpload.Margin = new System.Windows.Forms.Padding(2);
            this.buttonWavFileUpload.Name = "buttonWavFileUpload";
            this.buttonWavFileUpload.Size = new System.Drawing.Size(125, 25);
            this.buttonWavFileUpload.TabIndex = 2;
            this.buttonWavFileUpload.Text = "Upload To Scanner";
            this.buttonWavFileUpload.UseVisualStyleBackColor = true;
            this.buttonWavFileUpload.Click += new System.EventHandler(this.btnWavFileUpload_Click);
            // 
            // txtWavFile
            // 
            this.txtWavFile.Location = new System.Drawing.Point(8, 24);
            this.txtWavFile.Margin = new System.Windows.Forms.Padding(2);
            this.txtWavFile.Name = "txtWavFile";
            this.txtWavFile.Size = new System.Drawing.Size(354, 20);
            this.txtWavFile.TabIndex = 0;
            this.txtWavFile.TextChanged += new System.EventHandler(this.txtWavFile_TextChanged);
            // 
            // buttonWavFileBrowse
            // 
            this.buttonWavFileBrowse.Location = new System.Drawing.Point(375, 20);
            this.buttonWavFileBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.buttonWavFileBrowse.Name = "buttonWavFileBrowse";
            this.buttonWavFileBrowse.Size = new System.Drawing.Size(77, 26);
            this.buttonWavFileBrowse.TabIndex = 1;
            this.buttonWavFileBrowse.Text = "Browse";
            this.buttonWavFileBrowse.UseVisualStyleBackColor = true;
            this.buttonWavFileBrowse.Click += new System.EventHandler(this.btnWavFileBrowse_Click);
            // 
            // filterScnrs
            // 
            this.filterScnrs.Controls.Add(this.cmbFilterScnrs);
            this.filterScnrs.Location = new System.Drawing.Point(321, 152);
            this.filterScnrs.Name = "filterScnrs";
            this.filterScnrs.Size = new System.Drawing.Size(163, 51);
            this.filterScnrs.TabIndex = 2;
            this.filterScnrs.TabStop = false;
            this.filterScnrs.Text = "Protocol Select";
            this.filterScnrs.Enter += new System.EventHandler(this.filterScnrs_Enter);
            // 
            // cmbFilterScnrs
            // 
            this.cmbFilterScnrs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterScnrs.FormattingEnabled = true;
            this.cmbFilterScnrs.Items.AddRange(new object[] {
            "ALL",
            "HID KEYBOARD",
            "IBM HANDHELD",
            "SNAPI"});
            this.cmbFilterScnrs.Location = new System.Drawing.Point(33, 17);
            this.cmbFilterScnrs.Name = "cmbFilterScnrs";
            this.cmbFilterScnrs.Size = new System.Drawing.Size(121, 21);
            this.cmbFilterScnrs.TabIndex = 0;
            this.cmbFilterScnrs.SelectedIndexChanged += new System.EventHandler(this.cmbFilterScnrs_SelectedIndexChanged);
            // 
            // grpFrmWrUpdate
            // 
            this.grpFrmWrUpdate.BackColor = System.Drawing.SystemColors.Window;
            this.grpFrmWrUpdate.Controls.Add(this.grpFWoptns);
            this.grpFrmWrUpdate.Controls.Add(this.progressBarFWUpdate);
            this.grpFrmWrUpdate.Controls.Add(this.buttonFWBrowse);
            this.grpFrmWrUpdate.Controls.Add(this.txtFWFile);
            this.grpFrmWrUpdate.Location = new System.Drawing.Point(16, 14);
            this.grpFrmWrUpdate.Name = "grpFrmWrUpdate";
            this.grpFrmWrUpdate.Size = new System.Drawing.Size(468, 130);
            this.grpFrmWrUpdate.TabIndex = 0;
            this.grpFrmWrUpdate.TabStop = false;
            this.grpFrmWrUpdate.Text = "Firmware Operations";
            this.grpFrmWrUpdate.Enter += new System.EventHandler(this.grpFrmWrUpdate_Enter);
            // 
            // grpFWoptns
            // 
            this.grpFWoptns.Controls.Add(this.chkBulk);
            this.grpFWoptns.Controls.Add(this.btnAbortFWUpdate);
            this.grpFWoptns.Controls.Add(this.btnFWUpdate);
            this.grpFWoptns.Controls.Add(this.btnLaunchNewFW);
            this.grpFWoptns.Location = new System.Drawing.Point(23, 56);
            this.grpFWoptns.Name = "grpFWoptns";
            this.grpFWoptns.Size = new System.Drawing.Size(435, 44);
            this.grpFWoptns.TabIndex = 28;
            this.grpFWoptns.TabStop = false;
            this.grpFWoptns.Enter += new System.EventHandler(this.grpFWoptns_Enter);
            // 
            // chkBulk
            // 
            this.chkBulk.AutoSize = true;
            this.chkBulk.Checked = true;
            this.chkBulk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBulk.Location = new System.Drawing.Point(37, 19);
            this.chkBulk.Name = "chkBulk";
            this.chkBulk.Size = new System.Drawing.Size(85, 17);
            this.chkBulk.TabIndex = 0;
            this.chkBulk.Text = "Bulk Update";
            this.chkBulk.UseVisualStyleBackColor = true;
            this.chkBulk.CheckedChanged += new System.EventHandler(this.chkBulk_CheckedChanged);
            // 
            // btnAbortFWUpdate
            // 
            this.btnAbortFWUpdate.Location = new System.Drawing.Point(340, 13);
            this.btnAbortFWUpdate.Name = "btnAbortFWUpdate";
            this.btnAbortFWUpdate.Size = new System.Drawing.Size(89, 23);
            this.btnAbortFWUpdate.TabIndex = 2;
            this.btnAbortFWUpdate.Text = "Abort";
            this.btnAbortFWUpdate.UseVisualStyleBackColor = true;
            this.btnAbortFWUpdate.Click += new System.EventHandler(this.btnAbortFWUpdate_Click);
            // 
            // btnFWUpdate
            // 
            this.btnFWUpdate.Location = new System.Drawing.Point(157, 13);
            this.btnFWUpdate.Name = "btnFWUpdate";
            this.btnFWUpdate.Size = new System.Drawing.Size(81, 23);
            this.btnFWUpdate.TabIndex = 1;
            this.btnFWUpdate.Text = "Update";
            this.btnFWUpdate.UseVisualStyleBackColor = true;
            this.btnFWUpdate.Click += new System.EventHandler(this.btnFWUpdate_Click);
            // 
            // btnLaunchNewFW
            // 
            this.btnLaunchNewFW.Location = new System.Drawing.Point(244, 13);
            this.btnLaunchNewFW.Name = "btnLaunchNewFW";
            this.btnLaunchNewFW.Size = new System.Drawing.Size(90, 23);
            this.btnLaunchNewFW.TabIndex = 3;
            this.btnLaunchNewFW.Text = "Launch";
            this.btnLaunchNewFW.UseVisualStyleBackColor = true;
            this.btnLaunchNewFW.Click += new System.EventHandler(this.btnLaunchNewFW_Click);
            // 
            // progressBarFWUpdate
            // 
            this.progressBarFWUpdate.BackColor = System.Drawing.Color.White;
            this.progressBarFWUpdate.Location = new System.Drawing.Point(23, 111);
            this.progressBarFWUpdate.Name = "progressBarFWUpdate";
            this.progressBarFWUpdate.Size = new System.Drawing.Size(435, 13);
            this.progressBarFWUpdate.TabIndex = 17;
            this.progressBarFWUpdate.Click += new System.EventHandler(this.progressBarFWUpdate_Click);
            // 
            // buttonFWBrowse
            // 
            this.buttonFWBrowse.Location = new System.Drawing.Point(375, 24);
            this.buttonFWBrowse.Name = "buttonFWBrowse";
            this.buttonFWBrowse.Size = new System.Drawing.Size(77, 23);
            this.buttonFWBrowse.TabIndex = 1;
            this.buttonFWBrowse.Text = "Browse";
            this.buttonFWBrowse.UseVisualStyleBackColor = true;
            this.buttonFWBrowse.Click += new System.EventHandler(this.btnFWBrowse_Click);
            // 
            // txtFWFile
            // 
            this.txtFWFile.BackColor = System.Drawing.Color.White;
            this.txtFWFile.Location = new System.Drawing.Point(23, 27);
            this.txtFWFile.Name = "txtFWFile";
            this.txtFWFile.Size = new System.Drawing.Size(339, 20);
            this.txtFWFile.TabIndex = 0;
            this.txtFWFile.TextChanged += new System.EventHandler(this.txtFWFile_TextChanged);
            // 
            // grpScannerProp
            // 
            this.grpScannerProp.Controls.Add(this.chkClaim);
            this.grpScannerProp.Location = new System.Drawing.Point(16, 152);
            this.grpScannerProp.Name = "grpScannerProp";
            this.grpScannerProp.Size = new System.Drawing.Size(218, 44);
            this.grpScannerProp.TabIndex = 1;
            this.grpScannerProp.TabStop = false;
            this.grpScannerProp.Text = "Exclusively Claim Selected Scanner";
            this.grpScannerProp.Enter += new System.EventHandler(this.grpScannerProp_Enter);
            // 
            // chkClaim
            // 
            this.chkClaim.AutoSize = true;
            this.chkClaim.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkClaim.Location = new System.Drawing.Point(18, 19);
            this.chkClaim.Name = "chkClaim";
            this.chkClaim.Size = new System.Drawing.Size(94, 17);
            this.chkClaim.TabIndex = 0;
            this.chkClaim.Text = "Claim Scanner";
            this.chkClaim.UseVisualStyleBackColor = false;
            this.chkClaim.CheckedChanged += new System.EventHandler(this.OnClaimScanner);
            // 
            // grpElectricFenceCustomTone
            // 
            this.grpElectricFenceCustomTone.BackColor = System.Drawing.SystemColors.Window;
            this.grpElectricFenceCustomTone.Controls.Add(this.btnElectricFenceEraseTone);
            this.grpElectricFenceCustomTone.Controls.Add(this.buttonElectricFenceWavFileUpload);
            this.grpElectricFenceCustomTone.Controls.Add(this.txtElectricFenceWaveFile);
            this.grpElectricFenceCustomTone.Controls.Add(this.buttonElectricFenceWavFileBrowse);
            this.grpElectricFenceCustomTone.Location = new System.Drawing.Point(16, 318);
            this.grpElectricFenceCustomTone.Margin = new System.Windows.Forms.Padding(2);
            this.grpElectricFenceCustomTone.Name = "grpElectricFenceCustomTone";
            this.grpElectricFenceCustomTone.Padding = new System.Windows.Forms.Padding(2);
            this.grpElectricFenceCustomTone.Size = new System.Drawing.Size(468, 89);
            this.grpElectricFenceCustomTone.TabIndex = 4;
            this.grpElectricFenceCustomTone.TabStop = false;
            this.grpElectricFenceCustomTone.Text = "Electric Fence Custom Tone";
            this.grpElectricFenceCustomTone.Enter += new System.EventHandler(this.grpElectricFenceCustomTone_Enter);
            // 
            // btnElectricFenceEraseTone
            // 
            this.btnElectricFenceEraseTone.Location = new System.Drawing.Point(339, 51);
            this.btnElectricFenceEraseTone.Name = "btnElectricFenceEraseTone";
            this.btnElectricFenceEraseTone.Size = new System.Drawing.Size(113, 25);
            this.btnElectricFenceEraseTone.TabIndex = 3;
            this.btnElectricFenceEraseTone.Text = "Erase Tone";
            this.btnElectricFenceEraseTone.UseVisualStyleBackColor = true;
            this.btnElectricFenceEraseTone.Click += new System.EventHandler(this.btnElectricFenceEraseTone_Click);
            // 
            // buttonElectricFenceWavFileUpload
            // 
            this.buttonElectricFenceWavFileUpload.Location = new System.Drawing.Point(209, 51);
            this.buttonElectricFenceWavFileUpload.Margin = new System.Windows.Forms.Padding(2);
            this.buttonElectricFenceWavFileUpload.Name = "buttonElectricFenceWavFileUpload";
            this.buttonElectricFenceWavFileUpload.Size = new System.Drawing.Size(125, 25);
            this.buttonElectricFenceWavFileUpload.TabIndex = 2;
            this.buttonElectricFenceWavFileUpload.Text = "Upload To Scanner";
            this.buttonElectricFenceWavFileUpload.UseVisualStyleBackColor = true;
            this.buttonElectricFenceWavFileUpload.Click += new System.EventHandler(this.btnElectricFenceWavFileUpload_Click);
            // 
            // txtElectricFenceWaveFile
            // 
            this.txtElectricFenceWaveFile.Location = new System.Drawing.Point(8, 24);
            this.txtElectricFenceWaveFile.Margin = new System.Windows.Forms.Padding(2);
            this.txtElectricFenceWaveFile.Name = "txtElectricFenceWaveFile";
            this.txtElectricFenceWaveFile.Size = new System.Drawing.Size(354, 20);
            this.txtElectricFenceWaveFile.TabIndex = 0;
            this.txtElectricFenceWaveFile.TextChanged += new System.EventHandler(this.txtElectricFenceWaveFile_TextChanged);
            // 
            // buttonElectricFenceWavFileBrowse
            // 
            this.buttonElectricFenceWavFileBrowse.Location = new System.Drawing.Point(375, 20);
            this.buttonElectricFenceWavFileBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.buttonElectricFenceWavFileBrowse.Name = "buttonElectricFenceWavFileBrowse";
            this.buttonElectricFenceWavFileBrowse.Size = new System.Drawing.Size(77, 26);
            this.buttonElectricFenceWavFileBrowse.TabIndex = 1;
            this.buttonElectricFenceWavFileBrowse.Text = "Browse";
            this.buttonElectricFenceWavFileBrowse.UseVisualStyleBackColor = true;
            this.buttonElectricFenceWavFileBrowse.Click += new System.EventHandler(this.btnElectricFenceWavFileBrowse_Click);
            // 
            // tabRta
            // 
            this.tabRta.Controls.Add(this.btnClean);
            this.tabRta.Controls.Add(this.btnGetRTAEventStatus);
            this.tabRta.Controls.Add(this.btnSetRTAEventStatus);
            this.tabRta.Controls.Add(this.btnRegisterRTAEvents);
            this.tabRta.Controls.Add(this.btnGetRegRTAEvents);
            this.tabRta.Controls.Add(this.btnGetSuppRTAEvents);
            this.tabRta.Controls.Add(this.grpRTAEventLog);
            this.tabRta.Controls.Add(this.grpRTAConfig);
            this.tabRta.Location = new System.Drawing.Point(4, 22);
            this.tabRta.Name = "tabRta";
            this.tabRta.Size = new System.Drawing.Size(1171, 686);
            this.tabRta.TabIndex = 12;
            this.tabRta.Text = "RTA";
            this.tabRta.UseVisualStyleBackColor = true;
            this.tabRta.Click += new System.EventHandler(this.tabRta_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(359, 250);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(134, 23);
            this.btnClean.TabIndex = 8;
            this.btnClean.Text = "Clear All";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnGetRTAEventStatus
            // 
            this.btnGetRTAEventStatus.Location = new System.Drawing.Point(191, 250);
            this.btnGetRTAEventStatus.Name = "btnGetRTAEventStatus";
            this.btnGetRTAEventStatus.Size = new System.Drawing.Size(161, 23);
            this.btnGetRTAEventStatus.TabIndex = 7;
            this.btnGetRTAEventStatus.Text = "Get RTA Event Status";
            this.btnGetRTAEventStatus.UseVisualStyleBackColor = true;
            this.btnGetRTAEventStatus.Click += new System.EventHandler(this.btnGetRTAEventStatus_Click);
            // 
            // btnSetRTAEventStatus
            // 
            this.btnSetRTAEventStatus.Location = new System.Drawing.Point(16, 250);
            this.btnSetRTAEventStatus.Name = "btnSetRTAEventStatus";
            this.btnSetRTAEventStatus.Size = new System.Drawing.Size(168, 23);
            this.btnSetRTAEventStatus.TabIndex = 6;
            this.btnSetRTAEventStatus.Text = "Set RTA Event Status";
            this.btnSetRTAEventStatus.UseVisualStyleBackColor = true;
            this.btnSetRTAEventStatus.Click += new System.EventHandler(this.btnSetRTAEventStatus_Click);
            // 
            // btnRegisterRTAEvents
            // 
            this.btnRegisterRTAEvents.Location = new System.Drawing.Point(359, 219);
            this.btnRegisterRTAEvents.Name = "btnRegisterRTAEvents";
            this.btnRegisterRTAEvents.Size = new System.Drawing.Size(134, 23);
            this.btnRegisterRTAEvents.TabIndex = 5;
            this.btnRegisterRTAEvents.Text = "Register RTA Events";
            this.btnRegisterRTAEvents.UseVisualStyleBackColor = true;
            this.btnRegisterRTAEvents.Click += new System.EventHandler(this.btnRegisterRTAEvents_Click);
            // 
            // btnGetRegRTAEvents
            // 
            this.btnGetRegRTAEvents.Location = new System.Drawing.Point(191, 220);
            this.btnGetRegRTAEvents.Name = "btnGetRegRTAEvents";
            this.btnGetRegRTAEvents.Size = new System.Drawing.Size(161, 23);
            this.btnGetRegRTAEvents.TabIndex = 4;
            this.btnGetRegRTAEvents.Text = "Get Registered RTA Events";
            this.btnGetRegRTAEvents.UseVisualStyleBackColor = true;
            this.btnGetRegRTAEvents.Click += new System.EventHandler(this.btnGetRegRTAEvents_Click);
            // 
            // btnGetSuppRTAEvents
            // 
            this.btnGetSuppRTAEvents.Location = new System.Drawing.Point(16, 220);
            this.btnGetSuppRTAEvents.Name = "btnGetSuppRTAEvents";
            this.btnGetSuppRTAEvents.Size = new System.Drawing.Size(168, 23);
            this.btnGetSuppRTAEvents.TabIndex = 3;
            this.btnGetSuppRTAEvents.Text = "Get Supported RTA Events";
            this.btnGetSuppRTAEvents.UseVisualStyleBackColor = true;
            this.btnGetSuppRTAEvents.Click += new System.EventHandler(this.btnGetSuppRTAEvents_Click);
            // 
            // grpRTAEventLog
            // 
            this.grpRTAEventLog.Controls.Add(this.lblRTAState);
            this.grpRTAEventLog.Controls.Add(this.btnGetRTAState);
            this.grpRTAEventLog.Controls.Add(this.btnCleanEvents);
            this.grpRTAEventLog.Controls.Add(this.dgRtaEventResponse);
            this.grpRTAEventLog.Location = new System.Drawing.Point(10, 280);
            this.grpRTAEventLog.Name = "grpRTAEventLog";
            this.grpRTAEventLog.Size = new System.Drawing.Size(491, 181);
            this.grpRTAEventLog.TabIndex = 2;
            this.grpRTAEventLog.TabStop = false;
            this.grpRTAEventLog.Text = "RTA Event Log";
            this.grpRTAEventLog.Enter += new System.EventHandler(this.grpRTAEventLog_Enter);
            // 
            // lblRTAState
            // 
            this.lblRTAState.AutoSize = true;
            this.lblRTAState.Location = new System.Drawing.Point(120, 158);
            this.lblRTAState.Name = "lblRTAState";
            this.lblRTAState.Size = new System.Drawing.Size(57, 13);
            this.lblRTAState.TabIndex = 3;
            this.lblRTAState.Text = "RTA State";
            this.lblRTAState.Visible = false;
            this.lblRTAState.Click += new System.EventHandler(this.lblRTAState_Click);
            // 
            // btnGetRTAState
            // 
            this.btnGetRTAState.Location = new System.Drawing.Point(10, 153);
            this.btnGetRTAState.Name = "btnGetRTAState";
            this.btnGetRTAState.Size = new System.Drawing.Size(104, 23);
            this.btnGetRTAState.TabIndex = 2;
            this.btnGetRTAState.Text = "Get RTA State";
            this.btnGetRTAState.UseVisualStyleBackColor = true;
            this.btnGetRTAState.Click += new System.EventHandler(this.btnGetRTAState_Click);
            // 
            // btnCleanEvents
            // 
            this.btnCleanEvents.Location = new System.Drawing.Point(349, 153);
            this.btnCleanEvents.Name = "btnCleanEvents";
            this.btnCleanEvents.Size = new System.Drawing.Size(134, 23);
            this.btnCleanEvents.TabIndex = 1;
            this.btnCleanEvents.Text = "Clear All";
            this.btnCleanEvents.UseVisualStyleBackColor = true;
            this.btnCleanEvents.Click += new System.EventHandler(this.btnCleanEvents_Click);
            // 
            // dgRtaEventResponse
            // 
            this.dgRtaEventResponse.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgRtaEventResponse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRtaEventResponse.Location = new System.Drawing.Point(10, 16);
            this.dgRtaEventResponse.Name = "dgRtaEventResponse";
            this.dgRtaEventResponse.Size = new System.Drawing.Size(473, 131);
            this.dgRtaEventResponse.TabIndex = 0;
            this.dgRtaEventResponse.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRtaEventResponse_CellContentClick);
            this.dgRtaEventResponse.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgRtaEventResponse_CellFormatting);
            // 
            // grpRTAConfig
            // 
            this.grpRTAConfig.Controls.Add(this.cbSuspend);
            this.grpRTAConfig.Controls.Add(this.dgRtaView);
            this.grpRTAConfig.Location = new System.Drawing.Point(10, 15);
            this.grpRTAConfig.Name = "grpRTAConfig";
            this.grpRTAConfig.Size = new System.Drawing.Size(489, 198);
            this.grpRTAConfig.TabIndex = 1;
            this.grpRTAConfig.TabStop = false;
            this.grpRTAConfig.Text = "RTA Configuration Settings";
            this.grpRTAConfig.Enter += new System.EventHandler(this.grpRTAConfig_Enter);
            // 
            // cbSuspend
            // 
            this.cbSuspend.AutoSize = true;
            this.cbSuspend.Location = new System.Drawing.Point(340, 13);
            this.cbSuspend.Name = "cbSuspend";
            this.cbSuspend.Size = new System.Drawing.Size(146, 17);
            this.cbSuspend.TabIndex = 2;
            this.cbSuspend.Text = "Suspend Reporting Alerts";
            this.cbSuspend.UseVisualStyleBackColor = true;
            this.cbSuspend.CheckedChanged += new System.EventHandler(this.cbSuspend_CheckedChanged);
            // 
            // dgRtaView
            // 
            this.dgRtaView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgRtaView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRtaView.Location = new System.Drawing.Point(10, 34);
            this.dgRtaView.Name = "dgRtaView";
            this.dgRtaView.Size = new System.Drawing.Size(473, 156);
            this.dgRtaView.TabIndex = 1;
            this.dgRtaView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRtaView_CellContentClick);
            this.dgRtaView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgRtaView_CellFormatting);
            this.dgRtaView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgRtaView_CellValidating);
            // 
            // tabScan2Connect
            // 
            this.tabScan2Connect.Controls.Add(this.grpScan2Connect);
            this.tabScan2Connect.Location = new System.Drawing.Point(4, 22);
            this.tabScan2Connect.Name = "tabScan2Connect";
            this.tabScan2Connect.Size = new System.Drawing.Size(1171, 686);
            this.tabScan2Connect.TabIndex = 10;
            this.tabScan2Connect.Text = "ScanToConnect";
            this.tabScan2Connect.UseVisualStyleBackColor = true;
            this.tabScan2Connect.Click += new System.EventHandler(this.tabScan2Connect_Click);
            // 
            // grpScan2Connect
            // 
            this.grpScan2Connect.Controls.Add(this.btnSaveBarcode);
            this.grpScan2Connect.Controls.Add(this.label13);
            this.grpScan2Connect.Controls.Add(this.cmbHostName);
            this.grpScan2Connect.Controls.Add(this.label12);
            this.grpScan2Connect.Controls.Add(this.label11);
            this.grpScan2Connect.Controls.Add(this.cmbScannerType);
            this.grpScan2Connect.Controls.Add(this.label10);
            this.grpScan2Connect.Controls.Add(this.label9);
            this.grpScan2Connect.Controls.Add(this.label8);
            this.grpScan2Connect.Controls.Add(this.picBBarcode);
            this.grpScan2Connect.Controls.Add(this.cmbImageSize);
            this.grpScan2Connect.Controls.Add(this.cmbDefaultOption);
            this.grpScan2Connect.Controls.Add(this.cmbProtocol);
            this.grpScan2Connect.Location = new System.Drawing.Point(3, 15);
            this.grpScan2Connect.Name = "grpScan2Connect";
            this.grpScan2Connect.Size = new System.Drawing.Size(505, 450);
            this.grpScan2Connect.TabIndex = 4;
            this.grpScan2Connect.TabStop = false;
            this.grpScan2Connect.Text = "ScanToConnect Barcode";
            this.grpScan2Connect.Enter += new System.EventHandler(this.grpScan2Connect_Enter);
            // 
            // btnSaveBarcode
            // 
            this.btnSaveBarcode.Location = new System.Drawing.Point(384, 274);
            this.btnSaveBarcode.Name = "btnSaveBarcode";
            this.btnSaveBarcode.Size = new System.Drawing.Size(104, 23);
            this.btnSaveBarcode.TabIndex = 21;
            this.btnSaveBarcode.Text = "Save Barcode";
            this.btnSaveBarcode.UseVisualStyleBackColor = true;
            this.btnSaveBarcode.Click += new System.EventHandler(this.btnSaveBarcode_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 122);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Host Name";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // cmbHostName
            // 
            this.cmbHostName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHostName.FormattingEnabled = true;
            this.cmbHostName.Items.AddRange(new object[] {
            "SSI BT Classic (Non-Discoverable)"});
            this.cmbHostName.Location = new System.Drawing.Point(98, 119);
            this.cmbHostName.Name = "cmbHostName";
            this.cmbHostName.Size = new System.Drawing.Size(167, 21);
            this.cmbHostName.TabIndex = 19;
            this.cmbHostName.SelectedIndexChanged += new System.EventHandler(this.cmbHostName_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 274);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Received Barcode:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Scanner Type";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // cmbScannerType
            // 
            this.cmbScannerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScannerType.FormattingEnabled = true;
            this.cmbScannerType.Items.AddRange(new object[] {
            "Legacy",
            "New"});
            this.cmbScannerType.Location = new System.Drawing.Point(98, 27);
            this.cmbScannerType.Name = "cmbScannerType";
            this.cmbScannerType.Size = new System.Drawing.Size(167, 21);
            this.cmbScannerType.TabIndex = 15;
            this.cmbScannerType.SelectedIndexChanged += new System.EventHandler(this.cmbScannerType_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 214);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Image Size";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Default Option";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Protocol Name";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // picBBarcode
            // 
            this.picBBarcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picBBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBBarcode.Location = new System.Drawing.Point(6, 305);
            this.picBBarcode.Name = "picBBarcode";
            this.picBBarcode.Size = new System.Drawing.Size(493, 135);
            this.picBBarcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBBarcode.TabIndex = 10;
            this.picBBarcode.TabStop = false;
            this.picBBarcode.Click += new System.EventHandler(this.picBBarcode_Click);
            // 
            // cmbImageSize
            // 
            this.cmbImageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImageSize.FormattingEnabled = true;
            this.cmbImageSize.Items.AddRange(new object[] {
            "Small",
            "Medium",
            "Large"});
            this.cmbImageSize.Location = new System.Drawing.Point(98, 211);
            this.cmbImageSize.Name = "cmbImageSize";
            this.cmbImageSize.Size = new System.Drawing.Size(76, 21);
            this.cmbImageSize.TabIndex = 9;
            this.cmbImageSize.SelectedIndexChanged += new System.EventHandler(this.cmbImageSize_SelectedIndexChanged);
            // 
            // cmbDefaultOption
            // 
            this.cmbDefaultOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefaultOption.FormattingEnabled = true;
            this.cmbDefaultOption.Items.AddRange(new object[] {
            "No Defaults",
            "Set Factory Defaults",
            "Restore Factory Defaults"});
            this.cmbDefaultOption.Location = new System.Drawing.Point(98, 165);
            this.cmbDefaultOption.Name = "cmbDefaultOption";
            this.cmbDefaultOption.Size = new System.Drawing.Size(167, 21);
            this.cmbDefaultOption.TabIndex = 2;
            this.cmbDefaultOption.SelectedIndexChanged += new System.EventHandler(this.cmbDefaultOption_SelectedIndexChanged);
            // 
            // cmbProtocol
            // 
            this.cmbProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProtocol.FormattingEnabled = true;
            this.cmbProtocol.Items.AddRange(new object[] {
            "Simple Serial Interface (SSI)",
            "Serial Port Profile (SPP)",
            "Human Interface Device (HID)"});
            this.cmbProtocol.Location = new System.Drawing.Point(98, 73);
            this.cmbProtocol.Name = "cmbProtocol";
            this.cmbProtocol.Size = new System.Drawing.Size(190, 21);
            this.cmbProtocol.TabIndex = 1;
            this.cmbProtocol.SelectedIndexChanged += new System.EventHandler(this.cmbProtocol_SelectedIndexChanged);
            // 
            // tabMisc
            // 
            this.tabMisc.Controls.Add(this.grpMiscOther);
            this.tabMisc.Location = new System.Drawing.Point(4, 22);
            this.tabMisc.Name = "tabMisc";
            this.tabMisc.Size = new System.Drawing.Size(1171, 686);
            this.tabMisc.TabIndex = 4;
            this.tabMisc.Text = "Miscellaneous";
            this.tabMisc.UseVisualStyleBackColor = true;
            this.tabMisc.Click += new System.EventHandler(this.tabMisc_Click);
            // 
            // grpMiscOther
            // 
            this.grpMiscOther.Controls.Add(this.grpSCdcSwitch);
            this.grpMiscOther.Controls.Add(this.grpMiscCmd);
            this.grpMiscOther.Controls.Add(this.grpAsync);
            this.grpMiscOther.Location = new System.Drawing.Point(3, 3);
            this.grpMiscOther.Name = "grpMiscOther";
            this.grpMiscOther.Size = new System.Drawing.Size(500, 459);
            this.grpMiscOther.TabIndex = 28;
            this.grpMiscOther.TabStop = false;
            this.grpMiscOther.Text = "Miscellaneous";
            this.grpMiscOther.Enter += new System.EventHandler(this.grpMiscOther_Enter);
            // 
            // grpSCdcSwitch
            // 
            this.grpSCdcSwitch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpSCdcSwitch.Controls.Add(this.btnSCdcSwitchDevices);
            this.grpSCdcSwitch.Controls.Add(this.chkSCdcSIsPermanent);
            this.grpSCdcSwitch.Controls.Add(this.chkSCdcSIsSilent);
            this.grpSCdcSwitch.Controls.Add(this.cmbSCdcSHostMode);
            this.grpSCdcSwitch.Controls.Add(this.lblSCdcSHostMode);
            this.grpSCdcSwitch.Location = new System.Drawing.Point(10, 109);
            this.grpSCdcSwitch.Margin = new System.Windows.Forms.Padding(2);
            this.grpSCdcSwitch.Name = "grpSCdcSwitch";
            this.grpSCdcSwitch.Padding = new System.Windows.Forms.Padding(2);
            this.grpSCdcSwitch.Size = new System.Drawing.Size(485, 101);
            this.grpSCdcSwitch.TabIndex = 4;
            this.grpSCdcSwitch.TabStop = false;
            this.grpSCdcSwitch.Text = "CDC Switching";
            this.grpSCdcSwitch.Enter += new System.EventHandler(this.grpSCdcSwitch_Enter);
            // 
            // btnSCdcSwitchDevices
            // 
            this.btnSCdcSwitchDevices.Location = new System.Drawing.Point(266, 62);
            this.btnSCdcSwitchDevices.Name = "btnSCdcSwitchDevices";
            this.btnSCdcSwitchDevices.Size = new System.Drawing.Size(120, 23);
            this.btnSCdcSwitchDevices.TabIndex = 4;
            this.btnSCdcSwitchDevices.Text = "Switch CDC Devices";
            this.btnSCdcSwitchDevices.UseVisualStyleBackColor = true;
            this.btnSCdcSwitchDevices.Click += new System.EventHandler(this.btnSCdcSwitchDevices_Click);
            // 
            // chkSCdcSIsPermanent
            // 
            this.chkSCdcSIsPermanent.AutoSize = true;
            this.chkSCdcSIsPermanent.Location = new System.Drawing.Point(340, 29);
            this.chkSCdcSIsPermanent.Margin = new System.Windows.Forms.Padding(2);
            this.chkSCdcSIsPermanent.Name = "chkSCdcSIsPermanent";
            this.chkSCdcSIsPermanent.Size = new System.Drawing.Size(88, 17);
            this.chkSCdcSIsPermanent.TabIndex = 3;
            this.chkSCdcSIsPermanent.Text = "Is Permanent";
            this.chkSCdcSIsPermanent.UseVisualStyleBackColor = true;
            this.chkSCdcSIsPermanent.CheckedChanged += new System.EventHandler(this.chkSCdcSIsPermanent_CheckedChanged);
            // 
            // chkSCdcSIsSilent
            // 
            this.chkSCdcSIsSilent.AutoSize = true;
            this.chkSCdcSIsSilent.Location = new System.Drawing.Point(266, 28);
            this.chkSCdcSIsSilent.Margin = new System.Windows.Forms.Padding(2);
            this.chkSCdcSIsSilent.Name = "chkSCdcSIsSilent";
            this.chkSCdcSIsSilent.Size = new System.Drawing.Size(63, 17);
            this.chkSCdcSIsSilent.TabIndex = 2;
            this.chkSCdcSIsSilent.Text = "Is Silent";
            this.chkSCdcSIsSilent.UseVisualStyleBackColor = true;
            this.chkSCdcSIsSilent.CheckedChanged += new System.EventHandler(this.chkSCdcSIsSilent_CheckedChanged);
            // 
            // cmbSCdcSHostMode
            // 
            this.cmbSCdcSHostMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSCdcSHostMode.FormattingEnabled = true;
            this.cmbSCdcSHostMode.Location = new System.Drawing.Point(75, 27);
            this.cmbSCdcSHostMode.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSCdcSHostMode.Name = "cmbSCdcSHostMode";
            this.cmbSCdcSHostMode.Size = new System.Drawing.Size(143, 21);
            this.cmbSCdcSHostMode.TabIndex = 1;
            this.cmbSCdcSHostMode.SelectedIndexChanged += new System.EventHandler(this.cmbSCdcSHostMode_SelectedIndexChanged);
            // 
            // lblSCdcSHostMode
            // 
            this.lblSCdcSHostMode.AutoSize = true;
            this.lblSCdcSHostMode.Location = new System.Drawing.Point(6, 29);
            this.lblSCdcSHostMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSCdcSHostMode.Name = "lblSCdcSHostMode";
            this.lblSCdcSHostMode.Size = new System.Drawing.Size(62, 13);
            this.lblSCdcSHostMode.TabIndex = 0;
            this.lblSCdcSHostMode.Text = "Host Mode ";
            this.lblSCdcSHostMode.Click += new System.EventHandler(this.lblSCdcSHostMode_Click);
            // 
            // grpMiscCmd
            // 
            this.grpMiscCmd.BackColor = System.Drawing.SystemColors.Window;
            this.grpMiscCmd.Controls.Add(this.btnGetDevTopology);
            this.grpMiscCmd.Controls.Add(this.btnSdkVersion);
            this.grpMiscCmd.Location = new System.Drawing.Point(10, 26);
            this.grpMiscCmd.Name = "grpMiscCmd";
            this.grpMiscCmd.Size = new System.Drawing.Size(280, 66);
            this.grpMiscCmd.TabIndex = 0;
            this.grpMiscCmd.TabStop = false;
            this.grpMiscCmd.Text = "Miscellaneous Commands";
            this.grpMiscCmd.Enter += new System.EventHandler(this.grpMiscCmd_Enter);
            // 
            // btnGetDevTopology
            // 
            this.btnGetDevTopology.Location = new System.Drawing.Point(143, 26);
            this.btnGetDevTopology.Name = "btnGetDevTopology";
            this.btnGetDevTopology.Size = new System.Drawing.Size(119, 23);
            this.btnGetDevTopology.TabIndex = 1;
            this.btnGetDevTopology.Text = "Get Device Topology";
            this.btnGetDevTopology.UseVisualStyleBackColor = true;
            this.btnGetDevTopology.Click += new System.EventHandler(this.btnGetDevTopology_Click);
            // 
            // btnSdkVersion
            // 
            this.btnSdkVersion.Location = new System.Drawing.Point(19, 26);
            this.btnSdkVersion.Name = "btnSdkVersion";
            this.btnSdkVersion.Size = new System.Drawing.Size(118, 23);
            this.btnSdkVersion.TabIndex = 0;
            this.btnSdkVersion.Text = "CoreScanner Version";
            this.btnSdkVersion.UseVisualStyleBackColor = true;
            this.btnSdkVersion.Click += new System.EventHandler(this.btnSdkVersion_Click);
            // 
            // grpAsync
            // 
            this.grpAsync.BackColor = System.Drawing.SystemColors.Window;
            this.grpAsync.Controls.Add(this.chkAsync);
            this.grpAsync.Location = new System.Drawing.Point(326, 25);
            this.grpAsync.Name = "grpAsync";
            this.grpAsync.Size = new System.Drawing.Size(150, 63);
            this.grpAsync.TabIndex = 1;
            this.grpAsync.TabStop = false;
            this.grpAsync.Text = "Command Mode";
            this.grpAsync.Enter += new System.EventHandler(this.grpAsync_Enter);
            // 
            // chkAsync
            // 
            this.chkAsync.AutoSize = true;
            this.chkAsync.Location = new System.Drawing.Point(19, 19);
            this.chkAsync.Name = "chkAsync";
            this.chkAsync.Size = new System.Drawing.Size(93, 17);
            this.chkAsync.TabIndex = 0;
            this.chkAsync.Text = "Asynchronous";
            this.chkAsync.UseVisualStyleBackColor = true;
            this.chkAsync.CheckedChanged += new System.EventHandler(this.chkAsync_CheckedChanged);
            // 
            // tabScale
            // 
            this.tabScale.Controls.Add(this.grpScale);
            this.tabScale.Location = new System.Drawing.Point(4, 22);
            this.tabScale.Name = "tabScale";
            this.tabScale.Padding = new System.Windows.Forms.Padding(3);
            this.tabScale.Size = new System.Drawing.Size(1171, 686);
            this.tabScale.TabIndex = 8;
            this.tabScale.Text = "Scale";
            this.tabScale.UseVisualStyleBackColor = true;
            this.tabScale.Click += new System.EventHandler(this.tabScale_Click);
            // 
            // grpScale
            // 
            this.grpScale.Controls.Add(this.lblScalStatusDesc);
            this.grpScale.Controls.Add(this.txtWeightUnit);
            this.grpScale.Controls.Add(this.txtWeight);
            this.grpScale.Controls.Add(this.label2);
            this.grpScale.Controls.Add(this.label1);
            this.grpScale.Controls.Add(this.btnSystemRest);
            this.grpScale.Controls.Add(this.btnZeroScale);
            this.grpScale.Controls.Add(this.btnReadWeight);
            this.grpScale.Location = new System.Drawing.Point(6, 6);
            this.grpScale.Name = "grpScale";
            this.grpScale.Size = new System.Drawing.Size(493, 456);
            this.grpScale.TabIndex = 20;
            this.grpScale.TabStop = false;
            this.grpScale.Enter += new System.EventHandler(this.grpScale_Enter);
            // 
            // lblScalStatusDesc
            // 
            this.lblScalStatusDesc.AutoSize = true;
            this.lblScalStatusDesc.Location = new System.Drawing.Point(91, 216);
            this.lblScalStatusDesc.Name = "lblScalStatusDesc";
            this.lblScalStatusDesc.Size = new System.Drawing.Size(0, 13);
            this.lblScalStatusDesc.TabIndex = 21;
            this.lblScalStatusDesc.Click += new System.EventHandler(this.lblScalStatusDesc_Click);
            // 
            // txtWeightUnit
            // 
            this.txtWeightUnit.Location = new System.Drawing.Point(293, 144);
            this.txtWeightUnit.Name = "txtWeightUnit";
            this.txtWeightUnit.ReadOnly = true;
            this.txtWeightUnit.Size = new System.Drawing.Size(100, 20);
            this.txtWeightUnit.TabIndex = 4;
            this.txtWeightUnit.TextChanged += new System.EventHandler(this.txtWeightUnit_TextChanged);
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(94, 144);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.ReadOnly = true;
            this.txtWeight.Size = new System.Drawing.Size(100, 20);
            this.txtWeight.TabIndex = 3;
            this.txtWeight.TextChanged += new System.EventHandler(this.txtWeight_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Weight Unit";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Weight Measured";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSystemRest
            // 
            this.btnSystemRest.Location = new System.Drawing.Point(321, 24);
            this.btnSystemRest.Name = "btnSystemRest";
            this.btnSystemRest.Size = new System.Drawing.Size(128, 23);
            this.btnSystemRest.TabIndex = 2;
            this.btnSystemRest.Text = "Reset Scale";
            this.btnSystemRest.UseVisualStyleBackColor = true;
            this.btnSystemRest.Click += new System.EventHandler(this.btnSystemRest_Click);
            // 
            // btnZeroScale
            // 
            this.btnZeroScale.Location = new System.Drawing.Point(167, 24);
            this.btnZeroScale.Name = "btnZeroScale";
            this.btnZeroScale.Size = new System.Drawing.Size(128, 23);
            this.btnZeroScale.TabIndex = 1;
            this.btnZeroScale.Text = "Zero scale";
            this.btnZeroScale.UseVisualStyleBackColor = true;
            this.btnZeroScale.Click += new System.EventHandler(this.btnZeroScale_Click);
            // 
            // btnReadWeight
            // 
            this.btnReadWeight.Location = new System.Drawing.Point(17, 24);
            this.btnReadWeight.Name = "btnReadWeight";
            this.btnReadWeight.Size = new System.Drawing.Size(128, 23);
            this.btnReadWeight.TabIndex = 0;
            this.btnReadWeight.Text = "Read weight";
            this.btnReadWeight.UseVisualStyleBackColor = true;
            this.btnReadWeight.Click += new System.EventHandler(this.btnReadWeight_Click);
            // 
            // tabSSW
            // 
            this.tabSSW.Controls.Add(this.btnClear);
            this.tabSSW.Controls.Add(this.txtEpcId);
            this.tabSSW.Controls.Add(this.label14);
            this.tabSSW.Controls.Add(this.rdoHex);
            this.tabSSW.Controls.Add(this.rdoASCII);
            this.tabSSW.Controls.Add(this.btnVerifyTag);
            this.tabSSW.Controls.Add(this.label7);
            this.tabSSW.Controls.Add(this.btnWriteTag);
            this.tabSSW.Controls.Add(this.cmbPartition);
            this.tabSSW.Controls.Add(this.cmbFilterValue);
            this.tabSSW.Controls.Add(this.statusIcon);
            this.tabSSW.Controls.Add(this.label21);
            this.tabSSW.Controls.Add(this.label22);
            this.tabSSW.Controls.Add(this.chkAutoIncrement);
            this.tabSSW.Controls.Add(this.txtSerialNumber);
            this.tabSSW.Controls.Add(this.txtUserBank);
            this.tabSSW.Controls.Add(this.txtNewEpcId);
            this.tabSSW.Controls.Add(this.lblUserBank);
            this.tabSSW.Controls.Add(this.txtUpcaBarcode);
            this.tabSSW.Controls.Add(this.label25);
            this.tabSSW.Controls.Add(this.label23);
            this.tabSSW.Location = new System.Drawing.Point(4, 22);
            this.tabSSW.Margin = new System.Windows.Forms.Padding(2);
            this.tabSSW.Name = "tabSSW";
            this.tabSSW.Size = new System.Drawing.Size(1171, 686);
            this.tabSSW.TabIndex = 11;
            this.tabSSW.Text = "Scan Scan Write";
            this.tabSSW.UseVisualStyleBackColor = true;
            this.tabSSW.Click += new System.EventHandler(this.tabSSW_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(237, 103);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 24);
            this.btnClear.TabIndex = 35;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtEpcId
            // 
            this.txtEpcId.BackColor = System.Drawing.Color.White;
            this.txtEpcId.Location = new System.Drawing.Point(94, 53);
            this.txtEpcId.Margin = new System.Windows.Forms.Padding(2);
            this.txtEpcId.Name = "txtEpcId";
            this.txtEpcId.ReadOnly = true;
            this.txtEpcId.Size = new System.Drawing.Size(193, 20);
            this.txtEpcId.TabIndex = 33;
            this.txtEpcId.TextChanged += new System.EventHandler(this.txtEpcId_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 54);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Existing EPC Id";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // rdoHex
            // 
            this.rdoHex.AutoSize = true;
            this.rdoHex.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rdoHex.Location = new System.Drawing.Point(152, 233);
            this.rdoHex.Margin = new System.Windows.Forms.Padding(2);
            this.rdoHex.Name = "rdoHex";
            this.rdoHex.Size = new System.Drawing.Size(44, 17);
            this.rdoHex.TabIndex = 32;
            this.rdoHex.TabStop = true;
            this.rdoHex.Text = "Hex";
            this.rdoHex.UseVisualStyleBackColor = true;
            this.rdoHex.CheckedChanged += new System.EventHandler(this.rdoASCII_Binary_CheckedChanged);
            // 
            // rdoASCII
            // 
            this.rdoASCII.AutoSize = true;
            this.rdoASCII.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rdoASCII.Location = new System.Drawing.Point(95, 232);
            this.rdoASCII.Margin = new System.Windows.Forms.Padding(2);
            this.rdoASCII.Name = "rdoASCII";
            this.rdoASCII.Size = new System.Drawing.Size(52, 17);
            this.rdoASCII.TabIndex = 31;
            this.rdoASCII.TabStop = true;
            this.rdoASCII.Text = "ASCII";
            this.rdoASCII.UseVisualStyleBackColor = true;
            this.rdoASCII.CheckedChanged += new System.EventHandler(this.rdoASCII_Binary_CheckedChanged);
            // 
            // btnVerifyTag
            // 
            this.btnVerifyTag.Location = new System.Drawing.Point(160, 103);
            this.btnVerifyTag.Margin = new System.Windows.Forms.Padding(2);
            this.btnVerifyTag.Name = "btnVerifyTag";
            this.btnVerifyTag.Size = new System.Drawing.Size(72, 24);
            this.btnVerifyTag.TabIndex = 30;
            this.btnVerifyTag.Text = "Verify Tag";
            this.btnVerifyTag.UseVisualStyleBackColor = true;
            this.btnVerifyTag.Click += new System.EventHandler(this.btnVerifyTag_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(332, 83);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Serial Number";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btnWriteTag
            // 
            this.btnWriteTag.Location = new System.Drawing.Point(94, 103);
            this.btnWriteTag.Margin = new System.Windows.Forms.Padding(2);
            this.btnWriteTag.Name = "btnWriteTag";
            this.btnWriteTag.Size = new System.Drawing.Size(63, 24);
            this.btnWriteTag.TabIndex = 27;
            this.btnWriteTag.Text = "Write Tag";
            this.btnWriteTag.UseVisualStyleBackColor = true;
            this.btnWriteTag.Click += new System.EventHandler(this.btnWriteTag_Click);
            // 
            // cmbPartition
            // 
            this.cmbPartition.FormattingEnabled = true;
            this.cmbPartition.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cmbPartition.Location = new System.Drawing.Point(408, 52);
            this.cmbPartition.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPartition.Name = "cmbPartition";
            this.cmbPartition.Size = new System.Drawing.Size(92, 21);
            this.cmbPartition.TabIndex = 25;
            this.cmbPartition.SelectedIndexChanged += new System.EventHandler(this.cmbPartition_SelectedIndexChanged);
            // 
            // cmbFilterValue
            // 
            this.cmbFilterValue.FormattingEnabled = true;
            this.cmbFilterValue.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cmbFilterValue.Location = new System.Drawing.Point(408, 24);
            this.cmbFilterValue.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFilterValue.Name = "cmbFilterValue";
            this.cmbFilterValue.Size = new System.Drawing.Size(92, 21);
            this.cmbFilterValue.TabIndex = 24;
            this.cmbFilterValue.SelectedIndexChanged += new System.EventHandler(this.cmbFilterValue_SelectedIndexChanged);
            // 
            // statusIcon
            // 
            this.statusIcon.ErrorImage = null;
            this.statusIcon.InitialImage = null;
            this.statusIcon.Location = new System.Drawing.Point(291, 80);
            this.statusIcon.Margin = new System.Windows.Forms.Padding(2);
            this.statusIcon.Name = "statusIcon";
            this.statusIcon.Size = new System.Drawing.Size(17, 19);
            this.statusIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.statusIcon.TabIndex = 23;
            this.statusIcon.TabStop = false;
            this.statusIcon.Click += new System.EventHandler(this.statusIcon_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(332, 55);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(45, 13);
            this.label21.TabIndex = 14;
            this.label21.Text = "Partition";
            this.label21.Click += new System.EventHandler(this.label21_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(332, 28);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 13);
            this.label22.TabIndex = 13;
            this.label22.Text = "Filter value";
            this.label22.Click += new System.EventHandler(this.label22_Click);
            // 
            // chkAutoIncrement
            // 
            this.chkAutoIncrement.AutoSize = true;
            this.chkAutoIncrement.Location = new System.Drawing.Point(408, 107);
            this.chkAutoIncrement.Margin = new System.Windows.Forms.Padding(2);
            this.chkAutoIncrement.Name = "chkAutoIncrement";
            this.chkAutoIncrement.Size = new System.Drawing.Size(97, 17);
            this.chkAutoIncrement.TabIndex = 8;
            this.chkAutoIncrement.Text = "Auto increment";
            this.toolTip1.SetToolTip(this.chkAutoIncrement, "Increment provided serial number and write tags continuously.");
            this.chkAutoIncrement.UseVisualStyleBackColor = true;
            this.chkAutoIncrement.CheckedChanged += new System.EventHandler(this.chkAutoIncrement_CheckedChanged);
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(408, 80);
            this.txtSerialNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(90, 20);
            this.txtSerialNumber.TabIndex = 7;
            this.txtSerialNumber.TextChanged += new System.EventHandler(this.txtSerialNumber_TextChanged);
            this.txtSerialNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerialNumber_KeyPress);
            // 
            // txtUserBank
            // 
            this.txtUserBank.BackColor = System.Drawing.Color.White;
            this.txtUserBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserBank.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserBank.Location = new System.Drawing.Point(94, 150);
            this.txtUserBank.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserBank.Multiline = true;
            this.txtUserBank.Name = "txtUserBank";
            this.txtUserBank.ReadOnly = true;
            this.txtUserBank.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUserBank.Size = new System.Drawing.Size(193, 81);
            this.txtUserBank.TabIndex = 9;
            this.txtUserBank.TextChanged += new System.EventHandler(this.txtUserBank_TextChanged);
            // 
            // txtNewEpcId
            // 
            this.txtNewEpcId.BackColor = System.Drawing.Color.White;
            this.txtNewEpcId.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNewEpcId.Location = new System.Drawing.Point(94, 80);
            this.txtNewEpcId.Margin = new System.Windows.Forms.Padding(2);
            this.txtNewEpcId.Name = "txtNewEpcId";
            this.txtNewEpcId.ReadOnly = true;
            this.txtNewEpcId.Size = new System.Drawing.Size(193, 20);
            this.txtNewEpcId.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtNewEpcId, "SGTIN 96 encoded");
            this.txtNewEpcId.TextChanged += new System.EventHandler(this.txtNewEpcId_TextChanged);
            // 
            // lblUserBank
            // 
            this.lblUserBank.AutoSize = true;
            this.lblUserBank.Location = new System.Drawing.Point(14, 150);
            this.lblUserBank.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserBank.Name = "lblUserBank";
            this.lblUserBank.Size = new System.Drawing.Size(56, 13);
            this.lblUserBank.TabIndex = 12;
            this.lblUserBank.Text = "User bank";
            this.lblUserBank.Click += new System.EventHandler(this.lblUserBank_Click);
            // 
            // txtUpcaBarcode
            // 
            this.txtUpcaBarcode.BackColor = System.Drawing.Color.White;
            this.txtUpcaBarcode.Location = new System.Drawing.Point(94, 25);
            this.txtUpcaBarcode.Margin = new System.Windows.Forms.Padding(2);
            this.txtUpcaBarcode.Name = "txtUpcaBarcode";
            this.txtUpcaBarcode.ReadOnly = true;
            this.txtUpcaBarcode.Size = new System.Drawing.Size(193, 20);
            this.txtUpcaBarcode.TabIndex = 0;
            this.txtUpcaBarcode.TextChanged += new System.EventHandler(this.txtUpcaBarcode_TextChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(14, 83);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 13);
            this.label25.TabIndex = 11;
            this.label25.Text = "New EPC Id";
            this.label25.Click += new System.EventHandler(this.label25_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(14, 28);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(74, 13);
            this.label23.TabIndex = 10;
            this.label23.Text = "Scan barcode";
            this.label23.Click += new System.EventHandler(this.label23_Click);
            // 
            // tabXml
            // 
            this.tabXml.Controls.Add(this.btnClearXmlArea);
            this.tabXml.Controls.Add(this.btnClearLogsArea);
            this.tabXml.Controls.Add(this.grpResult);
            this.tabXml.Controls.Add(this.grpOutXml);
            this.tabXml.Location = new System.Drawing.Point(4, 22);
            this.tabXml.Name = "tabXml";
            this.tabXml.Size = new System.Drawing.Size(1171, 686);
            this.tabXml.TabIndex = 7;
            this.tabXml.Text = "Logs";
            this.tabXml.UseVisualStyleBackColor = true;
            this.tabXml.Click += new System.EventHandler(this.tabXml_Click);
            // 
            // btnClearXmlArea
            // 
            this.btnClearXmlArea.Location = new System.Drawing.Point(306, 436);
            this.btnClearXmlArea.Name = "btnClearXmlArea";
            this.btnClearXmlArea.Size = new System.Drawing.Size(91, 23);
            this.btnClearXmlArea.TabIndex = 3;
            this.btnClearXmlArea.Text = "Clear XML Log";
            this.btnClearXmlArea.UseVisualStyleBackColor = true;
            this.btnClearXmlArea.Click += new System.EventHandler(this.btnClearXmlArea_Click);
            // 
            // btnClearLogsArea
            // 
            this.btnClearLogsArea.Location = new System.Drawing.Point(124, 436);
            this.btnClearLogsArea.Name = "btnClearLogsArea";
            this.btnClearLogsArea.Size = new System.Drawing.Size(96, 23);
            this.btnClearLogsArea.TabIndex = 2;
            this.btnClearLogsArea.Text = "Clear Event Log";
            this.btnClearLogsArea.UseVisualStyleBackColor = true;
            this.btnClearLogsArea.Click += new System.EventHandler(this.btnClearLogsArea_Click);
            // 
            // grpResult
            // 
            this.grpResult.BackColor = System.Drawing.SystemColors.Window;
            this.grpResult.Controls.Add(this.txtResults);
            this.grpResult.Location = new System.Drawing.Point(4, 3);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(490, 177);
            this.grpResult.TabIndex = 0;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "Event Log";
            this.grpResult.Enter += new System.EventHandler(this.grpResult_Enter);
            // 
            // txtResults
            // 
            this.txtResults.BackColor = System.Drawing.Color.White;
            this.txtResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResults.Location = new System.Drawing.Point(8, 19);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(476, 152);
            this.txtResults.TabIndex = 0;
            this.txtResults.TextChanged += new System.EventHandler(this.txtResults_TextChanged);
            // 
            // grpOutXml
            // 
            this.grpOutXml.BackColor = System.Drawing.SystemColors.Window;
            this.grpOutXml.Controls.Add(this.txtOutXml);
            this.grpOutXml.Location = new System.Drawing.Point(4, 186);
            this.grpOutXml.Name = "grpOutXml";
            this.grpOutXml.Size = new System.Drawing.Size(490, 244);
            this.grpOutXml.TabIndex = 1;
            this.grpOutXml.TabStop = false;
            this.grpOutXml.Text = "XML Log";
            this.grpOutXml.Enter += new System.EventHandler(this.grpOutXml_Enter);
            // 
            // txtOutXml
            // 
            this.txtOutXml.BackColor = System.Drawing.Color.White;
            this.txtOutXml.Location = new System.Drawing.Point(8, 16);
            this.txtOutXml.Multiline = true;
            this.txtOutXml.Name = "txtOutXml";
            this.txtOutXml.ReadOnly = true;
            this.txtOutXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutXml.Size = new System.Drawing.Size(476, 219);
            this.txtOutXml.TabIndex = 0;
            this.txtOutXml.TextChanged += new System.EventHandler(this.txtOutXml_TextChanged);
            // 
            // grpTrigger
            // 
            this.grpTrigger.Controls.Add(this.btnReleaseTrigger);
            this.grpTrigger.Controls.Add(this.btnPullTrigger);
            this.grpTrigger.Location = new System.Drawing.Point(8, 435);
            this.grpTrigger.Name = "grpTrigger";
            this.grpTrigger.Size = new System.Drawing.Size(446, 53);
            this.grpTrigger.TabIndex = 3;
            this.grpTrigger.TabStop = false;
            this.grpTrigger.Text = "Soft Trigger";
            this.grpTrigger.Visible = false;
            this.grpTrigger.Enter += new System.EventHandler(this.grpTrigger_Enter);
            // 
            // btnReleaseTrigger
            // 
            this.btnReleaseTrigger.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnReleaseTrigger.Location = new System.Drawing.Point(290, 19);
            this.btnReleaseTrigger.Name = "btnReleaseTrigger";
            this.btnReleaseTrigger.Size = new System.Drawing.Size(110, 23);
            this.btnReleaseTrigger.TabIndex = 1;
            this.btnReleaseTrigger.Text = "Release Trigger";
            this.btnReleaseTrigger.UseVisualStyleBackColor = false;
            this.btnReleaseTrigger.Click += new System.EventHandler(this.btnReleaseTrigger_Click);
            // 
            // btnPullTrigger
            // 
            this.btnPullTrigger.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPullTrigger.Location = new System.Drawing.Point(32, 19);
            this.btnPullTrigger.Name = "btnPullTrigger";
            this.btnPullTrigger.Size = new System.Drawing.Size(110, 23);
            this.btnPullTrigger.TabIndex = 0;
            this.btnPullTrigger.Text = "Pull Trigger";
            this.btnPullTrigger.UseVisualStyleBackColor = false;
            this.btnPullTrigger.Click += new System.EventHandler(this.btnPullTrigger_Click);
            // 
            // gbAdvanced
            // 
            this.gbAdvanced.Location = new System.Drawing.Point(0, 0);
            this.gbAdvanced.Name = "gbAdvanced";
            this.gbAdvanced.Size = new System.Drawing.Size(200, 100);
            this.gbAdvanced.TabIndex = 0;
            this.gbAdvanced.TabStop = false;
            this.gbAdvanced.Enter += new System.EventHandler(this.gbAdvanced_Enter);
            // 
            // grpGeneral
            // 
            this.grpGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpGeneral.Location = new System.Drawing.Point(12, 12);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(320, 700);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "Selected Scanners";
            this.grpGeneral.Visible = false;
            this.grpGeneral.Enter += new System.EventHandler(this.grpGeneral_Enter);
            // 
            // openFileDialogFW
            // 
            this.openFileDialogFW.Filter = "Firmware files (*.dat)|*.dat|Plugin Files (*.SCNPLG)|*.SCNPLG";
            this.openFileDialogFW.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogFW_FileOk);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // openFileDialogAttr
            // 
            this.openFileDialogAttr.Filter = "xml files (*.xml)|*.xml";
            this.openFileDialogAttr.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogAttr_FileOk);
            // 
            // stStripResult
            // 
            this.stStripResult.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.stStripResult.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stStripResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLbl,
            this.toolStripStatusLblTotal,
            this.toolStripStatusLblIbmhid,
            this.toolStripStatusLblSnapi,
            this.toolStripStatusIBMTT,
            this.toolStripStatusLblHidkb,
            this.toolStripStatusLblSsi,
            this.toolStripStatusLblNxmdb});
            this.stStripResult.Location = new System.Drawing.Point(0, 724);
            this.stStripResult.Name = "stStripResult";
            this.stStripResult.Size = new System.Drawing.Size(1203, 25);
            this.stStripResult.TabIndex = 2;
            this.stStripResult.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.stStripResult_ItemClicked);
            // 
            // toolStripStatusLbl
            // 
            this.toolStripStatusLbl.Name = "toolStripStatusLbl";
            this.toolStripStatusLbl.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripStatusLbl.Size = new System.Drawing.Size(425, 20);
            this.toolStripStatusLbl.Text = "                                                                                 " +
    "                       ";
            this.toolStripStatusLbl.Click += new System.EventHandler(this.toolStripStatusLbl_Click);
            // 
            // toolStripStatusLblTotal
            // 
            this.toolStripStatusLblTotal.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.toolStripStatusLblTotal.Name = "toolStripStatusLblTotal";
            this.toolStripStatusLblTotal.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripStatusLblTotal.Size = new System.Drawing.Size(72, 20);
            this.toolStripStatusLblTotal.Text = "Total = 0";
            this.toolStripStatusLblTotal.Click += new System.EventHandler(this.toolStripStatusLblTotal_Click);
            // 
            // toolStripStatusLblIbmhid
            // 
            this.toolStripStatusLblIbmhid.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLblIbmhid.Name = "toolStripStatusLblIbmhid";
            this.toolStripStatusLblIbmhid.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripStatusLblIbmhid.Size = new System.Drawing.Size(91, 20);
            this.toolStripStatusLblIbmhid.Text = "IBMHID = 0";
            this.toolStripStatusLblIbmhid.Click += new System.EventHandler(this.toolStripStatusLblIbmhid_Click);
            // 
            // toolStripStatusLblSnapi
            // 
            this.toolStripStatusLblSnapi.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLblSnapi.Name = "toolStripStatusLblSnapi";
            this.toolStripStatusLblSnapi.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripStatusLblSnapi.Size = new System.Drawing.Size(80, 20);
            this.toolStripStatusLblSnapi.Text = "SNAPI = 0";
            this.toolStripStatusLblSnapi.Click += new System.EventHandler(this.toolStripStatusLblSnapi_Click);
            // 
            // toolStripStatusIBMTT
            // 
            this.toolStripStatusIBMTT.Name = "toolStripStatusIBMTT";
            this.toolStripStatusIBMTT.Size = new System.Drawing.Size(77, 20);
            this.toolStripStatusIBMTT.Text = "IBMTT = 0";
            this.toolStripStatusIBMTT.Click += new System.EventHandler(this.toolStripStatusIBMTT_Click);
            // 
            // toolStripStatusLblHidkb
            // 
            this.toolStripStatusLblHidkb.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLblHidkb.Name = "toolStripStatusLblHidkb";
            this.toolStripStatusLblHidkb.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripStatusLblHidkb.Size = new System.Drawing.Size(83, 20);
            this.toolStripStatusLblHidkb.Text = "HIDKB = 0";
            this.toolStripStatusLblHidkb.Click += new System.EventHandler(this.toolStripStatusLblHidkb_Click);
            // 
            // toolStripStatusLblSsi
            // 
            this.toolStripStatusLblSsi.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLblSsi.Name = "toolStripStatusLblSsi";
            this.toolStripStatusLblSsi.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripStatusLblSsi.Size = new System.Drawing.Size(59, 20);
            this.toolStripStatusLblSsi.Text = "SSI = 0";
            this.toolStripStatusLblSsi.Click += new System.EventHandler(this.toolStripStatusLblSsi_Click);
            // 
            // toolStripStatusLblNxmdb
            // 
            this.toolStripStatusLblNxmdb.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLblNxmdb.Name = "toolStripStatusLblNxmdb";
            this.toolStripStatusLblNxmdb.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripStatusLblNxmdb.Size = new System.Drawing.Size(103, 20);
            this.toolStripStatusLblNxmdb.Text = "NXMODB = 0";
            this.toolStripStatusLblNxmdb.Click += new System.EventHandler(this.toolStripStatusLblNxmdb_Click);
            // 
            // saveImgFileDialog
            // 
            this.saveImgFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveImgFileDialog_FileOk);
            // 
            // openFileDialogWavFile
            // 
            this.openFileDialogWavFile.FileName = "openFileDialogWavFile";
            this.openFileDialogWavFile.Filter = "Wav files (*.wav)|*.wav";
            this.openFileDialogWavFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogWavFile_FileOk);
            // 
            // openFileDialogDADF
            // 
            this.openFileDialogDADF.Filter = "Driver ADF Script files (*.dadf)|*.dadf";
            this.openFileDialogDADF.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogDADF_FileOk);
            // 
            // folderBrowserDialogBarcodePath
            // 
            this.folderBrowserDialogBarcodePath.HelpRequest += new System.EventHandler(this.folderBrowserDialogBarcodePath_HelpRequest);
            // 
            // frmScannerApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1203, 749);
            this.Controls.Add(this.stStripResult);
            this.Controls.Add(this.tabCtrl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmScannerApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scanner SDK C# Sample Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmScannerApp_Load);
            this.tabCtrl.ResumeLayout(false);
            this.tabConectar.ResumeLayout(false);
            this.tabConectar.PerformLayout();
            this.grpScanners.ResumeLayout(false);
            this.tabVinculador.ResumeLayout(false);
            this.gbxInventoryEx.ResumeLayout(false);
            this.tablaContenedorTimbrado.ResumeLayout(false);
            this.tabaLadoTimbrado.ResumeLayout(false);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            this.TableLayoutPanel6.ResumeLayout(false);
            this.TableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTagList)).EndInit();
            this.TableLayoutPanel2.ResumeLayout(false);
            this.TableLayoutPanel2.PerformLayout();
            this.tbContEspacioVertical.ResumeLayout(false);
            this.TableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.TableLayoutPanel7.ResumeLayout(false);
            this.TableLayoutPanel7.PerformLayout();
            this.tbConsolidado.ResumeLayout(false);
            this.tbConsolidado.PerformLayout();
            this.panelScroll.ResumeLayout(false);
            this.tabBarcode.ResumeLayout(false);
            this.tabBarcode.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpBoxLanguage.ResumeLayout(false);
            this.grpBoxLanguage.PerformLayout();
            this.grpboxBarcodeLbl.ResumeLayout(false);
            this.grpboxBarcodeLbl.PerformLayout();
            this.tabImgVdo.ResumeLayout(false);
            this.grpImageVideo.ResumeLayout(false);
            this.grpImageVideo.PerformLayout();
            this.grpBoxImgType.ResumeLayout(false);
            this.grpBoxImgType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImageVideo)).EndInit();
            this.tabISO15434.ResumeLayout(false);
            this.grpIDC.ResumeLayout(false);
            this.grpIDC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxISO15434Image)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabScnAction.ResumeLayout(false);
            this.grpScnActions.ResumeLayout(false);
            this.grpPagerMotor.ResumeLayout(false);
            this.grpPagerMotor.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.grpHVS.ResumeLayout(false);
            this.grpHVS.PerformLayout();
            this.grpReboot.ResumeLayout(false);
            this.grpEnbDisScanner.ResumeLayout(false);
            this.grpBeeper.ResumeLayout(false);
            this.grpLed.ResumeLayout(false);
            this.grpAim.ResumeLayout(false);
            this.tabRsm.ResumeLayout(false);
            this.grpRSM.ResumeLayout(false);
            this.grpBoxClrSlect.ResumeLayout(false);
            this.grpBoxSetRset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).EndInit();
            this.tabConfig.ResumeLayout(false);
            this.grpCustomDecodeTone.ResumeLayout(false);
            this.grpCustomDecodeTone.PerformLayout();
            this.filterScnrs.ResumeLayout(false);
            this.grpFrmWrUpdate.ResumeLayout(false);
            this.grpFrmWrUpdate.PerformLayout();
            this.grpFWoptns.ResumeLayout(false);
            this.grpFWoptns.PerformLayout();
            this.grpScannerProp.ResumeLayout(false);
            this.grpScannerProp.PerformLayout();
            this.grpElectricFenceCustomTone.ResumeLayout(false);
            this.grpElectricFenceCustomTone.PerformLayout();
            this.tabRta.ResumeLayout(false);
            this.grpRTAEventLog.ResumeLayout(false);
            this.grpRTAEventLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRtaEventResponse)).EndInit();
            this.grpRTAConfig.ResumeLayout(false);
            this.grpRTAConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRtaView)).EndInit();
            this.tabScan2Connect.ResumeLayout(false);
            this.grpScan2Connect.ResumeLayout(false);
            this.grpScan2Connect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBBarcode)).EndInit();
            this.tabMisc.ResumeLayout(false);
            this.grpMiscOther.ResumeLayout(false);
            this.grpSCdcSwitch.ResumeLayout(false);
            this.grpSCdcSwitch.PerformLayout();
            this.grpMiscCmd.ResumeLayout(false);
            this.grpAsync.ResumeLayout(false);
            this.grpAsync.PerformLayout();
            this.tabScale.ResumeLayout(false);
            this.grpScale.ResumeLayout(false);
            this.grpScale.PerformLayout();
            this.tabSSW.ResumeLayout(false);
            this.tabSSW.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusIcon)).EndInit();
            this.tabXml.ResumeLayout(false);
            this.grpResult.ResumeLayout(false);
            this.grpResult.PerformLayout();
            this.grpOutXml.ResumeLayout(false);
            this.grpOutXml.PerformLayout();
            this.grpTrigger.ResumeLayout(false);
            this.stStripResult.ResumeLayout(false);
            this.stStripResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabBarcode;
        private System.Windows.Forms.TabPage tabImgVdo;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.GroupBox grpScannerProp;
        private System.Windows.Forms.CheckBox chkClaim;
        private System.Windows.Forms.GroupBox grpAsync;
        private System.Windows.Forms.CheckBox chkAsync;
        private System.Windows.Forms.TabPage tabRsm;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.TabPage tabMisc;
        private System.Windows.Forms.GroupBox grpImageVideo;
        private System.Windows.Forms.Button btnAbortImageXfer;
        private System.Windows.Forms.CheckBox chkVideoViewFinderEnable;
        private System.Windows.Forms.PictureBox pbxImageVideo;
        private System.Windows.Forms.GroupBox grpRSM;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnGetNext;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.DataGridView dgvAttributes;
        private System.Windows.Forms.TabPage tabScnAction;
        private System.Windows.Forms.GroupBox grpFrmWrUpdate;
        private System.Windows.Forms.Button btnAbortFWUpdate;
        private System.Windows.Forms.ProgressBar progressBarFWUpdate;
        private System.Windows.Forms.Button btnFWUpdate;
        private System.Windows.Forms.Button buttonFWBrowse;
        private System.Windows.Forms.TextBox txtFWFile;
        private System.Windows.Forms.Button btnLaunchNewFW;
        private System.Windows.Forms.TabPage tabXml;
        private System.Windows.Forms.GroupBox grpOutXml;
        private System.Windows.Forms.Button btnClearXmlArea;
        private System.Windows.Forms.TextBox txtOutXml;
        private System.Windows.Forms.RadioButton rdoJPG;
        private System.Windows.Forms.RadioButton rdoBMP;
        private System.Windows.Forms.RadioButton rdoTIFF;
        private System.Windows.Forms.DataGridViewTextBoxColumn attrNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn attrType;
        private System.Windows.Forms.DataGridViewTextBoxColumn property;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.GroupBox grpTrigger;
        private System.Windows.Forms.Button btnReleaseTrigger;
        private System.Windows.Forms.Button btnPullTrigger;
        private System.Windows.Forms.Button btnGetScanners;
        private System.Windows.Forms.GroupBox grpScanners;
        private System.Windows.Forms.ListView lstvScanners;
        private System.Windows.Forms.ColumnHeader clmId;
        private System.Windows.Forms.ColumnHeader clmType;
        private System.Windows.Forms.ColumnHeader clmSerial;
        private System.Windows.Forms.ColumnHeader clmModel;
        private System.Windows.Forms.ColumnHeader clmGuid;
        private System.Windows.Forms.OpenFileDialog openFileDialogFW;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog openFileDialogAttr;
        private System.Windows.Forms.GroupBox grpScnActions;
        private System.Windows.Forms.GroupBox grpReboot;
        private System.Windows.Forms.Button btnRebootScanner;
        private System.Windows.Forms.GroupBox grpEnbDisScanner;
        private System.Windows.Forms.GroupBox grpBeeper;
        private System.Windows.Forms.Button btnSoundBeeper;
        private System.Windows.Forms.GroupBox grpLed;
        private System.Windows.Forms.Button btnLedOff;
        private System.Windows.Forms.Button btnLedOn;
        private System.Windows.Forms.GroupBox grpAim;
        private System.Windows.Forms.Button btnAimOn;
        private System.Windows.Forms.Button btnAimOff;
        private System.Windows.Forms.GroupBox grpMiscOther;
        private System.Windows.Forms.GroupBox grpMiscCmd;
        private System.Windows.Forms.Button btnGetDevTopology;
        private System.Windows.Forms.Button btnSdkVersion;
        private System.Windows.Forms.StatusStrip stStripResult;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLbl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLblTotal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLblSnapi;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLblSsi;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLblIbmhid;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLblHidkb;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLblNxmdb;
        private System.Windows.Forms.GroupBox gbAdvanced;
        private System.Windows.Forms.CheckBox chkBulk;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.Button btnClearLogsArea;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.ComboBox cmbSlcrScnr;
        private System.Windows.Forms.ComboBox cmbBeep;
        private System.Windows.Forms.GroupBox grpHVS;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.CheckBox chkShmPermChange;
        private System.Windows.Forms.CheckBox chkShmSilentSwitch;
        private System.Windows.Forms.Button btnSwitchHostMode;
        private System.Windows.Forms.GroupBox grpboxBarcodeLbl;
        private System.Windows.Forms.TextBox txtBarcodeLbl;
        private System.Windows.Forms.GroupBox filterScnrs;
        private System.Windows.Forms.ComboBox cmbFilterScnrs;
        private System.Windows.Forms.Button btnSveImge;
        private System.Windows.Forms.SaveFileDialog saveImgFileDialog;
        private System.Windows.Forms.Label lblSlctScnnr;
        private System.Windows.Forms.Button btnFlushMacroPdf;
        private System.Windows.Forms.Button btnBarcodeClear;
        private System.Windows.Forms.Button btnAbortMacroPdf;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.GroupBox grpFWoptns;
        private System.Windows.Forms.Label lblDecdBarCde;
        private System.Windows.Forms.Label lblSyblogy;
        private System.Windows.Forms.TextBox txtSyblogy;
        private System.Windows.Forms.GroupBox grpBoxImgType;
        private System.Windows.Forms.ColumnHeader clmFrmwr;
        private System.Windows.Forms.ColumnHeader clmMnftrd;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.GroupBox grpBoxClrSlect;
        private System.Windows.Forms.GroupBox grpBoxSetRset;
        private System.Windows.Forms.ComboBox cmbLed;
        private System.Windows.Forms.GroupBox grpBoxLanguage;
        private System.Windows.Forms.CheckBox chkBoxEmulation;
        private System.Windows.Forms.ComboBox cmbEmulation;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.TabPage tabScale;
        private System.Windows.Forms.GroupBox grpScale;
        private System.Windows.Forms.Button btnSystemRest;
        private System.Windows.Forms.Button btnZeroScale;
        private System.Windows.Forms.Button btnReadWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScalStatusDesc;
        private System.Windows.Forms.TextBox txtWeightUnit;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabISO15434;
        private System.Windows.Forms.PictureBox pbxISO15434Image;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDocCapDecodeDataSymbol;
        private System.Windows.Forms.TextBox txtDocCapDecodeData;
        private System.Windows.Forms.CheckBox checkUseHID;
        private System.Windows.Forms.ComboBox cmbSnapiParams;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbSnapiParamValue;
        private System.Windows.Forms.Button btnSnapiGet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSnapiSet;
        private System.Windows.Forms.Button btnSnapiStore;
        private System.Windows.Forms.Button btnClearpbx;
        public System.Windows.Forms.GroupBox grpIDC;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusIBMTT;
        private System.Windows.Forms.OpenFileDialog openFileDialogWavFile;
        private System.Windows.Forms.Button btnEraseTone;
        private System.Windows.Forms.Button buttonWavFileUpload;
        private System.Windows.Forms.TextBox txtWavFile;
        private System.Windows.Forms.Button buttonWavFileBrowse;
        private System.Windows.Forms.GroupBox grpCustomDecodeTone;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBoxAppADF;
        private System.Windows.Forms.Button btnScriptEditor;
        private System.Windows.Forms.Button btnBrowseScript;
        private System.Windows.Forms.OpenFileDialog openFileDialogDADF;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogBarcodePath;
        private System.Windows.Forms.TabPage tabScan2Connect;
        private System.Windows.Forms.GroupBox grpScan2Connect;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox picBBarcode;
        private System.Windows.Forms.ComboBox cmbImageSize;
        private System.Windows.Forms.ComboBox cmbDefaultOption;
        private System.Windows.Forms.ComboBox cmbProtocol;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbScannerType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbHostName;
        private System.Windows.Forms.Button btnSaveBarcode;
        private System.Windows.Forms.TabPage tabSSW;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox chkAutoIncrement;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.TextBox txtUserBank;
        private System.Windows.Forms.TextBox txtNewEpcId;
        private System.Windows.Forms.Label lblUserBank;
        private System.Windows.Forms.TextBox txtUpcaBarcode;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.PictureBox statusIcon;
        private System.Windows.Forms.ComboBox cmbPartition;
        private System.Windows.Forms.ComboBox cmbFilterValue;
        private System.Windows.Forms.Button btnWriteTag;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnVerifyTag;
        private System.Windows.Forms.RadioButton rdoASCII;
        private System.Windows.Forms.TextBox txtEpcId;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton rdoHex;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSaveIdc;
        private System.Windows.Forms.Button btnScannerDisable;
        private System.Windows.Forms.Button btnScannerEnable;
        private System.Windows.Forms.GroupBox grpSCdcSwitch;
        private System.Windows.Forms.Button btnSCdcSwitchDevices;
        private System.Windows.Forms.CheckBox chkSCdcSIsPermanent;
        private System.Windows.Forms.CheckBox chkSCdcSIsSilent;
        private System.Windows.Forms.ComboBox cmbSCdcSHostMode;
        private System.Windows.Forms.Label lblSCdcSHostMode;
        private System.Windows.Forms.GroupBox grpPagerMotor;
        private System.Windows.Forms.Button btnEnablePagerMotor;
        private System.Windows.Forms.Label lblPagerMotorTimeout;
        private System.Windows.Forms.TextBox txtPagerMotorDuration;
        private System.Windows.Forms.Button btnElectricFenceEraseTone;
        private System.Windows.Forms.Button buttonElectricFenceWavFileUpload;
        private System.Windows.Forms.TextBox txtElectricFenceWaveFile;
        private System.Windows.Forms.Button buttonElectricFenceWavFileBrowse;
        private System.Windows.Forms.GroupBox grpElectricFenceCustomTone;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbEncoding;
        private System.Windows.Forms.ColumnHeader clmCnfig;
        private System.Windows.Forms.TabPage tabRta;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnGetRTAEventStatus;
        private System.Windows.Forms.Button btnSetRTAEventStatus;
        private System.Windows.Forms.Button btnRegisterRTAEvents;
        private System.Windows.Forms.Button btnGetRegRTAEvents;
        private System.Windows.Forms.Button btnGetSuppRTAEvents;
        private System.Windows.Forms.GroupBox grpRTAEventLog;
        private System.Windows.Forms.GroupBox grpRTAConfig;
        private System.Windows.Forms.DataGridView dgRtaView;
        private System.Windows.Forms.CheckBox cbSuspend;
        private System.Windows.Forms.Button btnCleanEvents;
        private System.Windows.Forms.DataGridView dgRtaEventResponse;
        private System.Windows.Forms.Label lblRTAState;
        private System.Windows.Forms.Button btnGetRTAState;
        private System.Windows.Forms.TabPage tabConectar;
        private System.Windows.Forms.TabPage tabVinculador;
        internal System.Windows.Forms.GroupBox gbxInventoryEx;
        internal System.Windows.Forms.TableLayoutPanel tablaContenedorTimbrado;
        internal System.Windows.Forms.TableLayoutPanel tabaLadoTimbrado;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Button btnLimpiarRFID;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Label cantidadRFID;
        internal System.Windows.Forms.Label MsnVincular;
        internal System.Windows.Forms.TextBox CodBarras;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel6;
        internal System.Windows.Forms.DataGridView dgvTagList;
        internal System.Windows.Forms.DataGridViewTextBoxColumn clnEPC;
        internal System.Windows.Forms.DataGridViewTextBoxColumn clnTID;
        internal System.Windows.Forms.DataGridViewTextBoxColumn clnCount;
        internal System.Windows.Forms.TextBox nroOP;
        internal System.Windows.Forms.TextBox nroHM;
        internal System.Windows.Forms.Button btnLimpiarOPHM;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.Button btnVerConsolidado;
        internal System.Windows.Forms.Label lblTotalCount;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TableLayoutPanel tbContEspacioVertical;
        internal System.Windows.Forms.Button btnStopInventoryEx;
        internal System.Windows.Forms.ComboBox cbxInventory;
        internal System.Windows.Forms.Button btnStartInventoryEx;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel3;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn linea;
        internal System.Windows.Forms.DataGridViewTextBoxColumn op;
        internal System.Windows.Forms.DataGridViewTextBoxColumn hoja_marcacion;
        internal System.Windows.Forms.DataGridViewTextBoxColumn corte;
        internal System.Windows.Forms.DataGridViewTextBoxColumn subcorte;
        internal System.Windows.Forms.DataGridViewTextBoxColumn color;
        internal System.Windows.Forms.DataGridViewTextBoxColumn talla;
        internal System.Windows.Forms.DataGridViewTextBoxColumn cod_talla;
        internal System.Windows.Forms.DataGridViewTextBoxColumn id_talla;
        internal System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        internal System.Windows.Forms.DataGridViewTextBoxColumn id_rfid;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel7;
        internal System.Windows.Forms.TableLayoutPanel tbConsolidado;
        internal System.Windows.Forms.Label lblTotalDetalle;
        internal System.Windows.Forms.Panel panelScroll;
        internal System.Windows.Forms.TableLayoutPanel tbDetalleTimbrado;
    }
}

