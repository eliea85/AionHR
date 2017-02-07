using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using Ext.Net;

namespace HRSite
{
    public partial class CalendarTest : System.Web.UI.Page
    {
        public void LoadHijriYears()
        {
            for (int i = 1360; i < 1460; i++)
            {
                Hijiri_Year.Items.Add(new Ext.Net.ListItem { Text = i.ToString() });
            }
        }
        public int GetFirstDayOfMonth(int year, int month)
        {
            String[] Days = { "", "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            int str = 0;
            UmAlQuraCalendar umcal = new UmAlQuraCalendar();
            DateTime Date = umcal.ToDateTime(year, month, 1, 0, 0, 0, 0);
            str = Array.IndexOf(Days, Date.DayOfWeek.ToString());
            return str;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //MainPanel.Width = 300;

            if (!X.IsAjaxRequest)
            {
                LoadHijriYears();

                /*  MainPanel.ID = "MainPanel";
                  Window1.Items.Add(MainPanel);*/
                UmAlQuraCalendar umcal = new UmAlQuraCalendar();
                int month = umcal.GetMonth(DateTime.Now);
                int year = umcal.GetYear(DateTime.Now);
                LoadCalendar(year, month);
                Hijiri_Month.SelectedItem.Value = month.ToString();
                Hijiri_Year.SelectedItem.Text = year.ToString();


            }

        }
        public void GetMonthCal(object sender, DirectEventArgs e)
        {
            //MainPanel.Hidden = true;
            int year = Convert.ToInt32(Hijiri_Year.SelectedItem.Text);
            int month = Convert.ToInt32(Hijiri_Month.SelectedItem.Value);
            LoadCalendar(year, month);
        }

        public void Clearing(object sender, DirectEventArgs e)
        {
            MainPanel.RemoveAll();
        }
        public void RemoveAll()
        {
            for (int i = 0; i < MainPanel.Items.Count; i++)
            {
                MainPanel.Remove(MainPanel.Items[i].ID);
            }
        }
        public void Doaction(object sender, DirectEventArgs e)
        {
            X.Msg.Alert("??????? ???????", Hijiri_Year.SelectedItem.Text + "-" + Hijiri_Month.SelectedItem.Value + "-" + e.ExtraParams["pId"].ToString()).Show();
        }
        [DirectMethod]
        public void GetHijiriDate(String Month)
        {
            X.Msg.Alert("asd", Hijiri_Year.SelectedItem.Text + "-" + Hijiri_Month.SelectedItem.Value + "-" + Month).Show();
            //Window1.Close();
        }
        public void LoadCalendar(int year, int month)
        {
            MainPanel.Items.Clear();
            RemoveAll();
            MainForm.UpdateLayout();
            int StartDayIndex = GetFirstDayOfMonth(year, month);
            UmAlQuraCalendar umcal = new UmAlQuraCalendar();
            int daylenth = umcal.GetDaysInMonth(year, month);
            Ext.Net.Container cont = new Ext.Net.Container();
            cont.Layout = "HBoxLayout";
            Ext.Net.Label label;
            Ext.Net.Button b1;
            int STT = 0;
            for (int i = 1; i <= 7; i++)
            {
                if (i < StartDayIndex)
                {
                    label = new Ext.Net.Label();
                    label.Width = 50;
                    label.ID = Guid.NewGuid().ToString();
                    cont.Items.Add(label);
                }
                else
                {
                    b1 = new Ext.Net.Button();
                    b1.Width =50;
                    b1.Height = 25;
                    b1.ID = Guid.NewGuid().ToString();
                    STT = (i - StartDayIndex + 1);
                    b1.Text = (STT).ToString();
                    b1.Listeners.Click.Handler = "App.direct.GetHijiriDate(" + b1.Text + ")";
                    b1.ToolTip = Hijiri_Year.SelectedItem.Text + "-" + Hijiri_Month.SelectedItem.Value + "-" + b1.Text;
                    cont.Items.Add(b1);
                }
            }
            MainPanel.Items.Add(cont);
            cont = new Container();
            cont.ID = Guid.NewGuid().ToString();
            int j = 1;
            for (int i = STT + 1; i <= daylenth; i++)
            {
                b1 = new Ext.Net.Button();
                b1.Width = 50;
                b1.Height = 25;
                b1.Text = (i).ToString();
                b1.ID = Guid.NewGuid().ToString();
                b1.Listeners.Click.Handler = "App.direct.GetHijiriDate(" + b1.Text + ")";
                b1.ToolTip = Hijiri_Year.SelectedItem.Text + "-" + Hijiri_Month.SelectedItem.Value + "-" + b1.Text;
                cont.Items.Add(b1);
                if (j == 7)
                {
                    cont.Layout = "HBoxLayout";
                    MainPanel.Items.Add(cont);
                    cont = new Container();
                    cont.ID = Guid.NewGuid().ToString();
                    j = 0;
                }
                if (j < 7 && i == daylenth)
                {
                    MainPanel.Items.Add(cont);
                }
                ++j;
            }
            MainForm.UpdateLayout();
            MainPanel.Render();

        }
    }
}
