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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // POPULATE DATATABLE FROM DB
                DataTable dt = this.GetData();

                // BUILD HTML STRING
                StringBuilder html = new StringBuilder();

                html.Append("<table class='table'>");
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<th>");
                    html.Append(column.ColumnName);
                    html.Append("</th>");
                }
                html.Append("</tr>");

                // BUILD DATA ROWS
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        if (column.ColumnName.ToString() == "Veiksmas")
                        {
                            html.Append("<td>");
                            html.Append("<a href=kilnMod.aspx?ID=" + row[column.ColumnName] + ">Keisti..</a>");
                            html.Append("</td>");
                        } else if (column.ColumnName.ToString() == "Atnaujinta M3") {
                            if (row[column.ColumnName].ToString() == "1")
                            {
                                html.Append("<td>");
                                html.Append("<span class='glyphicon glyphicon-ok' style='color:#5FC424;'></span>");
                                html.Append("</td>");
                            } else
                            {
                                html.Append("<td>");
                                html.Append("<span class='glyphicon glyphicon-remove' style='color:#FF0000;'></span>");
                                html.Append("</td>");
                            }
                        } else if (column.ColumnName.ToString() == "Standarto korekcija") {
                            if (Convert.ToInt32(row[column.ColumnName].ToString()) < -50)
                            {
                                html.Append("<td>");
                                html.Append(" ");
                                html.Append("</td>");
                            } else
                            {
                                html.Append("<td>");
                                html.Append(row[column.ColumnName]);
                                html.Append("</td>");
                            }
                        }
                        else
                        {
                            if (row[column.ColumnName].ToString() == "1900.01.01 00:00:00")
                            {
                                html.Append("<td>");
                                html.Append(" ");
                                html.Append("</td>");
                            } else
                            {
                                html.Append("<td>");
                                html.Append(row[column.ColumnName]);
                                html.Append("</td>");
                            }


                        }
                    }
                    html.Append("</tr>");
                }
                html.Append("</table>");

                // ADD HTML STRING TO PLACEHOLDER
                phKilnView.Controls.Add(new Literal { Text = html.ToString() });
            }
        }

        private DataTable GetData()
        {
            string connstr = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand("select L.ID as 'Veiksmas', K.NAME as 'Kamerinė krosnis', N.NormName as 'Programa', L.startDate as 'Paleista', L.stopDate as 'Sustabdyta', L.updateM3 as 'Atnaujinta M3', L.unloadStart as 'Iškrovimo pradžia', L.unloadStop as 'Iškrovimo pabaiga', L.loadStart as 'Pakrovimo pradžia', L.loadStop as 'Pakrovimo pabaiga', DATEDIFF(day,L.startDate,L.stopDate)-N.NormDuration as 'Standarto korekcija' from tbl_Kilns K, tbl_KilnLog L, tbl_Norms N where L.kilnID = K.ID and N.ID = L.normID and (L.loadStop is NULL or L.loadStop='')"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        protected void btn_new_Click(object sender, EventArgs e)
        {
            Response.Redirect("KilnAdd.aspx");
        }
    }
}