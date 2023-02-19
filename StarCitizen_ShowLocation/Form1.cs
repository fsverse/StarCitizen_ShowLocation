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

        //
        //  This was an attempt to auto feed /showlocation into the SC window
        //
        const UInt32 WM_KEYDOWN = 0x0100;
        const int VK_RETURN = 0x0D;
        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 
        SCPoint3D player_current;
        SCPoint3D player_last;
        SCPoint3D target;

        //
        //          HELPERS
        //

        /*
        public static void copy_point(SCPoint3D src, SCPoint3D dest)
        {
            dest.X = src.X;
            dest.Y = src.Y;
            dest.Z = src.Z;
            dest.timestamp = src.timestamp;
            dest.distance_to_target = src.distance_to_target;
        }
        */
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
            return degrees * ((double)Math.PI / 180);
        }
        public double GetBearing(double x1, double y1, double x2, double y2)
        {
            double brg = 0;
            brg = (360 - convert_cartesian_to_deg_from_north((y2 - y1), (x2 - x1))) - 90;
            if (brg < 0) brg += 360;
            if (brg < 360) brg += 360;
            if (brg >= 360) brg -= 360;
            return brg;
        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////






        public Form1()
        {
            InitializeComponent();

            player_current = new SCPoint3D(0, 0, 0,0,0, DateTime.Now,0,0,0);
            player_last = new SCPoint3D(0, 0, 0,0,0, DateTime.Now,0,0,0);
            target = new SCPoint3D(0, 0, 0,0,0, DateTime.Now,0,0,0);


            // this makes the dispXY picture box a circle and not a square    
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, dispXY.Width - 3, dispXY.Height - 3);
            Region rg = new Region(gp);
            dispXY.Region = rg;
            ///////////////////////////////////////////////////////////////////////

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //double x = 0.0;
        //double y = 0.0;
        //double z = 0.0;

        //double last_x = 0.0;
        //double last_y = 0.0;
        //double last_z = 0.0;

        //double target_x = 0.0;
        //double target_y = 0.0;
        //double target_z = 0.0;

        //double dist_to_target = 0;
        //double last_dist_to_target = 0;
        double rate_of_change = 0;
        //double bearing_to_target = 0;
        //double current_bearing = 0;
        //double current_elevation = 0;
        //double target_elevation = 0;


        string current_clipboardText = "";

        string last_clipboardText = "";



        double display_zoom = 512.0;
        double display_zoom_2 = 512.0;

       // DateTime time_of_last_coord_change;


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
                range_in_meters = i * ((max_range * 1000) / 5); // max_range is in km..so convert back to meters
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
                    String drawString = (range_in_meters / 1000 / 2).ToString("N0");

                    // Create font and brush.


                    // Create point for upper-left corner of drawing.

                    // Set format of string.
                    StringFormat drawFormat = new StringFormat();
                    drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

                    // Draw string to screen.
                    e.Graphics.DrawString(drawString, drawFont, drawBrush, (max_x / 2) + (display_rangecircle_x / 2), max_y / 2, drawFormat);
                }
            }

            // Show user
            using (Pen pen = new Pen(Color.LightGreen, 2))
            {
                float center_x = max_x / 2;
                float center_y = max_y / 2;
                float nose_x = (float)(40.0 * Math.Cos(convert_deg_from_north_to_radians(player_current.heading)));
                float nose_y = (float)(40.0 * Math.Sin(convert_deg_from_north_to_radians(player_current.heading)));
                e.Graphics.TranslateTransform(center_x, center_y);
                //e.Graphics.TranslateTransform(-(float)this.Width / 2, -(float)this.Height / 2); 
                e.Graphics.RotateTransform((float)player_current.heading);
                //e.Graphics.TranslateTransform((float)this.Width / 2, (float)this.Height / 2);
                //e.Graphics.TranslateTransform(center_x, center_y);
                //e.Graphics.DrawLine(pen, center_x, center_y, center_x + 0, center_y -50);
                // Create rectangle for icon.

                /*
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, 20, 20);

                // Draw icon to screen.
                //  e.Graphics.DrawIcon(newIcon, rect);
                Point[] points = { new Point(-10, -25), new Point(10, -25), new Point(0, -50) };
                e.Graphics.DrawPolygon(new Pen(Color.LightGreen), points);
                //Point[] points2 = { new Point(100, 100), new Point(200, 100), new Point(150, 10) };
                //e.Graphics.FillPolygon(new SolidBrush(Color.Red), points2);

                e.Graphics.DrawLine(pen, 0, 25, 0, -25);
                */

                e.Graphics.DrawLine(pen, -6, 20, 6, 20);    //tail
                e.Graphics.DrawLine(pen, -15, -15, 15, -15); // wings
                e.Graphics.DrawLine(pen, 0, 25, 0, -25);    //body

                e.Graphics.TranslateTransform(-center_x, -center_y);
                e.Graphics.ResetTransform();
            }

            // show target
            double norm_target_x = 0.5 + ((target.X - player_current.X) / 1000 / max_range);             // normalize
            double norm_target_y = 0.5 - ((target.Y - player_current.Y) / 1000 / max_range);            // normalize
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
        }
        private void displayXZ_Paint(object sender, PaintEventArgs e)
        {


            float max_x = dispXZ.ClientRectangle.Width;
            float max_y = dispXZ.ClientRectangle.Height;
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
                range_in_meters = i * ((max_range * 1000) / 5); // max_range is in km..so convert back to meters
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
                    String drawString = (range_in_meters / 1000 / 2).ToString("N0");
                    StringFormat drawFormat = new StringFormat();
                    drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                    e.Graphics.DrawString(drawString, drawFont, drawBrush, (max_x / 2) + (display_rangecircle_x / 2), max_y / 2, drawFormat);
                }
            }

            // show user

            using (Pen pen = new Pen(Color.LightGreen, 2))
            {
                float center_x = max_x / 2;
                float center_y = max_y / 2;

                e.Graphics.TranslateTransform(center_x, center_y);
                e.Graphics.RotateTransform((float)player_current.elevation);
                e.Graphics.DrawLine(pen, -6, 20, 6, 20);    //tail
                e.Graphics.DrawLine(pen, -15, -15, 15, -15); // wings
                e.Graphics.DrawLine(pen, 0, 25, 0, -25);    //body

                e.Graphics.TranslateTransform(-center_x, -center_y);
                e.Graphics.ResetTransform();
            }

            // show target
            double delta_x, delta_z;
            delta_x = target.X - player_current.X;
            delta_z = target.Z - player_current.Z;
            double norm_target_x = 0.5 + (delta_x / 1000 / max_range);       // normalize x
            double norm_target_z = 0.5 - ((delta_z) / 1000 / max_range);   // normalize z

            float display_target_x = 0;
            float display_target_y = 0;
            if ((norm_target_x < 1) && (norm_target_z < 1))
            {
                display_target_x = (float)(norm_target_x * max_x);
                display_target_y = (float)(norm_target_z * max_y);
            }
            using (Pen pen = new Pen(Color.Red, 3))
            {
                e.Graphics.DrawEllipse(pen, display_target_x - 4, display_target_y - 4, 8, 8);
            }
        }

        private void grabCoords()
        {
            // Format on clipboard is....
            // Coordinates: x:-18999594517.847286 y:-2657740650.665195 z:15986.802810

            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                // MoveCurrentCoordsToLast
                

                player_last.X = player_current.X;
                player_last.Y = player_current.Y;
                player_last.Z = player_current.Z;
                player_last.timestamp = player_current.timestamp;

                // dont copy distance to target or closure rate yet.

                txtCoordXLast.Text = player_last.X.ToString();
                txtCoordYLast.Text = player_last.Y.ToString();
                txtCoordZLast.Text = player_last.Z.ToString();

                ///////////////////////////////////////////////////////

                // Get New X,Y,Z

                current_clipboardText = Clipboard.GetText(TextDataFormat.Text);
                txtFromClipboard.Text = current_clipboardText;

                string[] clipboardTokens = current_clipboardText.Split(' ');



                string[] tempTokensX = clipboardTokens[1].Split(':');
                
                player_current.X= Convert.ToDouble(tempTokensX[1]);
                txtCoordX.Text = player_current.X.ToString();

                string[] tempTokensY = clipboardTokens[2].Split(':');
                player_current.Y = Convert.ToDouble(tempTokensY[1]);
                txtCoordY.Text = player_current.Y.ToString();

                string[] tempTokensZ = clipboardTokens[3].Split(':');
                player_current.Z = Convert.ToDouble(tempTokensZ[1]);
                txtCoordZ.Text = player_current.Z.ToString();

                player_current.timestamp = DateTime.Now;

                /////////////////////////////////////////////////////////
                ///

                // Calculate Deltas

                double delta_x, delta_y, delta_z;
                delta_x = target.X - player_current.X;
                delta_y = target.Y - player_current.Y;
                delta_z = target.Z - player_current.Z;

                txtDeltaX.Text = delta_x.ToString();
                txtDeltaY.Text = delta_y.ToString();
                txtDeltaZ.Text = delta_z.ToString();

                /////////////////////////////////////////

                // Calc Distance

                //last_dist_to_target = dist_to_target;   // before we change it

                double delta_x_squared = (delta_x * delta_x);
                double delta_y_squared = (delta_y * delta_y);
                double delta_z_squared = (delta_z * delta_z);

                player_current.distance_to_target = Math.Sqrt(delta_x_squared + delta_y_squared + delta_z_squared);
                string tmp_dist_to_target_str = "";

                
                if (player_current.distance_to_target > 10000)
                {
                    tmp_dist_to_target_str = Math.Round(player_current.distance_to_target / 1000, 2).ToString("N0") + " km";
                }
                if (player_current.distance_to_target <= 10000)
                {
                    tmp_dist_to_target_str = Math.Round(player_current.distance_to_target, 2).ToString("N0") + " m";
                }

                lblDistanceToTarget.ForeColor = Color.Black;
                if (player_current.distance_to_target < 300000)
                {
                    lblDistanceToTarget.ForeColor = Color.Blue;
                }
                if (player_current.distance_to_target < 100000)
                {
                    lblDistanceToTarget.ForeColor = Color.Green;
                }

                lblDistanceToTarget.Text = tmp_dist_to_target_str;

                //////////////////////////////////////////////////////////
                ///

                // Rate of Change ie. How fast are we approaching the target..the faster the better

                

                TimeSpan time_delta;
                time_delta = player_current.timestamp - player_last.timestamp;
                double msecs_delta = time_delta.TotalMilliseconds;
                double distance_to_target_delta = player_last.distance_to_target - player_current.distance_to_target;

                rate_of_change = (distance_to_target_delta / msecs_delta) * 1000;
                lblRateOfChange.Text = rate_of_change.ToString("N0") + " m/s";

                player_last.timestamp = DateTime.Now;
                
                player_last.distance_to_target = player_current.distance_to_target;


                

                //////////////////////////////////////////////////////////////////
                ///

                //  Bearing to target
                double brg;
                brg = GetBearing(player_current.X, player_current.Y, target.X, target.Y);
                player_current.bearing_to_target = brg;
                lblBearingToTarget.Text = brg.ToString("N0");

                //
                //  Current Heading  (computed from last and current co-ords

                double hdg;
                hdg = GetBearing(player_last.X, player_last.Y, player_current.X, player_current.Y);
                player_current.heading = hdg;
                lblCurrentBearing.Text = hdg.ToString("N0");
                //////////////////////////////////////////////////////////////////
                ///

                // Elevation (Z-coord) dist to target
                if (Math.Abs(player_current.Z) < 1000)
                {
                    lblCurrentZ.Text = player_current.Z.ToString("N0") + " m";
                }
                else
                {
                    lblCurrentZ.Text = (player_current.Z / 1000).ToString("N0") + " km";
                }
                if (Math.Abs(target.Z) < 1000)
                {
                    lblTargetZ.Text = target.Z.ToString("N0") + " m";
                }
                else
                {
                    lblTargetZ.Text = (target.Z / 1000).ToString("N0") + " km";
                }




                //  Elevation (angle) to target
                delta_x = target.X - player_current.X;
                delta_z = target.Z - player_current.Z;
                player_current.elevation_to_target = GetBearing(player_current.X, player_current.Z, target.X, target.Z);
                lblElevationToTarget.Text = String.Format("{0:.##}", player_current.elevation_to_target);

                
                // Current Elevation (pitch?) (computed from last and current co-ords
                delta_x = player_last.X - player_current.X;
                delta_z = player_last.Z - player_current.Z;
                player_current.elevation = GetBearing(player_last.X, player_last.Z, player_current.X, player_current.Z);
                lblCurrentElevation.Text = String.Format("{0:.##}", player_current.elevation);


            }
        }
        
        //
        // TARGET
        //

        private void setTarget()
        {
            string targetText = txtTarget.Text;

            string[] targetTokens = targetText.Split(' ');

            string[] tempTokensX = targetTokens[1].Split(':');
            target.X = Convert.ToDouble(tempTokensX[1]);
            txtCoordXTarget.Text = target.X.ToString();

            string[] tempTokensY = targetTokens[2].Split(':');
            target.Y = Convert.ToDouble(tempTokensY[1]);
            txtCoordYTarget.Text = target.Y.ToString();

            string[] tempTokensZ = targetTokens[3].Split(':');
            target.Z = Convert.ToDouble(tempTokensZ[1]);
            txtCoordZTarget.Text = target.Z.ToString();
        }
        private void btnTargetSet_Click(object sender, EventArgs e)
        {
            setTarget();
        }
        private void btnMakeTarget_Click(object sender, EventArgs e)
        {
            txtTarget.Text = txtFromClipboard.Text;
            setTarget();
        }


        //
        // ZOOM
        //

        private void displayZoomIn_Click(object sender, EventArgs e)
        {
            display_zoom = display_zoom * 2;
            lblDisplayZoomLevel.Text = String.Format("{0:.#}", display_zoom);
            dispXY.Refresh();
            dispXZ.Refresh();
        }

        private void displayZoomOut_Click(object sender, EventArgs e)
        {
            display_zoom = display_zoom / 2;
            lblDisplayZoomLevel.Text = String.Format("{0:.#}", display_zoom);
            dispXY.Refresh();
            dispXZ.Refresh();
        }


        //
        //   TIMERS
        //   1=Check Clipboard for new coords and actions
        //   2= to do with flashing a box green to show an update
        //   3=auto send /showlocation (doesnt work)
        //

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
                        dispXY.Refresh();
                        dispXZ.Refresh();
                    }
                }
            }

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            txtFromClipboard.BackColor = Color.White;
            timer2.Enabled = false;
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            // attempt to auto feed /showlocation to SC window .. fails
            Process[] processes = Process.GetProcessesByName("STARCITIZEN");
            foreach (Process proc in processes)
                PostMessage(proc.MainWindowHandle, WM_KEYDOWN, VK_RETURN, 0);
        }
    }

    public class SCPoint3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double heading { get; set; }
        public double elevation { get; set; }  //  kind of pitch..but not really..its the angle  off the XY   plane
        public DateTime timestamp { get; set; }
        public double distance_to_target { get; set; }
        public double bearing_to_target { get; set; }
        public double elevation_to_target { get; set; }
        public SCPoint3D(double x, double y, double z, double hdg,double elev, DateTime t, double dist_to_target, double brg_to_target, double elev_to_target)
        {
            X = x;
            Y = y;
            Z = z;
            heading = hdg;
            elevation = elev;
            timestamp = t;
            distance_to_target = dist_to_target;
            bearing_to_target = brg_to_target;
            elevation_to_target = elev_to_target;
        }
    }

}
