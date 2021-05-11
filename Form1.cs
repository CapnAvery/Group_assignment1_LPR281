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
            Constraint NewConstraint = new Constraint(ID.ToString(), Sign, X1Coef, X2Coef, RHS, MaxX1, MaxX2);
            AllConstraints.Add(NewConstraint);
            string Line = "";
            Line += ID.ToString() + ". " + X1Coef + "x1 + " + X2Coef + "x2 " + Sign + " " + RHS;
            lbxConstraints.Items.Add(Line);
            DrawConstraints(NewConstraint);
        }

        void DrawConstraints(Constraint _Const  =   null)
        {
            ResetGraph();
            chart1.Series.Clear();
            Random rand = new Random();
            for (int i = 0; i < AllConstraints.Count; i++)
            {
                string Name = "Constraint " + AllConstraints[i].ID;
                chart1.Series.Add(Name);
                chart1.Series[Name].Color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                chart1.Series[Name].Legend = "Legend1";
                chart1.Series[Name].ChartArea = "ChartArea1";
                chart1.Series[Name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
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
                _Const.SetCuts(MaxX1, MaxX2);
                //The following is to make sure that the graph has the correct range
                if (_Const.Cut1.X > MaxX1)
                {
                    MaxX1 = (int)_Const.Cut1.X + 1;
                    ResetGraph();
                    break;
                }
                if (_Const.Cut2.Y > MaxX2)
                {
                    MaxX2 = (int)_Const.Cut2.Y + 1;
                    ResetGraph();
                    break;
                }
                if (_Const.Cut1.Y > MaxX2)
                {
                    MaxX2 = (int)_Const.Cut1.Y + 1;
                    ResetGraph();
                    break;
                }
                if (_Const.Cut1.Y<MinX2)
                {

                }
                if (_Const.Cut1.X < MinX1)
                {
                    MinX1 = (int)_Const.Cut1.X + 1;
                    ResetGraph();
                    break;
                }
                if (_Const.Cut2.Y < MinX2)
                {
                    MinX2 = (int)_Const.Cut2.Y + 1;
                    ResetGraph();
                    break;
                }
            }
        }

        public class Constraint
        {
            public string ID;
            public string Sign;
            public float X1Coefficient;
            public float X2Coefficient;
            public float RHS;
            public Point Cut1;
            public Point Cut2;

            public Constraint(string _ID, string _Sign, string _X1Coef, string _X2Coef, string _RHS, int MaxX1, int MaxX2)
            {
                ID = _ID;
                Sign = _Sign;
                X1Coefficient = int.Parse(_X1Coef);
                X2Coefficient = int.Parse(_X2Coef);
                RHS = int.Parse(_RHS);
                Cut1 = new Point(0, 0);
                Cut2 = new Point(0, 0);
                SetCuts(MaxX1, MaxX2);
            }

            public  bool CheckPoint(Point _Point)
            {
                bool Result = true;
                float X1Value = _Point.X * X1Coefficient;
                float X2Value = _Point.Y * X2Coefficient;
                float Total = X1Value + X2Value;
                if (Sign==">=")
                {
                    Result = !(Total >= RHS);
                }
                else
                {
                    if (Sign=="<=")
                    {
                        Result = !(Total <= RHS);
                    }
                    else
                    {
                        Result = !(Total == RHS);
                    }
                }
                return Result;
            }

            public void SetCuts(int MaxX1, int MaxX2)
            {
                bool Cut1Zero = false;
                if (X1Coefficient != 0)
                {
                    Cut1 = new Point(RHS / X1Coefficient, 0);
                }
                else
                {//If the coefficient of x1 is 0, then the line must represent a single x2 value
                    Cut1Zero = true;
                    Cut1 = new Point(MaxX1, 0);
                }
                if (Cut1.X < 0)
                {//If the cut is less than 0, we flip it over to the maximum positive side for aesthetic purposes
                    Cut1.X = MaxX1;
                    Cut1.Y = (RHS - X1Coefficient * MaxX1) / X2Coefficient;
                }
                if (X2Coefficient != 0)
                {
                    Cut2 = new Point(0, RHS / X2Coefficient);
                }
                else
                {
                    Cut2 = new Point(Cut2.X, MaxX2);
                }
                if (Cut1Zero == true)
                {
                    Cut1.Y = Cut2.Y;
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

        private bool ValuesAreEmpty() 
        {
            bool x1coefecientValid = false;
            bool x2coefecientValid = false;
            bool signValid = false;
            bool RHSvalid = false;
            bool valid = false;
            if (txtX1Coef.Text.Length != 0)
            {
                x1coefecientValid = true;
            }
            if (txtRHS.Text.Length != 0)
            {
                RHSvalid = true;
            }
            if (cbxSign.Text.Length != 0)
            {
                signValid = true;
            }
            if (txtX2Coef.Text.Length != 0)
            {
                x2coefecientValid = true;
            }
            if (x1coefecientValid==true && RHSvalid == true && signValid == true && x2coefecientValid == true)
            {
                return true;
            } else
            {
                return false;
            }
        }

        private void btnAddConstraint_Click(object sender, EventArgs e)
        {
            if (ValuesAreEmpty())
            {
                AddConstraint(txtX1Coef.Text, txtX2Coef.Text, cbxSign.Text, txtRHS.Text);
            }
            
            
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
       
        void    DisplayError    (string Error)
        {
            lblError.Text = Error;
        }
    }
}
