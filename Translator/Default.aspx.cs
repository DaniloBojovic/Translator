using System;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Xml;

namespace Translator
{
    public partial class Default : System.Web.UI.Page
    {
        string connString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            Session["TranslationInput"] = txtInput.Text;
            string textStoredInDb = CheckIfTranslationExists(txtInput.Text);
            if (string.IsNullOrEmpty(textStoredInDb))
            {
                TranslateInput(txtInput.Text);
            }
            else
            {
                Session["TranslationResult"] = textStoredInDb;
                Server.Transfer("~/Result.aspx");
            }
        }

        public void TranslateInput(string input)
        {
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["text"] = input;
                data["lang"] = "sr";
                data["key"] = "trnsl.1.1.20181222T104117Z.4caae5ced5211218.b12b341dfce7d8bdcd63ff2a9a90d44c7b48ff06";

                var stringResponse = wb.UploadValues("https://translate.yandex.net/api/v1.5/tr.json/translate", "POST", data);

                string translationResultFullStr = Encoding.UTF8.GetString(stringResponse);
                var result = JsonConvert.DeserializeObject<Helper>(translationResultFullStr);
                string strResult = result.Text[0];
                Session["TranslationResult"] = strResult;
                StoreTranslatedData(input, strResult);
                Server.Transfer("~/Result.aspx");
            }
        }

        public void StoreTranslatedData(string input, string translatedInput)
        {
            string query = "INSERT INTO TranslatedData VALUES(@InputText, @TranslatedTex)";
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@InputText", input);
                    cmd.Parameters.AddWithValue("@TranslatedTex", translatedInput);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public string CheckIfTranslationExists(string InputText)
        {
            string outputText = "";
            string query = "SELECT TranslatedTex FROM TranslatedData WHERE InputText = @InputText";
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@InputText", InputText);
                    cmd.Connection = con;
                    con.Open();
                    outputText = (string)cmd.ExecuteScalar();
                    con.Close();
                }
            }
            return outputText;
        }
    }
}