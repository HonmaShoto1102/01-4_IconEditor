using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;


namespace IconEditor
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        Rectangle[,] Rectangles = new Rectangle[32, 32];
        Stack<Color[,]> UndoStack = new Stack<Color[,]>();
        Stack<Color[,]> RedoStack = new Stack<Color[,]>();

    
        public static RoutedCommand UndoCommand { get; }
            = new RoutedCommand(nameof(UndoCommand), typeof(MainWindow));
        public static RoutedCommand RedoCommand { get; }
            = new RoutedCommand(nameof(RedoCommand), typeof(MainWindow));
        public static RoutedCommand MenuItem_NewCommand { get; }
                    = new RoutedCommand(nameof(MenuItem_NewCommand), typeof(MainWindow));
        public static RoutedCommand MenuItem_OpenCommand { get; }
                           = new RoutedCommand(nameof(MenuItem_OpenCommand), typeof(MainWindow));
        public static RoutedCommand MenuItem_SaveCommand { get; }
                                   = new RoutedCommand(nameof(MenuItem_SaveCommand), typeof(MainWindow));
        public static RoutedCommand MenuItem_SaveAsCommand { get; }
                                   = new RoutedCommand(nameof(MenuItem_SaveAsCommand), typeof(MainWindow));
        public static RoutedCommand MenuItem_ExitCommand { get; }
                                   = new RoutedCommand(nameof(MenuItem_ExitCommand), typeof(MainWindow));
        public static RoutedCommand MenuItem_CopyCommand { get; }
                                   = new RoutedCommand(nameof(MenuItem_CopyCommand), typeof(MainWindow));
        public static RoutedCommand MenuItem_PasteCommand { get; }
                                   = new RoutedCommand(nameof(MenuItem_PasteCommand), typeof(MainWindow));
        public static RoutedCommand MenuItem_HelpCommand { get; }
                                           = new RoutedCommand(nameof(MenuItem_HelpCommand), typeof(MainWindow));
        public static RoutedCommand MenuItem_AboutCommand { get; }
                                           = new RoutedCommand(nameof(MenuItem_AboutCommand), typeof(MainWindow));



        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainCanvas_Initialized(object sender, EventArgs e)
        {
            Canvas canvas = (Canvas)sender;

            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    Rectangle rect;
                    rect = new Rectangle();
                    rect.Fill = new SolidColorBrush(Colors.White);
                    rect.Width = 19;
                    rect.Height = 19;
                    rect.MouseDown += Rectangle_MouseDown;
                    rect.MouseMove += Rectangle_MouseMove;
                    Canvas.SetLeft(rect, x * 20);
                    Canvas.SetTop(rect, y * 20);

                    canvas.Children.Add(rect);

                    Rectangles[y, x] = rect;
                }
            }
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            {
                Color[,] color = new Color[32, 32];

                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        SolidColorBrush brush
                            = (SolidColorBrush)Rectangles[y, x].Fill;
                        color[y, x] = Color.FromArgb(brush.Color.A, brush.Color.R,
                            brush.Color.G, brush.Color.B);
                    }
                }

                RedoStack.Clear();
                UndoStack.Push(color);
            }
            //Paint();
            Rectangle rect = (Rectangle)sender;
            SolidColorBrush paltteBrush = (SolidColorBrush)ColorPalette.Fill;
            rect.Fill = new SolidColorBrush(paltteBrush.Color);
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            SolidColorBrush brush = (SolidColorBrush)rect.Fill;
            String text;

            int x = (int)Canvas.GetLeft(rect) / 20;
            int y = (int)Canvas.GetTop(rect) / 20;

            text = "X:" + x.ToString() + "Y:" + y.ToString();

            text += "RGB( " + brush.Color.R.ToString() + ", " +
                brush.Color.G.ToString() + ", " +
                brush.Color.B.ToString() + ")";

            StatusBarLabel.Content = text;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //Paint();
                SolidColorBrush paltteBrush = (SolidColorBrush)ColorPalette.Fill;
                rect.Fill = new SolidColorBrush(paltteBrush.Color);
            }

        }

        /*private void Paint()
        {
            Point mousePosition = Mouse.GetPosition(canvas);
            double penSize = Slider_PenSize.Value * 10;
            double penStrength = Slider_PenStrength.Value * 0.01;

            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    Rectangle rect = Rectangles[y, x];
                    Point rectPosition = new Point();
                    rectPosition.X = (int)Canvas.GetLeft(rect) + 10;
                    rectPosition.Y = (int)Canvas.GetTop(rect) + 10;

                    Vector dist = rectPosition - mousePosition;

                    if (dist.Length < penSize)
                    {
                        SolidColorBrush destBrush = (SolidColorBrush)rect.Fill;
                        SolidColorBrush paletteBrush = (SolidColorBrush)ColorPalette.Fill;

                        Color color = new Color();
                        color.R = (byte)(destBrush.Color.R * (1.0 - penStrength) + paletteBrush.Color.R * penStrength);
                        color.G = (byte)(destBrush.Color.G * (1.0 - penStrength) + paletteBrush.Color.G * penStrength);
                        color.B = (byte)(destBrush.Color.B * (1.0 - penStrength) + paletteBrush.Color.B * penStrength);
                        color.A = 255;
                        rect.Fill = new SolidColorBrush(color);
                    }

                }
            }

        }*/

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ColorPalette_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Forms.ColorDialog cd = new System.Windows.Forms.ColorDialog();

            cd.FullOpen = true;

            SolidColorBrush paletteBrush = (SolidColorBrush)ColorPalette.Fill;
            cd.Color = System.Drawing.Color.FromArgb(paletteBrush.Color.A,
                paletteBrush.Color.R, paletteBrush.Color.G, paletteBrush.Color.B);

            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Color color = Color.FromArgb(cd.Color.A, cd.Color.R, cd.Color.G, cd.Color.B);
                ColorPalette.Fill = new SolidColorBrush(color);
            }
        }

        private void MenuItem_About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Icon Editor\nVersion 0.0.1", "IconEditorのバージョン情報", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.Yes);
        }

        private void MenuItem_ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            int index = Slider_Zoom.Ticks.IndexOf(Slider_Zoom.Value);
            index--;

            if (index < 0)
                return;

            Slider_Zoom.Value = Slider_Zoom.Ticks[index];
        }

        private void MenuItem_ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            int index = Slider_Zoom.Ticks.IndexOf(Slider_Zoom.Value);
            index++;

            if (Slider_Zoom.Ticks.Count <= index)
                return;

            Slider_Zoom.Value = Slider_Zoom.Ticks[index];
        }

        private void Slider_Zoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MainCanvas == null)
                return;

            Matrix matrix = new Matrix();
            matrix.Scale(Slider_Zoom.Value * 0.01, Slider_Zoom.Value * 0.01);
            matrixTransform.Matrix = matrix;

            ZoomLabel.Content = Slider_Zoom.Value + "%";

            MainCanvas.Width = 640 * Slider_Zoom.Value * 0.01;
            MainCanvas.Height = 640 * Slider_Zoom.Value * 0.01;

        }
        private void MenuItem_Undo_Click_Can(object sender, CanExecuteRoutedEventArgs e)
        {
            if (UndoStack.Count == 0)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }
        private void MenuItem_Undo_Click(object sender, RoutedEventArgs e)
        {
            if (UndoStack.Count == 0)
                return;

            {
                Color[,] color = UndoStack.Pop();

                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        SolidColorBrush brush = (SolidColorBrush)Rectangles[y, x].Fill;
                        color[y, x] = Color.FromArgb(brush.Color.A, brush.Color.R,
                            brush.Color.G, brush.Color.B);
                    }
                }
                RedoStack.Push(color);
            }

            {
                Color[,] color = UndoStack.Pop();

                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        Rectangles[y, x].Fill = new SolidColorBrush(color[y, x]);
                    }
                }
            }
        }

        private void MenuItem_Redo_Click_Can(object sender, CanExecuteRoutedEventArgs e)
        {
            if (RedoStack.Count == 0)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }
        private void MenuItem_Redo_Click(object sender, RoutedEventArgs e)
        {
            if (RedoStack.Count == 0)
                return;

            {
                Color[,] color = UndoStack.Pop();

                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        SolidColorBrush brush = (SolidColorBrush)Rectangles[y, x].Fill;
                        color[y, x] = Color.FromArgb(brush.Color.A, brush.Color.R,
                            brush.Color.G, brush.Color.B);
                    }
                }
                UndoStack.Push(color);
            }

            {
                Color[,] color = RedoStack.Pop();

                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        Rectangles[y, x].Fill = new SolidColorBrush(color[y, x]);
                    }
                }
            }
        }

        private void MenuItem_SaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dig = new SaveFileDialog();
            dig.Filter = "PNG(*.png)| *.png";
            bool? result = dig.ShowDialog();
            if (result != true)
                return;

            WriteableBitmap bit = GetWriteableBitmap();

            using (FileStream stream = new FileStream(dig.FileName, FileMode.Create, FileAccess.Write))
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bit));
                encoder.Save(stream);
            }
        }

        private void MenuItem_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Filter = "PNG(*.png)| *.png";
            bool? result = dig.ShowDialog();
            if (result != true)
                return;

            byte[] pixels = new byte[32 * 32 * 4];

            using (FileStream stream = new FileStream(dig.FileName, FileMode.Open, FileAccess.Read))
            {
                PngBitmapDecoder decoder = new PngBitmapDecoder(stream,
                    BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                BitmapSource bitmap = decoder.Frames[0];
                bitmap.CopyPixels(pixels, 32 * 4, 0);
            }

            //pixelsからRectangles[y,x].Fillに変換する
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    Color color = new Color();
                    color.B = pixels[(y * 32 + x) * 4 + 0];
                    color.G = pixels[(y * 32 + x) * 4 + 1];
                    color.R = pixels[(y * 32 + x) * 4 + 2];
                    color.A = pixels[(y * 32 + x) * 4 + 3];

                    Rectangles[y, x].Fill = new SolidColorBrush(color);

                }
            }
        }

        private void MenuItem_Copy_Click(object sender, RoutedEventArgs e)
        {
            WriteableBitmap bit = GetWriteableBitmap();

            Clipboard.SetImage(bit);
        }

        private void MenuItem_Paste_Click(object sender, RoutedEventArgs e)
        {
            BitmapSource bitmap = Clipboard.GetImage();
            if (bitmap == null)
                return;

            byte[] pixels = new byte[bitmap.PixelWidth * bitmap.PixelHeight * 4];
            bitmap.CopyPixels(pixels, bitmap.PixelWidth * 4, 0);

            int width = Math.Min(32, bitmap.PixelWidth);
            int height = Math.Min(32, bitmap.PixelHeight);

            //pixelsからRectangles[y,x].Fillに変換する
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color color = new Color();
                    color.B = pixels[(y * bitmap.PixelWidth + x) * 4 + 0];
                    color.G = pixels[(y * bitmap.PixelWidth + x) * 4 + 1];
                    color.R = pixels[(y * bitmap.PixelWidth + x) * 4 + 2];
                    color.A = 255;

                    Rectangles[y, x].Fill = new SolidColorBrush(color);

                }
            }
        }

        private void MenuItem_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_New_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ColorList_Initalized(object sender, EventArgs e)
        {
            Grid grid = (Grid)sender;

            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Rectangle rect;
                    rect = new Rectangle();
                    rect.StrokeThickness = 0;
                    rect.Stroke = new SolidColorBrush(Colors.White);
                    rect.Margin = new Thickness();

                    byte r, g, b;
                    r = (byte)(x / 7.0f * 255.0f);
                    g = (byte)((int)(y / 4.0f) / 3.0f * 255.0f);
                    b = (byte)(y % 4 / 3.0f * 255.0f);

                    rect.Fill = new SolidColorBrush(Color.FromRgb(r, g, b));
                    rect.MouseDown += ColorList_MouseDown;
                    rect.MouseMove += ColorList_MouseMove;

                    Grid.SetRow(rect, y);
                    Grid.SetColumn(rect, x);

                    grid.Children.Add(rect);
                }

            }

        }

       
        private void ColorList_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            SolidColorBrush brush = (SolidColorBrush)rect.Fill;

            ColorPalette.Fill = new SolidColorBrush(brush.Color);

        }

        private void ColorList_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            SolidColorBrush brush = (SolidColorBrush)rect.Fill;
            
            StatusBarLabel.Content= "RGB( " + brush.Color.R.ToString() + ", " +
                brush.Color.G.ToString() + ", " +
                brush.Color.B.ToString() + ")";

        }


        private WriteableBitmap GetWriteableBitmap()
        {
            byte[] pixels = new byte[32 * 32 * 4];

            //pixelsに色データを保存する
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    SolidColorBrush brush = (SolidColorBrush)Rectangles[y, x].Fill;

                    pixels[(y * 32 + x) * 4 + 0] = brush.Color.B;
                    pixels[(y * 32 + x) * 4 + 1] = brush.Color.G;
                    pixels[(y * 32 + x) * 4 + 2] = brush.Color.R;
                    pixels[(y * 32 + x) * 4 + 3] = brush.Color.A;

                }
            }

            WriteableBitmap bitmap = new WriteableBitmap(32, 32, 300, 300, PixelFormats.Bgr32, null);
            bitmap.WritePixels(new Int32Rect(0, 0, 32, 32), pixels, 32 * 4, 0, 0);

            return bitmap;
        }

        private void MenuItem_Help_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
