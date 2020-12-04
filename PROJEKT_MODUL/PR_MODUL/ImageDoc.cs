using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI;

using AForge;
using AForge.Imaging.Filters;

namespace PR_MODUL
{

    public class ImageDoc : Content
    {
        private Bitmap backup = null;
        private Bitmap image = null;
        private IDocumentsHost host = null;

        private bool cropping = false;
        private bool dragging = false;
        private Point start, end, startW, endW;

        private MainMenu mainMenu;
        private MenuItem imageItem;
        private MenuItem filtersItem;
        private MenuItem cloneImageItem;
        private MenuItem rotateColorFiltersItem;
        private MenuItem invertColorFiltersItem;
        private MenuItem sepiaColorFiltersItem;
        private MenuItem menuItem2;
        private MenuItem backImageItem;
        private MenuItem menuItem4;
        private MenuItem menuItem5;
        private MenuItem menuItem6;
        private MenuItem menuItem7;
        private MenuItem z10ImageItem;
        private MenuItem z25ImageItem;
        private MenuItem z50ImageItem;
        private MenuItem z75ImageItem;
        private MenuItem z100ImageItem;
        private MenuItem z150ImageItem;
        private MenuItem z200ImageItem;
        private MenuItem z400ImageItem;
        private MenuItem z500ImageItem;
        private MenuItem menuItem8;
        private MenuItem zoomInImageItem;
        private MenuItem zoomOutImageItem;
        private MenuItem menuItem11;
        private MenuItem zoomFitImageItem;
        private MenuItem colorFiltersItem;
        private MenuItem binaryFiltersItem;
        private MenuItem floydBinaryFiltersItem;
        private MenuItem morphologyFiltersItem;
        private MenuItem dilatationMorphologyFiltersItem;
        private MenuItem convolutionFiltersItem;
        private MenuItem meanConvolutionFiltersItem;
        private MenuItem blurConvolutionFiltersItem;
        private MenuItem edgesConvolutionFiltersItem;
        private MenuItem flipImageItem;
        private MenuItem mirrorItem;
        private MenuItem rotateImageItem;
        private MenuItem menuItem10;
        private MenuItem cropImageItem;
        private MenuItem menuItem3;
        private MenuItem openingMorphologyFiltersItem;
        private MenuItem medianFiltersItem;
        private MenuItem closingMorphologyFiltersItem;
        private MenuItem erosionMorphologyFiltersItem;
        private MenuItem menuItem16;
        private MenuItem redColorFiltersItem;
        private MenuItem greenColorFiltersItem;
        private MenuItem blueColorFiltersItem;
        private MenuItem menuItem17;
        private MenuItem cyanColorFiltersItem;
        private MenuItem magentaColorFiltersItem;
        private MenuItem yellowColorFiltersItem;
        private MenuItem orderedDitherBinaryFiltersItem;
        private MenuItem menuItem14;
        private MenuItem bayerDitherBinaryFiltersItem;
        private MenuItem burkesBinaryFiltersItem;
        private MenuItem stuckiBinaryFiltersItem;
        private MenuItem jarvisBinaryFiltersItem;
        private MenuItem sierraBinaryFiltersItem;
        private MenuItem stevensonBinaryFiltersItem;
        private MenuItem resizeFiltersItem;
        private MenuItem menuItem26;
        private MenuItem rotateFiltersItem;
        private MenuItem edgeFiltersItem;
        private MenuItem homogenityEdgeFiltersItem;
        private MenuItem differenceEdgeFiltersItem;
        private MenuItem sobelEdgeFiltersItem;
        private MenuItem menuItem31;
        private MenuItem sisThresholdBinaryFiltersItem;
        private MenuItem cannyEdgeFiltersItem;
        private System.ComponentModel.IContainer components;

        // Свойство изображения
        public Bitmap Image
        {
            get { return image; }
        }
        // Width Свойство
        public int ImageWidth { get; private set; }
        // Height Свойство
        public int ImageHeight { get; private set; }
        // Zoom Свойство
        public float Zoom { get; private set; } = 1;
        // возвращает имя файла, если документ был создан из файла или null
        public string FileName { get; } = null;


        // События
        public delegate void SelectionEventHandler(object sender, SelectionEventArgs e);

        //public event EventHandler DocumentChanged;
        public event EventHandler ZoomChanged;
        public event SelectionEventHandler MouseImagePosition;
       // public event SelectionEventHandler SelectionChanged;


        // Конструктор
        private ImageDoc(IDocumentsHost host)
        {
            this.host = host;
        }
        // Построить из файла
        public ImageDoc(string fileName, IDocumentsHost host)
            : this(host)
        {
            try
            {
                // загруженное изображение
                image = (Bitmap)System.Drawing.Image.FromFile(fileName);

                // формат изображения
                AForge.Imaging.Image.FormatImage(ref image);

                FileName = fileName;
            }
            catch (Exception)
            {
                throw new ApplicationException("Неудачная загрузка изображения");
            }

            Init();
        }
        // Построить из изображения
        public ImageDoc(Bitmap image, IDocumentsHost host)
            : this(host)
        {
            this.image = image;
            AForge.Imaging.Image.FormatImage(ref this.image);

            Init();
        }

        //Очистите все используемые ресурсы.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                if (image != null)
                {
                    image.Dispose();
                }
            }
            base.Dispose(disposing);
        }

      
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mainMenu = new MainMenu(components);
            imageItem = new MenuItem();
            backImageItem = new MenuItem();
            cloneImageItem = new MenuItem();
            menuItem4 = new MenuItem();
            menuItem5 = new MenuItem();
            z10ImageItem = new MenuItem();
            z25ImageItem = new MenuItem();
            z50ImageItem = new MenuItem();
            z75ImageItem = new MenuItem();
            menuItem7 = new MenuItem();
            z100ImageItem = new MenuItem();
            menuItem6 = new MenuItem();
            z150ImageItem = new MenuItem();
            z200ImageItem = new MenuItem();
            z400ImageItem = new MenuItem();
            z500ImageItem = new MenuItem();
            menuItem8 = new MenuItem();
            zoomInImageItem = new MenuItem();
            zoomOutImageItem = new MenuItem();
            menuItem11 = new MenuItem();
            zoomFitImageItem = new MenuItem();
            menuItem10 = new MenuItem();
            flipImageItem = new MenuItem();
            mirrorItem = new MenuItem();
            rotateImageItem = new MenuItem();
            menuItem3 = new MenuItem();
            cropImageItem = new MenuItem();
            filtersItem = new MenuItem();
            colorFiltersItem = new MenuItem();
            sepiaColorFiltersItem = new MenuItem();
            menuItem2 = new MenuItem();
            invertColorFiltersItem = new MenuItem();
            rotateColorFiltersItem = new MenuItem();
            menuItem16 = new MenuItem();
            redColorFiltersItem = new MenuItem();
            greenColorFiltersItem = new MenuItem();
            blueColorFiltersItem = new MenuItem();
            menuItem17 = new MenuItem();
            cyanColorFiltersItem = new MenuItem();
            magentaColorFiltersItem = new MenuItem();
            yellowColorFiltersItem = new MenuItem();
            binaryFiltersItem = new MenuItem();
            orderedDitherBinaryFiltersItem = new MenuItem();
            bayerDitherBinaryFiltersItem = new MenuItem();
            menuItem14 = new MenuItem();
            floydBinaryFiltersItem = new MenuItem();
            burkesBinaryFiltersItem = new MenuItem();
            stuckiBinaryFiltersItem = new MenuItem();
            jarvisBinaryFiltersItem = new MenuItem();
            sierraBinaryFiltersItem = new MenuItem();
            stevensonBinaryFiltersItem = new MenuItem();
            menuItem31 = new MenuItem();
            sisThresholdBinaryFiltersItem = new MenuItem();
            morphologyFiltersItem = new MenuItem();
            erosionMorphologyFiltersItem = new MenuItem();
            dilatationMorphologyFiltersItem = new MenuItem();
            openingMorphologyFiltersItem = new MenuItem();
            closingMorphologyFiltersItem = new MenuItem();
            convolutionFiltersItem = new MenuItem();
            meanConvolutionFiltersItem = new MenuItem();
            blurConvolutionFiltersItem = new MenuItem();
            edgesConvolutionFiltersItem = new MenuItem();
            edgeFiltersItem = new MenuItem();
            homogenityEdgeFiltersItem = new MenuItem();
            differenceEdgeFiltersItem = new MenuItem();
            sobelEdgeFiltersItem = new MenuItem();
            cannyEdgeFiltersItem = new MenuItem();
            resizeFiltersItem = new MenuItem();
            rotateFiltersItem = new MenuItem();
            menuItem26 = new MenuItem();
            medianFiltersItem = new MenuItem();
            SuspendLayout();
            // 
            // mainMenu
            // 
            mainMenu.MenuItems.AddRange(new MenuItem[] {
            imageItem,
            filtersItem});
            // 
            // imageItem
            // 
            imageItem.Index = 0;
            imageItem.MenuItems.AddRange(new MenuItem[] {
            backImageItem,
            cloneImageItem,
            menuItem4,
            menuItem5,
            menuItem10,
            flipImageItem,
            mirrorItem,
            rotateImageItem,
            menuItem3,
            cropImageItem});
            imageItem.MergeOrder = 1;
            imageItem.Text = "Изображение";
            imageItem.Popup += new EventHandler(imageItem_Popup);
            // 
            // backImageItem
            // 
            backImageItem.Index = 0;
            backImageItem.Shortcut = Shortcut.CtrlZ;
            backImageItem.Text = "Назад";
            backImageItem.Click += new EventHandler(backImageItem_Click);
            // 
            // cloneImageItem
            // 
            cloneImageItem.Index = 1;
            cloneImageItem.Shortcut = Shortcut.CtrlN;
            cloneImageItem.Text = "Копия";
            cloneImageItem.Click += new EventHandler(cloneImageItem_Click);
            // 
            // menuItem4
            // 
            menuItem4.Index = 2;
            menuItem4.Text = "-";
            menuItem4.Click += new EventHandler(menuItem4_Click);
            // 
            // menuItem5
            // 
            menuItem5.Index = 3;
            menuItem5.MenuItems.AddRange(new MenuItem[] {
            z10ImageItem,
            z25ImageItem,
            z50ImageItem,
            z75ImageItem,
            menuItem7,
            z100ImageItem,
            menuItem6,
            z150ImageItem,
            z200ImageItem,
            z400ImageItem,
            z500ImageItem,
            menuItem8,
            zoomInImageItem,
            zoomOutImageItem,
            menuItem11,
            zoomFitImageItem});
            menuItem5.Text = "Увеличение";
            // 
            // z10ImageItem
            // 
            z10ImageItem.Index = 0;
            z10ImageItem.Text = "10%";
            z10ImageItem.Click += new EventHandler(zoomItem_Click);
            // 
            // z25ImageItem
            // 
            z25ImageItem.Index = 1;
            z25ImageItem.Text = "25%";
            z25ImageItem.Click += new EventHandler(zoomItem_Click);
            // 
            // z50ImageItem
            // 
            z50ImageItem.Index = 2;
            z50ImageItem.Text = "50%";
            z50ImageItem.Click += new EventHandler(zoomItem_Click);
            // 
            // z75ImageItem
            // 
            z75ImageItem.Index = 3;
            z75ImageItem.Text = "75%";
            z75ImageItem.Click += new EventHandler(zoomItem_Click);
            // 
            // menuItem7
            // 
            menuItem7.Index = 4;
            menuItem7.Text = "-";
            // 
            // z100ImageItem
            // 
            z100ImageItem.Index = 5;
            z100ImageItem.Shortcut = Shortcut.Ctrl0;
            z100ImageItem.Text = "100%";
            z100ImageItem.Click += new EventHandler(zoomItem_Click);
            // 
            // menuItem6
            // 
            menuItem6.Index = 6;
            menuItem6.Text = "-";
            // 
            // z150ImageItem
            // 
            z150ImageItem.Index = 7;
            z150ImageItem.Text = "150%";
            z150ImageItem.Click += new EventHandler(zoomItem_Click);
            // 
            // z200ImageItem
            // 
            z200ImageItem.Index = 8;
            z200ImageItem.Text = "200%";
            z200ImageItem.Click += new EventHandler(zoomItem_Click);
            // 
            // z400ImageItem
            // 
            z400ImageItem.Index = 9;
            z400ImageItem.Text = "400%";
            z400ImageItem.Click += new EventHandler(zoomItem_Click);
            // 
            // z500ImageItem
            // 
            z500ImageItem.Index = 10;
            z500ImageItem.Text = "500%";
            z500ImageItem.Click += new EventHandler(zoomItem_Click);
            // 
            // menuItem8
            // 
            menuItem8.Index = 11;
            menuItem8.Text = "-";
            // 
            // zoomInImageItem
            // 
            zoomInImageItem.Index = 12;
            zoomInImageItem.Shortcut = Shortcut.Ctrl8;
            zoomInImageItem.Text = "Увеличить";
            zoomInImageItem.Click += new EventHandler(zoomInImageItem_Click);
            // 
            // zoomOutImageItem
            // 
            zoomOutImageItem.Index = 13;
            zoomOutImageItem.Shortcut = Shortcut.Ctrl7;
            zoomOutImageItem.Text = "Уменьшить";
            zoomOutImageItem.Click += new EventHandler(zoomOutImageItem_Click);
            // 
            // menuItem11
            // 
            menuItem11.Index = 14;
            menuItem11.Text = "-";
            // 
            // zoomFitImageItem
            // 
            zoomFitImageItem.Index = 15;
            zoomFitImageItem.Shortcut = Shortcut.Ctrl9;
            zoomFitImageItem.Text = "По размеру экрана";
            zoomFitImageItem.Click += new EventHandler(zoomFitImageItem_Click);
            // 
            // menuItem10
            // 
            menuItem10.Index = 4;
            menuItem10.Text = "-";
            // 
            // flipImageItem
            // 
            flipImageItem.Index = 5;
            flipImageItem.Text = "Сальто";
            flipImageItem.Click += new EventHandler(flipImageItem_Click);
            // 
            // mirrorItem
            // 
            mirrorItem.Index = 6;
            mirrorItem.Text = "Развернуть по вертикали";
            mirrorItem.Click += new EventHandler(mirrorItem_Click);
            // 
            // rotateImageItem
            // 
            rotateImageItem.Index = 7;
            rotateImageItem.Text = "Развернуть по горизонтали";
            rotateImageItem.Click += new EventHandler(rotateImageItem_Click);
            // 
            // menuItem3
            // 
            menuItem3.Index = 8;
            menuItem3.Text = "-";
            // 
            // cropImageItem
            // 
            cropImageItem.Index = 9;
            cropImageItem.Shortcut = Shortcut.CtrlE;
            cropImageItem.Text = "Обрезать";
            cropImageItem.Click += new EventHandler(cropImageItem_Click);
            // 
            // filtersItem
            // 
            filtersItem.Index = 1;
            filtersItem.MenuItems.AddRange(new MenuItem[] {
            colorFiltersItem,
            binaryFiltersItem,
            morphologyFiltersItem,
            convolutionFiltersItem,
            edgeFiltersItem,
            resizeFiltersItem,
            rotateFiltersItem,
            menuItem26,
            medianFiltersItem});
            filtersItem.MergeOrder = 1;
            filtersItem.Text = "Фильтры";
            // 
            // colorFiltersItem
            // 
            colorFiltersItem.Index = 0;
            colorFiltersItem.MenuItems.AddRange(new MenuItem[] {
            sepiaColorFiltersItem,
            menuItem2,
            invertColorFiltersItem,
            rotateColorFiltersItem,
            menuItem16,
            redColorFiltersItem,
            greenColorFiltersItem,
            blueColorFiltersItem,
            menuItem17,
            cyanColorFiltersItem,
            magentaColorFiltersItem,
            yellowColorFiltersItem});
            colorFiltersItem.Text = "&Цветные";
            // 
            // sepiaColorFiltersItem
            // 
            sepiaColorFiltersItem.Index = 0;
            sepiaColorFiltersItem.Text = "&Сепия";
            sepiaColorFiltersItem.Click += new EventHandler(sepiaColorFiltersItem_Click);
            // 
            // menuItem2
            // 
            menuItem2.Index = 1;
            menuItem2.Text = "-";
            // 
            // invertColorFiltersItem
            // 
            invertColorFiltersItem.Index = 2;
            invertColorFiltersItem.Text = "&Инвентировать";
            invertColorFiltersItem.Click += new EventHandler(invertColorFiltersItem_Click);
            // 
            // rotateColorFiltersItem
            // 
            rotateColorFiltersItem.Index = 3;
            rotateColorFiltersItem.Text = "&Вращать";
            rotateColorFiltersItem.Click += new EventHandler(rotateColorFiltersItem_Click);
            // 
            // menuItem16
            // 
            menuItem16.Index = 4;
            menuItem16.Text = "-";
            // 
            // redColorFiltersItem
            // 
            redColorFiltersItem.Index = 5;
            redColorFiltersItem.Text = "Красный";
            redColorFiltersItem.Click += new EventHandler(redColorFiltersItem_Click);
            // 
            // greenColorFiltersItem
            // 
            greenColorFiltersItem.Index = 6;
            greenColorFiltersItem.Text = "Зеленый";
            greenColorFiltersItem.Click += new EventHandler(greenColorFiltersItem_Click);
            // 
            // blueColorFiltersItem
            // 
            blueColorFiltersItem.Index = 7;
            blueColorFiltersItem.Text = "Синий";
            blueColorFiltersItem.Click += new EventHandler(blueColorFiltersItem_Click);
            // 
            // menuItem17
            // 
            menuItem17.Index = 8;
            menuItem17.Text = "-";
            // 
            // cyanColorFiltersItem
            // 
            cyanColorFiltersItem.Index = 9;
            cyanColorFiltersItem.Text = "Бирюзовый";
            cyanColorFiltersItem.Click += new EventHandler(cyanColorFiltersItem_Click);
            // 
            // magentaColorFiltersItem
            // 
            magentaColorFiltersItem.Index = 10;
            magentaColorFiltersItem.Text = "Пурпурный";
            magentaColorFiltersItem.Click += new EventHandler(magentaColorFiltersItem_Click);
            // 
            // yellowColorFiltersItem
            // 
            yellowColorFiltersItem.Index = 11;
            yellowColorFiltersItem.Text = "Желтый";
            yellowColorFiltersItem.Click += new EventHandler(yellowColorFiltersItem_Click);
            // 
            // binaryFiltersItem
            // 
            binaryFiltersItem.Index = 1;
            binaryFiltersItem.MenuItems.AddRange(new MenuItem[] {
            orderedDitherBinaryFiltersItem,
            bayerDitherBinaryFiltersItem,
            menuItem14,
            floydBinaryFiltersItem,
            burkesBinaryFiltersItem,
            stuckiBinaryFiltersItem,
            jarvisBinaryFiltersItem,
            sierraBinaryFiltersItem,
            stevensonBinaryFiltersItem,
            menuItem31,
            sisThresholdBinaryFiltersItem});
            binaryFiltersItem.Text = "Бинаризация";
            // 
            // orderedDitherBinaryFiltersItem
            // 
            orderedDitherBinaryFiltersItem.Index = 0;
            orderedDitherBinaryFiltersItem.Text = "Упорядоченное Размывание";
            orderedDitherBinaryFiltersItem.Click += new EventHandler(orderedDitherBinaryFiltersItem_Click);
            // 
            // bayerDitherBinaryFiltersItem
            // 
            bayerDitherBinaryFiltersItem.Index = 1;
            bayerDitherBinaryFiltersItem.Text = "Упорядоченное Размывание Dither";
            bayerDitherBinaryFiltersItem.Click += new EventHandler(bayerDitherBinaryFiltersItem_Click);
            // 
            // menuItem14
            // 
            menuItem14.Index = 2;
            menuItem14.Text = "-";
            // 
            // floydBinaryFiltersItem
            // 
            floydBinaryFiltersItem.Index = 3;
            floydBinaryFiltersItem.Text = "Флойда Стейнберга";
            floydBinaryFiltersItem.Click += new EventHandler(floydBinaryFiltersItem_Click);
            // 
            // burkesBinaryFiltersItem
            // 
            burkesBinaryFiltersItem.Index = 4;
            burkesBinaryFiltersItem.Text = "Заминание";
            burkesBinaryFiltersItem.Click += new EventHandler(burkesBinaryFiltersItem_Click);
            // 
            // stuckiBinaryFiltersItem
            // 
            stuckiBinaryFiltersItem.Index = 5;
            stuckiBinaryFiltersItem.Text = "Stucki";
            stuckiBinaryFiltersItem.Click += new EventHandler(stuckiBinaryFiltersItem_Click);
            // 
            // jarvisBinaryFiltersItem
            // 
            jarvisBinaryFiltersItem.Index = 6;
            jarvisBinaryFiltersItem.Text = "Jarvis-Judice-Ninke";
            jarvisBinaryFiltersItem.Click += new EventHandler(jarvisBinaryFiltersItem_Click);
            // 
            // sierraBinaryFiltersItem
            // 
            sierraBinaryFiltersItem.Index = 7;
            sierraBinaryFiltersItem.Text = "Горная цепь";
            sierraBinaryFiltersItem.Click += new EventHandler(sierraBinaryFiltersItem_Click);
            // 
            // stevensonBinaryFiltersItem
            // 
            stevensonBinaryFiltersItem.Index = 8;
            stevensonBinaryFiltersItem.Text = "Стивенсон и Арс";
            stevensonBinaryFiltersItem.Click += new EventHandler(stevensonBinaryFiltersItem_Click);
            // 
            // menuItem31
            // 
            menuItem31.Index = 9;
            menuItem31.Text = "-";
            // 
            // sisThresholdBinaryFiltersItem
            // 
            sisThresholdBinaryFiltersItem.Index = 10;
            sisThresholdBinaryFiltersItem.Text = "SIS Порог";
            sisThresholdBinaryFiltersItem.Click += new EventHandler(sisThresholdBinaryFiltersItem_Click);
            // 
            // morphologyFiltersItem
            // 
            morphologyFiltersItem.Index = 2;
            morphologyFiltersItem.MenuItems.AddRange(new MenuItem[] {
            erosionMorphologyFiltersItem,
            dilatationMorphologyFiltersItem,
            openingMorphologyFiltersItem,
            closingMorphologyFiltersItem});
            morphologyFiltersItem.Text = "Морфология";
            // 
            // erosionMorphologyFiltersItem
            // 
            erosionMorphologyFiltersItem.Index = 0;
            erosionMorphologyFiltersItem.Text = "Эрозия";
            erosionMorphologyFiltersItem.Click += new EventHandler(erosionMorphologyFiltersItem_Click);
            // 
            // dilatationMorphologyFiltersItem
            // 
            dilatationMorphologyFiltersItem.Index = 1;
            dilatationMorphologyFiltersItem.Text = "Расширение";
            dilatationMorphologyFiltersItem.Click += new EventHandler(dilatationMorphologyFiltersItem_Click);
            // 
            // openingMorphologyFiltersItem
            // 
            openingMorphologyFiltersItem.Index = 2;
            openingMorphologyFiltersItem.Text = "Открытие";
            openingMorphologyFiltersItem.Click += new EventHandler(openingMorphologyFiltersItem_Click);
            // 
            // closingMorphologyFiltersItem
            // 
            closingMorphologyFiltersItem.Index = 3;
            closingMorphologyFiltersItem.Text = "Закрытие";
            closingMorphologyFiltersItem.Click += new EventHandler(closingMorphologyFiltersItem_Click);
            // 
            // convolutionFiltersItem
            // 
            convolutionFiltersItem.Index = 3;
            convolutionFiltersItem.MenuItems.AddRange(new MenuItem[] {
            meanConvolutionFiltersItem,
            blurConvolutionFiltersItem,
            edgesConvolutionFiltersItem});
            convolutionFiltersItem.Text = "Свертка и Корреляция";
            // 
            // meanConvolutionFiltersItem
            // 
            meanConvolutionFiltersItem.Index = 0;
            meanConvolutionFiltersItem.Text = "Mean";
            meanConvolutionFiltersItem.Click += new EventHandler(meanConvolutionFiltersItem_Click);
            // 
            // blurConvolutionFiltersItem
            // 
            blurConvolutionFiltersItem.Index = 1;
            blurConvolutionFiltersItem.Text = "Пятно";
            blurConvolutionFiltersItem.Click += new EventHandler(blurConvolutionFiltersItem_Click);
            // 
            // edgesConvolutionFiltersItem
            // 
            edgesConvolutionFiltersItem.Index = 2;
            edgesConvolutionFiltersItem.Text = "Края";
            edgesConvolutionFiltersItem.Click += new EventHandler(edgesConvolutionFiltersItem_Click);
            // 
            // edgeFiltersItem
            // 
            edgeFiltersItem.Index = 4;
            edgeFiltersItem.MenuItems.AddRange(new MenuItem[] {
            homogenityEdgeFiltersItem,
            differenceEdgeFiltersItem,
            sobelEdgeFiltersItem,
            cannyEdgeFiltersItem});
            edgeFiltersItem.Text = "Края детекторы";
            // 
            // homogenityEdgeFiltersItem
            // 
            homogenityEdgeFiltersItem.Index = 0;
            homogenityEdgeFiltersItem.Text = "Однородность";
            homogenityEdgeFiltersItem.Click += new EventHandler(homogenityEdgeFiltersItem_Click);
            // 
            // differenceEdgeFiltersItem
            // 
            differenceEdgeFiltersItem.Index = 1;
            differenceEdgeFiltersItem.Text = "Различность";
            differenceEdgeFiltersItem.Click += new EventHandler(differenceEdgeFiltersItem_Click);
            // 
            // sobelEdgeFiltersItem
            // 
            sobelEdgeFiltersItem.Index = 2;
            sobelEdgeFiltersItem.Text = "Sobel";
            sobelEdgeFiltersItem.Click += new EventHandler(sobelEdgeFiltersItem_Click);
            // 
            // cannyEdgeFiltersItem
            // 
            cannyEdgeFiltersItem.Index = 3;
            cannyEdgeFiltersItem.Text = "";
            // 
            // resizeFiltersItem
            // 
            resizeFiltersItem.Index = 5;
            resizeFiltersItem.Text = "Изменить размер";
            resizeFiltersItem.Click += new EventHandler(resizeFiltersItem_Click);
            // 
            // rotateFiltersItem
            // 
            rotateFiltersItem.Index = 6;
            rotateFiltersItem.Text = "Поворот";
            rotateFiltersItem.Click += new EventHandler(rotateFiltersItem_Click);
            // 
            // menuItem26
            // 
            menuItem26.Index = 7;
            menuItem26.Text = "-";
            // 
            // medianFiltersItem
            // 
            medianFiltersItem.Index = 8;
            medianFiltersItem.Text = "Медианный";
            medianFiltersItem.Click += new EventHandler(medianFiltersItem_Click);
            // 
            // ImageDoc
            // 
            AllowedStates = ContentStates.Document;
            AutoScaleBaseSize = new Size(5, 13);
            ClientSize = new Size(528, 417);
            Menu = mainMenu;
            Name = "ImageDoc";
            Text = "Image";
            MouseDown += new MouseEventHandler(ImageDoc_MouseDown);
            MouseLeave += new EventHandler(ImageDoc_MouseLeave);
            MouseMove += new MouseEventHandler(ImageDoc_MouseMove);
            MouseUp += new MouseEventHandler(ImageDoc_MouseUp);
            ResumeLayout(false);

        }

        //***********************************************************************
        // Запустить документ
        private void Init()
        {
            // компоненты инициализации
            InitializeComponent();
            // стиль формы
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);
            //полосы прокрутки инициализации
            AutoScroll = true;
            UpdateSize();
        }
        //************************************************************************
        // Выполнить команду
        public void ExecuteCommand(ImageDocCommands cmd)
        {
            switch (cmd)
            {
                case ImageDocCommands.Clone:		
                    Clone();
                    break;
                case ImageDocCommands.Crop:			
                    Crop();
                    break;
                case ImageDocCommands.ZoomIn:		
                    ZoomIn();
                    break;
                case ImageDocCommands.ZoomOut:		
                    ZoomOut();
                    break;
                case ImageDocCommands.ZoomOriginal:	
                    Zoom = 1;
                    UpdateZoom();
                    break;
                case ImageDocCommands.FitToSize:	
                    FitToScreen();
                    break;
                
            }
        }
        //*************************************
        // Обновить документ и уведомить клиента об изменениях
        private void UpdateNewImage()
        {
            // обновить размер
            UpdateSize();
            // перекрашивать
            Invalidate();
        }
        
        //*****************************************************
        //Центрировать изображение в документе
        public void Center()
        {
            Rectangle rc = ClientRectangle;
            Point p = AutoScrollPosition;
            int width = (int)(ImageWidth * Zoom);
            int height = (int)(ImageHeight * Zoom);

            if (rc.Width < width)
                p.X = (width - rc.Width) >> 1;
            if (rc.Height < height)
                p.Y = (height - rc.Height) >> 1;

            AutoScrollPosition = p;
        }
        //********************************************************************************************
        // Обновить размер документа
        private void UpdateSize()
        {
            //размер изображения
            ImageWidth = image.Width;
            ImageHeight = image.Height;
            // размер полосы прокрутки
            AutoScrollMinSize = new Size((int)(ImageWidth * Zoom), (int)(ImageHeight * Zoom));
        }
//*********************************************************************************
        // Отобразить открытое изображение
        protected override void OnPaint(PaintEventArgs e)
        {
            if (image != null)
            {
                Graphics g = e.Graphics;
                Rectangle rc = ClientRectangle;
                Pen pen = new Pen(Color.FromArgb(0, 0, 0));

                int width = (int)(ImageWidth * Zoom);
                int height = (int)(ImageHeight * Zoom);
                int x = (rc.Width < width) ? AutoScrollPosition.X : (rc.Width - width) / 2;
                int y = (rc.Height < height) ? AutoScrollPosition.Y : (rc.Height - height) / 2;
                //рисуем прямоугольник вокруг изображения
                g.DrawRectangle(pen, x - 1, y - 1, width + 1, height + 1);
                 //установить ближайшую интерполяцию
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                 // нарисовать изображение
                g.DrawImage(image, x, y, width, height);

                pen.Dispose();
            }
        }
     
//****************************************************************************************************
        // Применить фильтр к изображению
        private void ApplyFilter(IFilter filter)
        {
            try
            {
                // установить курсор ожидания
               // this.Cursor = Cursors.WaitCursor;

                // применить фильтр к изображению
                Bitmap newImage = filter.Apply(image);

                if (host.CreateNewDocumentOnChange)
                {
                    //открыть новое изображение в новом документе
                    host.NewDocument(newImage);
                }
                else
                {
                    if (host.RememberOnChange)
                    {
                        //резервное копирование текущего изображения
                        if (backup != null)
                            backup.Dispose();

                        backup = image;
                    }
                    else
                    {
                        // освободить текущее изображение
                        image.Dispose();
                    }

                    image = newImage;

                    // Обновить
                    UpdateNewImage();
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Выбранный фильтр нельзя применить к изображению ", " Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
//*********************************************************************
        // во всплывающем окне  "Изображение"
        private void imageItem_Popup(object sender, EventArgs e)
        {
            backImageItem.Enabled = (backup != null);
            cropImageItem.Checked = cropping;
        }
//******************************************************************************
        // Восстановить изображение к предыдущему
        private void backImageItem_Click(object sender, EventArgs e)
        {
            if (backup != null)
            {
                // освободить текущее изображение
                image.Dispose();
                // восстановить
                image = backup;
                backup = null;

                // обновить
                UpdateNewImage();
            }
        }

      //***********************************************
        // Клонировать изображение
        private void Clone()
        {
            if (host != null)
            {
                Bitmap clone = AForge.Imaging.Image.Clone(image);

                if (!host.NewDocument(clone))
                {
                    clone.Dispose();
                }
            }
        }
//*********************************************************
        //клик клонировать
        private void cloneImageItem_Click(object sender, EventArgs e)
        {
            Clone();
        }
//**********************************************************
        // Обновить коэффициент масштабирования
        private void UpdateZoom()
        {
            AutoScrollMinSize = new Size((int)(ImageWidth * Zoom), (int)(ImageHeight * Zoom));
            Invalidate();

            if (ZoomChanged != null)
            { ZoomChanged(this, null); }
        }
//*********************************************************
        // Увеличить изображение
        private void zoomItem_Click(object sender, EventArgs e)
        {
            // получить текст пункта меню
            String t = ((MenuItem)sender).Text;
            // проанализировать его значение
            int i = int.Parse(t.Remove(t.Length - 1, 1));
            // коэффициент масштабирования 
            Zoom = (float)i / 100;

            UpdateZoom();
        }
//****************************************************************
        // Увеличить изображение
        private void ZoomIn()
        {
            float z = Zoom * 1.5f;

            if (z <= 10)
            {
                Zoom = z;
                UpdateZoom();
            }
        }
//**********************************************************************
        //  «Изображение Увеличить Увеличить»
        private void zoomInImageItem_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }
//**************************************************************************
        //Уменьшить изображение
        private void ZoomOut()
        {
            float z = Zoom / 1.5f;

            if (z >= 0.05)
            {
                Zoom = z;
                UpdateZoom();
            }
        }
        //**************************************************************************
        // «Изображение Увеличить Уменьшить»
        private void zoomOutImageItem_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }
        //**************************************************************************
        // По размеру
        private void FitToScreen()
        {
            Rectangle rc = ClientRectangle;

            Zoom = Math.Min((float)rc.Width / (ImageWidth + 2), (float)rc.Height / (ImageHeight + 2));

            UpdateZoom();
        }
         // Изображение Масштаб  По размеру экрана 
        private void zoomFitImageItem_Click(object sender, EventArgs e)
        {
            FitToScreen();
        }
         // Отразить изображение
        private void flipImageItem_Click(object sender, EventArgs e)
        {
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);

            Invalidate();
        }
         // Зеркальное изображение
        private void mirrorItem_Click(object sender, EventArgs e)
        {
            image.RotateFlip(RotateFlipType.RotateNoneFlipX);

            Invalidate();
        }
         // Повернуть изображение на 90 градусов
        private void rotateImageItem_Click(object sender, EventArgs e)
        {
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // 
            UpdateNewImage();
        }
         //  Инвертировать изображение
        private void invertColorFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Invert());
        }
         // Rotatet colors
        private void rotateColorFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new RotateChannels());
        }

        // Изображение сепии
        private void sepiaColorFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Sepia());
        }
        //удалить зеленый и синий каналы
        private void redColorFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ChannelFiltering(new IntRange(0, 255), new IntRange(0, 0), new IntRange(0, 0)));
        }
          // Убрать красный и синий каналы
        private void greenColorFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ChannelFiltering(new IntRange(0, 0), new IntRange(0, 255), new IntRange(0, 0)));
        }
        // Убрать красный и зеленый каналы
        private void blueColorFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ChannelFiltering(new IntRange(0, 0), new IntRange(0, 0), new IntRange(0, 255)));
        }
        // Удалить зеленый канал
        private void cyanColorFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ChannelFiltering(new IntRange(0, 0), new IntRange(0, 255), new IntRange(0, 255)));
        }
        // Удалить зеленый канал
        private void magentaColorFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ChannelFiltering(new IntRange(0, 255), new IntRange(0, 0), new IntRange(0, 255)));
        }
        // Удалить синий канал
        private void yellowColorFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ChannelFiltering(new IntRange(0, 255), new IntRange(0, 255), new IntRange(0, 0)));
        }
        //Упорядоченное Размывание
        private void orderedDitherBinaryFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new OrderedDithering());
        }
         // Упорядоченное Размывани dithering
        private void bayerDitherBinaryFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new BayerDithering());
        }
         //   Floyd-Steinverg  
        private void floydBinaryFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new FloydSteinbergDithering());
        }

        //   Burkes  
        private void burkesBinaryFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new BurkesDithering());
        }
         //  Stucki  
        private void stuckiBinaryFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new StuckiDithering());
        }
        // Jarvis  Judice   Ninke  
        private void jarvisBinaryFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new JarvisJudiceNinkeDithering());
        }
         //  Sierra 
        private void sierraBinaryFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new SierraDithering());
        }
         //  Stevenson and Arce 
        private void stevensonBinaryFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new StevensonArceDithering());
        }
         //   Simple Image Statistics
        private void sisThresholdBinaryFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new SISThreshold());
        }

        // Эррозия
        private void erosionMorphologyFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Erosion());
        }

        // расширение
        private void dilatationMorphologyFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Dilatation());
        }

        // открытие
        private void openingMorphologyFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Opening());
        }

        // закрытие
        private void closingMorphologyFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Closing());
        }
         // Mean
        private void meanConvolutionFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Mean());
        }
        // Размытие
        private void blurConvolutionFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Blur());
        }
        // Края
        private void edgesConvolutionFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Edges());
        }
         // однородность
        private void homogenityEdgeFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new HomogenityEdgeDetector());
        }
         // различность
        private void differenceEdgeFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new DifferenceEdgeDetector());
        }
         // Sobel  
        private void sobelEdgeFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new SobelEdgeDetector());
        }
        // Изменить размер изображения
        private void ResizeImage()
        {
            ResizeForm form = new ResizeForm();

            form.OriginalSize = new Size(ImageWidth, ImageHeight);

            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }
        //  Фильтры  Изменить размер 
        private void resizeFiltersItem_Click(object sender, EventArgs e)
        {
            ResizeImage();
        }
         // Поворачиваем изображение
        private void RotateImage()
        {
            RotateForm form = new RotateForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }
         // Фильтры  Повернуть 
        private void rotateFiltersItem_Click(object sender, EventArgs e)
        {
            RotateImage();
        }
        // Медианный
        private void medianFiltersItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Median());
        }
        // Вычислить координаты точки на изображении и на экране для обрезки
        private void GetImageAndScreenPoints(Point point, out Point imgPoint, out Point screenPoint)
        {
            Rectangle rc = ClientRectangle;
            int width = (int)(ImageWidth * Zoom);
            int height = (int)(ImageHeight * Zoom);
            int x = (rc.Width < width) ? AutoScrollPosition.X : (rc.Width - width) / 2;
            int y = (rc.Height < height) ? AutoScrollPosition.Y : (rc.Height - height) / 2;

            int ix = Math.Min(Math.Max(x, point.X), x + width - 1);
            int iy = Math.Min(Math.Max(y, point.Y), y + height - 1);

            ix = (int)((ix - x) / Zoom);
            iy = (int)((iy - y) / Zoom);

            imgPoint = new Point(ix, iy);
             screenPoint = PointToScreen(new Point((int)(ix * Zoom + x), (int)(iy * Zoom + y)));
        }

        

        // Нарисовать прямоугольник выделения
        private void DrawSelectionFrame(Graphics g)
        {
            Point sp = startW;
            Point ep = endW;
            ControlPaint.DrawReversibleFrame(new Rectangle(sp.X, sp.Y, ep.X - sp.X + 1, ep.Y - sp.Y + 1), Color.White, FrameStyle.Dashed);
        }
//*****************************************************************
        // Обрезать изображение
        private void Crop()
        {
            if (!cropping)
            {
                // если поворот on
                cropping = true;
                Cursor = Cursors.Cross;

            }
            else
            {
                cropping = false;
            }
        }

        // Изображение  Обрезка   включить / выключить 
        private void cropImageItem_Click(object sender, EventArgs e)
        {
            Crop();
        }
   ///*****************************************************************     
        // On mouse down
        private void ImageDoc_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // выключить режим обрезки
                if (!dragging)
                {
                    cropping = false;
                   // this.Cursor = Cursors.Default;
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (cropping)
                {
                    // начать перетаскивать
                    dragging = true;
                    // установить захват мыши
                    Capture = true;

                    // получить точку начала выбора
                    GetImageAndScreenPoints(new Point(e.X, e.Y), out start, out startW);

                    // конечная точка такая же, как и начало
                    end = start;
                    endW = startW;

                    // рисовать рамку
                    Graphics g = CreateGraphics();
                    DrawSelectionFrame(g);
                    g.Dispose();
                }
            }
        }
      
        private void menuItem4_Click(object sender, EventArgs e)
        {

        }
        
//***************************************************************************************
        // On mouse up
        private void ImageDoc_MouseUp(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                // прекратить перетаскивать и обрезать
                dragging = cropping = false;
                // освободить захват
                Capture = false;
                
                // стереть рамку
                Graphics g = CreateGraphics();
                DrawSelectionFrame(g);
                g.Dispose();
                // обрезать изображение
                ApplyFilter(new Crop(new Rectangle(start.X, start.Y, end.X - start.X + 1, end.Y - start.Y + 1)));
            }
        }
        //***********************************************************
        // обрезка По движению мыши
        private void ImageDoc_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Graphics g = CreateGraphics();
                // стереть кадр
                DrawSelectionFrame(g);
                // получить конечную точку выбора
                GetImageAndScreenPoints(new Point(e.X, e.Y), out end, out endW);
                //нарисовать рамку
                DrawSelectionFrame(g);
                g.Dispose();
             
            }
            else
            {
                if (MouseImagePosition != null)
                {
                    Rectangle rc = ClientRectangle;
                    int width = (int)(ImageWidth * Zoom);
                    int height = (int)(ImageHeight * Zoom);
                    int x = (rc.Width < width) ? AutoScrollPosition.X : (rc.Width - width) / 2;
                    int y = (rc.Height < height) ? AutoScrollPosition.Y : (rc.Height - height) / 2;

                    if ((e.X >= x) && (e.Y >= y) &&
                        (e.X < x + width) && (e.Y < y + height))
                    {
                        // находится над изображением
                        MouseImagePosition(this, new SelectionEventArgs(
                            new Point((int)((e.X - x) / Zoom), (int)((e.Y - y) / Zoom))));
                    }
                    else
                    {
                        // мышь находится вне области изображения
                        MouseImagePosition(this, new SelectionEventArgs(new Point(-1, -1)));
                    }
                }
            }
        }

        // On mouse leave
        private void ImageDoc_MouseLeave(object sender, EventArgs e)
        {
            if ((!dragging) && (MouseImagePosition != null))
            {
                MouseImagePosition(this, new SelectionEventArgs(new Point(-1, -1)));
            }
        }
    }
//*****************************************************************************
    // Аргументы выбора
    public class SelectionEventArgs : EventArgs
    {

        // Конструкторы
        public SelectionEventArgs(Point location)
        {
            Location = location;
        }
        public SelectionEventArgs(Point location, Size size)
        {
            Location = location;
            Size = size;
        }

        // Местоположение свойство
        public Point Location { get; }
        // Свойство размера
        public Size Size { get; }
    }
//******************************************************************************
    // Команды всплывающего меню
    public enum ImageDocCommands
    {
        Clone,
        Crop,
        ZoomIn,
        ZoomOut,
        ZoomOriginal,
        FitToSize
    }
}
