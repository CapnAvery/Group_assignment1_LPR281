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


        public class Constraint
        {
            public string ID;
            public string Sign;
            public float X1Coefficient;
            public float X2Coefficient;
            public float RHS;
            public Point Cut1;
            public Point Cut2;

            public Constraint(string _ID, string _Sign, string _X1Coef, string _X2Coef, string _RHS, int MaxX1, int MaxX2, int MinX1, int MinX2)
            {
                ID = _ID;
                Sign = _Sign;
                X1Coefficient = float.Parse(_X1Coef);
                X2Coefficient = float.Parse(_X2Coef);
                RHS = float.Parse(_RHS);
                Cut1 = new Point(0, 0);
                Cut2 = new Point(0, 0);
                SetCuts(MaxX1, MaxX2, MinX1, MinX2);
            }

            public bool CheckPoint(Point _Point)
            {
                bool Result = true;
                float X1Value = _Point.X * X1Coefficient;
                float X2Value = _Point.Y * X2Coefficient;
                float Total = X1Value + X2Value;
                if (Sign == ">=")
                {
                    Result = (Total >= RHS);
                }
                else
                {
                    if (Sign == "<=")
                    {
                        Result = (Total <= RHS);
                    }
                    else
                    {
                        Result = (Total == RHS);
                    }
                }
                return Result;
            }

            public void SetCuts(int MaxX1, int MaxX2, int MinX1, int MinX2)
            {
                if (!(X1Coefficient == 0 && X2Coefficient == 0))
                {
                    if (X2Coefficient != 0)
                    {
                        Cut1.X = MinX1;
                        Cut1.Y = (RHS - X1Coefficient * MinX1) / X2Coefficient;

                        Cut2.X = MaxX1;
                        Cut2.Y = (RHS - X1Coefficient * MaxX1) / X2Coefficient;
                    }
                    else
                    {
                        Cut1.X = RHS / X1Coefficient;
                        Cut1.Y = MinX2;

                        Cut2.X = RHS / X1Coefficient;
                        Cut2.Y = MaxX2;
                    }

                    if (X1Coefficient == 0)
                    {
                        Cut1.X = MinX1;
                        Cut1.Y = RHS / X2Coefficient;

                        Cut2.X = MaxX2;
                        Cut2.Y = RHS / X2Coefficient;
                    }
                }
                else
                {
                    Cut1 = new Point(0, 0);
                    Cut2 = new Point(0, 0);
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

        public Form1()
        {
            InitializeComponent();
        }

        public List<Constraint> AllConstraints;
        public List<Point> FeasibleArea;
        public int MaxX1 = 1;
        public int MaxX2 = 1;
        public int MinX1 = 0;
        public int MinX2 = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            //hallo mensies


            //as julle die kan sien dan werk alles :D
            //Theuns has joined the club
            AllConstraints = new List<Constraint>();
            ResetGraph();
        }

        void AddConstraint(string X1Coef, string X2Coef, string Sign, string RHS)
        {
            int ID = AllConstraints.Count;
            Constraint NewConstraint = new Constraint(ID.ToString(), Sign, X1Coef, X2Coef, RHS, MaxX1, MaxX2, MinX1, MinX2);
            AllConstraints.Add(NewConstraint);
            DisplayConstraints();
            DrawConstraints(NewConstraint);
        }

        void DisplayConstraints()
        {
            lbxConstraints.Items.Clear();
            for (int i = 0; i < AllConstraints.Count; i++)
            {
                string Line = "";
                Line += AllConstraints[i].ID.ToString() + ". ";
                Line += AllConstraints[i].X1Coefficient + "x1 + ";
                Line += AllConstraints[i].X2Coefficient + "x2 ";
                Line += AllConstraints[i].Sign + " ";
                Line += AllConstraints[i].RHS;
                lbxConstraints.Items.Add(Line);
            }
        }


        void DrawConstraints(Constraint _Const = null)
        {
            //Calculate the maximums and minimums of the graph
            ResetGraph();

            //Clear the current graph
            chart1.Series.Clear();
            //Draw the axis for X1
            string Name = "X1";
            chart1.Series.Add(Name);
            chart1.Series[Name].Color = Color.FromArgb(0, 0, 0);
            chart1.Series[Name].Legend = "Legend1";
            chart1.Series[Name].ChartArea = "ChartArea1";
            chart1.Series[Name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int y = -2; y <= 2; y++)
            {//We draw 5 lines instead of just 1 so that it appears extra thick
                chart1.Series[Name].Points.AddXY(MinX1, (float)y/100.0f);
                chart1.Series[Name].Points.AddXY(MaxX1, (float)y / 100.0f);
            }

            Name = "X2";
            chart1.Series.Add(Name);
            chart1.Series[Name].Color = Color.FromArgb(0, 0, 0);
            chart1.Series[Name].Legend = "Legend1";
            chart1.Series[Name].ChartArea = "ChartArea1";
            chart1.Series[Name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int x = -2; x <= 2; x++)//We draw 5 lines instead of just 1 so that it appears extra thick
            {
                chart1.Series[Name].Points.AddXY((float)x / 100.0f, MinX2);
                chart1.Series[Name].Points.AddXY((float)x / 100.0f, MaxX2);
            }

            Random rand = new Random();
            for (int i = 0; i < AllConstraints.Count; i++)
            {
                Name = "Constraint " + AllConstraints[i].ID;
                chart1.Series.Add(Name);
                chart1.Series[Name].Color = Color.FromArgb(rand.Next(246) + 10, rand.Next(246) + 10, rand.Next(246) + 10);
                //We say 246 + 10 so that the minimum value is 10. This is so that there are no lines that are near black in color, to avoid confusion with the X1 and X2 lines.
                chart1.Series[Name].Legend = "Legend1";
                chart1.Series[Name].ChartArea = "ChartArea1";
                chart1.Series[Name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                AllConstraints[i].SetCuts(MaxX1, MaxX2,MinX1,MinX2);
                chart1.Series[Name].Points.AddXY(AllConstraints[i].Cut1.X, AllConstraints[i].Cut1.Y);
                chart1.Series[Name].Points.AddXY(AllConstraints[i].Cut2.X, AllConstraints[i].Cut2.Y);
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
                Constraint _Const = AllConstraints[i];
                //The following is to make sure that the graph has the correct range
                //These are for the maximums
                if (_Const.X1Coefficient > MaxX1)
                {
                    MaxX1 = (int)_Const.X1Coefficient + 1;
                    ResetGraph();
                    break;
                }
                if (_Const.X2Coefficient > MaxX2)
                {
                    MaxX2 = (int)_Const.X2Coefficient + 1;
                    ResetGraph();
                    break;
                }
                //These are for the minimums
                if (_Const.X1Coefficient < MinX1)
                {
                    MinX1 = (int)_Const.X1Coefficient - 1;
                    ResetGraph();
                    break;
                }
                if (_Const.X2Coefficient < MinX2)
                {
                    MinX2 = (int)_Const.X2Coefficient - 1;
                    ResetGraph();
                    break;
                }

                _Const.SetCuts(MaxX1, MaxX2, MinX1, MinX2);
            }
        }

        private void btnAddConstraint_Click(object sender, EventArgs e)
        {
            AddConstraint(txtX1Coef.Text, txtX2Coef.Text, cbxSign.Text, txtRHS.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawConstraints();
        }

        void ScanFeasibleArea()
        {
            if (AllConstraints!=null)
            {
                if (AllConstraints.Count>0)
                {
                    int XMax = (int)MaxX1 * 100;
                    int XMin = (int)MinX1;
                    int YMax = (int)MaxX2 * 100;
                    int YMin = (int)MinX2;
                    FeasibleArea = new List<Point>();
                    for (int x = XMin; x < XMax; x++)
                    {
                        for (int y = YMin; y < YMax; y++)
                        {
                            Point TestPoint = new Point((float)x / 100.0f, (float)y / 100.0f);
                            bool Feasible = true;
                            for (int i = 0; i < AllConstraints.Count; i++)
                            {
                                if (!AllConstraints[i].CheckPoint(TestPoint))
                                {
                                    Feasible = false;
                                    break;
                                }
                            }
                            if (Feasible)
                            {
                                FeasibleArea.Add(TestPoint);
                            }
                        }
                    }
                }
                else
                {
                    DisplayError("Must have at least one constraint!");
                }
            }
            else
            {
                DisplayError("Must have at least one constraint!");
            }
        }

        void    DrawFeasibleArea    ()
        {
            if (FeasibleArea!=null)
            {
                if (FeasibleArea.Count>0)
                {
                    string Name = "Feasible Area";
                    Random rand = new Random();
                    chart1.Series.Add(Name);
                    chart1.Series[Name].Color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                    chart1.Series[Name].Legend = "Legend1";
                    chart1.Series[Name].ChartArea = "ChartArea1";
                    chart1.Series[Name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    for (int i = 0; i < FeasibleArea.Count; i++)
                    {
                        chart1.Series[Name].Points.AddXY(FeasibleArea[i].X, FeasibleArea[i].Y);
                    }
                }
                else
                {
                    DisplayError("No Feasible Area Found");
                }
            }
            else
            {
                DisplayError("Feasible Area Not Yet Scanned!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScanFeasibleArea();
            DrawFeasibleArea();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
       
        public  void    DisplayError    (string Error)
        {
            lblError.Text = Error;
        }

        private void btnRemoveConstraint_Click(object sender, EventArgs e)
        {
            string ID = txtRemoveID.Text;
            int pos = -1;
            if (AllConstraints!=null)
            {
                if (AllConstraints.Count>0)
                {
                    for (int i = 0; i < AllConstraints.Count; i++)
                    {
                        if (AllConstraints[i].ID==ID)
                        {
                            pos = i;
                            break;
                        }
                    }
                    if (pos>-1)
                    {
                        AllConstraints.RemoveAt(pos);
                        for (int i = 0; i < AllConstraints.Count; i++)
                        {
                            AllConstraints[i].ID = i.ToString();
                        }
                        DisplayConstraints();
                    }
                    else
                    {
                        DisplayError("Constraint not found");
                    }
                }
                else
                {
                    DisplayError("No Constraints");
                }
            }
            else
            {
                DisplayError("No Constraints");
            }
        }
    }
}
