using ExcelDataReader;
using System.Data;
using System.IO;
using UnityEngine;

public class ExcelStart : MonoBehaviour
{
    private string filePath = Application.streamingAssetsPath + "/" + "ExampleData.xlsx";
    void Start()
    {
        //ExcelHandle_0();
        ExcelHandle_1();
    }

    public void ExcelHandle_0()
    {
        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                Debug.Log("SheetName:" + reader.Name);
                Debug.Log("SheetCodeName:" + reader.CodeName);

                var result = reader.AsDataSet();
                if (result.Tables.Count > 0)
                {
                    for (int i = 0; i < result.Tables[0].Rows.Count; i++)
                    {
                        Debug.Log(result.Tables[0].Rows[i][0].ToString());
                        Debug.Log(result.Tables[0].Rows[i][1].ToString());
                    }
                }
            }
        }
    }

    public void ExcelHandle_1()
    {
        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            // Auto-detect format, supports:
            //  - Binary Excel files (2.0-2003 format; *.xls)
            //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {

                // Choose one of either 1 or 2:

                // 1. Use the reader methods
                do
                {
                    while (reader.Read())
                    {

                    }
                } while (reader.NextResult());

                // 2. Use the AsDataSet extension method
                var result = reader.AsDataSet();

                // The result of each spreadsheet is in result.Tables


                /*
                 * Read() 从当前工作表中读取一行。
                   NextResult() 将光标前进到下一张纸。
                   ResultsCount 返回当前工作簿中的工作表数。
                   Name 返回当前工作表的名称。
                   CodeName 返回当前工作表的VBA代码名称标识符。
                   FieldCount 返回当前工作表中的列数。
                   RowCount返回当前工作表中的行数。这包括终端空行，否则这些空行被AsDataSet（）排除。InvalidOperationException与一起使用时会抛出CSV文件AnalyzeInitialCsvRows。
                   HeaderFooter返回一个对象，其中包含有关页眉和页脚的信息，null如果没有，则不提供任何信息。
                   MergeCells 返回当前工作表中合并单元格范围的数组。
                   RowHeight返回当前行的视觉高度（以磅为单位）。如果该行是隐藏的，则可以为0。
                   GetColumnWidth()以字符为单位返回列的宽度。如果该列是隐藏的，则可以为0。
                   GetFieldType()返回当前行中值的类型。永远的类型之一支持Excel中：double，int，bool，DateTime，TimeSpan，string，或者null如果没有价值。
                   IsDBNull() 检查当前行中的值是否为空。
                   GetValue()返回当前行的值object，null如果没有，则返回。
                   GetDouble()，GetInt32()，GetBoolean()，GetDateTime()，GetString()从目前投行的值返回各自的类型。
                   GetNumberFormatString()返回一个字符串，其中包含当前行中某个值的格式代码，或者null如果没有值，则返回该字符串。另请参阅下面的“格式化”部分。
                   GetNumberFormatIndex()返回当前行中值的数字格式索引。低于164的索引值是指内置数字格式，否则表示自定义数字格式。
                   GetCellStyle() 返回一个对象，该对象包含当前行中单元格的样式信息：缩进，水平对齐，隐藏，锁定。
                   除非类型完全匹配，否则将Get*()抛出类型化方法InvalidCastException。
                 */

                //ResultsCount 返回当前工作簿中的工作表数
                Debug.Log($"返回当前工作簿中的工作表数:{reader.ResultsCount}");
                Debug.Log($"返回当前工作表的名称:{reader.Name}");
                Debug.Log($"返回当前工作表中的列数:{reader.FieldCount}");
                //Debug.Log($"Namespace:{result.Namespace}");

                if (result.Tables.Count <= 0)
                {
                    return;
                }

                DataTable dataTable = result.Tables[0];
                DataRow dataRow = dataTable.Rows[0];
                //获取第一张表
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    //获取每一列的数据
                    DataColumn dataColumn = dataTable.Columns[i];
                    Debug.Log("ColumnName:" + dataColumn.ColumnName);
                    //"Column0"
                    Debug.Log("Ordinal:" + dataColumn.Ordinal);
                    
                    //获取此列中每一行的数据
                }

            }
        }
    }
}
