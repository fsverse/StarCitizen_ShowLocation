using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Shapes;



namespace StarCitizen_ShowLocation
{

    public partial class Form1 : Form
    {
        const UInt32 WM_KEYDOWN = 0x0100;
        const int VK_RETURN = 0x0D;
        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        public Form1()
        {
            InitializeComponent();
            previous_positions = new List<struct_position>();
            
            
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, dispXY.Width - 3, dispXY.Height - 3);
            Region rg = new Region(gp);
            dispXY.Region = rg;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        struct struct_position
        {
            public double x, y,z;
        }

        double x = 0.0;
        double y = 0.0;
        double z = 0.0;

        double last_x = 0.0;
        double last_y = 0.0;
        double last_z = 0.0;

        double target_x = 0.0;
        double target_y = 0.0;
        double target_z = 0.0;

        double dist_to_target = 0;
        double last_dist_to_target = 0;
        double rate_of_change = 0;
        double bearing_to_target = 0;
        double current_bearing = 0;

        double sweep_bearing = 0;
        string current_clipboardText = "";

        string last_clipboardText = "";

   

        double display_zoom = 512.0;
        double display_zoom_2 = 512.0;

        DateTime time_of_last_coord_change;

        List<struct_position> previous_positions;

        
        public static double fmod(double a, double b)
        {
            return a % b;

        }
        public static double convert_deg_from_north_to_radians(double deg)
        {
            double t_deg = deg;
            t_deg -= 90;
            if (t_deg < 0) t_deg += 360;
            if (t_deg > 360) t_deg -= 360;
            return deg2rad(t_deg);
            //return (450 - deg) % 360;
        }
        

        public static double convert_cartesian_to_deg_from_north(double x, double y)
        {
            double rad = ((3 * Math.PI / 2.0) - Math.Atan2(y, x));
            
            return fmod(((rad) + (2 * Math.PI)), (2 * Math.PI)) * (180.0 / Math.PI);
        }

        public static double rad2deg(double radians)
        {
            return radians * (180.0 / (double)Math.PI);
        }
        public static double deg2rad(double degrees)
        {
            return degrees * ((double)Math.PI/180);
        }

        private double GetBearing(double x1,double y1,double x2,double y2)
        {
            double brg = 0;
            brg = (360 - convert_cartesian_to_deg_from_north((y2 - y1), (x2 - x1))) - 90;
            if (brg < 0) brg += 360;
            if (brg < 360) brg += 360;
            if (brg >= 360) brg -= 360;
            return brg;
        }
        private double GetBearing_On_A_Sphere(double lat1, double lon1, double lat2, double lon2)
        {
            double brg=0;
            double DEG_PER_RAD = (180.0 / Math.PI);
            var dLon = lon2 - lon1;
            var y = Math.Sin(dLon) * Math.Cos(lat2);
            var x = Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(dLon);
            brg = DEG_PER_RAD * Math.Atan2(y, x);
            if (brg < 360) brg += 360;
            if (brg >= 360) brg -= 360;
            return brg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grabCoords();
        }

        private void displayXY_Paint_OLD(object sender, PaintEventArgs e)
        {
            float max_x = dispXY.ClientRectangle.Width;
            float max_y = dispXY.ClientRectangle.Height;

            double max_range;
            max_range = 100.0 * display_zoom;


            using (Pen pen = new Pen(Color.DarkGreen, 1))
            {
                e.Graphics.DrawLine(pen, max_x / 2, 0, max_x / 2, max_y);
                e.Graphics.DrawLine(pen, 0, max_y / 2, max_x, max_y / 2);

            }
            // shows within 40,000 km range
            // user needs to get this close before the display shows anything
            


            // normalize
            double norm_target_x = ((target_x-x)/1000 / max_range) +  0.5;
            double norm_target_y = ((target_y-y)/1000 / max_range) + 0.5;


            float display_x = 0;
            float display_y = 0;
            if((norm_target_x < 1) && (norm_target_y < 1)){
                display_x = (float)(norm_target_x * max_x);
                display_y = (float)(norm_target_y * max_y);
            }



            using (Pen pen = new Pen(Color.Red, 1))
            {
                e.Graphics.DrawEllipse(pen,display_x-2, display_y-2, 4, 4);
            }
            /*
            using (Pen pen = new Pen(Color.Blue, 2))
            {
                e.Graphics.DrawLine(pen, 0,0, max_x, max_y);
            }
            */
            /*
            Rectangle ee = new Rectangle(10, 10, 30, 30);
            using (Pen pen = new Pen(Color.Red, 2))
            {
                e.Graphics.DrawRectangle(pen, ee);
            }
            */
        }
        private void displayXY_Paint(object sender, PaintEventArgs e)
        {
            float max_x = dispXY.ClientRectangle.Width;
            float max_y = dispXY.ClientRectangle.Height;

            double max_range;
            max_range = 100.0 * display_zoom;

            // Draw GRID
            using (Pen pen = new Pen(Color.DarkGreen, 1))
            {
                e.Graphics.DrawLine(pen, max_x / 2, 0, max_x / 2, max_y);
                e.Graphics.DrawLine(pen, 0, max_y / 2, max_x, max_y / 2);
            }

            // Draw range rings
            Font drawFont = new Font("Arial", 8);
            SolidBrush drawBrush = new SolidBrush(Color.LightGreen);
            double range_in_meters = 0;
            for (int i = 1; i < 5; i++)
            {
                range_in_meters = i * ((max_range*1000)/5); // max_range is in km..so convert back to meteres
                                                            // NB. this is the range across the WHOLE scope NOT from the centre
                double norm_rangecircle_x = ((range_in_meters) / 1000 / max_range);
                double norm_rangecircle_y = -((range_in_meters) / 1000 / max_range);


                float display_rangecircle_x = 0;
                float display_rangecircle_y = 0;
                if ((norm_rangecircle_x < 1) && (norm_rangecircle_y < 1))
                {
                    display_rangecircle_x = (float)(norm_rangecircle_x * max_x);
                    display_rangecircle_y = (float)(norm_rangecircle_y * max_y);
                }

                using (Pen pen = new Pen(Color.DarkGreen, 1))
                {
                    e.Graphics.DrawEllipse(pen, (max_x / 2) - (display_rangecircle_x / 2), (max_y / 2) - (display_rangecircle_y) / 2, display_rangecircle_x, display_rangecircle_y);
                    String drawString = (range_in_meters/1000/2).ToString("N0");

                    // Create font and brush.
                    

                    // Create point for upper-left corner of drawing.
                    
                    // Set format of string.
                    StringFormat drawFormat = new StringFormat();
                    drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

                    // Draw string to screen.
                    e.Graphics.DrawString(drawString, drawFont, drawBrush, (max_x/2)+(display_rangecircle_x/2), max_y/2, drawFormat);
                }
            }
            /*
            double norm_t_x = 0.5 + ((-10000 - x) / 1000 / max_range);
            double norm_t_y = 0.5 - ((10000 - y) / 1000 / max_range);

            float temp_x = 0;
            float temp_y = 0;
            temp_x = (float)(norm_t_x * max_x);
            temp_y = (float)(norm_t_y * max_y);

            using (Pen pen = new Pen(Color.White, 1))
            {
                e.Graphics.DrawEllipse(pen, temp_x - 2, temp_y - 2, 4, 4);
            }
            */

            ///////////////////////////////////////////////////////////////////////////
            // Show user
            //Icon newIcon = new Icon("Resources/Icon1.ico");



            using (Pen pen = new Pen(Color.Green, 2))
            {
                float center_x = max_x / 2;
                float center_y = max_y / 2;
                float nose_x = (float)(40.0 * Math.Cos(convert_deg_from_north_to_radians(current_bearing)));
                float nose_y = (float)(40.0 * Math.Sin(convert_deg_from_north_to_radians(current_bearing)));
                e.Graphics.TranslateTransform(center_x, center_y);
                //e.Graphics.TranslateTransform(-(float)this.Width / 2, -(float)this.Height / 2); 
                e.Graphics.RotateTransform((float)current_bearing);
                //e.Graphics.TranslateTransform((float)this.Width / 2, (float)this.Height / 2);
                //e.Graphics.TranslateTransform(center_x, center_y);
                //e.Graphics.DrawLine(pen, center_x, center_y, center_x + 0, center_y -50);
                // Create rectangle for icon.
                
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, 20, 20);

                // Draw icon to screen.
                //  e.Graphics.DrawIcon(newIcon, rect);
                Point[] points = { new Point(-10, -25), new Point(10, -25), new Point(0, -50) };
                e.Graphics.DrawPolygon(new Pen(Color.LightGreen), points);
                //Point[] points2 = { new Point(100, 100), new Point(200, 100), new Point(150, 10) };
                //e.Graphics.FillPolygon(new SolidBrush(Color.Red), points2);

                e.Graphics.DrawLine(pen, 0, 25, 0, -25);
                e.Graphics.TranslateTransform(-center_x, -center_y);
                e.Graphics.ResetTransform();
            }


            // show target
            // normalize
            double norm_target_x = 0.5 + ((target_x - x) / 1000 / max_range);
            double norm_target_y = 0.5- ((target_y - y) / 1000 / max_range) ;


            float display_target_x = 0;
            float display_target_y = 0;
            if ((norm_target_x < 1) && (norm_target_y < 1))
            {
                display_target_x = (float)(norm_target_x * max_x);
                display_target_y = (float)(norm_target_y * max_y);
            }


            

            using (Pen pen = new Pen(Color.Red, 3))
            {
                e.Graphics.DrawEllipse(pen, display_target_x - 4, display_target_y - 4, 8, 8);
            }
            ///////////////////////
            ///


            //  Display previous target positions

            int fade = 200;
            foreach(struct_position pos in previous_positions){
                norm_target_x = 0.5 + ((target_x - pos.x) / 1000 / max_range);
                norm_target_y = 0.5 - ((target_y - pos.y) / 1000 / max_range);

                display_target_x = 0;
                display_target_y = 0;
                if ((norm_target_x < 1) && (norm_target_y < 1))
                {
                    display_target_x = (float)(norm_target_x * max_x);
                    display_target_y = (float)(norm_target_y * max_y);
                }

                using (Pen pen = new Pen(Color.FromArgb(fade,255,0,0), 1))
                {
                    e.Graphics.DrawEllipse(pen, display_target_x - 2, display_target_y - 2, 4, 4);
                }
                fade = fade-20;
            }


            /*
            using (Pen pen = new Pen(Color.Blue, 2))
            {
                e.Graphics.DrawLine(pen, 0,0, max_x, max_y);
            }
            */
            /*
            Rectangle ee = new Rectangle(10, 10, 30, 30);
            using (Pen pen = new Pen(Color.Red, 2))
            {
                e.Graphics.DrawRectangle(pen, ee);
            }
            */
        }
        
        private void displayXZ_Paint(object sender, PaintEventArgs e)
        {
            // shows within 20,000 km range
            // user needs to get this close before the display shows anything
            double max_range;
            max_range = 100.0 * display_zoom_2;

            float max_x = dispXZ.ClientRectangle.Width;
            float max_y = dispXZ.ClientRectangle.Height;

            // normalize
            double delta_x, delta_y, delta_z;
            delta_x = target_x - x;
            delta_y = target_y - y;
            delta_z = target_z - z;

            double target_xy = 0.0; // Math.Sqrt((delta_x*delta_x) + (delta_y * delta_y));
            double norm_target_xy = 0.5 + (target_xy/1000 / max_range);
            double norm_target_z = 0.5 - ((target_z-z)/1000 / max_range);

            float display_target_x = 0;
            float display_target_y = 0;
            if ((norm_target_xy < 1) && (norm_target_z < 1))
            {
                display_target_x = (float)(norm_target_xy * max_x);
                display_target_y = (float)(norm_target_z * max_y) ; 
            }

            using (Pen pen = new Pen(Color.DarkGreen, 1))
            {
                e.Graphics.DrawLine(pen, max_x / 2, 0, max_x / 2, max_y);
                e.Graphics.DrawLine(pen, 0, max_y / 2, max_x, max_y / 2);

            }
            
            using (Pen pen = new Pen(Color.Red, 3))
            {
                e.Graphics.DrawEllipse(pen, display_target_x - 4, display_target_y - 4, 8, 8);
            }
            /*
            using (Pen pen = new Pen(Color.Blue, 2))
            {
                e.Graphics.DrawLine(pen, 0,0, max_x, max_y);
            }
            */
            /*
            Rectangle ee = new Rectangle(10, 10, 30, 30);
            using (Pen pen = new Pen(Color.Red, 2))
            {
                e.Graphics.DrawRectangle(pen, ee);
            }
            */
        }
        private void updateDisplayXY()
        {
            dispXY.Refresh();
        }

        private void updateDisplayXZ()
        {
            dispXZ.Refresh();
        }

        private void grabCoords()
        {
            // Coordinates: x:-18999594517.847286 y:-2657740650.665195 z:15986.802810
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                // MoveCurrentCoordsToLast
                last_x = x;
                last_y = y;
                last_z = z;
                // Move them onto the previos_position list
                struct_position temp_pos;
                temp_pos.x = x;
                temp_pos.y = y;
                temp_pos.z = z;

                if (previous_positions.Count > 5)
                {
                    previous_positions.RemoveAt(4);
                }
                previous_positions.Add(temp_pos);


                txtCoordXLast.Text = last_x.ToString();
                txtCoordYLast.Text = last_y.ToString();
                txtCoordZLast.Text = last_z.ToString();

                ///////////////////////////////////////////////////////

                // Get New X,Y,Z

                current_clipboardText = Clipboard.GetText(TextDataFormat.Text);
                txtFromClipboard.Text = current_clipboardText;

                string[] clipboardTokens = current_clipboardText.Split(' ');



                string[] tempTokensX = clipboardTokens[1].Split(':');
                x = Convert.ToDouble(tempTokensX[1]);
                txtCoordX.Text = x.ToString();

                string[] tempTokensY = clipboardTokens[2].Split(':');
                y = Convert.ToDouble(tempTokensY[1]);
                txtCoordY.Text = y.ToString();

                string[] tempTokensZ = clipboardTokens[3].Split(':');
                z = Convert.ToDouble(tempTokensZ[1]);
                txtCoordZ.Text = z.ToString();

                /////////////////////////////////////////////////////////
                ///

                // Calculate Deltas

                double delta_x, delta_y, delta_z;
                delta_x = target_x - x;
                delta_y = target_y - y;
                delta_z = target_z - z;

                txtDeltaX.Text = delta_x.ToString();
                txtDeltaY.Text = delta_y.ToString();
                txtDeltaZ.Text = delta_z.ToString();

                /////////////////////////////////////////

                // Calc Distance

                last_dist_to_target = dist_to_target;   // before we change it

                double delta_x_squared = (delta_x * delta_x);
                double delta_y_squared = (delta_y * delta_y);
                double delta_z_squared = (delta_z * delta_z);

                dist_to_target = Math.Sqrt(delta_x_squared + delta_y_squared + delta_z_squared);
                string tmp_dist_to_target_str = "";

                /*
                if (dist_to_target > 1000000000)
                {
                    tmp_dist_to_target_str = String.Format("{0:.##}", Math.Round(dist_to_target / 1000000000, 2)) + " mil km";
                }
                */

                if (dist_to_target > 10000)
                {
                    tmp_dist_to_target_str = Math.Round(dist_to_target/1000, 2).ToString("N0") + " km";
                }
                if (dist_to_target <= 10000)
                {
                    tmp_dist_to_target_str = Math.Round(dist_to_target, 2).ToString("N0") + " m";
                }

                lblDistanceToTarget.ForeColor = Color.Black;
                if (dist_to_target < 300000)
                {
                    lblDistanceToTarget.ForeColor = Color.Blue;
                }
                if(dist_to_target < 100000)
                {
                    lblDistanceToTarget.ForeColor = Color.Green;
                }

                lblDistanceToTarget.Text = tmp_dist_to_target_str;

                //////////////////////////////////////////////////////////
                ///

                // Rate of Change ie. How fast are we approaching the target..the faster the better

                DateTime current_time = DateTime.Now;

                TimeSpan time_delta;
                time_delta = current_time - time_of_last_coord_change;
                double msecs_delta = time_delta.TotalMilliseconds;
                double distance_to_target_delta = last_dist_to_target-dist_to_target;

                //textBox1.Text = msecs_delta.ToString();
                //textBox2.Text = distance_to_target_delta.ToString();

                rate_of_change = (distance_to_target_delta / msecs_delta)*1000;
                lblRateOfChange.Text = rate_of_change.ToString("N0") + " m/s";

                time_of_last_coord_change = DateTime.Now;
                last_dist_to_target = dist_to_target;


                // Coordinates: x:-19015740021.120113 y:-2634733670.744523 z:7019.973256

                //////////////////////////////////////////////////////////////////
                ///

                //  Bearing to target
                double brg;
                /*
                brg = rad2deg(Math.Atan2((target_y - y),(target_x - x)));
                brg -= 90;
                if (brg < 0) brg += 360;
                */

                /*
                brg = (360- convert_cartetian_to_deg_from_north((target_y - y), (target_x - x))) -90;
                if (brg < 0) brg += 360;
                */
                brg = GetBearing(x,y,target_x,target_y);

                bearing_to_target = brg;
                lblBearingToTarget.Text= brg.ToString("N0");

                //
                //  Current Bearing  (computed from last and current co-ords
                /*
                brg = rad2deg(Math.Atan2((y - last_y),(x-last_x)));
                brg -= 90;
                if (brg < 0) brg += 360;
                */
                /*
                brg = (360-convert_cartetian_to_deg_from_north((y - last_y), (x - last_x))-90);
                if (brg < 0) brg += 360;
                */
                brg = GetBearing(last_x, last_y, x, y);
                current_bearing = brg;

                //lblCurrentBearing.Text = String.Format("{0:.##}", brg);
                lblCurrentBearing.Text = brg.ToString("N0");
                //////////////////////////////////////////////////////////////////
                ///

                // Elevation (Z-coord)
                if (Math.Abs(z) < 1000)
                {
                    lblCurrentZ.Text =  z.ToString("N0") + " m";
                }
                else
                {
                    lblCurrentZ.Text = (z / 1000).ToString("N0") + " km";
                }
                if (Math.Abs(target_z) < 1000)
                {
                    lblTargetZ.Text = target_z.ToString("N0") + " m";
                }
                else
                {
                    lblTargetZ.Text = (target_z / 1000).ToString("N0") + " km";
                }
                



                //  Elevation (angle) to target
                double dist_xy = Math.Sqrt(delta_x_squared + delta_y_squared);
                
                double elev_to_target = Math.Atan2((target_z - z),dist_xy);
                lblElevationToTarget.Text = String.Format("{0:.##}",rad2deg(elev_to_target));

                // Current Elevation (pitch?) (computed from last and current co-ords

                delta_x = last_x-x;
                delta_y = last_y-y;
                delta_z = last_z-z;

                delta_x_squared = (delta_x * delta_x);
                delta_y_squared = (delta_y * delta_y);
                delta_z_squared = (delta_z * delta_z);

                dist_xy = Math.Sqrt(delta_x_squared + delta_y_squared);

                double pitch = Math.Atan2(delta_z, dist_xy);

                lblCurrentElevation.Text = String.Format("{0:.##}", pitch);
                
            }
        }
        private void setTarget()
        {
            string targetText = txtTarget.Text;


            string[] targetTokens = targetText.Split(' ');



            string[] tempTokensX = targetTokens[1].Split(':');
            target_x = Convert.ToDouble(tempTokensX[1]);
            txtCoordXTarget.Text = target_x.ToString();

            string[] tempTokensY = targetTokens[2].Split(':');
            target_y = Convert.ToDouble(tempTokensY[1]);
            txtCoordYTarget.Text = target_y.ToString();

            string[] tempTokensZ = targetTokens[3].Split(':');
            target_z = Convert.ToDouble(tempTokensZ[1]);
            txtCoordZTarget.Text = target_z.ToString();
        }
        private void btnTargetSet_Click(object sender, EventArgs e)
        {
            setTarget();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            timer2.Enabled = false;
            
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);
                if (clipboardText.StartsWith("Coordinates:"))
                {
                    if (clipboardText != last_clipboardText)
                    {
                        last_clipboardText = clipboardText;

                        timer2.Enabled = true;
                        txtFromClipboard.BackColor = Color.Green;

                        grabCoords();
                        updateDisplayXY();
                        updateDisplayXZ();
                    }
                }
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            txtFromClipboard.BackColor = Color.White;
            timer2.Enabled = false;
        }

        private void btnMakeTarget_Click(object sender, EventArgs e)
        {
            txtTarget.Text = txtFromClipboard.Text;
            setTarget();
        }

        private void dispXY_Click(object sender, EventArgs e)
        {

        }

        private void displayZoomIn_Click(object sender, EventArgs e)
        {
            display_zoom= display_zoom*2;
            lblDisplayZoomLevel.Text = String.Format("{0:.#}", display_zoom);
            updateDisplayXY();
            updateDisplayXZ();
        }

        private void displayZoomOut_Click(object sender, EventArgs e)
        {
            display_zoom= display_zoom/2;
            lblDisplayZoomLevel.Text = String.Format("{0:.#}", display_zoom);
            updateDisplayXY();
            updateDisplayXZ();
        }


        private void displayZoomOut2_Click(object sender, EventArgs e)
        {
            display_zoom_2 = display_zoom_2 / 2;
            lblDisplayZoomLevel2.Text = String.Format("{0:.#}", display_zoom_2);
            updateDisplayXY();
            updateDisplayXZ();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            sweep_bearing++;
            if (sweep_bearing > 359) sweep_bearing = 0;
            updateDisplayXY();
            //SendKeys.SendWait("{TAB}");
            //SendKeys.SendWait("{TAB}");
            //SendKeys.SendWait("{ENTER}");
            //SendKeys.Flush();

            //while (true)
            //{
                Process[] processes = Process.GetProcessesByName("STARCITIZEN");

                foreach (Process proc in processes)
                    PostMessage(proc.MainWindowHandle, WM_KEYDOWN, VK_RETURN, 0);

                //Thread.Sleep(5000);
            //}
        }

        private void displayZoomIn2_Click(object sender, EventArgs e)
        {
            display_zoom_2 = display_zoom_2 * 2;
            lblDisplayZoomLevel2.Text = String.Format("{0:.#}", display_zoom_2);
            updateDisplayXY();
            updateDisplayXZ();
        }

    }
}
