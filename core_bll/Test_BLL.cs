using core_dal;
using core_utilities;
using System;

namespace core_bll
{
    public class Test_BLL
    {
        public string  Getest(int id)
        {
            try
            {
                string FilePath = ConfigFunction.GetConfig("FilePath");
                var dt = new Test_DAL().Getest(id);
                string name = "测试 .NET CORE";
                string Path = System.IO.Path.Combine(FilePath, name) + ".xls";
                new Export2Excel().Export(dt, "", Path);
                return "Success";
            }
            catch (Exception e)
            {
                return e.Message;
            }            
        }
    }
}
