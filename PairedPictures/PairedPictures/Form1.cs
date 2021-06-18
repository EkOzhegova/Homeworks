using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PairedPictures
{
    public partial class Form1 : Form
    {
        private static readonly Random Random = new Random();

        private Dictionary<PictureBox, int> _indexesOfPictures;

        private Timer _timer; //засечь время показа картинок до игры и во время

        private int[] _picturesOrder;

        private readonly List<PictureBox> _pictures;

        private bool _picturesAreEnabled; //активны-можно нажать, неактивны-нельзя(время показа перед игрой и когда два озображения уже выбраны

        private int _countClicks; //когда четный-сравниваем текущуу и предыдущую картинки

        private PictureBox _previousPicture;

        private DateTime _gameStartTime; 

        public Form1()
        {
            InitializeComponent();

            _pictures = new List<PictureBox>
            {
                pictureBox1, pictureBox2, pictureBox3, pictureBox4,
                pictureBox5, pictureBox6, pictureBox7, pictureBox8,
                pictureBox9, pictureBox10, pictureBox11, pictureBox12,
                pictureBox13, pictureBox14, pictureBox15, pictureBox16
            };

            
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _countClicks = 0;

            SetIndexesOnPictures();//инициализация словарь

            RefreshPictures(false);//обновление(перемешиваем) изображения

            _timer = new Timer
            {
                Interval = 3000
            };

            _timer.Tick += (o, a) =>//задаем поведение таймера
            {
                RefreshPictures(true);//истина-показывается задняя часть карточки

                _timer.Stop();

                _picturesAreEnabled = true;

                
                _gameStartTime = DateTime.Now;
            };
            _timer.Start();
        }

        private void RefreshPictures(bool isBackground)//параметр-ориентир: истина-обратная сторона, ложь - лицевая
        {
            for (var i = 0; i < _pictures.Count; i++)
            {
                _pictures[i].Image = isBackground
                    ? Image.FromFile("..\\..\\Pictures\\back.jpg")

                    : Image.FromFile($"..\\..\\Pictures\\{_picturesOrder[i]}.jpg");

                _pictures[i].Enabled = true;
            }
        }

        private static int[] GetRandomOrder()//последовательность случайного порядка
        {
            var indexes = Enumerable.Range(0, 8).Concat(Enumerable.Range(0, 8)).ToArray();//два диапазона от 0 до 7

            for (var i = 0; i < indexes.Length; ++i)
            {
                var randomIndex = Random.Next(0, indexes.Length - 1);//получаем случайное число (для некст от нуля до числа строго меньше второго аргумента (индексы нумеруются снуля)

                var temp = indexes[i];
                indexes[i] = indexes[randomIndex];
                indexes[randomIndex] = temp;//упорядоченный диапазон на случайную последовательность
            }

            return indexes;
        }

        private void SetIndexesOnPictures()
        {
            _indexesOfPictures = new Dictionary<PictureBox, int>();

            _picturesOrder = GetRandomOrder();//получаем пары случайных чисел

            for (var i = 0; i < _pictures.Count; i++)
                _indexesOfPictures[_pictures[i]] = _picturesOrder[i];
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (!_picturesAreEnabled)
                return;

            var currentBox = (PictureBox)sender;//изображение на которое нажали

            currentBox.Enabled = false;//каррточка становится неактивна

            _countClicks++;

            currentBox.Image = Image.FromFile($"..\\..\\Pictures\\{_indexesOfPictures[currentBox]}.jpg");//показывается лицевая часть

            if (_countClicks % 2 == 0)
                CheckOnEquals(currentBox);//если четное количество нажатий, проверяем выбраные картинки на одинаковость

            else _previousPicture = currentBox;//иначе запоминаем текущий элемент

            if (_countClicks == _pictures.Count)//проверка на выигрыш
            {
               
                DateTime gameEndTime = DateTime.Now;
                TimeSpan timeOfGame = gameEndTime - _gameStartTime;
                
                MessageBox.Show($"Вы выиграли!\nTime: {timeOfGame.Minutes}:{timeOfGame.Seconds}");

               
            }
        }

        private void CheckOnEquals(PictureBox currentBox)
        {
            _picturesAreEnabled = false;

            if (_indexesOfPictures[_previousPicture] == _indexesOfPictures[currentBox])//если индексы равны
            {
                _timer = new Timer { Interval = 100 };

                _timer.Tick += (o, a) =>
                {
                    _timer.Stop();

                    currentBox.Image = null;

                    _previousPicture.Image = null;

                    currentBox.Enabled = false;

                    _previousPicture.Enabled = false;

                    _picturesAreEnabled = true;
                };

                _timer.Start();
            }
            else
            {
                _countClicks -= 2;//вычитаем сделанные два нажатия на неодинаковые картинки, чтобы они не учитывались в счетчике 

                _timer = new Timer { Interval = 1500 };
                _timer.Tick += (o, a) =>
                {
                    _timer.Stop();

                    currentBox.Image = Image.FromFile(@"..\..\Pictures\back.jpg");
                    _previousPicture.Image = Image.FromFile(@"..\..\Pictures\back.jpg");

                    currentBox.Enabled = true;
                    _previousPicture.Enabled = true;

                    _picturesAreEnabled = true;
                };

                _timer.Start();
            }
        }
    }
}