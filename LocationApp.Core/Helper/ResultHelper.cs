using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationApp.Core.Helper
{
    public class ResultHelper
    {
        public ResultHelper()
        {
        }
        public ResultHelper(bool result, int resultSet, string resultDescription)
        {
            this.Result = result;
            this.ResultSet = resultSet;
            this.ResultDescription = resultDescription;
        }
        public bool Result { get; set; }
        public int ResultSet { get; set; }
        public string ResultDescription { get; set; }

        public static string SuccessMessage = "İşlem Başarılı!";
        public static string UnSuccessMessage = "İşlem Başarısız!";
        public static string IsThereItem = "Sistemde mevcut!";
        public static string DontDeleted = "Kayıt ile ilişkili veriler mevcut.";
        public static string DifficultArea = "Zorunlu alan!";
    }
}
