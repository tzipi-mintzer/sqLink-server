using Microsoft.AspNetCore.Mvc;
using myProject.Common;
using myProject.Services;
using OfficeOpenXml;
using System.Reflection;
//using Excel = Microsoft.Office.Interop.Excel;

namespace myProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {

        private readonly IPersonService _PersonService;
        public PersonController(IPersonService personService)
        {
            _PersonService = personService;
        }
        [HttpPost]
        public async Task<DataDTO> Post(IFormFile formFile, CancellationToken cancellationToken)
        {
            var list = new List<PersonDTO>();

            using (var stream = new MemoryStream())
            {
                await formFile.CopyToAsync(stream, cancellationToken);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.Commercial;

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        list.Add(new PersonDTO
                        {
                            fullName = worksheet.Cells[row, 1].Value.ToString().Trim() + worksheet.Cells[row, 2].Value.ToString().Trim(),
                            tz = worksheet.Cells[row, 3].Value.ToString().Trim(),
                            yearOfBirth = DateTime.Now.Year-int.Parse(worksheet.Cells[row, 4].Value.ToString().Trim()),
                        });
                    }
                }
            }
            return await _PersonService.AddPersonAsync(list);
        }


    }
}
