using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace WareHouse.Statement
{
    class DataTableExportPDF
    {
        internal MemoryStream ExportPDF(DataTable dtStru, DataTable dtSource)
        {
            MemoryStream mspdf = new MemoryStream();


            //字体读取的是windows系统宋体  
            BaseFont basefont = BaseFont.CreateFont("C:/Windows/Fonts/simsun.ttc,0", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font font = new Font(basefont, 12, Font.BOLD);//标题
            iTextSharp.text.Font font2 = new Font(basefont, 12);//普通列
            iTextSharp.text.Font font3 = new Font(basefont, 12, Font.BOLD);//合计列
            iTextSharp.text.Font font4 = new Font(basefont, 12, Font.BOLD, BaseColor.RED);//合计列数值
                                                                                          //font.Color = BaseColor.BLUE;//字体颜色  

            Document document = new Document(PageSize.A4.Rotate(), 8, 8, 8, 8);
            PdfWriter.GetInstance(document, mspdf);
            document.Open();

            /*document.AddTitle("报表");
            Paragraph element = new Paragraph("报表", new Font(basefont, 16));
            element.SpacingAfter = 10; //设置离后面内容的间距  
            element.Alignment = Element.ALIGN_CENTER;
            document.Add(element); */

            //打印时间  
            Paragraph element2 = new Paragraph("打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm"), new Font(basefont, 14));
            element2.SpacingAfter = 5; //设置离后面内容的间距
            document.Add(element2);

            PdfPTable table = new PdfPTable(dtStru.Rows.Count);
            table.WidthPercentage = 100;//设置表格宽度占用百分比 
                                        //此处各单元格宽度因为是前台可配置的,所以取配置的                
            var width = (from dt in dtStru.AsEnumerable() select float.Parse(dt["iwidth"].ToString())).ToArray();
            table.SetTotalWidth(width);

            #region 表头
            //第一行表头  
            foreach (DataRow item in dtStru.Rows)
            {
                PdfPCell cell = new PdfPCell(new Paragraph(item["ivalue"].ToString(), font));
                //cell.Colspan = 2; //定义一个表格单元的跨度  
                cell.Rowspan = 2;
                cell.BackgroundColor = BaseColor.GRAY;
                cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;  //垂直居中  
                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;//水平居中  
                table.AddCell(cell);
            }


            #endregion

            #region 数据载入
            Dictionary<string, double> agg = new Dictionary<string, double>();
            foreach (DataRow item in dtSource.Rows)
            {
                foreach (DataRow item2 in dtStru.Rows)
                {
                    var fldname = item2["fldname"].ToString();
                    var type = item2["fldtype"].ToString();
                    var format = item2["iformat"].ToString();
                    var iaggregate = item2["iaggregate"].ToString();
                    var df_value = item[fldname].ToString();
                    switch (type)
                    {
                        case "N":
                            var value = double.Parse(df_value);
                            if (iaggregate != string.Empty)
                            {
                                if (agg.ContainsKey(fldname))
                                {
                                    switch (iaggregate)
                                    {
                                        case "sum":
                                            agg[fldname] += value;
                                            break;
                                        case "max":
                                            agg[fldname] = agg[fldname] > value ? agg[fldname] : value;
                                            break;
                                        default:
                                            agg[fldname] = value;
                                            break;
                                    }
                                }
                                else
                                    agg[fldname] = 0d;
                            }
                            df_value = value.ToString("f" + format.Substring(1));
                            break;
                        case "D":
                            df_value = Convert.ToDateTime(df_value).ToString(format);
                            break;
                        default:
                            break;
                    }

                    PdfPCell cell_data = new PdfPCell(new Paragraph(df_value, font2));
                    cell_data.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;  //垂直居中
                    cell_data.HorizontalAlignment = PdfPCell.ALIGN_CENTER;//水平居中
                    if (type == "N")
                        cell_data.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;//水平居右
                    table.AddCell(cell_data);
                }
            }
            #endregion

            #region 汇总
            foreach (DataRow item2 in dtStru.Rows)
            {
                var fldname = item2["fldname"].ToString();
                var type = item2["fldtype"].ToString();
                var iaggregate = item2["iaggregate"].ToString();
                var format = item2["iformat"].ToString();
                var df_value = string.Empty;
                if (iaggregate != string.Empty && type == "N")
                {
                    df_value = agg[fldname].ToString("f" + format.Substring(1));
                }
                PdfPCell cell_data = new PdfPCell(new Paragraph(df_value, font4));
                cell_data.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;  //垂直居中  
                cell_data.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;//水平居中  

                if (dtStru.Rows.IndexOf(item2) == 0)
                {
                    df_value = "合計";
                    cell_data.Phrase = new Paragraph(df_value, font3);
                    cell_data.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                }

                table.AddCell(cell_data);
            }
            #endregion
            document.Add(table);
            document.Close();
            
            return mspdf;
        }
    }
}
