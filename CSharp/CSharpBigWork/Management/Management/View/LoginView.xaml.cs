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
using System.Windows.Shapes;
using Management.ViewModel;

namespace Management.View
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();

            this.DataContext = new LoginViewModel();
        }

        private void WinMove_LeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(LoginView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Journal | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static string VerificationCode;

        /// <summary>
        /// 随机生成的验证码
        /// </summary>
        public ImageSource ImageSource
        {
            get
            {
                return (ImageSource)GetValue(ImageSourceProperty);
            }
            set
            {
                SetValue(ImageSourceProperty, value);
            }
        }

        [Obsolete]
        private void CheckCode_Loaded(object sender, RoutedEventArgs e)
        => ImageSource = CreateCheckCodeImage(CreateCode(4), (int)Width, (int)Height);


        private static string CreateCode(int strLength)
        {
            var strCode = "abcdefhkmnprstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789"; ;
            var _charArray = strCode.ToCharArray();
            var randomCode = "";
            int temp = -1;

            Random rand = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < strLength; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(strCode.Length - 1);
                if (!string.IsNullOrWhiteSpace(randomCode))
                {
                    while (randomCode.ToLower().Contains(_charArray[t].ToString().ToLower()))
                    {
                        t = rand.Next(strCode.Length - 1);
                    }
                }
                if (temp == t)
                {
                    return CreateCode(strLength);
                }
                temp = t;

                randomCode += _charArray[t];
            }
            VerificationCode = randomCode;
            return randomCode;
        }

        [Obsolete]
        private ImageSource CreateCheckCodeImage(string checkCode, int width, int height)
        {
            if (string.IsNullOrWhiteSpace(checkCode))
                return null;
            if (width <= 0 || height <= 0)
                return null;
            DrawingVisual drawingVisual = new DrawingVisual();

            Random random = new Random(Guid.NewGuid().GetHashCode());

            using (DrawingContext dc = drawingVisual.RenderOpen())
            {
                dc.DrawRectangle(Brushes.White, new Pen(Brushes.Silver, 1D), new Rect(new Size(70, 23)));
                FormattedText formattedText = new FormattedText(checkCode,
                    System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                    new Typeface(new FontFamily("Arial"), FontStyles.Oblique, FontWeights.Bold, FontStretches.Normal),
                    20.001D, new LinearGradientBrush(Colors.Green, Colors.DarkRed, 1.2D))
                {
                    MaxLineCount = 1,
                    TextAlignment = TextAlignment.Justify,
                    Trimming = TextTrimming.CharacterEllipsis
                };

                dc.DrawText(formattedText, new Point(3D, 0.1D));

                for (int i = 0; i < 10; i++)
                {
                    int x1 = random.Next(width - 1);
                    int y1 = random.Next(height - 1);
                    int x2 = random.Next(width - 1);
                    int y2 = random.Next(height - 1);

                    dc.DrawGeometry(Brushes.Silver, new Pen(Brushes.Silver, 0.5D), new LineGeometry(new Point(x1, y1), new Point(x2, y2)));
                }

                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(width - 1);
                    int y = random.Next(height - 1);
                    SolidColorBrush c = new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)));
                    dc.DrawGeometry(c, new Pen(c, 1D), new LineGeometry(new Point(x - 0.5, y - 0.5), new Point(x + 0.5, y + 0.5)));
                }
                dc.Close();
            }
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(70, 23, 96, 96, PixelFormats.Pbgra32);
            renderBitmap.Render(drawingVisual);
            return BitmapFrame.Create(renderBitmap);
        }

        [Obsolete]
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        => ImageSource = CreateCheckCodeImage(CreateCode(4), (int)Width, (int)Height);
    }
}
