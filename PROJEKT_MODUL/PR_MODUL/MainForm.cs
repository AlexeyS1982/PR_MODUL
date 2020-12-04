//////////////**********

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using WeifenLuo.WinFormsUI;
using rpaulo.toolbar;
using AForge.Imaging;

namespace PR_MODUL
{
    public class Главная : Form, IDocumentsHost
    {
        private int unnamedNumber = 0;
        private Configuration config = new Configuration();
        private ToolBarManager toolBarManager;
        private DockManager dockManager;
        private MainMenu mainMenu;
        private MenuItem fileItem; 
        private MenuItem exitFileItem; 
        private MenuItem OpenItem; 
        private MenuItem menuItem2; 
        private MenuItem closeFileItem; 
        private MenuItem closeAllFileItem; 
        private Panel panel1;
        private MenuItem menuItem1; 
        private OpenFileDialog ofd;
        private ToolBarButton openButton;
        private ToolBar imageToolBar;
        private ImageList imageList2;
        private ToolBarButton cloneButton;
        private ToolBarButton cropButton;
        private ToolBarButton toolBarButton1;
        private ToolBarButton toolBarButton2;
        private ToolBarButton zoomInButton;
        private ToolBarButton zoomOutButton;
        private ToolBarButton toolBarButton3;
        private ToolBarButton fitToScreenButton;
        private ToolBarButton toolBarButton4;
        private MenuItem copyFileItem; //
        private MenuItem pasteFileItem; //
        private MenuItem menuItem5; //
        private MenuItem saveFileItem; //
        private SaveFileDialog sfd;//сохранить
        private ToolBarButton pasteButton;
        private ToolBarButton saveButton;
        private ToolBarButton copyButton;
        private ToolBarButton toolBarButton9;
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;
        private MenuItem printPreviewFileItem; //
        private MenuItem pageSetupFileItem; //
        private MenuItem menuItem8; //п
        private PageSetupDialog pageSetupDialog;
        private PrintDialog printDialog;
        private System.ComponentModel.IContainer components;
//***************************************************************************
        public Главная()
        {
            // Требуется для поддержки Windows Form 
            InitializeComponent();

            //
            // добавление кода конструктора 
            //
            toolBarManager = new ToolBarManager(this, this);

            // добавление панели инструментов
            ToolBarDockHolder holder;

            // Панель инструментов изображения
            imageToolBar.Text = "Панель инструментов изображения";
            holder = toolBarManager.AddControl(imageToolBar);
            holder.AllowedBorders = AllowedBorders.Top | AllowedBorders.Left | AllowedBorders.Right;


        }
        
    //**************************************************************************************    
        //для форм

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Главная));
            mainMenu = new MainMenu(components);
            fileItem = new MenuItem();
            OpenItem = new MenuItem();
            saveFileItem = new MenuItem();
            menuItem1 = new MenuItem();
            copyFileItem = new MenuItem();
            pasteFileItem = new MenuItem();
            menuItem5 = new MenuItem();
            closeFileItem = new MenuItem();
            closeAllFileItem = new MenuItem();
            menuItem8 = new MenuItem();
            pageSetupFileItem = new MenuItem();
            printPreviewFileItem = new MenuItem();
            menuItem2 = new MenuItem();
            exitFileItem = new MenuItem();
            panel1 = new Panel();
            dockManager = new DockManager();
            imageToolBar = new ToolBar();
            cloneButton = new ToolBarButton();
            toolBarButton1 = new ToolBarButton();
            cropButton = new ToolBarButton();
            toolBarButton2 = new ToolBarButton();
            zoomInButton = new ToolBarButton();
            zoomOutButton = new ToolBarButton();
            toolBarButton3 = new ToolBarButton();
            fitToScreenButton = new ToolBarButton();
            imageList2 = new ImageList(components);
            saveButton = new ToolBarButton();
            copyButton = new ToolBarButton();
            pasteButton = new ToolBarButton();
            toolBarButton9 = new ToolBarButton();
            toolBarButton4 = new ToolBarButton();
            openButton = new ToolBarButton();
            ofd = new OpenFileDialog();
            sfd = new SaveFileDialog();
            printDocument = new PrintDocument();
            printPreviewDialog = new PrintPreviewDialog();
            pageSetupDialog = new PageSetupDialog();
            printDialog = new PrintDialog();
            panel1.SuspendLayout();
            dockManager.SuspendLayout();
            SuspendLayout();
            // *****************************************************************************************************
            // Главное меню
            // 
            mainMenu.MenuItems.AddRange(new MenuItem[] {
            fileItem});
            // ***************************************************************************************************
            //Меню -фаил
            fileItem.Index = 0;
            fileItem.MenuItems.AddRange(new MenuItem[] {
            OpenItem,
            saveFileItem,
            menuItem1,
            copyFileItem,
            pasteFileItem,
            menuItem5,
            closeFileItem,
            closeAllFileItem,
            menuItem8,
            pageSetupFileItem,
            printPreviewFileItem,
            menuItem2,
            exitFileItem});
            fileItem.Text = "&Файл";
            fileItem.Popup += new EventHandler(fileItem_Popup);
            // 
            OpenItem.Index = 0;
            OpenItem.Shortcut = Shortcut.CtrlO;
            OpenItem.Text = "&Открыть";
            OpenItem.Click += new EventHandler(OpenItem_Click);
            // 
            saveFileItem.Shortcut = Shortcut.CtrlS;
            saveFileItem.Text = "&Сохранить как";
            saveFileItem.Click += new EventHandler(saveFileItem_Click);
            // 
            menuItem1.Index = 2;
            menuItem1.Text = "-";
            // 
            copyFileItem.Index = 3;
            copyFileItem.Shortcut = Shortcut.CtrlC;
            copyFileItem.Text = "&Копировать";
            copyFileItem.Click += new EventHandler(copyFileItem_Click);
            // 
            pasteFileItem.Index = 4;
            pasteFileItem.Shortcut = Shortcut.CtrlV;
            pasteFileItem.Text = "&Вставить";
            pasteFileItem.Click += new EventHandler(pasteFileItem_Click);
            // 
            menuItem5.Index = 5;
            menuItem5.Text = "-";
            // 
            closeFileItem.Index = 6;
            closeFileItem.Shortcut = Shortcut.CtrlF4;
            closeFileItem.Text = "&Закрыть";
            closeFileItem.Click += new EventHandler(closeFileItem_Click);
            // 
            closeAllFileItem.Index = 7;
            closeAllFileItem.Text = "Закрыть все";
            closeAllFileItem.Click += new EventHandler(closeAllFileItem_Click);
            // 
            menuItem8.Index = 8;
            menuItem8.Text = "-";
            // 
            pageSetupFileItem.Index = 9;
            pageSetupFileItem.Text = "Параметры страницы";
            pageSetupFileItem.Click += new EventHandler(pageSetupFileItem_Click);
            // 
            printPreviewFileItem.Index = 10;
            printPreviewFileItem.Text = "Предварительный просмотр печати";
            printPreviewFileItem.Click += new EventHandler(printPreviewFileItem_Click);
            // 
            menuItem2.Index = 11;
            menuItem2.Text = "-";
            // 
            exitFileItem.Index = 12;
            exitFileItem.Text = "&Выход";
            exitFileItem.Click += new EventHandler(exitFileItem_Click);

            // panel1
            // 
            panel1.Controls.Add(dockManager);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(792, 511);
            panel1.TabIndex = 2;
            //**************************************************************************************************** 
            // dockManager
            dockManager.ActiveAutoHideContent = null;
            dockManager.Controls.Add(imageToolBar);
            dockManager.Dock = DockStyle.Fill;
            dockManager.Location = new Point(0, 0);
            dockManager.Name = "dockManager";
            dockManager.Size = new Size(792, 511);
            dockManager.TabIndex = 2;
            dockManager.ActiveDocumentChanged += new EventHandler(dockManager_ActiveDocumentChanged);
            dockManager.Paint += new PaintEventHandler(dockManager_Paint);
            //*************************************************************************************** 
            // Подвижное меню
            imageToolBar.Appearance = ToolBarAppearance.Flat;
            imageToolBar.Buttons.AddRange(new ToolBarButton[] {
            cloneButton,
            toolBarButton1,
            cropButton,
            toolBarButton2,
            zoomInButton,
            zoomOutButton,
            toolBarButton3,
            fitToScreenButton,
             });
            imageToolBar.Divider = false;
            imageToolBar.Dock = DockStyle.None;
            imageToolBar.DropDownArrows = true;
            imageToolBar.ImageList = imageList2;
            imageToolBar.Location = new Point(144, 312);
            imageToolBar.Name = "imageToolBar";
            imageToolBar.ShowToolTips = true;
            imageToolBar.Size = new Size(472, 26);
            imageToolBar.TabIndex = 3;
            imageToolBar.ButtonClick += new ToolBarButtonClickEventHandler(imageToolBar_ButtonClick);
            // 
            cloneButton.ImageIndex = 0;
            cloneButton.Name = "cloneButton";
            cloneButton.ToolTipText = "Клонировать Изображение";
            // 
            toolBarButton1.Name = "toolBarButton1";
            toolBarButton1.Style = ToolBarButtonStyle.Separator;
            // 
            cropButton.ImageIndex = 1;
            cropButton.Name = "cropButton";
            cropButton.ToolTipText = "Обрезать изображение";
            // 
            toolBarButton2.Name = "toolBarButton2";
            toolBarButton2.Style = ToolBarButtonStyle.Separator;
            // 
            zoomInButton.ImageIndex = 2;
            zoomInButton.Name = "zoomInButton";
            zoomInButton.ToolTipText = "Уменьшить";
            // 
            zoomOutButton.ImageIndex = 3;
            zoomOutButton.Name = "zoomOutButton";
            zoomOutButton.ToolTipText = "Уаеличить";
            // 
            toolBarButton3.ImageIndex = 4;
            toolBarButton3.Name = "toolBarButton3";
            toolBarButton3.ToolTipText = "Оригенальный размер";
            // 
            fitToScreenButton.ImageIndex = 5;
            fitToScreenButton.Name = "fitToScreenButton";
            fitToScreenButton.ToolTipText = "Полный экран";
            // 
             // imageList2 подвижное меню
            // 
            imageList2.ImageStream = ((ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            imageList2.TransparentColor = Color.Transparent;
            imageList2.Images.SetKeyName(0, "");
            imageList2.Images.SetKeyName(1, "");
            imageList2.Images.SetKeyName(2, "");
            imageList2.Images.SetKeyName(3, "");
            imageList2.Images.SetKeyName(4, "");
            imageList2.Images.SetKeyName(5, "");
            imageList2.Images.SetKeyName(6, "");
            imageList2.Images.SetKeyName(7, "");

            // 
            saveButton.Name = "saveButton";
            // 
            copyButton.Name = "copyButton";
            // 
            pasteButton.Name = "pasteButton";
            // 
            toolBarButton9.Name = "toolBarButton9";
            // 
            toolBarButton4.Name = "toolBarButton4";
            // 
            openButton.ImageIndex = 0;
            openButton.Name = "openButton";
            openButton.ToolTipText = "Open an image ";
            // 
            ofd.Filter = "Image files (*.jpg,*.png,*.tif,*.bmp,*.gif)|*.jpg;*.png;*.tif;*.bmp;*.gif|JPG fil" +
    "es (*.jpg)|*.jpg|PNG files (*.png)|*.png|TIF files (*.tif)|*.tif|BMP files (*.bm" +
    "p)|*.bmp|GIF files (*.gif)|*.gif";
            ofd.Title = "Открыть картинку";
            // 
            sfd.Filter = "JPG files (*.jpg)|*.jpg|BMP files (*.bmp)|*.bmp";
            sfd.Title = "Сохранить картинку";
            // 
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            // 
            printPreviewDialog.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog.ClientSize = new Size(400, 300);
            printPreviewDialog.Enabled = true;
            printPreviewDialog.Icon = ((Icon)(resources.GetObject("printPreviewDialog.Icon")));
            printPreviewDialog.Name = "printPreviewDialog";
            printPreviewDialog.Visible = false;
            //****************************************************************************************************** 
            // Главная окно
            AutoScaleBaseSize = new Size(5, 13);
            ClientSize = new Size(792, 533);
            Controls.Add(panel1);
            IsMdiContainer = true;
            Menu = mainMenu;
            Name = "Главная";
            Text = "Графический редактор с использованием фильтров";
            Closing += new System.ComponentModel.CancelEventHandler(MainForm_Closing);
            panel1.ResumeLayout(false);
            dockManager.ResumeLayout(false);
            dockManager.PerformLayout();
            ResumeLayout(false);

        }
        /// точка входа в приложение.

        [STAThread]
        static void Main()
        {
            Application.Run(new Главная());
        }

        #region IDocumentsHost implementation
// Создаем новый документ при изменении существующего или изменяем его
        public bool CreateNewDocumentOnChange
        {
            get { return config.openInNewDoc; }
        }
//   чтобы мы могли вернуться на шаг назад
        public bool RememberOnChange
        {
            get { return config.rememberOnChange; }
        }

        // Создать новый документ
        public bool NewDocument(Bitmap image)
        {
            unnamedNumber++;

            ImageDoc imgDoc = new ImageDoc(image, (IDocumentsHost)this);

            imgDoc.Text = "Image " + unnamedNumber.ToString();
            imgDoc.Show(dockManager);
            imgDoc.Focus();
             // установить события
            //SetupDocumentEvents(imgDoc);
             return true;
        }
//***************************************************************************************************
        // Создать новый документ для сложного изображения
        public bool NewDocument(ComplexImage image)
        {
            unnamedNumber++;

           // FourierDoc imgDoc = new FourierDoc(image, (IDocumentsHost)this);

          //  imgDoc.Text = "Image " + unnamedNumber.ToString();
           // imgDoc.Show(dockManager);
           // imgDoc.Focus();

            return true;
        }
//*********************************************************************************************************
        // Получить изображение с заданным размером и форматом пикселей
        public Bitmap GetImage(object sender, String text, Size size, PixelFormat format)
        {
            ArrayList names = new ArrayList();
            ArrayList images = new ArrayList();

            foreach (Content doc in dockManager.Documents)
            {
                if ((doc != sender) && (doc is ImageDoc))
                {
                    Bitmap img = ((ImageDoc)doc).Image;

                    // проверить формат, ширину и высоту пикселей
                    if ((img.PixelFormat == format) &&
                        ((size.Width == -1) ||
                        ((img.Width == size.Width) && (img.Height == size.Height))))
                    {
                        names.Add(doc.Text);
                        images.Add(img);
                    }
                }
            }

            return null;
        }

        #endregion


        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //закрыть все
            foreach (Content c in dockManager.Documents)
                c.Close();

            // сохранить конфигурацию
            config.mainWindowLocation = Location;
            config.mainWindowSize = Size;
        }

        // активный документ изменен
        private void dockManager_ActiveDocumentChanged(object sender, EventArgs e)
        {
            Content doc = dockManager.ActiveDocument;
            ImageDoc imgDoc = (doc is ImageDoc) ? (ImageDoc)doc : null;
         }


        private void fileItem_Popup(object sender, EventArgs e)
        {
            Content doc = dockManager.ActiveDocument;
            bool docOpened = (doc != null);

            closeFileItem.Enabled = docOpened;
            closeAllFileItem.Enabled = (dockManager.Documents.Length > 0);
            saveFileItem.Enabled = docOpened;
            copyFileItem.Enabled = docOpened;
            pasteFileItem.Enabled = (Clipboard.GetDataObject().GetDataPresent(DataFormats.Bitmap));
           //printFileItem.Enabled = docOpened;
            printPreviewFileItem.Enabled = docOpened;
        }
//**************************************************************************
        // ВЫход
        private void exitFileItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    
//*********************************************************************************
        // открыть фаил
        private void OpenFile()
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ImageDoc imgDoc = null;

                try
                {
                    //создать
                    imgDoc = new ImageDoc(ofd.FileName, (IDocumentsHost)this);
                    imgDoc.Text = Path.GetFileName(ofd.FileName);

                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show(ex.Message, "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (imgDoc != null)
                {
                    imgDoc.Show(dockManager);
                    imgDoc.Focus();
                }
            }
        }

        //    открыть фаил
        private void OpenItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
//**************************************************************************
  //Сохранить фаил
        private void SaveFile()
        {
            Content doc = dockManager.ActiveDocument;

            if (doc != null)
            {
                if ((doc is ImageDoc) && (((ImageDoc)doc).FileName != null))
                {
                    sfd.FileName = Path.GetFileName(((ImageDoc)doc).FileName);
                }
                else
                {
                    sfd.FileName = doc.Text + ".jpg";
                }

                sfd.FilterIndex = 0;

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    ImageFormat format = ImageFormat.Jpeg;

                    // формат
                    switch (Path.GetExtension(sfd.FileName).ToLower())
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        default:
                            MessageBox.Show(this, "Unsupported image format was specified", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    // сохранить
                    try
                    {
                        if (doc is ImageDoc)
                        {
                            ((ImageDoc)doc).Image.Save(sfd.FileName, format);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(this, "Невозможно сохранить", "ОШИБКА",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // сохранить
        private void saveFileItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
//**********************************************************************
        // копирование
        private void CopyToClipboard()
        {
            Content doc = dockManager.ActiveDocument;

            if (doc != null)
            {
                if (doc is ImageDoc)
                {
                    Clipboard.SetDataObject(((ImageDoc)doc).Image, true);
                }
            }
        }

        // копирование
        private void copyFileItem_Click(object sender, EventArgs e)
        {
            CopyToClipboard();
        }
//************************************************************************************************
        // вставка
        private void PasteFromClipboard()
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Bitmap))
            {
                ImageDoc imgDoc = new ImageDoc((Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap), (IDocumentsHost)this);

                imgDoc.Text = "Image " + unnamedNumber.ToString();
                imgDoc.Show(dockManager);
                imgDoc.Focus();

            }
        }
         // вставка
        private void pasteFileItem_Click(object sender, EventArgs e)
        {
            PasteFromClipboard();
        }
//****************************************************************************************
        // закрыть файл
        private void closeFileItem_Click(object sender, EventArgs e)
        {
            if (dockManager.ActiveDocument != null)
                dockManager.ActiveDocument.Close();
        }
         //Закрыть все файлы
        private void closeAllFileItem_Click(object sender, EventArgs e)
        {
            foreach (Content c in dockManager.Documents)
                c.Close();
        }
//*******************************************************************************************************
        // Настройка страницы
        private void pageSetupFileItem_Click(object sender, EventArgs e)
        {
            try
            {
                pageSetupDialog.Document = printDocument;
                pageSetupDialog.ShowDialog();
            }
            catch (InvalidPrinterException)
            {
                MessageBox.Show(this, "Ошибка доступа к принтеру ", " Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
//***************************************************************************************
        // Распечатка
        private void printFileItem_Click(object sender, EventArgs e)
        {
            if (dockManager.ActiveDocument != null)
            {
                try
                {
                    printDialog.Document = printDocument;
                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        printDocument.Print();
                    }
                }
                catch (InvalidPrinterException)
                {
                    MessageBox.Show(this, "Ошибка доступа к принтеру ", " Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
//********************************************************************************************
        //Предварительный просмотр печати
        private void printPreviewFileItem_Click(object sender, EventArgs e)
        {
            if (dockManager.ActiveDocument != null)
            {
                try
                {
                    printPreviewDialog.Document = printDocument;
                    printPreviewDialog.ShowDialog();
                }
                catch (InvalidPrinterException)
                {
                    MessageBox.Show(this, "Ошибка доступа к принтеру ", " Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
      

//**********************************************************************************************
        //выплывающее меню
        private void imageToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            Content doc = dockManager.ActiveDocument;

            if (doc != null)
            {
                if (doc is ImageDoc)
                {
                    ImageDocCommands[] cmd = new ImageDocCommands[]
                    {
                        ImageDocCommands.Clone, ImageDocCommands.Crop,
                        ImageDocCommands.ZoomIn, ImageDocCommands.ZoomOut,
                        ImageDocCommands.ZoomOriginal, ImageDocCommands.FitToSize 
                    };

                    ((ImageDoc)doc).ExecuteCommand(cmd[e.Button.ImageIndex]);
                }
            }
        }

        // Панель инструментов изображения при нажмите
        private void imageBarViewItem_Click(object sender, EventArgs e)
        {
            ToolBarDockHolder holder = toolBarManager.GetHolder(imageToolBar);
            toolBarManager.ShowControl(imageToolBar, !holder.Visible);
        }
//*********************************************************************
        //Распечатать страницу документа
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Content doc = dockManager.ActiveDocument;

            if (doc != null)
            {
                Bitmap image = null;

                // получить изображение для печати
                if (doc is ImageDoc)
                {
                    image = ((ImageDoc)doc).Image;
                }
                System.Diagnostics.Debug.WriteLine("X: " + e.MarginBounds.Left + ", Y = " + e.MarginBounds.Top + ", width = " + e.MarginBounds.Width + ", height = " + e.MarginBounds.Height);
                System.Diagnostics.Debug.WriteLine("X: " + e.PageBounds.Left + ", Y = " + e.PageBounds.Top + ", width = " + e.PageBounds.Width + ", height = " + e.PageBounds.Height);

                int width = image.Width;
                int height = image.Height;

                if ((width > e.MarginBounds.Width) || (height > e.MarginBounds.Height))
                {
                    float f = Math.Min((float)e.MarginBounds.Width / width, (float)e.MarginBounds.Height / height);

                    width = (int)(f * width);
                    height = (int)(f * height);
                }

                e.Graphics.DrawImage(image, e.MarginBounds.Left, e.MarginBounds.Top, width, height);
            }
        }

        private void dockManager_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
