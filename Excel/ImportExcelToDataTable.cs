using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClosedXML.Excel;
using DocumentFormat.OpenXml;

namespace closedXml
{
    class Program
    {

        public string local()
        {
            string local = @"";
            return local;
        }
        public void Apagar(string cell)
        {
            var wb = new XLWorkbook(local());
            var ws = wb.Worksheet("Overview");
            ws.Cell(cell).Value = string.Empty;
            wb.Save();
        }
        public string LerCelula(string cell)
        {
            var wb = new XLWorkbook(local());
            var ws = wb.Worksheet("Overview");
          
            string texto = ws.Cell(cell).Value.ToString();

            return texto;
        }

        public void Deletar(string cell, int mover)
        {
            var wb = new XLWorkbook(local());
            var ws = wb.Worksheet("Overview");

            if (mover == 1)
                ws.Cell(cell).Delete(XLShiftDeletedCells.ShiftCellsLeft);
            else
                ws.Cell(cell).Delete(XLShiftDeletedCells.ShiftCellsUp);

            wb.Save();
        }

        public void Update(string cell, string valor)
        {
            var wb = new XLWorkbook(local());
            var ws = wb.Worksheet("Overview");

            ws.Cell(cell).Value = string.Empty;
            ws.Cell(cell).Value = valor;
            
            wb.Save();
        }

        public void Inserir(string cell, string valor)
        {
            var wb = new XLWorkbook(local());
            var ws = wb.Worksheet("Overview");

            ws.Cell(cell).Value = valor;

            wb.Save();
        }

        public string PegarLinha(string cell)
        {
            var wb = new XLWorkbook(local());
            var ws = wb.Worksheet("Overview");

            var cellString = ws.Cell(cell);

            String string1 = (String)cellString.Value;

            return string1;
        }



       


        static void Main(string[] args)
        {
            Program x = new Program();

            //x.Update("A2", "Outro Texto");

            //x.Inserir("B1", "22222222");

            //x.Apagar("A1");

            //x.Deletar("A1", 1);
            DataTable dt = GetDataFromExcel(x.local(), "Overview");

            Console.Read();
        }



        public static DataTable GetDataFromExcel(string path, dynamic worksheet)
        {
            //Save the uploaded Excel file.


            DataTable dt = new DataTable();
            //Open the Excel file using ClosedXML.
            using (XLWorkbook workBook = new XLWorkbook(path))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(worksheet);

                //Create a new DataTable.

                //Loop through the Worksheet rows.
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            if (!string.IsNullOrEmpty(cell.Value.ToString()))
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }
                            else
                            {
                                break;
                            }
                        }
                        firstRow = false;
                    }
                    else
                    {
                        int i = 0;
                        DataRow toInsert = dt.NewRow();
                        foreach (IXLCell cell in row.Cells(1, dt.Columns.Count))
                        {
                            try
                            {
                                toInsert[i] = cell.Value.ToString();
                            }
                            catch (Exception ex)
                            {

                            }
                            i++;
                        }
                        dt.Rows.Add(toInsert);
                    }
                }
                return dt;
            }



        }   
    }
}
