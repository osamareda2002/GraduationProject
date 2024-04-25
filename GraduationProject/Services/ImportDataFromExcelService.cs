using GraduationProject.Models;
using Microsoft.VisualBasic.FileIO;

namespace GraduationProject.Services
{
    public class ImportDataFromExcelService : IImportDataFromExcelService
    {
        private readonly ApplicationDbContext _context;

        public ImportDataFromExcelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void ReadCsvFile()
        {
            string filePath = "D:\\Downloads\\Project files\\DataSets\\Food and Calories - Sheet1.csv";
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(","); // Set the delimiter, change to '\t' for tab-delimited
                int cnt = 0;
                while (!parser.EndOfData)
                {
                    Food food = new Food();
                    string[] fields = parser.ReadFields();
                    if (cnt>0)
                    {
                        // Process the fields array
                        food.FoodName = fields[0];
                        food.Calories = double.Parse(fields[2]);
                        
                        _context.Foods.Add(food);
                        _context.SaveChanges();
                        
                    }
                    cnt++;
                }
            }
        }

    }
}
