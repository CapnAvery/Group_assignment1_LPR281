using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_assignment1_LPR281
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<Constraint> AllConstraints;
        public int MaxX1 = 1;
        public int MaxX2 = 1;
        public int MinX1 = 0;
        public int MinX2 = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            //hallo mensies
            //Theuns has joined the club
            AllConstraints = new List<Constraint>();
            ResetGraph();
        }

        void AddConstraint(string X1Coef, string X2Coef, string Sign, string RHS)
        {
            int ID = 0;
            if (AllConstraints.Count > 0)
            {
                ID = int.Parse(AllConstraints[AllConstraints.Count - 1].ID) + 1;
            }
            Constraint NewConstraint = new Constraint(ID.ToString(), Sign, X1Coef, X2Coef, RHS, MaxX1, MaxX2);
            AllConstraints.Add(NewConstraint);
            string Line = "";
            Line += ID.ToString() + ". " + X1Coef + "x1 + " + X2Coef + "x2 " + Sign + " " + RHS;
            lbxConstraints.Items.Add(Line);
            DrawConstraints(NewConstraint);
        }

        void DrawConstraints(Constraint _Const)
        {
            if (_Const.X1Cut.X > MaxX1)
            {
                MaxX1 = (int)_Const.X1Cut.X + 1;
                ResetGraph();
            }
            if (_Const.X2Cut.Y > MaxX2)
            {
                MaxX2 = (int)_Const.X2Cut.Y + 1;
                ResetGraph();
            }
            if (_Const.X1Cut.X < MinX1)
            {
                MinX1 = (int)_Const.X1Cut.X + 1;
                ResetGraph();
            }
            if (_Const.X2Cut.Y < MinX2)
            {
                MinX2 = (int)_Const.X2Cut.Y + 1;
                ResetGraph();
            }
            chart1.Series.Clear();
            Random rand = new Random();
            for (int i = 0; i < AllConstraints.Count; i++)
            {
                chart1.Series.Add(AllConstraints[i].ID);
                chart1.Series[AllConstraints[i].ID].Color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                chart1.Series[AllConstraints[i].ID].Legend = "Legend1";
                chart1.Series[AllConstraints[i].ID].ChartArea = "ChartArea1";
                chart1.Series[AllConstraints[i].ID].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series[AllConstraints[i].ID].Points.AddXY(AllConstraints[i].X1Cut.X, AllConstraints[i].X1Cut.Y);
                chart1.Series[AllConstraints[i].ID].Points.AddXY(AllConstraints[i].X2Cut.X, AllConstraints[i].X2Cut.Y);
            }
        }

        void ResetGraph()
        {
            var ChartObject = chart1.ChartAreas[0];
            ChartObject.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            ChartObject.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            ChartObject.AxisX.Minimum = MinX1;
            ChartObject.AxisY.Minimum = MinX2;
            ChartObject.AxisX.Maximum = MaxX1;
            ChartObject.AxisY.Maximum = MaxX2;
            for (int i = 0; i < AllConstraints.Count; i++)
            {
                AllConstraints[i].SetCuts(MaxX1, MaxX2);
            }
        }

        public struct Constraint
        {
            public string ID;
            public string Sign;
            public float X1Coefficient;
            public float X2Coefficient;
            public float RHS;
            public Point X1Cut;
            public Point X2Cut;

            public Constraint(string _ID, string _Sign, string _X1Coef, string _X2Coef, string _RHS, int MaxX1, int MaxX2)
            {
                ID = _ID;
                Sign = _Sign;
                X1Coefficient = int.Parse(_X1Coef);
                X2Coefficient = int.Parse(_X2Coef);
                RHS = int.Parse(_RHS);
                X1Cut = new Point(0, 0);
                X2Cut = new Point(0, 0);
                SetCuts(MaxX1, MaxX2);
            }

            public void SetCuts(int MaxX1, int MaxX2)
            {
                bool X1Zero = false;
                if (X1Coefficient != 0)
                {
                    X1Cut = new Point(RHS / X1Coefficient, 0);
                }
                else
                {
                    X1Zero = true;
                    X1Cut = new Point(MaxX1, 0);
                }
                if (X1Cut.X < 0)
                {

                }
                if (X2Coefficient != 0)
                {
                    X2Cut = new Point(0, RHS / X2Coefficient);
                }
                else
                {
                    X2Cut = new Point(X1Cut.X, MaxX2);
                }
                if (X1Zero == true)
                {
                    X1Cut.Y = X2Cut.Y;
                }
            }
        }
        public struct Point
        {
            public float X;
            public float Y;

            public Point(float _X, float _Y)
            {
                X = _X;
                Y = _Y;
            }
        }
    }
}
