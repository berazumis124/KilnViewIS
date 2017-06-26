using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace KilnView
{
    public partial class KilnAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDDLKilns();
                loadDDLPrograms();
            }
        }
        private void loadDDLKilns()
        {
            string connstr = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
            DataTable dt_kilns = new DataTable();

            using (SqlConnection con = new SqlConnection(connstr))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("select K.ID, K.NAME from tbl_Kilns K where K.ID NOT IN (SELECT kilnID as id from tbl_KilnLog where loadStop is null or loadStop = '')", con);
                    da.Fill(dt_kilns);
                    ddl_Kilns.DataSource = dt_kilns;
                    ddl_Kilns.DataValueField = "ID";
                    ddl_Kilns.DataTextField = "NAME";
                    ddl_Kilns.DataBind();
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }


        }

        private void loadDDLPrograms()
        {
            string connstr = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
            DataTable dt_norms = new DataTable();

            using (SqlConnection con = new SqlConnection(connstr))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("select ID, NormName from tbl_Norms order by ID", con);
                    da.Fill(dt_norms);
                    ddl_Programa.DataSource = dt_norms;
                    ddl_Programa.DataValueField = "ID";
                    ddl_Programa.DataTextField = "NormNAme";
                    ddl_Programa.DataBind();
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }


        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insertKilnInfo"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@KILNID", ddl_Kilns.SelectedValue);
                    cmd.Parameters.AddWithValue("@NORMID", ddl_Programa.SelectedValue);
                    cmd.Parameters.AddWithValue("@STARTDATE", txt_startDate.Text);
                    cmd.Parameters.AddWithValue("@STOPDATE", txt_stopDate.Text);
                    cmd.Parameters.AddWithValue("@UNLOADSTART", txt_unloadStart.Text);
                    cmd.Parameters.AddWithValue("@UNLOADSTOP", txt_unloadStop.Text);
                    cmd.Parameters.AddWithValue("@LOADSTART", txt_loadStart.Text);
                    cmd.Parameters.AddWithValue("@LOADSTOP", txt_loadStop.Text);
                    if (chk_AtnaujintaM3.Checked)
                    {
                        cmd.Parameters.AddWithValue("@UPDATEM3", "1");
                    }
                    else
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