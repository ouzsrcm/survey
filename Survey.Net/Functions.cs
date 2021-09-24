using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;

namespace Survey.Net
{
    public static class Functions
    {
        public static string clear(string word)
        {
            word = word.Replace("'", "''");
            word = word.Replace("--", " ");
            word = word.Replace(";", " ");
            word = word.Replace("(", " ");
            word = word.Replace(")", " ");
            word = word.Replace("WAITFOR", " ");
            word = word.Replace("DELAY", " ");
            word = word.Replace("waitfor", " ");
            word = word.Replace("delay", " ");
            word = word.Replace("=", " ");
            return word;
        }

        public static string DTtoJson(string type, DataTable dt, string allowCols)
        {
            
            List<string> listCols = new List<string>();
            if (allowCols != null)
            {
                foreach (string s in allowCols.Split(','))
                {
                    listCols.Add(s);
                }
            }

            StringBuilder JsonString = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                if (type == "0")
                {
                    JsonString.Append("{ ");
                    JsonString.Append("\"Head\":[ ");
                }
                else
                {
                    JsonString.Append("{ ");
                    JsonString.Append("\"TABLE\":[{ ");
                    JsonString.Append("\"ROW\":[ ");
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (type != "0")
                        JsonString.Append("\"COL\":[ ");

                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        
                        if ((allowCols == null) || (listCols.IndexOf(dt.Columns[j].ColumnName.ToString()) > -1))
                        {
                            if (j < dt.Columns.Count - 1)
                            {
                                if (type == "0")
                                    JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\",");
                                else
                                    JsonString.Append("{" + "\"DATA\":\"" + dt.Rows[i][j].ToString() + "\"},");
                            }
                            else if (j == dt.Columns.Count - 1)
                            {
                                if (type == "0")
                                    JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\"");
                                else
                                    JsonString.Append("{" + "\"DATA\":\"" + dt.Rows[i][j].ToString() + "\"}");
                            }
                        }
                    }
                    if (i == dt.Rows.Count - 1)
                    {
                        if (type == "0")
                            JsonString.Append("} ");
                        else
                            JsonString.Append("]} ");
                    }
                    else
                    {
                        if (type == "0")
                            JsonString.Append("}, ");
                        else
                            JsonString.Append("]}, ");
                    }
                }
                if (type == "0")
                    JsonString.Append("]}");
                else
                    JsonString.Append("]}]}");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}