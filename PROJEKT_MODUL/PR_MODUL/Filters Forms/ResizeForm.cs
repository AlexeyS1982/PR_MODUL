using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using AForge.Imaging;
using AForge.Imaging.Filters;

namespace PR_MODUL
{
    /// <summary>
    /// Summary description for ResizeForm.
    /// </summary>
    public class ResizeForm : Form
    {
        private FilterResize filter = null;
        private bool updating = false;

        private RadioButton factorButton;
        private TextBox factorBox;
        private PictureBox pictureBox1;
        private RadioButton sizeButton;
        private Label label1;
        private TextBox widthBox;
        private Label label2;
        private TextBox heightBox;
        private PictureBox pictureBox2;
        private Label label3;
        private ComboBox methodCombo;
        private Button okButton;
        private Button cancelButton;
        private CheckBox ratioCheck;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        // OriginalSize property
        public Size OriginalSize { get; set; }
        // Filter property
        public IFilter Filter
        {
            get { return filter; }
        }

        // Constructor
        public ResizeForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                if ( components != null )
                {
                    components.Dispose( );
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            factorButton = new RadioButton( );
            factorBox = new TextBox( );
            pictureBox1 = new PictureBox( );
            sizeButton = new RadioButton( );
            label1 = new Label( );
            widthBox = new TextBox( );
            label2 = new Label( );
            heightBox = new TextBox( );
            ratioCheck = new CheckBox( );
            pictureBox2 = new PictureBox( );
            label3 = new Label( );
            methodCombo = new ComboBox( );
            okButton = new Button( );
            cancelButton = new Button( );
            SuspendLayout( );
            // 
            // factorButton
            // 
            factorButton.Checked = true;
            factorButton.Location = new Point( 10, 10 );
            factorButton.Name = "factorButton";
            factorButton.Size = new Size( 100, 20 );
            factorButton.TabIndex = 0;
            factorButton.TabStop = true;
            factorButton.Text = "Resize &factor:";
            factorButton.CheckedChanged += new EventHandler( factorButton_CheckedChanged );
            // 
            // factorBox
            // 
            factorBox.Location = new Point( 100, 10 );
            factorBox.Name = "factorBox";
            factorBox.TabIndex = 1;
            factorBox.Text = "";
            factorBox.TextChanged += new EventHandler( factorBox_TextChanged );
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point( 10, 40 );
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size( 190, 2 );
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // sizeButton
            // 
            sizeButton.Location = new Point( 10, 50 );
            sizeButton.Name = "sizeButton";
            sizeButton.Size = new Size( 100, 20 );
            sizeButton.TabIndex = 2;
            sizeButton.Text = "Resize to &size";
            sizeButton.CheckedChanged += new EventHandler( sizeButton_CheckedChanged );
            // 
            // label1
            // 
            label1.Location = new Point( 30, 78 );
            label1.Name = "label1";
            label1.Size = new Size( 44, 14 );
            label1.TabIndex = 3;
            label1.Text = "&Width:";
            // 
            // widthBox
            // 
            widthBox.Enabled = false;
            widthBox.Location = new Point( 100, 75 );
            widthBox.Name = "widthBox";
            widthBox.TabIndex = 4;
            widthBox.Text = "";
            widthBox.TextChanged += new EventHandler( widthBox_TextChanged );
            // 
            // label2
            // 
            label2.Location = new Point( 30, 103 );
            label2.Name = "label2";
            label2.Size = new Size( 60, 14 );
            label2.TabIndex = 5;
            label2.Text = "&Height:";
            // 
            // heightBox
            // 
            heightBox.Enabled = false;
            heightBox.Location = new Point( 100, 100 );
            heightBox.Name = "heightBox";
            heightBox.TabIndex = 6;
            heightBox.Text = "";
            heightBox.TextChanged += new EventHandler( heightBox_TextChanged );
            // 
            // ratioCheck
            // 
            ratioCheck.Checked = true;
            ratioCheck.CheckState = CheckState.Checked;
            ratioCheck.Enabled = false;
            ratioCheck.Location = new Point( 30, 130 );
            ratioCheck.Name = "ratioCheck";
            ratioCheck.Size = new Size( 150, 20 );
            ratioCheck.TabIndex = 7;
            ratioCheck.Text = "&Keep aspect ratio";
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point( 10, 155 );
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size( 190, 2 );
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.Location = new Point( 10, 168 );
            label3.Name = "label3";
            label3.Size = new Size( 85, 14 );
            label3.TabIndex = 8;
            label3.Text = "&Interpolation:";
            // 
            // methodCombo
            // 
            methodCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            methodCombo.Items.AddRange( new object[] {
															 "Nearest neighbour",
															 "Bilinear",
															 "Bicubic"} );
            methodCombo.Location = new Point( 100, 165 );
            methodCombo.Name = "methodCombo";
            methodCombo.Size = new Size( 100, 21 );
            methodCombo.TabIndex = 9;
            // 
            // okButton
            // 
            okButton.FlatStyle = FlatStyle.Flat;
            okButton.Location = new Point( 25, 205 );
            okButton.Name = "okButton";
            okButton.TabIndex = 10;
            okButton.Text = "Ok";
            okButton.Click += new EventHandler( okButton_Click );
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Location = new Point( 115, 205 );
            cancelButton.Name = "cancelButton";
            cancelButton.TabIndex = 11;
            cancelButton.Text = "Cancel";
            // 
            // ResizeForm
            // 
            AcceptButton = okButton;
            AutoScaleBaseSize = new Size( 5, 13 );
            CancelButton = cancelButton;
            ClientSize = new Size( 214, 238 );
            Controls.AddRange( new Control[] {
																		  cancelButton,
																		  okButton,
																		  methodCombo,
																		  label3,
																		  pictureBox2,
																		  ratioCheck,
																		  heightBox,
																		  label2,
																		  widthBox,
																		  label1,
																		  sizeButton,
																		  pictureBox1,
																		  factorBox,
																		  factorButton} );
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ResizeForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Resize image";
            Load += new EventHandler( ResizeForm_Load );
            ResumeLayout( false );

        }
        #endregion

        // On form load
        private void ResizeForm_Load( object sender, EventArgs e )
        {
            // default resize factor
            factorBox.Text = "2";

            // width & height
            widthBox.Text = ( OriginalSize.Width * 2 ).ToString( );
            heightBox.Text = ( OriginalSize.Height * 2 ).ToString( );

            methodCombo.SelectedIndex = 1;
        }

        // On size radio button checked state changed
        private void sizeButton_CheckedChanged( object sender, EventArgs e )
        {
            bool enable = sizeButton.Checked;

            widthBox.Enabled = enable;
            heightBox.Enabled = enable;
            ratioCheck.Enabled = enable;
        }

        // On factor radio button checked state changed
        private void factorButton_CheckedChanged( object sender, EventArgs e )
        {
            factorBox.Enabled = factorButton.Checked;
        }

        // On factor changed
        private void factorBox_TextChanged( object sender, EventArgs e )
        {
            try
            {
                float factor = float.Parse( factorBox.Text );

                updating = true;
                widthBox.Text = Math.Max( 1, Math.Min( 5000, (int) ( factor * OriginalSize.Width ) ) ).ToString( );
                heightBox.Text = Math.Max( 1, Math.Min( 5000, (int) ( factor * OriginalSize.Height ) ) ).ToString( );
                updating = false;
            }
            catch ( Exception )
            {
            }
        }

        // On width changed
        private void widthBox_TextChanged( object sender, EventArgs e )
        {
            if ( ( !updating ) && ( ratioCheck.Checked ) )
            {
                try
                {
                    int width = int.Parse( widthBox.Text );

                    updating = true;
                    heightBox.Text = Math.Max( 1, Math.Min( 5000, (int) ( width * OriginalSize.Height / OriginalSize.Width ) ) ).ToString( );
                    updating = false;
                }
                catch ( Exception )
                {
                }
            }
        }

        // On height changed
        private void heightBox_TextChanged( object sender, EventArgs e )
        {
            if ( ( !updating ) && ( ratioCheck.Checked ) )
            {
                try
                {
                    int height = int.Parse( heightBox.Text );

                    updating = true;
                    widthBox.Text = Math.Max( 1, Math.Min( 5000, (int) ( height * OriginalSize.Width / OriginalSize.Height ) ) ).ToString( );
                    updating = false;
                }
                catch ( Exception )
                {
                }
            }
        }

        // On "Ok" button
        private void okButton_Click( object sender, EventArgs e )
        {
            try
            {
                // get new image size
                int width = Math.Max( 1, Math.Min( 5000, int.Parse( widthBox.Text ) ) );
                int height = Math.Max( 1, Math.Min( 5000, int.Parse( heightBox.Text ) ) );

                // create appropriate filter
                switch ( methodCombo.SelectedIndex )
                {
                    case 0:
                        filter = new ResizeNearestNeighbor( width, height );
                        break;
                    case 1:
                        filter = new ResizeBilinear( width, height );
                        break;
                    case 2:
                        filter = new ResizeBicubic( width, height );
                        break;
                }

                // close the dialog
                DialogResult = DialogResult.OK;
                Close( );
            }
            catch ( Exception )
            {
                MessageBox.Show( this, "Incorrect values are entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }
    }
}
