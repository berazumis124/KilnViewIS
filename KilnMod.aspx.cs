using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace KilnView
{
    public partial class KilnMod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string param = Request.QueryString["ID"];
                if (param != null)
                {
                    //Response.Write("ID:" + param);
                    GetData(param);


                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }

            if (IsPostBack)
            {

            }
            
        }

        private void GetData(string param)
        {
            string connstr = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
            SqlDataReader rdr = null;
            SqlConnection con = new SqlConnection(connstr);


            SqlCommand cmd = new SqlCommand("select K.NAME, L.startDate, L.stopDate, L.unloadStart, L.unloadStop, L.loadStart, L.loadStop, L.updateM3, L.unloadLoadNorm from tbl_KilnLog L, tbl_Kilns K where K.ID=L.kilnID and L.ID=" + param + "",con);
                    
           try
            {
                con.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    lbl_kilnID.Text = param;
                    lbl_kilnName.Text = rdr["NAME"].ToString();
                    txt_startDate.Text = checkDate(rdr["startDate"].ToString());
                    txt_stopDate.Text = checkDate(rdr["stopDate"].ToString());
                    txt_unloadStart.Text = checkDate(rdr["unloadStart"].ToString());
                    txt_unloadStop.Text = checkDate(rdr["unloadStop"].ToString());
                    txt_loadStart.Text = checkDate(rdr["loadStart"].ToString());
                    txt_loadStop.Text = checkDate(rdr["loadStop"].ToString());
                    txt_forkNorm.Text = rdr["unloadLoadNorm"].ToString();
                    if (Convert.ToInt32(rdr["updateM3"]) == 1)
                    {
                        chk_AtnaujintaM3.Checked = true;
                    } else
                    {
                        chk_AtnaujintaM3.Checked = false;
                    }
                }
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (con != null)
                {
                    con.Close();
                }
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_updateKilnInfo"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LOGID", lbl_kilnID.Text);
                    cmd.Parameters.AddWithValue("@STARTDATE", setDate(txt_startDate.Text));
                    cmd.Parameters.AddWithValue("@STOPDATE", setDate(txt_stopDate.Text));
                    cmd.Parameters.AddWithValue("@UNLOADSTART", setDate(txt_unloadStart.Text));
                    cmd.Parameters.AddWithValue("@UNLOADSTOP", setDate(txt_unloadStop.Text));
                    cmd.Parameters.AddWithValue("@LOADSTART", setDate(txt_loadStart.Text));
                    cmd.Parameters.AddWithValue("@LOADSTOP", setDate(txt_loadStop.Text));
                    cmd.Parameters.AddWithValue("@FORKNORM", txt_forkNorm.Text);
                    if (chk_AtnaujintaM3.Checked)
                    {
                        cmd.Parameters.AddWithValue("@UPDATEM3", "1");
                    } else
                    {
                        cmd.Parameters.AddWithValue("@UPDATEM3", "0");
                    }                   
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();
                }
            }
            Response.Redirect("Default.aspx");
        }

        protected string checkDate(string datefromDB)
        {
            string corrected = "";
            if (datefromDB == "1900.01.01 00:00:00")
            {
                corrected = "";
            } else
            {
                corrected = datefromDB;
            }
            return corrected;
        }
        protected string setDate(string dateToDB)
        {
            string corrected = dateToDB;
            if (dateToDB == "")
            {
                corrected = "1900.01.01 00:00:00";
            }
            return corrected;
        }

        protected void btn_startDate_Click(object sender, EventArgs e)
        {
            txt_startDate.Text = DateTime.Now.ToString();
        }

        protected void btn_stopDate_Click(object sender, EventArgs e)
        {
            txt_stopDate.Text = DateTime.Now.ToString();
        }

        protected void btn_unloadStart_Click(object sender, EventArgs e)
        {
            txt_unloadStart.Text = DateTime.Now.ToString();
        }

        protected void btn_unloadStop_Click(object sender, EventArgs e)
        {
            txt_unloadStop.Text = DateTime.Now.ToString();
        }

        protected void btn_loadStart_Click(object sender, EventArgs e)
        {
            txt_loadStart.Text = DateTime.Now.ToString();
        }

        protected void btn_loadStop_Click(object sender, EventArgs e)
        {
            txt_loadStop.Text = DateTime.Now.ToString();
        }
    }
}