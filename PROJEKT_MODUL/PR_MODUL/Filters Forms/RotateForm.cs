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
    /// Summary description for RotateForm.
    /// </summary>
    public class RotateForm : Form
    {
        private FilterRotate filter = null;

        private Label label1;
        private TextBox angleBox;
        private ComboBox methodCombo;
        private Label label3;
        private CheckBox keepSizeCheck;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox redBox;
        private Label label4;
        private TextBox greenBox;
        private Label label5;
        private TextBox blueBox;
        private Button okButton;
        private Button cancelButton;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        // Filter property
        public IFilter Filter
        {
            get { return filter; }
        }

        // Constructor
        public RotateForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            angleBox.Text = "45";
            redBox.Text = "0";
            greenBox.Text = "0";
            blueBox.Text = "0";

            methodCombo.SelectedIndex = 1;
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
            label1 = new Label( );
            angleBox = new TextBox( );
            methodCombo = new ComboBox( );
            label3 = new Label( );
            keepSizeCheck = new CheckBox( );
            groupBox1 = new GroupBox( );
            label2 = new Label( );
            redBox = new TextBox( );
            label4 = new Label( );
            greenBox = new TextBox( );
            label5 = new Label( );
            blueBox = new TextBox( );
            okButton = new Button( );
            cancelButton = new Button( );
            groupBox1.SuspendLayout( );
            SuspendLayout( );
            // 
            // label1
            // 
            label1.Location = new Point( 10, 13 );
            label1.Name = "label1";
            label1.Size = new Size( 42, 15 );
            label1.TabIndex = 0;
            label1.Text = "&Angle:";
            // 
            // angleBox
            // 
            angleBox.Location = new Point( 100, 10 );
            angleBox.Name = "angleBox";
            angleBox.TabIndex = 1;
            angleBox.Text = "";
            // 
            // methodCombo
            // 
            methodCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            methodCombo.Items.AddRange( new object[] {
															 "Nearest neighbour",
															 "Bilinear",
															 "Bicubic"} );
            methodCombo.Location = new Point( 100, 40 );
            methodCombo.Name = "methodCombo";
            methodCombo.Size = new Size( 100, 21 );
            methodCombo.TabIndex = 3;
            // 
            // label3
            // 
            label3.Location = new Point( 10, 43 );
            label3.Name = "label3";
            label3.Size = new Size( 85, 14 );
            label3.TabIndex = 2;
            label3.Text = "&Interpolation:";
            // 
            // keepSizeCheck
            // 
            keepSizeCheck.Location = new Point( 100, 70 );
            keepSizeCheck.Name = "keepSizeCheck";
            keepSizeCheck.Size = new Size( 93, 24 );
            keepSizeCheck.TabIndex = 4;
            keepSizeCheck.Text = "&Keep size";
            // 
            // groupBox1
            // 
            groupBox1.Controls.AddRange( new Control[] {
																					greenBox,
																					label4,
																					redBox,
																					label2,
																					label5,
																					blueBox} );
            groupBox1.Location = new Point( 10, 100 );
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size( 190, 50 );
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "&Fill color";
            // 
            // label2
            // 
            label2.Location = new Point( 5, 23 );
            label2.Name = "label2";
            label2.Size = new Size( 20, 14 );
            label2.TabIndex = 0;
            label2.Text = "R:";
            // 
            // redBox
            // 
            redBox.Location = new Point( 25, 20 );
            redBox.Name = "redBox";
            redBox.Size = new Size( 35, 20 );
            redBox.TabIndex = 1;
            redBox.Text = "";
            // 
            // label4
            // 
            label4.Location = new Point( 68, 23 );
            label4.Name = "label4";
            label4.Size = new Size( 20, 14 );
            label4.TabIndex = 2;
            label4.Text = "G:";
            // 
            // greenBox
            // 
            greenBox.Location = new Point( 87, 20 );
            greenBox.Name = "greenBox";
            greenBox.Size = new Size( 35, 20 );
            greenBox.TabIndex = 3;
            greenBox.Text = "";
            // 
            // label5
            // 
            label5.Location = new Point( 125, 23 );
            label5.Name = "label5";
            label5.Size = new Size( 20, 14 );
            label5.TabIndex = 6;
            label5.Text = "B:";
            // 
            // blueBox
            // 
            blueBox.Location = new Point( 145, 20 );
            blueBox.Name = "blueBox";
            blueBox.Size = new Size( 35, 20 );
            blueBox.TabIndex = 6;
            blueBox.Text = "";
            // 
            // okButton
            // 
            okButton.FlatStyle = FlatStyle.Flat;
            okButton.Location = new Point( 27, 170 );
            okButton.Name = "okButton";
            okButton.TabIndex = 6;
            okButton.Text = "Ok";
            okButton.Click += new EventHandler( okButton_Click );
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Location = new Point( 112, 170 );
            cancelButton.Name = "cancelButton";
            cancelButton.TabIndex = 7;
            cancelButton.Text = "Cancel";
            // 
            // RotateForm
            // 
            AcceptButton = okButton;
            AutoScaleBaseSize = new Size( 5, 13 );
            CancelButton = cancelButton;
            ClientSize = new Size( 214, 205 );
            Controls.AddRange( new Control[] {
																		  cancelButton,
																		  okButton,
																		  groupBox1,
																		  keepSizeCheck,
																		  methodCombo,
																		  label3,
																		  angleBox,
																		  label1} );
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RotateForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rotate image";
            groupBox1.ResumeLayout( false );
            ResumeLayout( false );

        }
        #endregion

        // On "Ok" button
        private void okButton_Click( object sender, EventArgs e )
        {
            try
            {
                // get rotation angle
                double angle = double.Parse( angleBox.Text );

                // create appropriate rotation filter
                switch ( methodCombo.SelectedIndex )
                {
                    case 0:
                        filter = new RotateNearestNeighbor( angle );
                        break;
                    case 1:
                        filter = new RotateBilinear( angle );
                        break;
                    case 2:
                        filter = new RotateBicubic( angle );
                        break;
                }

                // fill color
                filter.FillColor = Color.FromArgb(
                    byte.Parse( redBox.Text ),
                    byte.Parse( greenBox.Text ),
                    byte.Parse( blueBox.Text ) );

                // keep size
                filter.KeepSize = keepSizeCheck.Checked;

                // close dialog
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
