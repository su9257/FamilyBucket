using ExcelDataReader;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

[TypeInfoBox("<size=20>快速生成Excel对应C#文件</size>")]
public class OneKetCreatExcelCSharp : SerializedScriptableObject
{
    public string sourcePath;
    public string fileToPath;
    private string templatePath;


    [Button("开始生成")]
    public void CreatCSharp()
    {

    }

    private string filePath = Application.streamingAssetsPath + "/" + "ExampleData.xlsx";

    [Button("读取Excel数据")]
    public void ReadExcelFile()
    {
        Debug.Log("读取数据");
        //读取一共有多少列

        //读取前三行
        /*
         * 第一行注释
         * 第二行名称
         * 第三行类型
         */

        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var result = reader.AsDataSet();
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
                if (dataTable.Rows.Count < 3)
                {
                    Debug.LogError("Excel表格少于3行数据，请检查");
                    return;
                }

                List<string> fieldNameList = new List<string>();
                List<string> typeList = new List<string>();
                List<string> descriptionList = new List<string>();

                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    //第一行名称
                    fieldNameList.Add(dataTable.Rows[0][i].ToString());
                    //第二行类型
                    typeList.Add(dataTable.Rows[1][i].ToString());
                    //第三行注释
                    descriptionList.Add(dataTable.Rows[2][i].ToString());
                }
                Debug.Log($"{descriptionList.Count}---{fieldNameList.Count}---{typeList.Count}");
                for (int i = 0; i < descriptionList.Count; i++)
                {
                    Debug.Log($"{typeList[i]} {fieldNameList[i]} // {descriptionList[i]}");
                }
                //Debug.Log(Application.dataPath);
                string templatePath = Application.dataPath + "/" + "Editor" + "/" + "Template" + "/" + "81-C# Script-NewBehaviourScript.cs" + ".txt";
                string text = System.IO.File.ReadAllText(templatePath);

                Debug.Log($"内容："+text);
                //string path = templatePath;
                //using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                //{
                //    using (StreamWriter writer = new StreamWriter(fs, System.Text.Encoding.UTF8))
                //    {
                //        writer.Write(content);
                //    }
                //}

            }
        }
    }

    public void CreatCSharpFile(string className, string fileContent)
    {

    }
}
