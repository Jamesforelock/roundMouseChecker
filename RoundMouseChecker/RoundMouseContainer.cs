using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoundMouseChecker
{
    public partial class RoundMouseContainer : UserControl
    {
        public event EventHandler OnRoundMouse;

        private List<Point> points; // Список точек
        private System.Timers.Timer reset; // Таймер
        bool isChecking = false; // Факт обработки данных об отрисованных точках

        public RoundMouseContainer()
        {
            InitializeComponent();

            points = new List<Point>(); // Инициализация точек
            setTimer(); // Подготовка таймера
            
            // Добавление точек при наведении курсора на элемент
            this.MouseMove += (object sender, MouseEventArgs e) =>
            {
                this.addPoint(new Point(e.X, e.Y));
            };
        }

        private void setTimer() {
            // Инициализация таймера, Interval - миллисекунды, по истечении которых вызывается событие Elapsed
            reset = new System.Timers.Timer() { AutoReset = false, Interval = 500 };
            reset.Elapsed += (s, e) => // Добавление обработчика события Elapsed в виде лямбда-выражения
            {
                isCircleCheck();
                points.Clear(); // Очищаем список точек
                reset.Start(); // Перезапускаем таймер
            };
            reset.Start(); // Запускаем таймер
        }

        private void isCircleCheck() {
            if (points.Count <= 10) return; // Если количество точек, в которые попал курсор <= 10
            isChecking = true;
            // Максимальное и минимальное значения координат (могут быть равны null)
            double? max_x = null;
            double? min_x = null;
            double? max_y = null;
            double? min_y = null;

            // Нахождение максимальных и минимальных значений x и y
            foreach (var point in points) {
                max_x = Math.Max(max_x ?? point.X, point.X);
                min_x = Math.Min(min_x ?? point.X, point.X);
                max_y = Math.Max(max_y ?? point.Y, point.Y);
                min_y = Math.Min(min_y ?? point.Y, point.Y);
            }
            // Инициализация центра в качестве точки
            var center = new Point((int)((((double)max_x - (double)min_x) / 2) + (double)min_x), (int)((((double)max_y - (double)min_y) / 2) + (double)min_y));

            var count_r = 0; // Число расстояний
            var sum_r = 0d; // Сумма расстояний
            var all_r = new List<double>(); // Список расстояний
            var quadrands = new int[4]; // Массив квадрантов круга (её четвертей)

            // Определение квадрантов круга и получение суммы расстояний точек от центра
            foreach (var point in points) {
                // Определение расстояний точки от центра
                var r = Math.Sqrt(Math.Pow(point.X - center.X, 2) + Math.Pow(point.Y - center.Y, 2));
                // Увеличиваем сумму расстояний
                sum_r += r;
                // Увеличиваем число расстояний
                count_r += 1;
                // Добавляем расстояний в список
                all_r.Add(r);

                // Увеличиваем значение одного из квадрантов на единицу
                // Значение индекса высчитывается с помощью тернарных операторов, которые
                // определяют, больше ли значение y и x, чем значения x и y центра круга
                quadrands[(point.Y > center.Y ? 1 : 0) + (point.X > center.X ? 2 : 0)] += 1;
            }
            // Находим среднее расстояние точек от центра
            var r_avg = sum_r / count_r;

            // Если количество расстояний точек от центра, которые меньше среднего расстояния * .3
            // больше или равно количеству расстояния * .8, а также если значения всех квадрантов больше единицы,
            // то курсор нарисовал круг.
            if (all_r.Count(r => Math.Abs(r - r_avg) < r_avg * .3) >= count_r * .8 && quadrands.All(q => q > 1))
            {
                OnRoundMouse(this, new EventArgs()); // Вызываем событие OnRoundMouse
            }
            isChecking = false;
        }

        // Добавление точки в список при условии, что их обработка не происходит
        private void addPoint(Point point) {
            if (!isChecking) points.Add(point);
        }

    }
}
