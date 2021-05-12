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
            public string ID;//Used to identify the constraint
            public string Sign;
            public float X1Coefficient;
            public float X2Coefficient;
            public float RHS;
            public Point Cut1;  //These are points used to display the line
            public Point Cut2;  

            //Constructor for the constraint
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
                //This checks if a point is meets this constraint's requirements
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

            //This is used to set where the graph should be drawn
            public void SetCuts(int MaxX1, int MaxX2, int MinX1, int MinX2)
            {
                //If at least one variable is included in the constraint
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

            public  float   GetZ    (Point  Input)
            {//Returns a rhs value for a point
                return X1Coefficient * Input.X + X2Coefficient * Input.Y;
            }
        }

        //This is made to attach a X value to a Y value
        public struct Point
        {
            public float X;
            public float Y;

            //Constructor
            public Point(float _X, float _Y)
            {
                X = _X;
                Y = _Y;
            }


            public override string ToString()
            {
                return "( " + X.ToString() + " : " + Y.ToString() + " )";
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        public List<Constraint> AllConstraints;
        public Constraint ObjectiveFunction;//We make the OF a constriant, because why not?
        public List<Point> FeasibleArea;//This hold all the points that are within the feasible area
        //The following values are used to determine the size of the graph, so that it always scales with the constraints
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
            ResetForm();
        }

        void AddConstraint(string X1Coef, string X2Coef, string Sign, string RHS)
        {
            int ID = AllConstraints.Count;
            Constraint NewConstraint = new Constraint(ID.ToString(), Sign, X1Coef, X2Coef, RHS, MaxX1, MaxX2, MinX1, MinX2);
            AllConstraints.Add(NewConstraint);
            DisplayConstraints();//This shows the constraints in the list box
            DrawConstraints(NewConstraint);//This draws the constraints
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
                chart1.Series[Name].Points.AddXY(MinX1, (float)y/100.0f);//We devide by 100 so that they are close to each other
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

            for (int i = 0; i < AllConstraints.Count; i++)
            {
                DrawConstraint(AllConstraints[i]);
            }
        }

        void    DrawConstraint  (Constraint _Const)
        {
            Random rand = new Random();//For color purposes
            string Name = "Constraint " + _Const.ID;
            if (_Const.ID=="Objective Function")
            {
                Name = "Objective Function";
            }
            chart1.Series.Add(Name);
            chart1.Series[Name].Color = Color.FromArgb(rand.Next(246) + 10, rand.Next(246) + 10, rand.Next(246) + 10);
            //We say 246 + 10 so that the minimum value is 10. This is so that there are no lines that are near black in color, to avoid confusion with the X1 and X2 lines.
            chart1.Series[Name].Legend = "Legend1";
            chart1.Series[Name].ChartArea = "ChartArea1";
            chart1.Series[Name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            _Const.SetCuts(MaxX1, MaxX2, MinX1, MinX2);
            chart1.Series[Name].Points.AddXY(_Const.Cut1.X, _Const.Cut1.Y);
            chart1.Series[Name].Points.AddXY(_Const.Cut2.X, _Const.Cut2.Y);
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
        private bool signIsCorrect()
        {
            string sign = cbxSign.Text; 
            if (sign == "<=" || sign == ">=" || sign == "=")
            {
                return true;
            } else
            {
                return false;
            }
        }
        private bool ThisValueIsNumber(string value)
        {
            float f;
            bool isNumeric = float.TryParse(value, out f);
            if (isNumeric)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ValuesAreCorrect() 
        {
            bool x1coefecientValid = false;
            bool x2coefecientValid = false;
            bool signValid = false;
            bool RHSvalid = false;
            bool valid = false;
            if (txtX1Coef.Text.Length != 0)
            {
                if (ThisValueIsNumber(txtX1Coef.Text)){x1coefecientValid = true;}
            }
            if (txtRHS.Text.Length != 0)
            {
                if (ThisValueIsNumber(txtRHS.Text)){RHSvalid = true;}
            }
            if (cbxSign.Text.Length != 0)
            {
                if (signIsCorrect()) {signValid = true;}
            }
            if (txtX2Coef.Text.Length != 0)
            {
                if (ThisValueIsNumber(txtX2Coef.Text)) {x2coefecientValid = true;}
            }
            if (x1coefecientValid==true && RHSvalid == true && signValid == true && x2coefecientValid == true)
            {return true;} else { return false;}
        }

        private void btnAddConstraint_Click(object sender, EventArgs e)
        {
            if (ValuesAreCorrect())
            {
                AddConstraint(txtX1Coef.Text, txtX2Coef.Text, cbxSign.Text, txtRHS.Text);
                ResetConstraintAdd();
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
                if (AllConstraints.Count > 0)
                {
                    //To Check the feasible area, we start at 0,0 then we check every position in a 0.01 interval all the way to the max values
                    int XMax = (int)(MaxX1+1) * 100;//We say *100 to make the interval 0.01 later
                    int XMin = (int)0;
                    int YMax = (int)(MaxX2+1) * 100;
                    int YMin = (int)0;
                    FeasibleArea = new List<Point>();
                    for (int x = XMin; x < XMax; x++)
                    {
                        for (int y = YMin; y < YMax; y++)
                        {
                            Point TestPoint = new Point((float)x / 100.0f, (float)y / 100.0f);//Here we /100 again, to make it 0.01
                            bool Feasible = true;
                            for (int i = 0; i < AllConstraints.Count; i++)//Checks all the constraints to see if the current point is feasible
                            {
                                if (!AllConstraints[i].CheckPoint(TestPoint))//If the point is not within the current constraint's limits ->
                                {
                                    Feasible = false;//-> then we say the point is infeasible
                                    break;//We don't need to check the rest of the constraints then
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
            /*  Because of the way this check works, there is some loss of accuracy. The code only checks points in a .01 interval.
                So if there needs to be values less than 0.01, they will be ignored.
            */
        }

        void    DrawFeasibleArea    ()
        {
            if (FeasibleArea!=null)
            {
                if (FeasibleArea.Count>0)
                {
                    if (ObjectiveFunction!=null)
                    {
                        DrawConstraint(ObjectiveFunction);//We also draw the objective function
                        string Name = "Feasible Area";
                        Random rand = new Random();
                        chart1.Series.Add(Name);
                        chart1.Series[Name].Color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                        chart1.Series[Name].Legend = "Legend1";
                        chart1.Series[Name].ChartArea = "ChartArea1";
                        chart1.Series[Name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        float BestZ = -1;
                        Point OptimalPoint  =   new Point(-1,-1);//We default these values to -1 so that we can use it as a check later
                        for (int i = 0; i < FeasibleArea.Count; i++)
                        {
                            chart1.Series[Name].Points.AddXY(FeasibleArea[i].X, FeasibleArea[i].Y);
                            float Z = ObjectiveFunction.GetZ(FeasibleArea[i]);
                            if (ObjectiveFunction.Sign==">")
                            {
                                if (Z > BestZ   ||  BestZ==-1)
                                {
                                    BestZ = Z;
                                    OptimalPoint = FeasibleArea[i];
                                }
                            }
                            else
                            {
                                if (Z < BestZ || BestZ == -1)
                                {
                                    BestZ = Z;
                                    OptimalPoint = FeasibleArea[i];
                                }
                            }
                        }
                        if (OptimalPoint.X>-1)
                        {
                            DisplayError("Optimal Point is at "+OptimalPoint.ToString());
                            if (FeasibleArea.Contains(new   Point(MaxX1,MaxX2)))
                            {
                                DisplayError("Unbounded");
                            }
                        }
                        else
                        {
                            DisplayError("No Optimal Point Found");
                        }
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
            DrawConstraints();
            GetObjectiveFunction();
            ScanFeasibleArea();
            DrawFeasibleArea();
        }

        void GetObjectiveFunction   ()
        {
            string X1Coef = txtX1CoefOF.Text;
            string X2Coef = txtX2CoefOF.Text;
            string RHS = "0";
            string Sign = "<";//We use these signs just as a reference later on
            if (cbxMinMax.Text=="Max")
            {
                Sign = ">";
            }
            ObjectiveFunction = new Constraint("Objective Function", Sign, X1Coef, X2Coef, RHS, MaxX1, MaxX2, MinX1, MinX2);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        void    ResetForm ()
        {
            chart1.Series.Clear();
            AllConstraints = new List<Constraint>();
            FeasibleArea = new List<Point>();
            ObjectiveFunction = null;
            lblError.Text = "";
            lbxConstraints.Items.Clear();
            txtRemoveID.Text = "";
            txtX1CoefOF.Text = "";
            txtX2CoefOF.Text = "";
            cbxMinMax.Text = "Max";
            ResetConstraintAdd();
        }

        void    ResetConstraintAdd  ()
        {
            txtRHS.Text = "";
            txtX1Coef.Text = "";
            txtX2Coef.Text = "";
            cbxSign.Text = ">=";
        }
    }
}
